namespace Smart_match.Views
{
    partial class DashboardForm
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
            lblWelcome = new Label();
            btnMyProfile = new Button();
            btnFindMentors = new Button();
            btnLogout = new Button();
            btnRequests = new Button();
            btnSessions = new Button();
            btnFeedback = new Button();
            btnNotifications = new Button();
            btnManageUsers = new Button();
            btnReports = new Button();
            btnMessages = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(57, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnMyProfile
            // 
            btnMyProfile.Location = new Point(20, 70);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(300, 40);
            btnMyProfile.TabIndex = 1;
            btnMyProfile.Text = "My profile";
            btnMyProfile.UseVisualStyleBackColor = true;
            // 
            // btnFindMentors
            // 
            btnFindMentors.Location = new Point(20, 120);
            btnFindMentors.Name = "btnFindMentors";
            btnFindMentors.Size = new Size(300, 40);
            btnFindMentors.TabIndex = 2;
            btnFindMentors.Text = "Find mentors";
            btnFindMentors.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(20, 380);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(300, 40);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnRequests
            // 
            btnRequests.Location = new Point(20, 170);
            btnRequests.Name = "btnRequests";
            btnRequests.Size = new Size(300, 40);
            btnRequests.TabIndex = 4;
            btnRequests.Text = "Incoming requests";
            btnRequests.UseVisualStyleBackColor = true;
            // 
            // btnSessions
            // 
            btnSessions.Location = new Point(20, 170);
            btnSessions.Name = "btnSessions";
            btnSessions.Size = new Size(300, 40);
            btnSessions.TabIndex = 5;
            btnSessions.Text = "Sessions";
            btnSessions.UseVisualStyleBackColor = true;
            // 
            // btnFeedback
            // 
            btnFeedback.Location = new Point(20, 220);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.Size = new Size(300, 40);
            btnFeedback.TabIndex = 6;
            btnFeedback.Text = "Feedback";
            btnFeedback.UseVisualStyleBackColor = true;
            // 
            // btnNotifications
            // 
            btnNotifications.Location = new Point(20, 270);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(300, 40);
            btnNotifications.TabIndex = 7;
            btnNotifications.Text = "Notifications";
            btnNotifications.UseVisualStyleBackColor = true;
            // 
            // btnManageUsers
            // 
            btnManageUsers.Location = new Point(20, 70);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(300, 40);
            btnManageUsers.TabIndex = 8;
            btnManageUsers.Text = "Manage users";
            btnManageUsers.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(20, 120);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(300, 40);
            btnReports.TabIndex = 9;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnMessages
            // 
            btnMessages.Location = new Point(20, 320);
            btnMessages.Name = "btnMessages";
            btnMessages.Size = new Size(300, 40);
            btnMessages.TabIndex = 10;
            btnMessages.Text = "Messages";
            btnMessages.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 461);
            Controls.Add(btnMessages);
            Controls.Add(btnReports);
            Controls.Add(btnManageUsers);
            Controls.Add(btnNotifications);
            Controls.Add(btnFeedback);
            Controls.Add(btnSessions);
            Controls.Add(btnRequests);
            Controls.Add(btnLogout);
            Controls.Add(btnFindMentors);
            Controls.Add(btnMyProfile);
            Controls.Add(lblWelcome);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Dashboard";
            Load += DashboardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnMyProfile;
        private Button btnFindMentors;
        private Button btnLogout;
        private Button btnRequests;
        private Button btnSessions;
        private Button btnFeedback;
        private Button btnNotifications;
        private Button btnManageUsers;
        private Button btnReports;
        private Button btnMessages;
    }
}