using System;
using System.Windows.Forms;

namespace Buyer_Page___Hireko
{
    public partial class ServiceDetailsForm : Form
    {
        private Service service = null!;
        private Label nameLabel = null!;
        private Label informationLabel = null!;
        private Label categoryLabel = null!;
        private Label priceLabel = null!;
        private Button backButton = null!;
        private Button proceedToPaymentButton = null!;

        public ServiceDetailsForm(Service service)
        {
            InitializeComponent();

            // Store the service object passed to the constructor
            this.service = service;

            // Initialize form controls
            InitializeControls();

            // Display the details of the service
            DisplayServiceDetails();
        }

        private void InitializeControls()
        {
            // Initialize nameLabel
            nameLabel = new Label();
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 10);
            Controls.Add(nameLabel);

            // Initialize categoryLabel
            categoryLabel = new Label();
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(10, 30);
            Controls.Add(categoryLabel);

            // Initialize informationLabel
            informationLabel = new Label();
            informationLabel.AutoSize = true;
            informationLabel.Location = new System.Drawing.Point(10, 30); // Below the nameLabel
            Controls.Add(informationLabel);

            // Initialize priceLabel
            priceLabel = new Label();
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(10, 50);
            Controls.Add(priceLabel);

            backButton = new Button();
            backButton.Text = "Back";
            this.backButton.AutoSize = false; // Set AutoSize to false
            this.backButton.Size = new Size(100, 30);
            backButton.Location = new Point(10, 80); // Adjust the location as needed
            backButton.Click += BackButton_Click;
            Controls.Add(backButton);

            // Initialize proceedToPaymentButton
            proceedToPaymentButton = new Button();
            proceedToPaymentButton.Text = "Proceed to Payment";
            this.proceedToPaymentButton.AutoSize = false; // Set AutoSize to false
            this.proceedToPaymentButton.Size = new Size(150, 30);
            proceedToPaymentButton.Location = new Point(120, 80); // Adjust the location as needed
            proceedToPaymentButton.Click += ProceedToPaymentButton_Click;
            Controls.Add(proceedToPaymentButton);
        }
        private void DisplayServiceDetails()
        {
            nameLabel.Text = "Name: " + service.Name;
            informationLabel.Text = "Information: " + service.Information;
            categoryLabel.Text = "Category: " + service.Category;
            priceLabel.Text = "Price: $" + service.Price.ToString("0.00");
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Handle back button click event here
            // For example, close the current form
            this.Close();
        }
        // Inside the ServiceDetailsForm class
        private void ProceedToPaymentButton_Click(object sender, EventArgs e)
        {
            // Handle proceed to payment button click event here
            // Create and show the PaymentForm
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
        }


    }
}

