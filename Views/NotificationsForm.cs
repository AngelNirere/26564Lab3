using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class NotificationsForm : Form
{
    private readonly NotificationController _controller = new();

    public NotificationsForm()
    {
        InitializeComponent();
        LoadNotifications();
    }

    private void NotificationsForm_Load(object? sender, EventArgs e)
    {
    }

    private void LoadNotifications()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Message", typeof(string));
            table.Columns.Add("Date", typeof(string));

            foreach (var n in _controller.GetMyNotifications())
            {
                table.Rows.Add(n.IsRead ? "Read" : "New", n.Message,
                               n.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
            }

            dgvNotifications.DataSource = table;

            // the list above still shows which ones were new; now they count as read
            _controller.MarkAllRead();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}