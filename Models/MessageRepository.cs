using MySqlConnector;

namespace Smart_match.Models;

public class MessageRepository
{
    // the people this user is matched with
    public List<PartnerOption> GetPartners(int userId)
    {
        const string sql = @"SELECT DISTINCT u.id, u.name
                             FROM matches m
                             JOIN users u ON u.id = CASE WHEN m.mentee_id = @uid
                                                         THEN m.mentor_id
                                                         ELSE m.mentee_id END
                             WHERE m.mentee_id = @uid OR m.mentor_id = @uid
                             ORDER BY u.name";

        var list = new List<PartnerOption>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new PartnerOption
            {
                UserId = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]) ?? ""
            });
        }
        return list;
    }

    public bool AreMatched(int userA, int userB)
    {
        const string sql = @"SELECT COUNT(*) FROM matches
                             WHERE (mentee_id = @a AND mentor_id = @b)
                                OR (mentee_id = @b AND mentor_id = @a)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@a", MySqlDbType.Int32).Value = userA;
        cmd.Parameters.Add("@b", MySqlDbType.Int32).Value = userB;

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public List<MessageRow> GetConversation(int userA, int userB)
    {
        const string sql = @"SELECT m.id, m.sender_id, u.name, m.content, m.sent_at
                             FROM messages m
                             JOIN users u ON u.id = m.sender_id
                             WHERE (m.sender_id = @a AND m.receiver_id = @b)
                                OR (m.sender_id = @b AND m.receiver_id = @a)
                             ORDER BY m.sent_at, m.id";

        var list = new List<MessageRow>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@a", MySqlDbType.Int32).Value = userA;
        cmd.Parameters.Add("@b", MySqlDbType.Int32).Value = userB;

        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new MessageRow
            {
                Id = Convert.ToInt32(reader["id"]),
                SenderId = Convert.ToInt32(reader["sender_id"]),
                SenderName = Convert.ToString(reader["name"]) ?? "",
                Content = Convert.ToString(reader["content"]) ?? "",
                SentAt = Convert.ToDateTime(reader["sent_at"])
            });
        }
        return list;
    }

    public void Insert(int senderId, int receiverId, string content)
    {
        const string sql = @"INSERT INTO messages (sender_id, receiver_id, content)
                             VALUES (@sender, @receiver, @content)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@sender", MySqlDbType.Int32).Value = senderId;
        cmd.Parameters.Add("@receiver", MySqlDbType.Int32).Value = receiverId;
        cmd.Parameters.Add("@content", MySqlDbType.Text).Value = content;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}