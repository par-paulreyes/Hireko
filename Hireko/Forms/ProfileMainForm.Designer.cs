
namespace Hireko.Forms
{
    partial class ProfileMainForm
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
            panel1 = new Panel();
            btnEditProfile = new Button();
            pictureBox1 = new PictureBox();
            btnSellerService = new Button();
            btnBuyerOrder = new Button();
            label1 = new Label();
            btnSellerOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(162, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(761, 450);
            panel1.TabIndex = 5;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(20, 158);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(94, 29);
            btnEditProfile.TabIndex = 4;
            btnEditProfile.Text = "edit profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 120);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnSellerService
            // 
            btnSellerService.Location = new Point(20, 407);
            btnSellerService.Name = "btnSellerService";
            btnSellerService.Size = new Size(94, 29);
            btnSellerService.TabIndex = 6;
            btnSellerService.Text = "my services";
            btnSellerService.UseVisualStyleBackColor = true;
            btnSellerService.Click += btnSellerService_Click;
            // 
            // btnBuyerOrder
            // 
            btnBuyerOrder.Location = new Point(20, 279);
            btnBuyerOrder.Name = "btnBuyerOrder";
            btnBuyerOrder.Size = new Size(94, 29);
            btnBuyerOrder.TabIndex = 7;
            btnBuyerOrder.Text = "my orders";
            btnBuyerOrder.UseVisualStyleBackColor = true;
            btnBuyerOrder.Click += btnBuyerOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 347);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Seller Feature:";
            // 
            // btnSellerOrder
            // 
            btnSellerOrder.Location = new Point(20, 372);
            btnSellerOrder.Name = "btnSellerOrder";
            btnSellerOrder.Size = new Size(94, 29);
            btnSellerOrder.TabIndex = 8;
            btnSellerOrder.Text = "my orders";
            btnSellerOrder.UseVisualStyleBackColor = true;
            btnSellerOrder.Click += btnSellerOrder_Click;
            // 
            // ProfileMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
            Controls.Add(btnSellerOrder);
            Controls.Add(label1);
            Controls.Add(btnBuyerOrder);
            Controls.Add(btnSellerService);
            Controls.Add(panel1);
            Controls.Add(btnEditProfile);
            Controls.Add(pictureBox1);
            Name = "ProfileMainForm";
            Text = "ProfileForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnEditProfile;
        private PictureBox pictureBox1;
        private Button btnSellerService;
        private Button btnBuyerOrder;
        private Label label1;
        private Button btnSellerOrder;
    }
}
