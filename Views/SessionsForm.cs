using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class SessionsForm : Form
{
    private readonly SessionController _controller = new();

    public SessionsForm()
    {
        InitializeComponent();

        btnSchedule.Click += btnSchedule_Click;
        btnComplete.Click += btnComplete_Click;
        btnCancelSession.Click += btnCancelSession_Click;

        dtpDate.Value = DateTime.Now.AddDays(1);
        LoadMatches();
        LoadSessions();
    }

    private void SessionsForm_Load(object? sender, EventArgs e)
    {
    }

    private void LoadMatches()
    {
        try
        {
            cboMatch.DisplayMember = "PartnerName";
            cboMatch.ValueMember = "MatchId";
            cboMatch.DataSource = _controller.GetMyMatches();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sessions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadSessions()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("With", typeof(string));
            table.Columns.Add("Date", typeof(string));
            table.Columns.Add("Status", typeof(string));

            foreach (var s in _controller.GetMySessions())
            {
                table.Rows.Add(s.Id, s.PartnerName,
                               s.SessionDate.ToString("yyyy-MM-dd HH:mm"), s.Status);
            }

            dgvSessions.DataSource = table;
            dgvSessions.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sessions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private int GetSelectedSessionId()
    {
        if (dgvSessions.CurrentRow == null) return 0;
        return Convert.ToInt32(dgvSessions.CurrentRow.Cells["Id"].Value);
    }

    private void btnSchedule_Click(object? sender, EventArgs e)
    {
        try
        {
            int matchId = cboMatch.SelectedValue is int id ? id : 0;
            _controller.Schedule(matchId, dtpDate.Value);
            MessageBox.Show("Session scheduled.", "Sessions");
            LoadSessions();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sessions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnComplete_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.MarkCompleted(GetSelectedSessionId());
            MessageBox.Show("Session marked as completed.", "Sessions");
            LoadSessions();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sessions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnCancelSession_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.Cancel(GetSelectedSessionId());
            MessageBox.Show("Session cancelled.", "Sessions");
            LoadSessions();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sessions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}