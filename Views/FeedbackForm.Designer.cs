namespace Smart_match.Views
{
    partial class FeedbackForm
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
            dgvToRate = new DataGridView();
            lblRating = new Label();
            numRating = new NumericUpDown();
            lblComment = new Label();
            txtComment = new TextBox();
            btnSubmitFeedback = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvToRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Completed sessions you can rate";
            // 
            // dgvToRate
            // 
            dgvToRate.AllowUserToAddRows = false;
            dgvToRate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToRate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvToRate.Location = new Point(20, 45);
            dgvToRate.MultiSelect = false;
            dgvToRate.Name = "dgvToRate";
            dgvToRate.ReadOnly = true;
            dgvToRate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvToRate.Size = new Size(700, 180);
            dgvToRate.TabIndex = 1;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Location = new Point(20, 240);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(81, 15);
            lblRating.TabIndex = 2;
            lblRating.Text = "Rating (1 to 5)";
            // 
            // numRating
            // 
            numRating.Location = new Point(20, 263);
            numRating.MaximumSize = new Size(5, 0);
            numRating.MinimumSize = new Size(1, 0);
            numRating.Name = "numRating";
            numRating.Size = new Size(5, 23);
            numRating.TabIndex = 3;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(150, 240);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(61, 15);
            lblComment.TabIndex = 4;
            lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(150, 263);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(570, 80);
            txtComment.TabIndex = 5;
            // 
            // btnSubmitFeedback
            // 
            btnSubmitFeedback.Location = new Point(20, 360);
            btnSubmitFeedback.Name = "btnSubmitFeedback";
            btnSubmitFeedback.Size = new Size(200, 40);
            btnSubmitFeedback.TabIndex = 6;
            btnSubmitFeedback.Text = "Submit feedback";
            btnSubmitFeedback.UseVisualStyleBackColor = true;
            // 
            // FeedbackForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 431);
            Controls.Add(btnSubmitFeedback);
            Controls.Add(txtComment);
            Controls.Add(lblComment);
            Controls.Add(numRating);
            Controls.Add(lblRating);
            Controls.Add(dgvToRate);
            Controls.Add(lblTitle);
            Name = "FeedbackForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Match - Feedback";
            ((System.ComponentModel.ISupportInitialize)dgvToRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvToRate;
        private Label lblRating;
        private NumericUpDown numRating;
        private Label lblComment;
        private TextBox txtComment;
        private Button btnSubmitFeedback;
    }
}