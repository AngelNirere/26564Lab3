namespace Smart_match.Views
{
    partial class ProfileForm
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
            lblSkills = new Label();
            txtSkills = new TextBox();
            lblInterests = new Label();
            txtInterests = new TextBox();
            lblIndustry = new Label();
            txtIndustry = new TextBox();
            lblGoals = new Label();
            txtGoals = new TextBox();
            lblLevel = new Label();
            cboLevel = new ComboBox();
            lblAvailability = new Label();
            txtAvailability = new TextBox();
            lblMaxMentees = new Label();
            numMaxMentees = new NumericUpDown();
            btnSaveProfile = new Button();
            ((System.ComponentModel.ISupportInitialize)numMaxMentees).BeginInit();
            SuspendLayout();
            // 
            // lblSkills
            // 
            lblSkills.AutoSize = true;
            lblSkills.Location = new Point(20, 15);
            lblSkills.Name = "lblSkills";
            lblSkills.Size = new Size(33, 15);
            lblSkills.TabIndex = 0;
            lblSkills.Text = "Skills";
            // 
            // txtSkills
            // 
            txtSkills.Location = new Point(20, 38);
            txtSkills.MaximumSize = new Size(300, 60);
            txtSkills.Multiline = true;
            txtSkills.Name = "txtSkills";
            txtSkills.Size = new Size(300, 60);
            txtSkills.TabIndex = 1;
            // 
            // lblInterests
            // 
            lblInterests.AutoSize = true;
            lblInterests.Location = new Point(20, 108);
            lblInterests.Name = "lblInterests";
            lblInterests.Size = new Size(51, 15);
            lblInterests.TabIndex = 2;
            lblInterests.Text = "Interests";
            // 
            // txtInterests
            // 
            txtInterests.Location = new Point(20, 131);
            txtInterests.Multiline = true;
            txtInterests.Name = "txtInterests";
            txtInterests.Size = new Size(300, 60);
            txtInterests.TabIndex = 3;
            // 
            // lblIndustry
            // 
            lblIndustry.AutoSize = true;
            lblIndustry.Location = new Point(20, 201);
            lblIndustry.Name = "lblIndustry";
            lblIndustry.Size = new Size(50, 15);
            lblIndustry.TabIndex = 4;
            lblIndustry.Text = "Industry";
            // 
            // txtIndustry
            // 
            txtIndustry.Location = new Point(20, 224);
            txtIndustry.Name = "txtIndustry";
            txtIndustry.Size = new Size(300, 23);
            txtIndustry.TabIndex = 5;
            // 
            // lblGoals
            // 
            lblGoals.AutoSize = true;
            lblGoals.Location = new Point(20, 257);
            lblGoals.Name = "lblGoals";
            lblGoals.Size = new Size(36, 15);
            lblGoals.TabIndex = 6;
            lblGoals.Text = "Goals";
            // 
            // txtGoals
            // 
            txtGoals.Location = new Point(20, 280);
            txtGoals.Multiline = true;
            txtGoals.Name = "txtGoals";
            txtGoals.Size = new Size(300, 60);
            txtGoals.TabIndex = 7;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(20, 350);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(91, 15);
            lblLevel.TabIndex = 8;
            lblLevel.Text = "Experience level";
            // 
            // cboLevel
            // 
            cboLevel.AutoCompleteCustomSource.AddRange(new string[] { "Beginner", "Intermediate", "Advanced" });
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.FormattingEnabled = true;
            cboLevel.Items.AddRange(new object[] { "Beginner", "Intermediate", "Advanced" });
            cboLevel.Location = new Point(20, 373);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(300, 23);
            cboLevel.TabIndex = 9;
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Location = new Point(20, 406);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(65, 15);
            lblAvailability.TabIndex = 10;
            lblAvailability.Text = "Availability";
            // 
            // txtAvailability
            // 
            txtAvailability.Location = new Point(20, 429);
            txtAvailability.Name = "txtAvailability";
            txtAvailability.Size = new Size(300, 23);
            txtAvailability.TabIndex = 11;
            // 
            // lblMaxMentees
            // 
            lblMaxMentees.AutoSize = true;
            lblMaxMentees.Location = new Point(20, 467);
            lblMaxMentees.MinimumSize = new Size(1, 3);
            lblMaxMentees.Name = "lblMaxMentees";
            lblMaxMentees.Size = new Size(110, 15);
            lblMaxMentees.TabIndex = 12;
            lblMaxMentees.Text = "Maximum mentees";
            // 
            // numMaxMentees
            // 
            numMaxMentees.Location = new Point(20, 485);
            numMaxMentees.MinimumSize = new Size(1, 0);
            numMaxMentees.Name = "numMaxMentees";
            numMaxMentees.Size = new Size(147, 23);
            numMaxMentees.TabIndex = 13;
            numMaxMentees.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(20, 525);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(300, 40);
            btnSaveProfile.TabIndex = 14;
            btnSaveProfile.Text = "Save profile";
            btnSaveProfile.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 556);
            Controls.Add(btnSaveProfile);
            Controls.Add(numMaxMentees);
            Controls.Add(lblMaxMentees);
            Controls.Add(txtAvailability);
            Controls.Add(lblAvailability);
            Controls.Add(cboLevel);
            Controls.Add(lblLevel);
            Controls.Add(txtGoals);
            Controls.Add(lblGoals);
            Controls.Add(txtIndustry);
            Controls.Add(lblIndustry);
            Controls.Add(txtInterests);
            Controls.Add(lblInterests);
            Controls.Add(txtSkills);
            Controls.Add(lblSkills);
            Location = new Point(20, 485);
            MinimumSize = new Size(1, 3);
            Name = "ProfileForm";
            Text = "Smart Match -My Profile";
            Load += ProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)numMaxMentees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSkills;
        private TextBox txtSkills;
        private Label lblInterests;
        private TextBox txtInterests;
        private Label lblIndustry;
        private TextBox txtIndustry;
        private Label lblGoals;
        private TextBox txtGoals;
        private Label lblLevel;
        private ComboBox cboLevel;
        private Label lblAvailability;
        private TextBox txtAvailability;
        private Label lblMaxMentees;
        private NumericUpDown numMaxMentees;
        private Button btnSaveProfile;
    }
}