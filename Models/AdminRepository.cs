using MySqlConnector;

namespace Smart_match.Models;

public class AdminRepository
{
    public List<UserRow> GetAllUsers()
    {
        const string sql = @"SELECT id, name, email, role, is_active, created_at
                             FROM users ORDER BY id";

        var list = new List<UserRow>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new UserRow
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]) ?? "",
                Email = Convert.ToString(reader["email"]) ?? "",
                Role = Convert.ToString(reader["role"]) ?? "",
                IsActive = Convert.ToBoolean(reader["is_active"]),
                CreatedAt = Convert.ToDateTime(reader["created_at"])
            });
        }
        return list;
    }

    public string? GetRole(int userId)
    {
        const string sql = "SELECT role FROM users WHERE id = @id";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;

        con.Open();
        return Convert.ToString(cmd.ExecuteScalar());
    }

    public void SetActive(int userId, bool active)
    {
        const string sql = "UPDATE users SET is_active = @active WHERE id = @id";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@active", MySqlDbType.Bool).Value = active;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public ReportData GetReport()
    {
        using var con = Database.GetConnection();
        con.Open();

        int Count(string sql)
        {
            using var cmd = new MySqlCommand(sql, con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        double average;
        using (var cmd = new MySqlCommand("SELECT AVG(rating) FROM feedback", con))
        {
            object? value = cmd.ExecuteScalar();
            average = (value == null || value == DBNull.Value) ? 0 : Convert.ToDouble(value);
        }

        return new ReportData
        {
            TotalMentees = Count("SELECT COUNT(*) FROM users WHERE role = 'Mentee'"),
            TotalMentors = Count("SELECT COUNT(*) FROM users WHERE role = 'Mentor'"),
            TotalMatches = Count("SELECT COUNT(*) FROM matches"),
            PendingRequests = Count("SELECT COUNT(*) FROM mentorship_requests WHERE status = 'Pending'"),
            CompletedSessions = Count("SELECT COUNT(*) FROM sessions WHERE status = 'Completed'"),
            FeedbackCount = Count("SELECT COUNT(*) FROM feedback"),
            AverageRating = average
        };
    }
}