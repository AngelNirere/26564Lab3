namespace Smart_match.Views
{
    partial class SessionsForm
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
            lblMatch = new Label();
            cboMatch = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnSchedule = new Button();
            dgvSessions = new DataGridView();
            btnComplete = new Button();
            btnCancelSession = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            SuspendLayout();
            // 
            // lblMatch
            // 
            lblMatch.AutoSize = true;
            lblMatch.Location = new Point(20, 20);
            lblMatch.Name = "lblMatch";
            lblMatch.Size = new Size(60, 15);
            lblMatch.TabIndex = 0;
            lblMatch.Text = "Meet with";
            // 
            // cboMatch
            // 
            cboMatch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMatch.FormattingEnabled = true;
            cboMatch.Location = new Point(20, 43);
            cboMatch.Name = "cboMatch";
            cboMatch.Size = new Size(300, 23);
            cboMatch.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(340, 20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(81, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date and time";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "YYY-MM-dd  HH:mm";
            dtpDate.Location = new Point(340, 43);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 23);
            dtpDate.TabIndex = 3;
            // 
            // btnSchedule
            // 
            btnSchedule.Location = new Point(610, 38);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(110, 32);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Schedule";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // dgvSessions
            // 
            dgvSessions.AllowUserToAddRows = false;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSessions.Location = new Point(20, 85);
            dgvSessions.MultiSelect = false;
            dgvSessions.Name = "dgvSessions";
            dgvSessions.ReadOnly = true;
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.Size = new Size(700, 300);
            dgvSessions.TabIndex = 5;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(20, 400);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(150, 35);
            btnComplete.TabIndex = 6;
            btnComplete.Text = "Mark completed";
            btnComplete.UseVisualStyleBackColor = true;
            // 
            // btnCancelSession
            // 
            btnCancelSession.Location = new Point(180, 400);
            btnCancelSession.Name = "btnCancelSession";
            btnCancelSession.Size = new Size(150, 35);
            btnCancelSession.TabIndex = 7;
            btnCancelSession.Text = "Cancel session";
            btnCancelSession.UseVisualStyleBackColor = true;
            // 
            // SessionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 481);
            Controls.Add(btnCancelSession);
            Controls.Add(btnComplete);
            Controls.Add(dgvSessions);
            Controls.Add(btnSchedule);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cboMatch);
            Controls.Add(lblMatch);
            Name = "SessionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Sessions";
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMatch;
        private ComboBox cboMatch;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Button btnSchedule;
        private DataGridView dgvSessions;
        private Button btnComplete;
        private Button btnCancelSession;
    }
}