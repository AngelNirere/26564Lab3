using MySqlConnector;

namespace Smart_match.Models;

public class UserRepository
{
    public User? GetByEmail(string email)
    {
        const string sql = @"SELECT id, name, email, password_hash, role, is_active
                             FROM users WHERE email = @email";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = email;

        con.Open();
        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new User
        {
            Id = Convert.ToInt32(reader["id"]),
            Name = Convert.ToString(reader["name"]) ?? "",
            Email = Convert.ToString(reader["email"]) ?? "",
            PasswordHash = Convert.ToString(reader["password_hash"]) ?? "",
            Role = Convert.ToString(reader["role"]) ?? "Mentee",
            IsActive = Convert.ToBoolean(reader["is_active"])
        };
    }

    public void Insert(User user)
    {
        const string sql = @"INSERT INTO users (name, email, password_hash, role)
                             VALUES (@name, @email, @hash, @role)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = user.Name;
        cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = user.Email;
        cmd.Parameters.Add("@hash", MySqlDbType.VarChar, 255).Value = user.PasswordHash;
        cmd.Parameters.Add("@role", MySqlDbType.VarChar, 10).Value = user.Role;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}