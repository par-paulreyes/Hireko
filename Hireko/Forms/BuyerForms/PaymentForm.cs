using System;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class PaymentForm : Form
    {
        private readonly ServiceDB serviceDB = new ServiceDB();
        private readonly OrderDB orderDB = new OrderDB();
        private MainForm mainForm;

        public PaymentForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;

            // Set initial pretext for the textboxes
            SetPretext(txtCardID, "Card ID");
            SetPretext(txtCardholderName, "Cardholder's Name");

            // Attach event handlers for textboxes
            txtCardID.GotFocus += TxtCardID_GotFocus;
            txtCardID.LostFocus += TxtCardID_LostFocus;

            txtCardholderName.GotFocus += TxtCardholderName_GotFocus;
            txtCardholderName.LostFocus += TxtCardholderName_LostFocus;
        }

        private void SetPretext(TextBox textBox, string pretext)
        {
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Text = pretext;
        }

        private void ClearPretext(TextBox textBox, string pretext)
        {
            if (textBox.Text == pretext)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void TxtCardID_GotFocus(object sender, EventArgs e)
        {
            ClearPretext(txtCardID, "Card ID");
        }

        private void TxtCardID_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardID.Text))
            {
                SetPretext(txtCardID, "Card ID");
            }
        }

        private void TxtCardholderName_GotFocus(object sender, EventArgs e)
        {
            ClearPretext(txtCardholderName, "Cardholder's Name");
        }

        private void TxtCardholderName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardholderName.Text))
            {
                SetPretext(txtCardholderName, "Cardholder's Name");
            }
        }

        // Other methods...

        // Validate card button click event handler
        private void btnValidateCard_Click(object sender, EventArgs e)
        {
            string cardType = cmbCardType.SelectedItem?.ToString();
            string CardID = txtCardID.Text;
            string CardName = txtCardholderName.Text;

            if (string.IsNullOrEmpty(cardType))
            {
                MessageBox.Show("Please select a card type.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int expectedLength = 0;
            string prefix = "";

            if (cardType == "Visa Card")
            {
                expectedLength = 16; // use 4111111111111111
                prefix = "4";
            }
            else if (cardType == "Master Card")
            {
                expectedLength = 16; // use 5555555555554444
                prefix = "5";
            }
            else if (cardType == "American Express")
            {
                expectedLength = 15; // use 340000000000009
                prefix = "34";
            }

            if (CardID.Length != expectedLength || !CardID.StartsWith(prefix))
            {
                MessageBox.Show($"Please enter a valid {cardType} card ID. ", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(CardName))
            {
                MessageBox.Show("Please enter the Card Holder's Name.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the card number using the Luhn algorithm
            if (CheckLuhn(CardID))
            {
                MessageBox.Show("Payment successful!", "Validation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CreateOrder();
            }
            else
            {
                MessageBox.Show("Invalid card number.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validates the card number using the Luhn algorithm
        private bool CheckLuhn(string CardID)
        {
            int nDigits = CardID.Length;
            int nSum = 0;
            bool isSecond = false;

            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = CardID[i] - '0';

                if (isSecond)
                    d *= 2;

                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }

            return (nSum % 10 == 0);
        }

        private void CreateOrder()
        {
            if (CurrentService.ServiceId != 0)
            {
                // Use the ServiceDB instance to fetch details of the selected service
                Service service = serviceDB.GetServiceDetails(CurrentService.ServiceId);

                if (service != null)
                {
                    CurrentService.SellerId = service.UserId;
                    CurrentService.ServiceId = service.ServiceId;
                    CurrentService.ServiceFee = serviceDB.GetServiceFee(service.ServiceId);
                    CurrentService.Price = service.Price;
                    int orderId = orderDB.CreateOrder();

                    if (orderId != -1)
                    {
                        MessageBox.Show("Order created successfully");
                        // Properly close and dispose of the PaymentForm
                        this.Close();
                        this.Dispose();
                        // Show the BuyServiceForm on the main form
                        mainForm.ShowBuyServiceForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create order. Please try again.");
                    }

                }
                else
                {
                    MessageBox.Show("Service details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close the form if service details are not found
                }
            }
            else
            {
                MessageBox.Show("No service selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Close the form if no service is selected
            }
        }

    }
}
