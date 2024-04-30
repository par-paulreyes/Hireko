namespace Hireko.Forms
{
    partial class MainForm
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
            panel = new Panel();
            bntHome = new Button();
            bntCreateService = new Button();
            btnProfile = new Button();
            lblClose = new Label();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Location = new Point(36, 67);
            panel.Name = "panel";
            panel.Size = new Size(994, 537);
            panel.TabIndex = 0;
            panel.Paint += panel_Paint;
            // 
            // bntHome
            // 
            bntHome.Location = new Point(89, 23);
            bntHome.Name = "bntHome";
            bntHome.Size = new Size(94, 29);
            bntHome.TabIndex = 1;
            bntHome.Text = "Home";
            bntHome.UseVisualStyleBackColor = true;
            bntHome.Click += bntHome_Click;
            // 
            // bntCreateService
            // 
            bntCreateService.Location = new Point(283, 23);
            bntCreateService.Name = "bntCreateService";
            bntCreateService.Size = new Size(138, 29);
            bntCreateService.TabIndex = 2;
            bntCreateService.Text = "Sell a Service";
            bntCreateService.UseVisualStyleBackColor = true;
            bntCreateService.Click += bntCreateService_Click;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(905, 23);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(94, 29);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.BorderStyle = BorderStyle.FixedSingle;
            lblClose.Location = new Point(1049, 9);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(18, 22);
            lblClose.TabIndex = 4;
            lblClose.Text = "x";
            lblClose.Click += lblClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 629);
            Controls.Add(lblClose);
            Controls.Add(btnProfile);
            Controls.Add(bntCreateService);
            Controls.Add(bntHome);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel;
        private Button bntHome;
        private Button bntCreateService;
        private Button btnProfile;
        private Label lblClose;
    }
}