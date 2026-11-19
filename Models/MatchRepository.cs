using MySqlConnector;

namespace Smart_match.Models;

public class MatchRepository
{
    public void Insert(int menteeId, int mentorId, double score)
    {
        const string sql = @"INSERT INTO matches (mentee_id, mentor_id, match_score)
                             VALUES (@mentee, @mentor, @score)";

        using var con = Database.GetConnection();
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@mentee", MySqlDbType.Int32).Value = menteeId;
        cmd.Parameters.Add("@mentor", MySqlDbType.Int32).Value = mentorId;
        cmd.Parameters.Add("@score", MySqlDbType.Decimal).Value = Math.Round(score * 100, 2);

        con.Open();
        cmd.ExecuteNonQuery();
    }
}