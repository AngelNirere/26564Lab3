using Smart_match.Models;

namespace Smart_match.Controllers;

public class FeedbackController
{
    private readonly FeedbackRepository _feedback = new();
    private readonly SessionRepository _sessions = new();

    private static User RequireUser()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");
        return user;
    }

    public List<SessionRow> GetSessionsToRate()
    {
        return _feedback.GetSessionsAwaitingFeedback(RequireUser().Id);
    }

    public void Submit(int sessionId, int rating, string comment)
    {
        var user = RequireUser();

        if (sessionId <= 0)
            throw new ArgumentException("Select a session first.");

        if (rating < 1 || rating > 5)
            throw new ArgumentException("The rating must be between 1 and 5.");

        string? status = _sessions.GetStatusIfParticipant(sessionId, user.Id);
        if (status == null)
            throw new InvalidOperationException("This session does not belong to you.");

        if (status != "Completed")
            throw new ArgumentException("You can only rate completed sessions.");

        if (_feedback.Exists(sessionId, user.Id))
            throw new ArgumentException("You already rated this session.");

        _feedback.Insert(sessionId, user.Id, rating, comment.Trim());
    }
}