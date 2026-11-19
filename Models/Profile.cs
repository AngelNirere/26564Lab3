namespace Smart_match.Models;

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Skills { get; set; } = "";
    public string Interests { get; set; } = "";
    public string Industry { get; set; } = "";
    public string Goals { get; set; } = "";
    public string ExperienceLevel { get; set; } = "";
    public string Availability { get; set; } = "";
    public int MaxMentees { get; set; } = 3;
}