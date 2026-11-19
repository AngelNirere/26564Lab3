namespace Smart_match.Views
{
    partial class RequestsForm
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
            dgvRequests = new DataGridView();
            btnAccept = new Button();
            btnReject = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(131, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Requests from mentees";
            lblTitle.UseMnemonic = false;
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(20, 50);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(700, 280);
            dgvRequests.TabIndex = 1;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(20, 350);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(150, 35);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(180, 350);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(150, 35);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            // 
            // RequestsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 411);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(dgvRequests);
            Controls.Add(lblTitle);
            Name = "RequestsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Incoming Requests";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvRequests;
        private Button btnAccept;
        private Button btnReject;
    }
}