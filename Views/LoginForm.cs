using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class LoginForm : Form
{
    private readonly AuthController _auth = new();
    private readonly TextBox txtEmail = new();
    private readonly TextBox txtPassword = new();
    private readonly Button btnLogin = new();
    private readonly Button btnRegister = new();

    public LoginForm()
    {
        InitializeComponent();
        BuildUi();
        Theme.Apply(this);
    }

    private void LoginForm_Load(object? sender, EventArgs e)
    {
    }

    private void BuildUi()
    {
        Text = "Smart Match - Login";
        ClientSize = new Size(360, 300);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        var title = new Label
        {
            Text = "Smart Match",
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            Location = new Point(20, 15),
            AutoSize = true
        };

        var lblEmail = new Label { Text = "Email", Location = new Point(20, 70), AutoSize = true };
        txtEmail.Location = new Point(20, 90);
        txtEmail.Width = 320;

        var lblPassword = new Label { Text = "Password", Location = new Point(20, 125), AutoSize = true };
        txtPassword.Location = new Point(20, 145);
        txtPassword.Width = 320;
        txtPassword.UseSystemPasswordChar = true;

        btnLogin.Text = "Login";
        btnLogin.Location = new Point(20, 190);
        btnLogin.Size = new Size(320, 40);
        btnLogin.Click += btnLogin_Click;
        AcceptButton = btnLogin;

        btnRegister.Text = "Create a new account";
        btnRegister.Location = new Point(20, 240);
        btnRegister.Size = new Size(320, 35);
        btnRegister.Click += btnRegister_Click;

        Controls.AddRange(new Control[]
        {
            title, lblEmail, txtEmail, lblPassword, txtPassword, btnLogin, btnRegister
        });
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        try
        {
            var user = _auth.Login(txtEmail.Text, txtPassword.Text);

            Hide();
            using var dashboard = new DashboardForm();
            dashboard.ShowDialog(this);
            _auth.Logout();
            txtPassword.Clear();
            Show();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        using var form = new RegisterForm();
        form.ShowDialog(this);
    }

    private void LoginForm_Load_1(object sender, EventArgs e)
    {

    }
}