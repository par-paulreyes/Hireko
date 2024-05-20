using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class AdminViewUsersForm : Form
    {
        private readonly AccountDB accountDB = new AccountDB();
        private readonly AdminDB adminDB = new AdminDB();

        public AdminViewUsersForm()
        {
            InitializeComponent();
            LoadUsers();
            this.AutoScroll = true;
        }

        private void LoadUsers()
        {
            panel1.Controls.Clear();
            var users = accountDB.GetAllUsers();
            int panelWidth = 420;
            int panelHeight = 160;
            int columns = 2; // Two panels per row
            int spacing = 10; // Spacing between panels
            int yOffset = 20;
            int xOffset = 20; // Initial X offset

            foreach (var user in users)
            {
                Panel userPanel = CreateUserPanel(user, panelWidth, panelHeight, xOffset, yOffset);
                panel1.Controls.Add(userPanel);

                // Update xOffset and yOffset for the next panel
                xOffset += panelWidth + spacing;
                if (xOffset + panelWidth > panel1.Width) // If the next panel will exceed the panel width
                {
                    xOffset = 20; // Reset X offset
                    yOffset += panelHeight + spacing; // Move to the next row
                }
            }

            // Adjust panel height based on the number of rows
            int numberOfRows = (int)Math.Ceiling((double)users.Count / columns);
            panel1.Height = numberOfRows * (panelHeight + spacing) + 20;
        }

        private Panel CreateUserPanel(User user, int panelWidth, int panelHeight, int xOffset, int yOffset)
        {
            Panel userPanel = new Panel
            {
                Size = new System.Drawing.Size(panelWidth, panelHeight),
                Location = new System.Drawing.Point(xOffset, yOffset),
                BackColor = Color.White // Setting the background color
            };

            CreateLabelsForUser(user, userPanel);
            CreateDeleteButtonForUser(user, userPanel, panelWidth, panelHeight);

            return userPanel;
        }

        private void CreateLabelsForUser(User user, Panel parentPanel)
        {
            string[] labelsText = {
                $"User ID: {user.UserId}",
                $"Username: {user.Username}",
                $"Name: {user.UserFName} {user.UserLName}",
                $"Email: {user.UserEmail}",
                $"User Type: {user.UserType}"
            };

            for (int i = 0; i < labelsText.Length; i++)
            {
                Label label = new Label
                {
                    Text = labelsText[i],
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, 10 + i * 20),
                    Font = new Font("Bahnschrift", 10) // Setting the font
                };
                parentPanel.Controls.Add(label);
            }
        }

        private void CreateDeleteButtonForUser(User user, Panel parentPanel, int panelWidth, int panelHeight)
        {
            Button deleteButton = new Button
            {
                Text = "Delete",
                Tag = user.UserId,
                Location = new System.Drawing.Point(panelWidth - 90, panelHeight - 40),
                Font = new Font("Bahnschrift", 10), // Setting the font
                BackColor = Color.White // Setting the background color
            };
            deleteButton.AutoSize = true;
            deleteButton.Click += BtnDelete_Click;

            parentPanel.Controls.Add(deleteButton);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32((sender as Button).Tag);
            ConfirmAndPerformAction("Delete", () => adminDB.DeleteUser(userId));
        }

        private void ConfirmAndPerformAction(string actionName, Action action)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to {actionName} this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                action.Invoke();
                LoadUsers();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var users = accountDB.GetAllUsers();

                users = users.Where(user =>
                    (user.UserId.ToString().Contains(searchTerm.ToLower()) ||
                    user.Username.ToLower().Contains(searchTerm.ToLower()))).ToList();

                panel1.Controls.Clear();
                int panelWidth = 380;
                int panelHeight = 130;
                int columns = 2; // Two panels per row
                int spacing = 10; // Spacing between panels
                int yOffset = 20;
                int xOffset = 20; // Initial X offset

                foreach (var user in users)
                {
                    Panel userPanel = CreateUserPanel(user, panelWidth, panelHeight, xOffset, yOffset);
                    panel1.Controls.Add(userPanel);

                    // Update xOffset and yOffset for the next panel
                    xOffset += panelWidth + spacing;
                    if (xOffset + panelWidth > panel1.Width) // If the next panel will exceed the panel width
                    {
                        xOffset = 20; // Reset X offset
                        yOffset += panelHeight + spacing; // Move to the next row
                    }
                }

                // Adjust panel height based on the number of rows
                int numberOfRows = (int)Math.Ceiling((double)users.Count / columns);
                panel1.Height = numberOfRows * (panelHeight + spacing) + 20;
            }
            else
            {
                panel1.Controls.Clear();
                LoadUsers();
            }
        }
    }
}
