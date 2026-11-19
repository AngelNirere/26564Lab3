using Smart_match.Models;

namespace Smart_match.Controllers;

public class MatchController
{
    private readonly ProfileRepository _profiles = new();
    private readonly MentorRepository _mentors = new();

    public List<MentorMatch> GetRecommendedMentors()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");

        var myProfile = _profiles.GetByUserId(user.Id);
        if (myProfile == null)
            throw new InvalidOperationException("Complete your profile first to see recommendations.");

        var result = new List<MentorMatch>();

        foreach (var mentor in _mentors.GetActiveMentors())
        {
            // skip mentors who reached their maximum number of mentees
            if (mentor.CurrentMentees >= mentor.Profile.MaxMentees)
                continue;

            mentor.Score = MatchingService.Score(myProfile, mentor.Profile);
            result.Add(mentor);
        }

        return result.OrderByDescending(m => m.Score).ToList();
    }
}