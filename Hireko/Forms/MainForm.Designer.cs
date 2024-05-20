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
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntHome
            // 
            this.bntHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.bntHome.FlatAppearance.BorderSize = 0;
            this.bntHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntHome.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHome.Location = new System.Drawing.Point(21, 13);
            this.bntHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(89, 38);
            this.bntHome.TabIndex = 0;
            this.bntHome.Text = "Home";
            this.bntHome.UseVisualStyleBackColor = false;
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // bntCreateService
            // 
            this.bntCreateService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.bntCreateService.FlatAppearance.BorderSize = 0;
            this.bntCreateService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntCreateService.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCreateService.Location = new System.Drawing.Point(119, 13);
            this.bntCreateService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntCreateService.Name = "bntCreateService";
            this.bntCreateService.Size = new System.Drawing.Size(188, 38);
            this.bntCreateService.TabIndex = 1;
            this.bntCreateService.Text = "Sell a Service";
            this.bntCreateService.UseVisualStyleBackColor = false;
            this.bntCreateService.Click += new System.EventHandler(this.bntCreateService_Click);
            // 
            // bntProfile
            // 
            this.bntProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.bntProfile.FlatAppearance.BorderSize = 0;
            this.bntProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntProfile.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntProfile.Location = new System.Drawing.Point(1711, 13);
            this.bntProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntProfile.Name = "bntProfile";
            this.bntProfile.Size = new System.Drawing.Size(89, 38);
            this.bntProfile.TabIndex = 2;
            this.bntProfile.Text = "Profile";
            this.bntProfile.UseVisualStyleBackColor = false;
            this.bntProfile.Click += new System.EventHandler(this.bntProfile_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(-10, 69);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1963, 984);
            this.panel.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1808, 13);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(89, 38);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(233)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(1946, 1106);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.bntProfile);
            this.Controls.Add(this.bntCreateService);
            this.Controls.Add(this.bntHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Button bntCreateService;
        private System.Windows.Forms.Button bntProfile;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnLogout;
    }
}