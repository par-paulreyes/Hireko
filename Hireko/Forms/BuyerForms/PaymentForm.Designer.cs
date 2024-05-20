namespace Hireko.Forms
{
    partial class PaymentForm
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
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtCardholderName = new System.Windows.Forms.TextBox();
            this.btnValidateCard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCardType
            // 
            this.cmbCardType.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Items.AddRange(new object[] {
            "Visa Card",
            "Master Card",
            "American Express"});
            this.cmbCardType.Location = new System.Drawing.Point(71, 74);
            this.cmbCardType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(418, 44);
            this.cmbCardType.TabIndex = 0;
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.Location = new System.Drawing.Point(71, 138);
            this.txtCardID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(418, 44);
            this.txtCardID.TabIndex = 1;
            // 
            // txtCardholderName
            // 
            this.txtCardholderName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardholderName.Location = new System.Drawing.Point(71, 200);
            this.txtCardholderName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCardholderName.Name = "txtCardholderName";
            this.txtCardholderName.Size = new System.Drawing.Size(418, 44);
            this.txtCardholderName.TabIndex = 2;
            // 
            // btnValidateCard
            // 
            this.btnValidateCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.btnValidateCard.FlatAppearance.BorderSize = 0;
            this.btnValidateCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidateCard.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidateCard.ForeColor = System.Drawing.Color.Black;
            this.btnValidateCard.Location = new System.Drawing.Point(203, 279);
            this.btnValidateCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnValidateCard.Name = "btnValidateCard";
            this.btnValidateCard.Size = new System.Drawing.Size(134, 52);
            this.btnValidateCard.TabIndex = 3;
            this.btnValidateCard.Text = "Validate";
            this.btnValidateCard.UseVisualStyleBackColor = false;
            this.btnValidateCard.Enter += new System.EventHandler(this.btnValidateCard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(104)))), ((int)(((byte)(71)))));
            this.label1.Location = new System.Drawing.Point(67, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Card Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(202)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnValidateCard);
            this.panel1.Controls.Add(this.txtCardholderName);
            this.panel1.Controls.Add(this.txtCardID);
            this.panel1.Controls.Add(this.cmbCardType);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 389);
            this.panel1.TabIndex = 7;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(202)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(555, 389);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.TextBox txtCardholderName;
        private System.Windows.Forms.Button btnValidateCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}