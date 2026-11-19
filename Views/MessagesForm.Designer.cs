namespace Smart_match.Views
{
    partial class MessagesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPartner = new Label();
            cboPartner = new ComboBox();
            dgvMessages = new DataGridView();
            txtMessage = new TextBox();
            btnSendMessage = new Button();
            btnRefreshMessages = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMessages).BeginInit();
            SuspendLayout();
            // 
            // lblPartner
            // 
            lblPartner.AutoSize = true;
            lblPartner.Location = new Point(20, 20);
            lblPartner.Name = "lblPartner";
            lblPartner.Size = new Size(58, 15);
            lblPartner.TabIndex = 0;
            lblPartner.Text = "Chat with";
            // 
            // cboPartner
            // 
            cboPartner.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPartner.FormattingEnabled = true;
            cboPartner.Location = new Point(20, 43);
            cboPartner.Name = "cboPartner";
            cboPartner.Size = new Size(300, 23);
            cboPartner.TabIndex = 1;
            // 
            // dgvMessages
            // 
            dgvMessages.AllowUserToAddRows = false;
            dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMessages.Location = new Point(20, 85);
            dgvMessages.MultiSelect = false;
            dgvMessages.Name = "dgvMessages";
            dgvMessages.ReadOnly = true;
            dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMessages.Size = new Size(700, 280);
            dgvMessages.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(20, 385);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(570, 23);
            txtMessage.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(600, 380);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(120, 32);
            btnSendMessage.TabIndex = 4;
            btnSendMessage.Text = "Send";
            btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // btnRefreshMessages
            // 
            btnRefreshMessages.Location = new Point(20, 425);
            btnRefreshMessages.Name = "btnRefreshMessages";
            btnRefreshMessages.Size = new Size(120, 32);
            btnRefreshMessages.TabIndex = 5;
            btnRefreshMessages.Text = "Refresh";
            btnRefreshMessages.UseVisualStyleBackColor = true;
            // 
            // MessagesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 481);
            Controls.Add(btnRefreshMessages);
            Controls.Add(btnSendMessage);
            Controls.Add(txtMessage);
            Controls.Add(dgvMessages);
            Controls.Add(cboPartner);
            Controls.Add(lblPartner);
            Name = "MessagesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Messages";
            ((System.ComponentModel.ISupportInitialize)dgvMessages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPartner;
        private ComboBox cboPartner;
        private DataGridView dgvMessages;
        private TextBox txtMessage;
        private Button btnSendMessage;
        private Button btnRefreshMessages;
    }
}