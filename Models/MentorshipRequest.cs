namespace Smart_match.Models;

public class MentorshipRequest
{
    public int Id { get; set; }
    public int MenteeId { get; set; }
    public int MentorId { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime RequestDate { get; set; }
}