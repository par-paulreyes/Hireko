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
            bntCreateService = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lblOccupation = new Label();
            lblCategory = new Label();
            lblDescription = new Label();
            lblPrice = new Label();
            lblEducationalBackground = new Label();
            lblExperienceLevel = new Label();
            cboCategory = new ComboBox();
            cboOccupation = new ComboBox();
            cboExperienceLevel = new ComboBox();
            txtDescription = new TextBox();
            cboEducationalBackground = new ComboBox();
            txtPrice = new TextBox();
            SuspendLayout();
            // 
            // bntCreateService
            // 
            bntCreateService.Location = new Point(104, 392);
            bntCreateService.Name = "bntCreateService";
            bntCreateService.Size = new Size(94, 29);
            bntCreateService.TabIndex = 0;
            bntCreateService.Text = "Create";
            bntCreateService.UseVisualStyleBackColor = true;
            bntCreateService.Click += bntCreateService_Click;
            // 
            // lblOccupation
            // 
            lblOccupation.AutoSize = true;
            lblOccupation.Location = new Point(602, 120);
            lblOccupation.Name = "lblOccupation";
            lblOccupation.Size = new Size(85, 20);
            lblOccupation.TabIndex = 1;
            lblOccupation.Text = "Occupation";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(345, 120);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(69, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(585, 199);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(629, 297);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblEducationalBackground
            // 
            lblEducationalBackground.AutoSize = true;
            lblEducationalBackground.Location = new Point(132, 297);
            lblEducationalBackground.Name = "lblEducationalBackground";
            lblEducationalBackground.Size = new Size(170, 20);
            lblEducationalBackground.TabIndex = 5;
            lblEducationalBackground.Text = "Educational Background";
            // 
            // lblExperienceLevel
            // 
            lblExperienceLevel.AutoSize = true;
            lblExperienceLevel.Location = new Point(280, 182);
            lblExperienceLevel.Name = "lblExperienceLevel";
            lblExperienceLevel.Size = new Size(119, 20);
            lblExperienceLevel.TabIndex = 6;
            lblExperienceLevel.Text = "Experience Level";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(420, 120);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 7;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // cboOccupation
            // 
            cboOccupation.FormattingEnabled = true;
            cboOccupation.Location = new Point(710, 120);
            cboOccupation.Name = "cboOccupation";
            cboOccupation.Size = new Size(151, 28);
            cboOccupation.TabIndex = 8;
            // 
            // cboExperienceLevel
            // 
            cboExperienceLevel.FormattingEnabled = true;
            cboExperienceLevel.Location = new Point(405, 182);
            cboExperienceLevel.Name = "cboExperienceLevel";
            cboExperienceLevel.Size = new Size(151, 28);
            cboExperienceLevel.TabIndex = 9;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(676, 198);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(125, 27);
            txtDescription.TabIndex = 10;
            //txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // cboEducationalBackground
            // 
            cboEducationalBackground.FormattingEnabled = true;
            cboEducationalBackground.Location = new Point(381, 301);
            cboEducationalBackground.Name = "cboEducationalBackground";
            cboEducationalBackground.Size = new Size(151, 28);
            cboEducationalBackground.TabIndex = 11;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(705, 308);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 12;
            // 
            // CreateServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
            Controls.Add(txtPrice);
            Controls.Add(cboEducationalBackground);
            Controls.Add(txtDescription);
            Controls.Add(cboExperienceLevel);
            Controls.Add(cboOccupation);
            Controls.Add(cboCategory);
            Controls.Add(lblExperienceLevel);
            Controls.Add(lblEducationalBackground);
            Controls.Add(lblPrice);
            Controls.Add(lblDescription);
            Controls.Add(lblCategory);
            Controls.Add(lblOccupation);
            Controls.Add(bntCreateService);
            Name = "CreateServiceForm";
            Text = "CreateServiceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bntCreateService;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblOccupation;
        private Label lblCategory;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblEducationalBackground;
        private Label lblExperienceLevel;
        private ComboBox cboCategory;
        private ComboBox cboOccupation;
        private ComboBox cboExperienceLevel;
        private TextBox txtDescription;
        private ComboBox cboEducationalBackground;
        private TextBox txtPrice;
    }
}