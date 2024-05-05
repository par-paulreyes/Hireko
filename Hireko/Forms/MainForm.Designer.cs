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
            this.bntHome = new System.Windows.Forms.Button();
            this.bntCreateService = new System.Windows.Forms.Button();
            this.bntProfile = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bntHome
            // 
            this.bntHome.Location = new System.Drawing.Point(30, 12);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(75, 23);
            this.bntHome.TabIndex = 0;
            this.bntHome.Text = "Home";
            this.bntHome.UseVisualStyleBackColor = true;
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // bntCreateService
            // 
            this.bntCreateService.Location = new System.Drawing.Point(289, 12);
            this.bntCreateService.Name = "bntCreateService";
            this.bntCreateService.Size = new System.Drawing.Size(133, 23);
            this.bntCreateService.TabIndex = 1;
            this.bntCreateService.Text = "Sell a Service";
            this.bntCreateService.UseVisualStyleBackColor = true;
            this.bntCreateService.Click += new System.EventHandler(this.bntCreateService_Click);
            // 
            // bntProfile
            // 
            this.bntProfile.Location = new System.Drawing.Point(636, 12);
            this.bntProfile.Name = "bntProfile";
            this.bntProfile.Size = new System.Drawing.Size(75, 23);
            this.bntProfile.TabIndex = 2;
            this.bntProfile.Text = "Profile";
            this.bntProfile.UseVisualStyleBackColor = true;
            this.bntProfile.Click += new System.EventHandler(this.bntProfile_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(3, 41);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(796, 409);
            this.panel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.bntProfile);
            this.Controls.Add(this.bntCreateService);
            this.Controls.Add(this.bntHome);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Button bntCreateService;
        private System.Windows.Forms.Button bntProfile;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
    }
}