using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class RequestsForm : Form
{
    private readonly RequestController _controller = new();

    public RequestsForm()
    {

        InitializeComponent();
        btnAccept.Click += btnAccept_Click;
        btnReject.Click += btnReject_Click;
        LoadRequests();
    }

    private void LoadRequests()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Mentee", typeof(string));
            table.Columns.Add("Skills", typeof(string));
            table.Columns.Add("Goals", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Date", typeof(string));

            foreach (var r in _controller.GetMyIncomingRequests())
            {
                table.Rows.Add(r.Id, r.MenteeName, r.Skills, r.Goals,
                               r.Status, r.RequestDate.ToString("yyyy-MM-dd HH:mm"));
            }

            dgvRequests.DataSource = table;
            dgvRequests.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Requests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private int GetSelectedRequestId()
    {
        if (dgvRequests.CurrentRow == null) return 0;
        return Convert.ToInt32(dgvRequests.CurrentRow.Cells["Id"].Value);
    }

    private void btnAccept_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.Accept(GetSelectedRequestId());
            MessageBox.Show("Request accepted. A match was created.", "Requests");
            LoadRequests();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Requests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnReject_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.Reject(GetSelectedRequestId());
            MessageBox.Show("Request rejected.", "Requests");
            LoadRequests();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Requests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}