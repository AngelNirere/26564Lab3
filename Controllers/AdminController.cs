using Smart_match.Models;

namespace Smart_match.Controllers;

public class AdminController
{
    private readonly AdminRepository _admin = new();

    private static User RequireAdmin()
    {
        var user = AuthController.CurrentUser;
        if (user == null || user.Role != "Admin")
            throw new InvalidOperationException("Only the administrator can use this screen.");
        return user;
    }

    public List<UserRow> GetAllUsers()
    {
        RequireAdmin();
        return _admin.GetAllUsers();
    }

    public void Suspend(int userId)
    {
        ChangeActive(userId, false);
    }

    public void Activate(int userId)
    {
        ChangeActive(userId, true);
    }

    private void ChangeActive(int userId, bool active)
    {
        var admin = RequireAdmin();

        if (userId <= 0)
            throw new ArgumentException("Select a user first.");

        if (userId == admin.Id)
            throw new InvalidOperationException("You cannot change your own account.");

        string? role = _admin.GetRole(userId);
        if (role == null)
            throw new ArgumentException("User not found.");

        if (role == "Admin")
            throw new InvalidOperationException("You cannot change another administrator.");

        _admin.SetActive(userId, active);
    }

    public ReportData GetReport()
    {
        RequireAdmin();
        return _admin.GetReport();
    }
}