namespace Hireko.Forms
{
    partial class CreateServiceForm
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
            this.txtService = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCreateService = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbOccupation = new System.Windows.Forms.ComboBox();
            this.cmbExperience = new System.Windows.Forms.ComboBox();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.txtFreelancerName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtService
            // 
            this.txtService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtService.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.Location = new System.Drawing.Point(17, 12);
            this.txtService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(962, 32);
            this.txtService.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(16, 12);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(458, 200);
            this.txtDescription.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(14, 12);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(458, 32);
            this.txtPrice.TabIndex = 6;
            // 
            // btnCreateService
            // 
            this.btnCreateService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.btnCreateService.FlatAppearance.BorderSize = 0;
            this.btnCreateService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateService.Location = new System.Drawing.Point(476, 731);
            this.btnCreateService.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCreateService.Name = "btnCreateService";
            this.btnCreateService.Size = new System.Drawing.Size(131, 45);
            this.btnCreateService.TabIndex = 14;
            this.btnCreateService.Text = "Create";
            this.btnCreateService.UseVisualStyleBackColor = false;
            this.btnCreateService.Click += new System.EventHandler(this.btnCreateService_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(14, 9);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(458, 39);
            this.cmbCategory.TabIndex = 15;
            // 
            // cmbOccupation
            // 
            this.cmbOccupation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOccupation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOccupation.FormattingEnabled = true;
            this.cmbOccupation.Location = new System.Drawing.Point(15, 8);
            this.cmbOccupation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbOccupation.Name = "cmbOccupation";
            this.cmbOccupation.Size = new System.Drawing.Size(458, 39);
            this.cmbOccupation.TabIndex = 16;
            // 
            // cmbExperience
            // 
            this.cmbExperience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExperience.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExperience.FormattingEnabled = true;
            this.cmbExperience.Location = new System.Drawing.Point(17, 8);
            this.cmbExperience.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbExperience.Name = "cmbExperience";
            this.cmbExperience.Size = new System.Drawing.Size(458, 39);
            this.cmbExperience.TabIndex = 17;
            // 
            // cmbEducation
            // 
            this.cmbEducation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEducation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Location = new System.Drawing.Point(17, 8);
            this.cmbEducation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(458, 39);
            this.cmbEducation.TabIndex = 18;
            // 
            // txtFreelancerName
            // 
            this.txtFreelancerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFreelancerName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreelancerName.Location = new System.Drawing.Point(15, 13);
            this.txtFreelancerName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtFreelancerName.Name = "txtFreelancerName";
            this.txtFreelancerName.Size = new System.Drawing.Size(964, 32);
            this.txtFreelancerName.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(202)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCreateService);
            this.panel1.Location = new System.Drawing.Point(521, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 823);
            this.panel1.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(202)))), ((int)(((byte)(82)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(116, 665);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(829, 32);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.txtDescription);
            this.panel9.Location = new System.Drawing.Point(27, 410);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(993, 224);
            this.panel9.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.txtPrice);
            this.panel8.Location = new System.Drawing.Point(27, 333);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(993, 56);
            this.panel8.TabIndex = 26;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.cmbExperience);
            this.panel7.Location = new System.Drawing.Point(531, 182);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(489, 56);
            this.panel7.TabIndex = 25;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cmbEducation);
            this.panel6.Location = new System.Drawing.Point(27, 182);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(489, 56);
            this.panel6.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.cmbOccupation);
            this.panel5.Location = new System.Drawing.Point(531, 257);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(489, 56);
            this.panel5.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtService);
            this.panel4.Location = new System.Drawing.Point(27, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(993, 56);
            this.panel4.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cmbCategory);
            this.panel3.Location = new System.Drawing.Point(27, 257);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(489, 56);
            this.panel3.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtFreelancerName);
            this.panel2.Location = new System.Drawing.Point(27, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 56);
            this.panel2.TabIndex = 21;
            // 
            // CreateServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(233)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(1924, 984);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "CreateServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateServiceForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnCreateService;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbOccupation;
        private System.Windows.Forms.ComboBox cmbExperience;
        private System.Windows.Forms.ComboBox cmbEducation;
        private System.Windows.Forms.TextBox txtFreelancerName;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox textBox1;
    }
}