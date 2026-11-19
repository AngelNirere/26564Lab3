using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class RegisterForm : Form
{
    private readonly AuthController _auth = new();
    private readonly TextBox txtName = new();
    private readonly TextBox txtEmail = new();
    private readonly TextBox txtPassword = new();
    private readonly ComboBox cboRole = new();
    private readonly Button btnRegister = new();

    public RegisterForm()
    {
        InitializeComponent();
        BuildUi();
        Theme.Apply(this);
    }
    private void RegisterForm_Load(object? sender, EventArgs e)
    {
    }
    private void BuildUi()
    {
        Text = "Smart Match - Register";
        ClientSize = new Size(360, 380);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        var title = new Label
        {
            Text = "Create account",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Location = new Point(20, 15),
            AutoSize = true
        };

        var lblName = new Label { Text = "Full name", Location = new Point(20, 65), AutoSize = true };
        txtName.Location = new Point(20, 85);
        txtName.Width = 320;

        var lblEmail = new Label { Text = "Email", Location = new Point(20, 120), AutoSize = true };
        txtEmail.Location = new Point(20, 140);
        txtEmail.Width = 320;

        var lblPassword = new Label { Text = "Password (min 6 characters)", Location = new Point(20, 175), AutoSize = true };
        txtPassword.Location = new Point(20, 195);
        txtPassword.Width = 320;
        txtPassword.UseSystemPasswordChar = true;

        var lblRole = new Label { Text = "I am a", Location = new Point(20, 230), AutoSize = true };
        cboRole.Location = new Point(20, 250);
        cboRole.Width = 320;
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRole.Items.AddRange(new object[] { "Mentee", "Mentor" });
        cboRole.SelectedIndex = 0;

        btnRegister.Text = "Register";
        btnRegister.Location = new Point(20, 300);
        btnRegister.Size = new Size(320, 40);
        btnRegister.Click += btnRegister_Click;
        AcceptButton = btnRegister;

        Controls.AddRange(new Control[]
        {
            title, lblName, txtName, lblEmail, txtEmail,
            lblPassword, txtPassword, lblRole, cboRole, btnRegister
        });
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        try
        {
            _auth.Register(txtName.Text, txtEmail.Text, txtPassword.Text,
                           cboRole.SelectedItem?.ToString() ?? "");
            MessageBox.Show("Account created successfully.", "Register");
            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}