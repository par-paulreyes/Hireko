using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class AdminViewOrderForm : Form
    {
        private readonly OrderDB orderDB = new OrderDB();
        private readonly AdminDB adminDB = new AdminDB();

        public AdminViewOrderForm()
        {
            InitializeComponent();
            LoadOrders();
            this.AutoScroll = true;
        }

        private void LoadOrders()
        {
            panel1.Controls.Clear();

            var orders = orderDB.GetAllOrders();
            int panelWidth = 420;
            int panelHeight = 160;
            int columns = 3; // Number of columns
            int spacing = 10; // Spacing between panels
            int totalOrders = orders.Count;
            int rows = (int)Math.Ceiling(totalOrders / (double)columns);

            int yOffset = 20;
            int xOffset = 20;

            for (int i = 0; i < totalOrders; i++)
            {
                var order = orders[i];

                Panel orderPanel = CreateOrderPanel(order, xOffset, yOffset, panelWidth, panelHeight);
                panel1.Controls.Add(orderPanel);

                // Update xOffset and yOffset for the next panel
                if ((i + 1) % columns == 0)
                {
                    // Move to the next row
                    xOffset = 20;
                    yOffset += panelHeight + spacing;
                }
                else
                {
                    // Move to the next column in the same row
                    xOffset += panelWidth + spacing;
                }
            }
            // Set the panel1 height dynamically based on the number of rows
            panel1.Height = (rows * (panelHeight + spacing)) + 20; // 20 for the initial offset
        }

        private Panel CreateOrderPanel(Order order, int xOffset, int yOffset, int panelWidth, int panelHeight)
        {
            Panel orderPanel = new Panel
            {
                BackColor = Color.White,
                Size = new Size(panelWidth, panelHeight),
                Location = new Point(xOffset, yOffset)
            };

            CreateOrderLabels(order, orderPanel);
            CreateStatusComboBox(order, orderPanel);
            CreateDeleteButton(order, orderPanel);

            return orderPanel;
        }

        private void CreateOrderLabels(Order order, Panel parentPanel)
        {
            string[] labelsText = {
                $"Order ID: {order.OrderId}",
                $"Seller ID: {order.SellerUserId}",
                $"Buyer ID: {order.BuyerUserId}",
                $"Order Status: {order.OrderStatus}"
            };

            for (int i = 0; i < labelsText.Length; i++)
            {
                Label label = new Label
                {
                    Text = labelsText[i],
                    AutoSize = true,
                    Font = new Font("Bahnschrift", 10),
                    Location = new Point(10, 10 + i * 20)
                };
                parentPanel.Controls.Add(label);
            }
        }

        private void CreateStatusComboBox(Order order, Panel parentPanel)
        {
            ComboBox comboBox = new ComboBox
            {
                Font = new Font("Bahnschrift", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                AutoSize = true,
                Items = { "Pending", "Processing", "Declined", "Cancelled", "Request Cancel Order", "Done", "Request Payment", "Paid", "Removed" },
                SelectedItem = order.OrderStatus,
                Tag = order.OrderId,
                Location = new Point(200, 120)
            };
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            parentPanel.Controls.Add(comboBox);
        }

        private void CreateDeleteButton(Order order, Panel parentPanel)
        {
            Button button = new Button
            {
                AutoSize = true,
                Text = "Delete",
                Font = new Font("Bahnschrift", 10),
                Tag = order.OrderId,
                Location = new Point(330, 120)
            };
            button.Click += BtnDelete_Click;

            parentPanel.Controls.Add(button);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            int orderId = Convert.ToInt32(comboBox.Tag);
            string newStatus = comboBox.SelectedItem.ToString();
            ConfirmAndPerformAction($"Update to {newStatus}", () => adminDB.UpdateOrderStatus(orderId, newStatus));
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32((sender as Button).Tag);
            ConfirmAndPerformAction("Delete", () => adminDB.DeleteOrder(orderId));
        }

        private void ConfirmAndPerformAction(string actionName, Action action)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to {actionName} this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                action.Invoke();
                LoadOrders();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term from the text box
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform the search using the OrderDB
                var orders = orderDB.GetAllOrders();
                orders = orders.Where(order => order.OrderId.ToString().Contains(searchTerm)).ToList();

                // Clear existing panels and reload the filtered orders
                panel1.Controls.Clear();
                int yOffset = 20;
                int xOffset = 20;
                int panelWidth = 420;
                int panelHeight = 160;
                int columns = 3; // Number of columns
                int spacing = 10; // Spacing between panels
                int totalOrders = orders.Count;
                int rows = (int)Math.Ceiling(totalOrders / (double)columns);

                for (int i = 0; i < totalOrders; i++)
                {
                    var order = orders[i];

                    Panel orderPanel = CreateOrderPanel(order, xOffset, yOffset, panelWidth, panelHeight);
                    panel1.Controls.Add(orderPanel);

                    // Update xOffset and yOffset for the next panel
                    if ((i + 1) % columns == 0)
                    {
                        // Move to the next row
                        xOffset = 20;
                        yOffset += panelHeight + spacing;
                    }
                    else
                    {
                        // Move to the next column in the same row
                        xOffset += panelWidth + spacing;
                    }
                }
                // Set the panel1 height dynamically based on the number of rows
                panel1.Height = (rows * (panelHeight + spacing)) + 20; // 20 for the initial offset
            }
            else
            {
                // If the search term is empty, reload all orders
                LoadOrders();
            }
        }
    }
}
