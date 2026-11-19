using MySqlConnector;

namespace Smart_match.Models;

public class RequestRepository
{
    // true if this mentee already has a Pending or Accepted request to this mentor
    public bool ExistsActive(int menteeId, int mentorId)
    {
        const string sql = @"SELECT COUNT(*) FROM mentorship_requests
                             WHERE mentee_id = @mentee AND mentor_id = @mentor
                               AND status IN ('Pending','Accepted')";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@mentee", MySqlDbType.Int32).Value = menteeId;
        cmd.Parameters.Add("@mentor", MySqlDbType.Int32).Value = mentorId;

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public void Insert(MentorshipRequest request)
    {
        const string sql = @"INSERT INTO mentorship_requests (mentee_id, mentor_id)
                             VALUES (@mentee, @mentor)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@mentee", MySqlDbType.Int32).Value = request.MenteeId;
        cmd.Parameters.Add("@mentor", MySqlDbType.Int32).Value = request.MentorId;

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // all requests sent to one mentor, newest first
    public List<RequestRow> GetForMentor(int mentorId)
    {
        const string sql = @"SELECT r.id, r.mentee_id, u.name, p.skills, p.goals,
                                    r.status, r.request_date
                             FROM mentorship_requests r
                             JOIN users u ON u.id = r.mentee_id
                             LEFT JOIN profiles p ON p.user_id = r.mentee_id
                             WHERE r.mentor_id = @mentor
                             ORDER BY r.request_date DESC";

        var list = new List<RequestRow>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@mentor", MySqlDbType.Int32).Value = mentorId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new RequestRow
            {
                Id = Convert.ToInt32(reader["id"]),
                MenteeId = Convert.ToInt32(reader["mentee_id"]),
                MenteeName = Convert.ToString(reader["name"]) ?? "",
                Skills = Convert.ToString(reader["skills"]) ?? "",
                Goals = Convert.ToString(reader["goals"]) ?? "",
                Status = Convert.ToString(reader["status"]) ?? "",
                RequestDate = Convert.ToDateTime(reader["request_date"])
            });
        }
        return list;
    }

    public MentorshipRequest? GetById(int id)
    {
        const string sql = @"SELECT id, mentee_id, mentor_id, status, request_date
                             FROM mentorship_requests WHERE id = @id";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

        con.Open();
        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new MentorshipRequest
        {
            Id = Convert.ToInt32(reader["id"]),
            MenteeId = Convert.ToInt32(reader["mentee_id"]),
            MentorId = Convert.ToInt32(reader["mentor_id"]),
            Status = Convert.ToString(reader["status"]) ?? "",
            RequestDate = Convert.ToDateTime(reader["request_date"])
        };
    }

    public void UpdateStatus(int id, string status)
    {
        const string sql = "UPDATE mentorship_requests SET status = @status WHERE id = @id";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@status", MySqlDbType.VarChar, 10).Value = status;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}