using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class FeedbackForm : Form
{
    private readonly FeedbackController _controller = new();

    public FeedbackForm()
    {
        InitializeComponent();
        btnSubmitFeedback.Click += btnSubmitFeedback_Click;
        LoadSessions();
    }

    private void FeedbackForm_Load(object? sender, EventArgs e)
    {
    }

    private void LoadSessions()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("With", typeof(string));
            table.Columns.Add("Date", typeof(string));

            foreach (var s in _controller.GetSessionsToRate())
            {
                table.Rows.Add(s.Id, s.PartnerName,
                               s.SessionDate.ToString("yyyy-MM-dd HH:mm"));
            }

            dgvToRate.DataSource = table;
            dgvToRate.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnSubmitFeedback_Click(object? sender, EventArgs e)
    {
        try
        {
            if (dgvToRate.CurrentRow == null)
                throw new ArgumentException("Select a session first.");

            int sessionId = Convert.ToInt32(dgvToRate.CurrentRow.Cells["Id"].Value);
            _controller.Submit(sessionId, (int)numRating.Value, txtComment.Text);

            MessageBox.Show("Thank you, your feedback was saved.", "Feedback");
            txtComment.Clear();
            numRating.Value = 5;
            LoadSessions();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}