namespace Buyer_Page___Hireko
{
    public partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();


            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize searchTextBox
            this.searchTextBox = new TextBox();
            this.searchTextBox.Location = new System.Drawing.Point(10, 10); // Set the location
            this.searchTextBox.Size = new System.Drawing.Size(200, 20); // Set the size
            this.searchTextBox.TextChanged += SearchTextBox_TextChanged; // Subscribe to TextChanged event
            this.Controls.Add(this.searchTextBox); // Add searchTextBox to form's controls
        }

    }
}
