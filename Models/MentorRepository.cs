using MySqlConnector;

namespace Smart_match.Models;

public class MentorRepository
{
    public List<MentorMatch> GetActiveMentors()
    {
        const string sql = @"SELECT u.id, u.name, p.skills, p.interests, p.industry,
                                    p.goals, p.experience_level, p.availability, p.max_mentees,
                                    (SELECT COUNT(*) FROM matches m
                                     WHERE m.mentor_id = u.id) AS current_mentees
                             FROM users u
                             JOIN profiles p ON p.user_id = u.id
                             WHERE u.role = 'Mentor' AND u.is_active = 1";

        var list = new List<MentorMatch>();

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new MentorMatch
            {
                MentorId = Convert.ToInt32(reader["id"]),
                MentorName = Convert.ToString(reader["name"]) ?? "",
                CurrentMentees = Convert.ToInt32(reader["current_mentees"]),
                Profile = new Profile
                {
                    UserId = Convert.ToInt32(reader["id"]),
                    Skills = Convert.ToString(reader["skills"]) ?? "",
                    Interests = Convert.ToString(reader["interests"]) ?? "",
                    Industry = Convert.ToString(reader["industry"]) ?? "",
                    Goals = Convert.ToString(reader["goals"]) ?? "",
                    ExperienceLevel = Convert.ToString(reader["experience_level"]) ?? "",
                    Availability = Convert.ToString(reader["availability"]) ?? "",
                    MaxMentees = Convert.ToInt32(reader["max_mentees"])
                }
            });
        }
        return list;
    }
}