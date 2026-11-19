using Smart_match.Controllers;
using Smart_match.Models;

namespace Smart_match.Views;

public partial class ProfileForm : Form
{
    private readonly ProfileController _controller = new();
    private void ProfileForm_Load(object? sender, EventArgs e)
    {
    }

    private void numericUpDown1_ValueChanged(object? sender, EventArgs e)
    {
    }

    public ProfileForm()
    {
        InitializeComponent();
        btnSaveProfile.Click += btnSaveProfile_Click;
        LoadProfile();
    }

    private void LoadProfile()
    {
        try
        {
            var profile = _controller.GetMyProfile();
            if (profile == null) return;

            txtSkills.Text = profile.Skills;
            txtInterests.Text = profile.Interests;
            txtIndustry.Text = profile.Industry;
            txtGoals.Text = profile.Goals;
            cboLevel.SelectedItem = profile.ExperienceLevel;
            txtAvailability.Text = profile.Availability;
            numMaxMentees.Value = profile.MaxMentees;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private Profile ReadProfileFromForm()
    {
        return new Profile
        {
            Skills = txtSkills.Text.Trim(),
            Interests = txtInterests.Text.Trim(),
            Industry = txtIndustry.Text.Trim(),
            Goals = txtGoals.Text.Trim(),
            ExperienceLevel = cboLevel.SelectedItem?.ToString() ?? "",
            Availability = txtAvailability.Text.Trim(),
            MaxMentees = (int)numMaxMentees.Value
        };
    }

    private void btnSaveProfile_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.SaveMyProfile(ReadProfileFromForm());
            MessageBox.Show("Profile saved successfully.", "Profile");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}