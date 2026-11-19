namespace Smart_match.Models;

public class PartnerOption
{
    public int UserId { get; set; }
    public string Name { get; set; } = "";
}

public class MessageRow
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public string SenderName { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime SentAt { get; set; }
}