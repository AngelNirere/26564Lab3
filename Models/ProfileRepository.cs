using MySqlConnector;

namespace Smart_match.Models;

public class ProfileRepository
{
    public Profile? GetByUserId(int userId)
    {
        const string sql = @"SELECT id, user_id, skills, interests, industry,
                                    goals, experience_level, availability, max_mentees
                             FROM profiles WHERE user_id = @uid";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

        con.Open();
        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new Profile
        {
            Id = Convert.ToInt32(reader["id"]),
            UserId = Convert.ToInt32(reader["user_id"]),
            Skills = Convert.ToString(reader["skills"]) ?? "",
            Interests = Convert.ToString(reader["interests"]) ?? "",
            Industry = Convert.ToString(reader["industry"]) ?? "",
            Goals = Convert.ToString(reader["goals"]) ?? "",
            ExperienceLevel = Convert.ToString(reader["experience_level"]) ?? "",
            Availability = Convert.ToString(reader["availability"]) ?? "",
            MaxMentees = Convert.ToInt32(reader["max_mentees"])
        };
    }

    public void Save(Profile p)
    {
        const string sql = @"INSERT INTO profiles
                (user_id, skills, interests, industry, goals,
                 experience_level, availability, max_mentees)
             VALUES (@uid, @skills, @interests, @industry, @goals,
                     @level, @availability, @max)
             ON DUPLICATE KEY UPDATE
                skills = @skills, interests = @interests, industry = @industry,
                goals = @goals, experience_level = @level,
                availability = @availability, max_mentees = @max";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = p.UserId;
        cmd.Parameters.Add("@skills", MySqlDbType.Text).Value = p.Skills;
        cmd.Parameters.Add("@interests", MySqlDbType.Text).Value = p.Interests;
        cmd.Parameters.Add("@industry", MySqlDbType.VarChar, 100).Value = p.Industry;
        cmd.Parameters.Add("@goals", MySqlDbType.Text).Value = p.Goals;
        cmd.Parameters.Add("@level", MySqlDbType.VarChar, 20).Value = p.ExperienceLevel;
        cmd.Parameters.Add("@availability", MySqlDbType.VarChar, 100).Value = p.Availability;
        cmd.Parameters.Add("@max", MySqlDbType.Int32).Value = p.MaxMentees;

        con.Open();
        cmd.ExecuteNonQuery();
    }
}