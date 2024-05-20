using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    internal partial class CreateServiceForm : Form
    {
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private ServiceDB serviceDB;
        private const string PretextCategory = "Select a category...";
        private const string PretextOccupation = "Select an occupation...";
        private const string PretextExperience = "Select experience level...";
        private const string PretextEducation = "Select education level...";

        public CreateServiceForm()
        {
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.CreateControl();
            mediaPlayer.Visible = false; // Hide the control from the UI
            mediaPlayer.settings.autoStart = false; // Do not start automatically
            InitializeComponent();
            LoadComboBoxes();
            serviceDB = new ServiceDB();

            // Set pretext for textboxes
            SetPretext(txtFreelancerName, "Freelancer Name");
            SetPretext(txtService, "Service");
            SetPretext(txtDescription, "Enter description...");
            SetPretext(txtPrice, "Enter price...");

            // Attach event handlers for textboxes' GotFocus and LostFocus events
            txtFreelancerName.GotFocus += TextBox_GotFocus;
            txtFreelancerName.LostFocus += TextBox_LostFocus;
            txtService.GotFocus += TextBox_GotFocus;
            txtService.LostFocus += TextBox_LostFocus;
            txtDescription.GotFocus += TextBox_GotFocus;
            txtDescription.LostFocus += TextBox_LostFocus;
            txtPrice.GotFocus += TextBox_GotFocus;
            txtPrice.LostFocus += TextBox_LostFocus;

            // Attach event handler for ComboBoxes' SelectedIndexChanged event
            cmbCategory.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbOccupation.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbExperience.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbEducation.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            textBox1.Text = "";
        }

        private void PlayAudio(string filePath)
        {
            mediaPlayer.URL = filePath; // Set the file path
            mediaPlayer.Ctlcontrols.play(); // Start playback
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ClearPretext(textBox);
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string pretext = GetPretext(textBox);
            SetPretext(textBox, pretext);
        }

        private string GetPretext(TextBox textBox)
        {
            if (textBox == txtFreelancerName)
                return "Freelancer Name";
            if (textBox == txtService)
                return "Service";
            if (textBox == txtDescription)
                return "Enter description...";
            if (textBox == txtPrice)
                return "Enter price...";
            return string.Empty;
        }

        private void SetPretext(TextBox textBox, string pretext = "")
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = SystemColors.GrayText;
                textBox.Text = pretext;
            }
        }

        private void ClearPretext(TextBox textBox)
        {
            if (textBox.ForeColor == SystemColors.GrayText)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            string freelancer = txtFreelancerName.ForeColor == SystemColors.GrayText ? "" : txtFreelancerName.Text;
            string service = txtService.ForeColor == SystemColors.GrayText ? "" : txtService.Text;
            string category = cmbCategory.Text == PretextCategory ? "" : cmbCategory.Text;
            string occupation = cmbOccupation.Text == PretextOccupation ? "" : cmbOccupation.Text;
            string description = txtDescription.ForeColor == SystemColors.GrayText ? "" : txtDescription.Text;
            string experience = cmbExperience.Text == PretextExperience ? "" : cmbExperience.Text;
            string education = cmbEducation.Text == PretextEducation ? "" : cmbEducation.Text;
            decimal price;

            if (!ValidateComboBoxItem(cmbCategory, category) ||
                !ValidateComboBoxItem(cmbOccupation, occupation) ||
                !ValidateComboBoxItem(cmbExperience, experience) ||
                !ValidateComboBoxItem(cmbEducation, education))
            {
                textBox1.Text = "Please select a valid option from the dropdown list.";
                PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Error.mp3");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || txtPrice.ForeColor == SystemColors.GrayText)
            {
                textBox1.Text = "Invalid price format.";
                PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Error.mp3");
                return;
            }

            int ServiceId = serviceDB.CreateService(freelancer, service, category, occupation, description, experience, education, price);

            if (ServiceId != -1)
            {
                textBox1.Text = "Service created successfully!";
                PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\ServiceCreated.mp3");
                serviceDB.UpdateUserTypeToSeller();
                ClearForm();
   
            }
            else
            {
                textBox1.Text = "Failed to create service.\nPlease try again.";
                PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Error.mp3");
            }
        }

        private void LoadComboBoxes()
        {
            // Populate combo boxes with example data and pretext
            cmbCategory.Items.Add(PretextCategory);
            cmbCategory.Items.AddRange(new string[] { "Consultation", "Landscaping and Housework", "Waste Management" });
            cmbCategory.SelectedIndex = 0;

            cmbExperience.Items.Add(PretextExperience);
            cmbExperience.Items.AddRange(new string[] { "Entry Level", "Intermediate", "Advanced" });
            cmbExperience.SelectedIndex = 0;

            cmbEducation.Items.Add(PretextEducation);
            cmbEducation.Items.AddRange(new string[] { "High School", "Bachelor's Degree", "Master's Degree", "PhD" });
            cmbEducation.SelectedIndex = 0;

            cmbOccupation.Items.Add(PretextOccupation);
            cmbOccupation.SelectedIndex = 0;
        }

        private void ClearForm()
        {
            SetPretext(txtFreelancerName, "Freelancer Name");
            SetPretext(txtService, "Service");
            SetPretext(txtDescription, "Enter description...");
            SetPretext(txtPrice, "Enter price...");

            cmbCategory.SelectedIndex = 0;
            cmbOccupation.SelectedIndex = 0;
            cmbExperience.SelectedIndex = 0;
            cmbEducation.SelectedIndex = 0;
        }

        private bool ValidateComboBoxItem(ComboBox comboBox, string value)
        {
            return comboBox.Items.Contains(value) && value != PretextCategory && value != PretextOccupation && value != PretextExperience && value != PretextEducation;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox == cmbCategory)
            {
                // Clear existing items in cmbOccupation and add pretext
                cmbOccupation.Items.Clear();
                cmbOccupation.Items.Add(PretextOccupation);

                // Example logic: Populate cmbOccupation based on selectedCategory
                if (cmbCategory.SelectedItem != null && cmbCategory.SelectedItem.ToString() != PretextCategory)
                {
                    string selectedCategory = cmbCategory.SelectedItem.ToString();

                    switch (selectedCategory)
                    {
                        case "Consultation":
                            cmbOccupation.Items.AddRange(new string[] { "Research and Summaries", "Technical Writing", "Sustainability Consulting" });
                            break;
                        case "Landscaping and Housework":
                            cmbOccupation.Items.AddRange(new string[] { "Green Cleaning", "Ecological Landscaping", "Xeriscaping" });
                            break;
                        case "Waste Management":
                            cmbOccupation.Items.AddRange(new string[] { "Garbage Collection", "Recycling Pickup", "Dumpster Rental" });
                            break;
                    }
                }

                cmbOccupation.SelectedIndex = 0; // Set pretext by default
            }

            // Set the combobox to gray text color if it shows the pretext
            if (comboBox.SelectedItem != null &&
                (comboBox.SelectedItem.ToString() == PretextCategory ||
                comboBox.SelectedItem.ToString() == PretextOccupation ||
                comboBox.SelectedItem.ToString() == PretextExperience ||
                comboBox.SelectedItem.ToString() == PretextEducation))
            {
                comboBox.ForeColor = SystemColors.GrayText;
            }
            else
            {
                comboBox.ForeColor = SystemColors.ControlText;
            }
        }

     
    }
}
