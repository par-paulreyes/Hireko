using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class ViewSellerOrdersForm : Form
    {
        public ViewSellerOrdersForm()
        {
            InitializeComponent();
            LoadOrders();
            panel3.AutoScroll = true; // Enable AutoScroll for panel3
        }

        public void LoadOrders()
        {
            panel3.Controls.Clear();

            OrderDB orderDB = new OrderDB();
            AccountDB accountDB = new AccountDB();

            int currentUserId = CurrentUser.UserId;
            var orders = orderDB.GetSellerOrders(currentUserId);

            orders = orders.Where(order =>
                    order.OrderStatus != "Removed").ToList();

            int yOffset = 20;
            int panelHeight = 120; // Initial height of each order panel

            foreach (var order in orders)
            {
                User userDetails = accountDB.GetUserDetails(order.BuyerUserId);

                Panel orderPanel = new Panel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Size = new Size(380, 130), // Fixed size of the panel
                    Location = new Point(20, yOffset)
                };
                orderPanel.BorderStyle = BorderStyle.FixedSingle;
                orderPanel.Size = new System.Drawing.Size(400, panelHeight); // Set the initial height of the order panel
                orderPanel.Location = new System.Drawing.Point(20, yOffset);
                orderPanel.Tag = order.OrderId; // Store OrderId in Tag for reference

                Label lblOrderId = CreateLabel($"Order ID: {order.OrderId}", 10, 10);
                Label lblBuyerUsername = CreateLabel($"Buyer Username: {userDetails.Username}", 10, 30);
                Label lblOrderStatus = CreateLabel($"Order Status: {order.OrderStatus}", 10, 50);

                orderPanel.Controls.AddRange(new Control[] { lblOrderId, lblBuyerUsername, lblOrderStatus });

                switch (order.OrderStatus)
                {
                    case "Pending":
                        CreateButton(orderPanel, "Accept", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Processing");
                            LoadOrders();
                        });
                        CreateButton(orderPanel, "Decline", 320, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Declined");
                            LoadOrders();
                        });
                        break;
                    case "Processing":
                        CreateButton(orderPanel, "Done", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Done");
                            LoadOrders();
                        });
                        CreateButton(orderPanel, "Cancel", 320, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Request Cancel Service");
                            LoadOrders();
                        });
                        break;
                    case "Request Cancel Order":
                        CreateButton(orderPanel, "Accept", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Processing");
                            LoadOrders();
                        });
                        CreateButton(orderPanel, "Decline", 320, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Declined");
                            LoadOrders();
                        });
                        break;
                    case "Request Cancel Service":
                        CreateButton(orderPanel, "Cancel Request", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Processing");
                            LoadOrders();
                        });
                        break;
                    case "Done":
                        CreateButton(orderPanel, "Request Payment", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Request Payment");
                            LoadOrders();
                        });
                        break;
                    case "Request Payment":
                        CreateButton(orderPanel, "Cancel Request", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Done");
                            LoadOrders();
                        });
                        break;
                    case "Paid":
                        CreateButton(orderPanel, "Remove", 200, 50, (sender, e) =>
                        {
                            orderDB.UpdateOrderStatus(order.OrderId, "Removed");
                            LoadOrders();
                        });
                        break;
                        // Add cases for other order statuses here
                }

                panel3.Controls.Add(orderPanel);
                yOffset += panelHeight + 20; // Increase yOffset by the panelHeight and some spacing
            }

            // Calculate the total height needed for panel3 based on the yOffset
            panel3.AutoScrollMinSize = new System.Drawing.Size(panel3.Width, yOffset + 20);
        }

        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Font = new Font("Bahnschrift", 10);
            label.Location = new System.Drawing.Point(x, y);
            return label;
        }

        private Button CreateButton(Panel parentPanel, string text, int x, int y, EventHandler clickHandler)
        {
            Button button = new Button()
            {
                Text = text,
                Font = new Font("Bahnschrift", 9),
                Size = new Size(85, 30),
                BackColor = Color.White,
                Location = new Point(parentPanel.Width - 100, parentPanel.Height - 40),
            };

            button.Click += (sender, e) =>
            {
                if (MessageBox.Show($"Are you sure you want to {text.ToLower()} this order?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clickHandler(sender, e);
                }
            };

            parentPanel.Controls.Add(button);
            return button;
        }

    }
}