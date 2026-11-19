namespace Smart_match.Models;

public class SessionRow
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public string PartnerName { get; set; } = "";
    public DateTime SessionDate { get; set; }
    public string Status { get; set; } = "";
}