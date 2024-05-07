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
            this.lblService = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblEducation = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnCreateService = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbOccupation = new System.Windows.Forms.ComboBox();
            this.cmbExperience = new System.Windows.Forms.ComboBox();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(106, 102);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(100, 22);
            this.txtService.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 167);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 22);
            this.txtDescription.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(410, 236);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 6;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(132, 65);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(53, 16);
            this.lblService.TabIndex = 7;
            this.lblService.Text = "Service";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(291, 65);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(437, 65);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(75, 16);
            this.lblOccupation.TabIndex = 9;
            this.lblOccupation.Text = "Occupation";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(25, 167);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(110, 208);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(75, 16);
            this.lblExperience.TabIndex = 11;
            this.lblExperience.Text = "Experience";
            // 
            // lblEducation
            // 
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(291, 208);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(67, 16);
            this.lblEducation.TabIndex = 12;
            this.lblEducation.Text = "Education";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(437, 208);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 16);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "Price";
            // 
            // btnCreateService
            // 
            this.btnCreateService.Location = new System.Drawing.Point(317, 339);
            this.btnCreateService.Name = "btnCreateService";
            this.btnCreateService.Size = new System.Drawing.Size(75, 23);
            this.btnCreateService.TabIndex = 14;
            this.btnCreateService.Text = "Create";
            this.btnCreateService.UseVisualStyleBackColor = true;
            this.btnCreateService.Click += new System.EventHandler(this.btnCreateService_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(288, 109);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 15;
            // 
            // cmbOccupation
            // 
            this.cmbOccupation.FormattingEnabled = true;
            this.cmbOccupation.Location = new System.Drawing.Point(440, 109);
            this.cmbOccupation.Name = "cmbOccupation";
            this.cmbOccupation.Size = new System.Drawing.Size(121, 24);
            this.cmbOccupation.TabIndex = 16;
            // 
            // cmbExperience
            // 
            this.cmbExperience.FormattingEnabled = true;
            this.cmbExperience.Location = new System.Drawing.Point(64, 236);
            this.cmbExperience.Name = "cmbExperience";
            this.cmbExperience.Size = new System.Drawing.Size(121, 24);
            this.cmbExperience.TabIndex = 17;
            // 
            // cmbEducation
            // 
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Location = new System.Drawing.Point(255, 236);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(121, 24);
            this.cmbEducation.TabIndex = 18;
            // 
            // CreateServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbEducation);
            this.Controls.Add(this.cmbExperience);
            this.Controls.Add(this.cmbOccupation);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnCreateService);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblEducation);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtService);
            this.Name = "CreateServiceForm";
            this.Text = "CreateServiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnCreateService;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbOccupation;
        private System.Windows.Forms.ComboBox cmbExperience;
        private System.Windows.Forms.ComboBox cmbEducation;
    }
}