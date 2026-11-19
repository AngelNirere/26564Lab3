namespace Smart_match.Views
{
    partial class UsersForm
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
            dgvUsers = new DataGridView();
            btnSuspend = new Button();
            btnActivate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(51, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "All users";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(20, 45);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(700, 290);
            dgvUsers.TabIndex = 1;
            // 
            // btnSuspend
            // 
            btnSuspend.Location = new Point(20, 355);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(150, 35);
            btnSuspend.TabIndex = 2;
            btnSuspend.Text = "Suspend\t";
            btnSuspend.UseVisualStyleBackColor = true;
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(180, 355);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(150, 35);
            btnActivate.TabIndex = 3;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = true;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 411);
            Controls.Add(btnActivate);
            Controls.Add(btnSuspend);
            Controls.Add(dgvUsers);
            Controls.Add(lblTitle);
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Manage Users";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvUsers;
        private Button btnSuspend;
        private Button btnActivate;
    }
}