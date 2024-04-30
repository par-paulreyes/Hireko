namespace Hireko.Forms
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
            lbl = new Label();
            lblUsername = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            lblFirstNameLabel = new Label();
            lblLastNameLabel = new Label();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(31, 28);
            lbl.Name = "lbl";
            lbl.Size = new Size(425, 20);
            lbl.TabIndex = 0;
            lbl.Text = "Names and status, descriptions, etc of the user will appear here";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(402, 122);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(402, 79);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(76, 20);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "FirstName";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(580, 79);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(75, 20);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "LastName";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(410, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblFirstNameLabel
            // 
            lblFirstNameLabel.AutoSize = true;
            lblFirstNameLabel.Location = new Point(320, 79);
            lblFirstNameLabel.Name = "lblFirstNameLabel";
            lblFirstNameLabel.Size = new Size(76, 20);
            lblFirstNameLabel.TabIndex = 5;
            lblFirstNameLabel.Text = "FirstName";
            // 
            // lblLastNameLabel
            // 
            lblLastNameLabel.AutoSize = true;
            lblLastNameLabel.Location = new Point(498, 79);
            lblLastNameLabel.Name = "lblLastNameLabel";
            lblLastNameLabel.Size = new Size(75, 20);
            lblLastNameLabel.TabIndex = 6;
            lblLastNameLabel.Text = "LastName";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 403);
            Controls.Add(lblLastNameLabel);
            Controls.Add(lblFirstNameLabel);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblUsername);
            Controls.Add(lbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProfileForm";
            Text = "ProfileMainForm";
            Load += ProfileMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private Label lblUsername;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblFirstNameLabel;
        private Label lblLastNameLabel;
    }
}