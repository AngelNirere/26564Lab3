namespace Smart_match.Models;

public class MentorMatch
{
    public int MentorId { get; set; }
    public string MentorName { get; set; } = "";
    public Profile Profile { get; set; } = new();
    public int CurrentMentees { get; set; }
    public double Score { get; set; }
}