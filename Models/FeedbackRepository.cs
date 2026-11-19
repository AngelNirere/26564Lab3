using MySqlConnector;

namespace Smart_match.Models;

public class FeedbackRepository
{
    // completed sessions of this user that this user has not rated yet
    public List<SessionRow> GetSessionsAwaitingFeedback(int userId)
    {
        const string sql = @"SELECT s.id, s.match_id, s.session_date, s.status,
                                    CASE WHEN m.mentee_id = @uid THEN mentor.name
                                         ELSE mentee.name END AS partner
                             FROM sessions s
                             JOIN matches m ON m.id = s.match_id
                             JOIN users mentee ON mentee.id = m.mentee_id
                             JOIN users mentor ON mentor.id = m.mentor_id
                             WHERE (m.mentee_id = @uid OR m.mentor_id = @uid)
                               AND s.status = 'Completed'
                               AND NOT EXISTS (SELECT 1 FROM feedback f
                                               WHERE f.session_id = s.id AND f.given_by = @uid)
                             ORDER BY s.session_date DESC";

        var list = new List<SessionRow>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new SessionRow
            {
                Id = Convert.ToInt32(reader["id"]),
                MatchId = Convert.ToInt32(reader["match_id"]),
                PartnerName = Convert.ToString(reader["partner"]) ?? "",
                SessionDate = Convert.ToDateTime(reader["session_date"]),
                Status = Convert.ToString(reader["status"]) ?? ""
            });
        }
        return list;
    }

    public bool Exists(int sessionId, int userId)
    {
        const string sql = @"SELECT COUNT(*) FROM feedback
                             WHERE session_id = @sid AND given_by = @uid";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = sessionId;
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public void Insert(int sessionId, int givenBy, int rating, string comment)
    {
        const string sql = @"INSERT INTO feedback (session_id, given_by, rating, comment)
                             VALUES (@sid, @uid, @rating, @comment)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = sessionId;
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = givenBy;
        cmd.Parameters.Add("@rating", MySqlDbType.Int32).Value = rating;
        cmd.Parameters.Add("@comment", MySqlDbType.Text).Value = comment;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}