using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class MentorsForm : Form
{
    private readonly MatchController _controller = new();
    private readonly RequestController _requestController = new();

    public MentorsForm()
    {
        InitializeComponent();
        Theme.Apply(this);
        LoadMentors();
    }

    private void LoadMentors()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("Mentor", typeof(string));
            table.Columns.Add("Skills", typeof(string));
            table.Columns.Add("Industry", typeof(string));
            table.Columns.Add("Level", typeof(string));
            table.Columns.Add("Availability", typeof(string));
            table.Columns.Add("Match", typeof(string));

            int rank = 1;
            foreach (var m in _controller.GetRecommendedMentors())
            {
                table.Rows.Add(m.MentorId, rank++, m.MentorName,
                               m.Profile.Skills, m.Profile.Industry,
                               m.Profile.ExperienceLevel, m.Profile.Availability,
                               (m.Score * 100).ToString("0") + "%");
            }

            dgvMentors.DataSource = table;
            dgvMentors.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Find Mentors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnSendRequest_Click(object sender, EventArgs e)
    {
        if (dgvMentors.CurrentRow == null)
        {
            MessageBox.Show("Select a mentor first.", "Send request");
            return;
        }

        int mentorId = Convert.ToInt32(dgvMentors.CurrentRow.Cells["Id"].Value);
        string mentorName = Convert.ToString(dgvMentors.CurrentRow.Cells["Mentor"].Value) ?? "";

        var answer = MessageBox.Show("Send a mentorship request to " + mentorName + "?",
                                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes) return;

        try
        {
            _requestController.SendRequest(mentorId);
            MessageBox.Show("Request sent to " + mentorName + ".", "Send request");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Send request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}