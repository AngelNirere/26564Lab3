using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class UsersForm : Form
{
    private readonly AdminController _controller = new();

    public UsersForm()
    {
        InitializeComponent();
        btnSuspend.Click += btnSuspend_Click;
        btnActivate.Click += btnActivate_Click;
        LoadUsers();
    }

    private void UsersForm_Load(object? sender, EventArgs e)
    {
    }

    private void LoadUsers()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Role", typeof(string));
            table.Columns.Add("Account", typeof(string));
            table.Columns.Add("Created", typeof(string));

            foreach (var u in _controller.GetAllUsers())
            {
                table.Rows.Add(u.Id, u.Name, u.Email, u.Role,
                               u.IsActive ? "Active" : "Suspended",
                               u.CreatedAt.ToString("yyyy-MM-dd"));
            }

            dgvUsers.DataSource = table;
            dgvUsers.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Manage users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private int GetSelectedUserId()
    {
        if (dgvUsers.CurrentRow == null) return 0;
        return Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
    }

    private void btnSuspend_Click(object? sender, EventArgs e)
    {
        try
        {
            var answer = MessageBox.Show("Suspend this account? The user will not be able to log in.",
                                         "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            _controller.Suspend(GetSelectedUserId());
            MessageBox.Show("Account suspended.", "Manage users");
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Manage users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnActivate_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.Activate(GetSelectedUserId());
            MessageBox.Show("Account activated.", "Manage users");
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Manage users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}