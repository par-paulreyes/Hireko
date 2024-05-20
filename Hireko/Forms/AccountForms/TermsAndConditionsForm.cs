using System.Windows.Forms;
﻿using System;
using System.IO;

namespace Hireko.Forms
{
    internal partial class TermsAndConditionsForm : Form
    {
        public TermsAndConditionsForm()
        {
            InitializeComponent();
            InitializeFormContents();
        }

        private void InitializeFormContents()
        {
            // Set the form size
            this.Size = new System.Drawing.Size(600, 400);

            // Create a RichTextBox to display the terms and conditions text
            RichTextBox rtbTerms = new RichTextBox();
            rtbTerms.Multiline = true;
            rtbTerms.ReadOnly = true;
            rtbTerms.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);

            // Read the terms and conditions text from a file
            //chane mo to 
            string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

            string filePath = Path.Combine(solutionDirectory, @"Forms\AccountForms\terms_and_conditions.txt");

            if (File.Exists(filePath))
            {
                string termsText = File.ReadAllText(filePath);
                rtbTerms.Text = termsText;
            }
            else
            {
                rtbTerms.Text = "Terms and conditions file not found.";
            }

            // Set RichTextBox properties
            rtbTerms.Dock = DockStyle.Fill;

            // Add the RichTextBox to the panel
            panelTerms.Controls.Add(rtbTerms);
        }
    }
}