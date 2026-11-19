using MySqlConnector;

namespace Smart_match.Models;

public class SessionRepository
{
    // the matches of one user, with the name of the other person
    public List<MatchOption> GetMatchOptions(int userId)
    {
        const string sql = @"SELECT m.id,
                                    CASE WHEN m.mentee_id = @uid THEN mentor.name
                                         ELSE mentee.name END AS partner
                             FROM matches m
                             JOIN users mentee ON mentee.id = m.mentee_id
                             JOIN users mentor ON mentor.id = m.mentor_id
                             WHERE m.mentee_id = @uid OR m.mentor_id = @uid
                             ORDER BY m.start_date DESC";

        var list = new List<MatchOption>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new MatchOption
            {
                MatchId = Convert.ToInt32(reader["id"]),
                PartnerName = Convert.ToString(reader["partner"]) ?? ""
            });
        }
        return list;
    }

    public List<SessionRow> GetSessionsForUser(int userId)
    {
        const string sql = @"SELECT s.id, s.match_id, s.session_date, s.status,
                                    CASE WHEN m.mentee_id = @uid THEN mentor.name
                                         ELSE mentee.name END AS partner
                             FROM sessions s
                             JOIN matches m ON m.id = s.match_id
                             JOIN users mentee ON mentee.id = m.mentee_id
                             JOIN users mentor ON mentor.id = m.mentor_id
                             WHERE m.mentee_id = @uid OR m.mentor_id = @uid
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

    public bool MatchBelongsToUser(int matchId, int userId)
    {
        const string sql = @"SELECT COUNT(*) FROM matches
                             WHERE id = @match AND (mentee_id = @uid OR mentor_id = @uid)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@match", MySqlDbType.Int32).Value = matchId;
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    // returns the status of the session if it belongs to this user, otherwise null
    public string? GetStatusIfParticipant(int sessionId, int userId)
    {
        const string sql = @"SELECT s.status FROM sessions s
                             JOIN matches m ON m.id = s.match_id
                             WHERE s.id = @sid AND (m.mentee_id = @uid OR m.mentor_id = @uid)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = sessionId;
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        return Convert.ToString(cmd.ExecuteScalar());
    }

    public void Insert(int matchId, DateTime date)
    {
        const string sql = "INSERT INTO sessions (match_id, session_date) VALUES (@match, @date)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@match", MySqlDbType.Int32).Value = matchId;
        cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void UpdateStatus(int sessionId, string status)
    {
        const string sql = "UPDATE sessions SET status = @status WHERE id = @id";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@status", MySqlDbType.VarChar, 15).Value = status;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = sessionId;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}