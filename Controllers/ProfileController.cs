using Smart_match.Models;

namespace Smart_match.Controllers;

public class ProfileController
{
    private readonly ProfileRepository _repository = new();

    public Profile? GetMyProfile()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");

        return _repository.GetByUserId(user.Id);
    }

    public void SaveMyProfile(Profile profile)
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");

        if (string.IsNullOrWhiteSpace(profile.Skills) ||
            string.IsNullOrWhiteSpace(profile.Interests) ||
            string.IsNullOrWhiteSpace(profile.Industry) ||
            string.IsNullOrWhiteSpace(profile.Goals) ||
            string.IsNullOrWhiteSpace(profile.ExperienceLevel) ||
            string.IsNullOrWhiteSpace(profile.Availability))
            throw new ArgumentException("Complete all profile fields.");

        if (profile.MaxMentees < 1)
            throw new ArgumentException("Maximum mentees must be at least 1.");

        profile.UserId = user.Id;
        _repository.Save(profile);
    }
}