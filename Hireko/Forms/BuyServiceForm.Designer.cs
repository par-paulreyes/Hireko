namespace Hireko.Forms
{
    partial class BuyServiceForm
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
            flowLayoutPanelServices = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelServices
            // 
            flowLayoutPanelServices.Location = new Point(12, 12);
            flowLayoutPanelServices.Name = "flowLayoutPanelServices";
            flowLayoutPanelServices.Size = new Size(918, 530);
            flowLayoutPanelServices.TabIndex = 0;
            // 
            // BuyServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
            Controls.Add(flowLayoutPanelServices);
            Name = "BuyServiceForm";
            Text = "BuyServiceForm";
            Load += BuyServiceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelServices;
    }
}