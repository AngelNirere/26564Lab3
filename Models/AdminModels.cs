namespace Smart_match.Models;

public class UserRow
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ReportData
{
    public int TotalMentees { get; set; }
    public int TotalMentors { get; set; }
    public int TotalMatches { get; set; }
    public int PendingRequests { get; set; }
    public int CompletedSessions { get; set; }
    public int FeedbackCount { get; set; }
    public double AverageRating { get; set; }
}