using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class ViewBuyerOrdersForm : Form
    {
        public ViewBuyerOrdersForm()
        {
            InitializeComponent();
            LoadOrders();
            this.AutoScroll = true;
        }

        public void LoadOrders()
        {
            panel1.Controls.Clear();

            OrderDB orderDB = new OrderDB();
            ServiceDB serviceDB = new ServiceDB();

            int currentUserId = CurrentUser.UserId;
            var orders = orderDB.GetBuyerOrders(currentUserId);

            orders = orders.Where(order => order.OrderStatus != "Removed").ToList();

            int xOffset = 20;
            int yOffset = 20;
            int panelWidth = 380;
            int panelHeight = 130;
            int panelSpacing = 20; // Space between panels

            if (orders.Any()) // Check if there are any orders
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    var order = orders[i];

                    // Create a panel for each order
                    Panel orderPanel = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        Size = new Size(panelWidth, panelHeight), // Fixed size of the panel
                        Location = new Point(xOffset, yOffset)
                    };

                    string serviceName = serviceDB.GetServiceName(order.ServiceId);

                    Label lblOrderId = CreateLabel($"Order ID: {order.OrderId}", 20, 20);
                    Label lblServiceName = CreateLabel($"Service Name: {serviceName}", 20, 40);
                    Label lblOrderStatus = CreateLabel($"Order Status: {order.OrderStatus}", 20, 60);

                    orderPanel.Controls.AddRange(new Control[] { lblOrderId, lblServiceName, lblOrderStatus });

                    switch (order.OrderStatus)
                    {
                        case "Pending":
                            CreateButton(orderPanel, "Cancel", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Cancelled");
                                LoadOrders();
                            });
                            break;
                        case "Cancelled":
                            CreateButton(orderPanel, "Remove", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Removed");
                                LoadOrders();
                            });
                            break;
                        case "Processing":
                            CreateButton(orderPanel, "Cancel Order", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Request Cancel Order");
                                LoadOrders();
                            });
                            break;
                        case "Request Cancel Order":
                            CreateButton(orderPanel, "Cancel Request", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Processing");
                                LoadOrders();
                            });
                            break;
                        case "Request Cancel Service":
                            CreateButton(orderPanel, "Accept", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Cancelled");
                                LoadOrders();
                            });
                            CreateButton(orderPanel, "Decline", 320, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Processing");
                                LoadOrders();
                            });
                            break;
                        case "Declined":
                            CreateButton(orderPanel, "Request Service", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Pending");
                                LoadOrders();
                            });
                            CreateButton(orderPanel, "Remove", 320, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Removed");
                                LoadOrders();
                            });
                            break;
                        case "Done":
                            CreateButton(orderPanel, "Pay", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Paid");
                                LoadOrders();
                            });
                            break;
                        case "Request Payment":
                            CreateButton(orderPanel, "Pay", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Paid");
                                LoadOrders();
                            });
                            break;
                        case "Paid":
                            CreateButton(orderPanel, "Remove", 200, 60, (sender, e) =>
                            {
                                orderDB.UpdateOrderStatus(order.OrderId, "Removed");
                                LoadOrders();
                            });
                            break;
                    }

                    panel1.Controls.Add(orderPanel);

                    // Adjust the x and y offset for the next panel
                    if (i % 2 == 0)
                    {
                        xOffset += panelWidth + panelSpacing; // Move to the next column
                    }
                    else
                    {
                        xOffset = 20; // Reset to the first column
                        yOffset += panelHeight + panelSpacing; // Move to the next row
                    }
                }
            }
            else
            {
                // Display a message indicating no orders
                Label lblNoOrders = CreateLabel("No orders to display.", 20, yOffset);
                panel1.Controls.Add(lblNoOrders);
            }
        }

        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(x, y),
                Font = new Font("Bahnschrift", 10)
            };
            return label;
        }

        private Button CreateButton(Panel parentPanel, string text, int x, int y, EventHandler clickHandler)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font("Bahnschrift", 9),
                Size = new Size(70, 30),
                BackColor = Color.White,
                Location = new Point(parentPanel.Width - 100, parentPanel.Height - 40),
            };

            button.Width = TextRenderer.MeasureText(button.Text, button.Font).Width + 20;

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

