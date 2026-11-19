using MySqlConnector;

namespace Smart_match.Models;

public class NotificationRepository
{
    public void Insert(int userId, string message)
    {
        const string sql = "INSERT INTO notifications (user_id, message) VALUES (@uid, @msg)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;
        cmd.Parameters.Add("@msg", MySqlDbType.Text).Value = message;

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public List<NotificationRow> GetForUser(int userId)
    {
        const string sql = @"SELECT id, message, is_read, created_at
                             FROM notifications
                             WHERE user_id = @uid
                             ORDER BY created_at DESC, id DESC";

        var list = new List<NotificationRow>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new NotificationRow
            {
                Id = Convert.ToInt32(reader["id"]),
                Message = Convert.ToString(reader["message"]) ?? "",
                IsRead = Convert.ToBoolean(reader["is_read"]),
                CreatedAt = Convert.ToDateTime(reader["created_at"])
            });
        }
        return list;
    }

    public int CountUnread(int userId)
    {
        const string sql = "SELECT COUNT(*) FROM notifications WHERE user_id = @uid AND is_read = 0";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    public void MarkAllRead(int userId)
    {
        const string sql = "UPDATE notifications SET is_read = 1 WHERE user_id = @uid AND is_read = 0";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}