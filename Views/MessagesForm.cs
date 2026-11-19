using System.Data;
using Smart_match.Controllers;

namespace Smart_match.Views;

public partial class MessagesForm : Form
{
    private readonly MessageController _controller = new();

    public MessagesForm()
    {
        InitializeComponent();
        Theme.Apply(this);

        AcceptButton = btnSendMessage;
        btnSendMessage.Click += btnSendMessage_Click;
        btnRefreshMessages.Click += btnRefreshMessages_Click;

        LoadPartners();
        cboPartner.SelectedIndexChanged += cboPartner_SelectedIndexChanged;
        LoadConversation();
    }

    private void MessagesForm_Load(object? sender, EventArgs e)
    {
    }

    private int GetSelectedPartnerId()
    {
        return cboPartner.SelectedValue is int id ? id : 0;
    }

    private void LoadPartners()
    {
        try
        {
            cboPartner.DisplayMember = "Name";
            cboPartner.ValueMember = "UserId";
            cboPartner.DataSource = _controller.GetMyPartners();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadConversation()
    {
        try
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("From", typeof(string));
            table.Columns.Add("Message", typeof(string));
            table.Columns.Add("Time", typeof(string));

            int partnerId = GetSelectedPartnerId();
            if (partnerId > 0)
            {
                foreach (var m in _controller.GetConversation(partnerId))
                {
                    table.Rows.Add(m.Id, m.SenderName, m.Content,
                                   m.SentAt.ToString("yyyy-MM-dd HH:mm"));
                }
            }

            dgvMessages.DataSource = table;
            dgvMessages.Columns["Id"].Visible = false;

            // show the newest message at the bottom
            if (dgvMessages.Rows.Count > 0)
                dgvMessages.FirstDisplayedScrollingRowIndex = dgvMessages.Rows.Count - 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void cboPartner_SelectedIndexChanged(object? sender, EventArgs e)
    {
        LoadConversation();
    }

    private void btnSendMessage_Click(object? sender, EventArgs e)
    {
        try
        {
            _controller.Send(GetSelectedPartnerId(), txtMessage.Text);
            txtMessage.Clear();
            txtMessage.Focus();
            LoadConversation();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnRefreshMessages_Click(object? sender, EventArgs e)
    {
        LoadConversation();
    }
}