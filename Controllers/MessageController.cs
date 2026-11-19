using Smart_match.Models;

namespace Smart_match.Controllers;

public class MessageController
{
    private readonly MessageRepository _messages = new();
    private readonly NotificationRepository _notifications = new();

    private static User RequireUser()
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");

        if (user.Role == "Admin")
            throw new InvalidOperationException("Messaging is for mentors and mentees.");

        return user;
    }

    public List<PartnerOption> GetMyPartners()
    {
        return _messages.GetPartners(RequireUser().Id);
    }

    public List<MessageRow> GetConversation(int partnerId)
    {
        var user = RequireUser();

        if (partnerId <= 0)
            throw new ArgumentException("Choose who you want to chat with.");

        if (!_messages.AreMatched(user.Id, partnerId))
            throw new InvalidOperationException("You can only chat with your matched partners.");

        return _messages.GetConversation(user.Id, partnerId);
    }

    public void Send(int partnerId, string content)
    {
        var user = RequireUser();

        if (partnerId <= 0)
            throw new ArgumentException("Choose who you want to chat with.");

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Type a message first.");

        if (content.Length > 1000)
            throw new ArgumentException("A message can have at most 1000 characters.");

        if (!_messages.AreMatched(user.Id, partnerId))
            throw new InvalidOperationException("You can only chat with your matched partners.");

        _messages.Insert(user.Id, partnerId, content.Trim());
        _notifications.Insert(partnerId, "New message from " + user.Name + ".");
    }
}