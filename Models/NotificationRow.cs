namespace Smart_match.Models;

public class NotificationRow
{
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}