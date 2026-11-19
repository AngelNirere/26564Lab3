using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class DashboardForm : Form
{
    private readonly NotificationController _notifications = new();

    public DashboardForm()
    {
        InitializeComponent();
        Theme.Apply(this);

        var user = AuthController.CurrentUser;
        lblWelcome.Text = "Welcome, " + user?.Name + " (" + user?.Role + ")";

        bool isAdmin = user?.Role == "Admin";

        // the admin only sees the admin buttons
        btnManageUsers.Visible = isAdmin;
        btnReports.Visible = isAdmin;
        btnMyProfile.Visible = !isAdmin;
        btnSessions.Visible = !isAdmin;
        btnFeedback.Visible = !isAdmin;
        btnNotifications.Visible = !isAdmin;
        btnMessages.Visible = !isAdmin;

        // mentees search for mentors, mentors answer requests
        btnFindMentors.Visible = user?.Role == "Mentee";
        btnRequests.Visible = user?.Role == "Mentor";
        btnRequests.Location = btnFindMentors.Location;

        if (isAdmin)
            btnLogout.Location = new Point(20, 180);

        btnMyProfile.Click += btnMyProfile_Click;
        btnFindMentors.Click += btnFindMentors_Click;
        btnRequests.Click += btnRequests_Click;
        btnSessions.Click += btnSessions_Click;
        btnFeedback.Click += btnFeedback_Click;
        btnNotifications.Click += btnNotifications_Click;
        btnMessages.Click += btnMessages_Click;
        btnManageUsers.Click += btnManageUsers_Click;
        btnReports.Click += btnReports_Click;

        if (!isAdmin)
            RefreshNotificationCount();
    }

    private void DashboardForm_Load(object? sender, EventArgs e)
    {
    }

    private void RefreshNotificationCount()
    {
        try
        {
            int unread = _notifications.CountMyUnread();
            btnNotifications.Text = unread > 0
                ? "Notifications (" + unread + " new)"
                : "Notifications";
        }
        catch (Exception)
        {
            btnNotifications.Text = "Notifications";
        }
    }

    private void btnMyProfile_Click(object? sender, EventArgs e)
    {
        using var form = new ProfileForm();
        form.ShowDialog(this);
    }

    private void btnFindMentors_Click(object? sender, EventArgs e)
    {
        using var form = new MentorsForm();
        form.ShowDialog(this);
        RefreshNotificationCount();
    }

    private void btnRequests_Click(object? sender, EventArgs e)
    {
        using var form = new RequestsForm();
        form.ShowDialog(this);
    }

    private void btnSessions_Click(object? sender, EventArgs e)
    {
        using var form = new SessionsForm();
        form.ShowDialog(this);
    }

    private void btnFeedback_Click(object? sender, EventArgs e)
    {
        using var form = new FeedbackForm();
        form.ShowDialog(this);
    }

    private void btnNotifications_Click(object? sender, EventArgs e)
    {
        using var form = new NotificationsForm();
        form.ShowDialog(this);
        RefreshNotificationCount();
    }

    private void btnMessages_Click(object? sender, EventArgs e)
    {
        using var form = new MessagesForm();
        form.ShowDialog(this);
    }

    private void btnManageUsers_Click(object? sender, EventArgs e)
    {
        using var form = new UsersForm();
        form.ShowDialog(this);
    }

    private void btnReports_Click(object? sender, EventArgs e)
    {
        using var form = new ReportsForm();
        form.ShowDialog(this);
    }

    private void btnLogout_Click_1(object? sender, EventArgs e)
    {
        Close();
    }
}