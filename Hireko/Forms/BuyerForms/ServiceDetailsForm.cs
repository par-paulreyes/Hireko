
using System;
using Hireko.Database;
using Hireko.Model;
using System.Windows.Forms;
using System.Drawing;

namespace Hireko.Forms
{
    internal partial class ServiceDetailsForm : Form
    {
        private readonly ServiceDB serviceDB = new ServiceDB();
        private MainForm mainForm;
        public ServiceDetailsForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            LoadServiceDetails();
        }

        private void LoadServiceDetails()
        {
            if (CurrentService.ServiceId != 0)
            {
                // Use the ServiceDB instance to fetch details of the selected service
                Service service = serviceDB.GetServiceDetails(CurrentService.ServiceId);

                if (service != null)
                {
                    // Create labels dynamically and populate them with service details
                    CreateLabelAndAddControl(panel1, $"Service Name: {service.ServiceName}", new Font("Bahnschrift", 10, FontStyle.Bold));
                    CreateLabelAndAddControl(panel1, $"Freelancer Name: {service.FreelancerName}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Category: {service.Category}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Occupation: {service.Occupation}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Description: {service.ServiceDescription}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Experience Level: {service.ExperienceLevel}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Educational Background: {service.EducationalBackground}", new Font("Bahnschrift", 10));
                    CreateLabelAndAddControl(panel1, $"Price: {service.Price:C}", new Font("Bahnschrift", 10, FontStyle.Italic));

                    // Adjust the form size to fit the content
                    this.AutoSize = false;
                    this.AutoSizeMode = AutoSizeMode.GrowOnly; // or AutoSizeMode.GrowAndShrink

                    // Show PaymentForm in panel2
                    PaymentForm paymentForm = new PaymentForm(mainForm);
                    paymentForm.TopLevel = false;
                    paymentForm.Anchor = AnchorStyles.None; // Anchor in the center
                    panel2.Controls.Add(paymentForm);

                    // Calculate the location to center the PaymentForm within panel2
                    paymentForm.Location = new Point(
                        (panel2.Width - paymentForm.Width) / 2,
                        (panel2.Height - paymentForm.Height) / 2
                    );
                    paymentForm.Show();
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

        private void CreateLabelAndAddControl(Panel panel, string labelText, Font font)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Font = font; // Setting the font
            label.AutoSize = true;
            label.Location = new Point(10, panel.Controls.Count * 20);
            panel.Controls.Add(label);
        }

    }
}