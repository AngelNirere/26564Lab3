using Smart_match.Models;

namespace Smart_match.Controllers;

public class SessionController
{
    private readonly SessionRepository _sessions = new();

    private static User RequireUser()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");
        return user;
    }

    public List<MatchOption> GetMyMatches()
    {
        return _sessions.GetMatchOptions(RequireUser().Id);
    }

    public List<SessionRow> GetMySessions()
    {
        return _sessions.GetSessionsForUser(RequireUser().Id);
    }

    public void Schedule(int matchId, DateTime date)
    {
        var user = RequireUser();

        if (matchId <= 0)
            throw new ArgumentException("Choose who you want to meet.");

        if (date <= DateTime.Now)
            throw new ArgumentException("Choose a date and time in the future.");

        if (!_sessions.MatchBelongsToUser(matchId, user.Id))
            throw new InvalidOperationException("You can only schedule sessions with your own matches.");

        _sessions.Insert(matchId, date);
    }

    public void MarkCompleted(int sessionId)
    {
        ChangeStatus(sessionId, "Completed");
    }

    public void Cancel(int sessionId)
    {
        ChangeStatus(sessionId, "Cancelled");
    }

    private void ChangeStatus(int sessionId, string newStatus)
    {
        var user = RequireUser();

        if (sessionId <= 0)
            throw new ArgumentException("Select a session first.");

        string? current = _sessions.GetStatusIfParticipant(sessionId, user.Id);
        if (current == null)
            throw new InvalidOperationException("This session does not belong to you.");

        if (current != "Scheduled")
            throw new ArgumentException("Only scheduled sessions can be changed.");

        _sessions.UpdateStatus(sessionId, newStatus);
    }
}