using Smart_match.Models;

namespace Smart_match.Controllers;

public class NotificationController
{
    private readonly NotificationRepository _notifications = new();

    private static User RequireUser()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");
        return user;
    }

    public List<NotificationRow> GetMyNotifications()
    {
        return _notifications.GetForUser(RequireUser().Id);
    }

    public int CountMyUnread()
    {
        return _notifications.CountUnread(RequireUser().Id);
    }

    public void MarkAllRead()
    {
        _notifications.MarkAllRead(RequireUser().Id);
    }
}