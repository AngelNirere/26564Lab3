namespace Smart_match.Models;

public class RequestRow
{
    public int Id { get; set; }
    public int MenteeId { get; set; }
    public string MenteeName { get; set; } = "";
    public string Skills { get; set; } = "";
    public string Goals { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime RequestDate { get; set; }
}