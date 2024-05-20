namespace Hireko.Forms
{
    partial class TermsAndConditionsForm
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
            this.panelTerms = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelTerms
            // 
            this.panelTerms.BackColor = System.Drawing.Color.White;
            this.panelTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTerms.Location = new System.Drawing.Point(0, 0);
            this.panelTerms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTerms.Name = "panelTerms";
            this.panelTerms.Size = new System.Drawing.Size(695, 752);
            this.panelTerms.TabIndex = 0;
            // 
            // TermsAndConditionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(233)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(695, 752);
            this.Controls.Add(this.panelTerms);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TermsAndConditionsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terms and Conditions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTerms;
    }
}