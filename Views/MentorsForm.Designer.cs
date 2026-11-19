namespace Smart_match.Views
{
    partial class MentorsForm
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
            lblTitle = new Label();
            dgvMentors = new DataGridView();
            btnSendRequest = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMentors).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(176, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Recommended mentors for you";
            // 
            // dgvMentors
            // 
            dgvMentors.AllowUserToAddRows = false;
            dgvMentors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMentors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMentors.Location = new Point(20, 50);
            dgvMentors.MultiSelect = false;
            dgvMentors.Name = "dgvMentors";
            dgvMentors.ReadOnly = true;
            dgvMentors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMentors.Size = new Size(640, 300);
            dgvMentors.TabIndex = 1;
            // 
            // btnSendRequest
            // 
            btnSendRequest.Location = new Point(20, 360);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(200, 35);
            btnSendRequest.TabIndex = 2;
            btnSendRequest.Text = "Send request";
            btnSendRequest.UseVisualStyleBackColor = true;
            btnSendRequest.Click += btnSendRequest_Click;
            // 
            // MentorsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(btnSendRequest);
            Controls.Add(dgvMentors);
            Controls.Add(lblTitle);
            Name = "MentorsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Find Mentors";
            ((System.ComponentModel.ISupportInitialize)dgvMentors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvMentors;
        private Button btnSendRequest;
    }
}