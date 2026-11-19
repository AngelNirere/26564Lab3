using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class ReportsForm : Form
{
    private readonly AdminController _controller = new();

    public ReportsForm()
    {
        InitializeComponent();
        LoadReport();
    }

    private void ReportsForm_Load(object? sender, EventArgs e)
    {
    }

    private void LoadReport()
    {
        try
        {
            var report = _controller.GetReport();

            var table = new DataTable();
            table.Columns.Add("Metric", typeof(string));
            table.Columns.Add("Value", typeof(string));

            table.Rows.Add("Registered mentees", report.TotalMentees.ToString());
            table.Rows.Add("Registered mentors", report.TotalMentors.ToString());
            table.Rows.Add("Active mentorships (matches)", report.TotalMatches.ToString());
            table.Rows.Add("Pending requests", report.PendingRequests.ToString());
            table.Rows.Add("Completed sessions", report.CompletedSessions.ToString());
            table.Rows.Add("Feedback received", report.FeedbackCount.ToString());
            table.Rows.Add("Average rating (out of 5)", report.AverageRating.ToString("0.0"));

            dgvReport.DataSource = table;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}