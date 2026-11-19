using Smart_match.Models;

namespace Smart_match.Controllers;

public class AuthController
{
    private readonly UserRepository _users = new();

    public static User? CurrentUser { get; private set; }

    public void Register(string name, string email, string password, string role)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Complete all fields.");

        if (!email.Contains('@') || !email.Contains('.'))
            throw new ArgumentException("Enter a valid email address.");

        if (password.Length < 6)
            throw new ArgumentException("Password must have at least 6 characters.");

        if (role != "Mentee" && role != "Mentor")
            throw new ArgumentException("Choose Mentee or Mentor.");

        if (_users.GetByEmail(email.Trim()) != null)
            throw new ArgumentException("This email is already registered.");

        _users.Insert(new User
        {
            Name = name.Trim(),
            Email = email.Trim(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = role
        });
    }

    public User Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Enter your email and password.");

        var user = _users.GetByEmail(email.Trim());

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            throw new ArgumentException("Wrong email or password.");

        if (!user.IsActive)
            throw new ArgumentException("This account is suspended. Contact the admin.");

        CurrentUser = user;
        return user;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}