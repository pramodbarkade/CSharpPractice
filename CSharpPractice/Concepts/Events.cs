using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Concepts
{

    // =========================
    // 1. ORDER MODEL
    // =========================
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
    }


    // =========================
    // 2. CUSTOM EVENT ARGUMENTS
    // =========================
    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; }
        public OrderEventArgs(Order order)
        {
            Order = order;
        }
    }

    // =========================
    // 3. ORDER SERVICE
    // =========================
    public class OrderService
    {
        // Event containing Order data
        public event EventHandler<OrderEventArgs> OrderPlaced;
     
        public void PlaceOrder(Order order)
        {
            Console.WriteLine("Receiving order from mobile...");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.CustomerName}");
            Console.WriteLine($"Product: {order.ProductName}");
            Console.WriteLine($"Amount: ₹{order.Amount}");

            // Save order to database here...
            Console.WriteLine("Order saved.");

            // Raise event and share Order data
            OnOrderPlaced(order);
        }

        protected virtual void OnOrderPlaced(Order order)
        {
            OrderPlaced?.Invoke(this, new OrderEventArgs(order));
        }
    }

    // =========================
    // 4. EMAIL SERVICE
    // =========================
    public class EmailService
    {
        public void SendOrderEmail(object sender, OrderEventArgs e)
        {
            Order order = e.Order;

            Console.WriteLine();
            Console.WriteLine("EMAIL SERVICE");
            Console.WriteLine($"Email sent for Order #{order.OrderId}");
            Console.WriteLine($"Product: {order.ProductName}");
        }
    }

    // =========================
    // 5. SMS SERVICE
    // =========================
    public class SmsService
    {
        public void SendOrderSms(object sender, OrderEventArgs e)
        {
            Order order = e.Order;

            Console.WriteLine();
            Console.WriteLine("SMS SERVICE");
            Console.WriteLine($"SMS sent to {order.MobileNumber}");
            Console.WriteLine($"Order #{order.OrderId} confirmed.");
        }
    }

    // =========================
    // 6. INVENTORY SERVICE
    // =========================
    public class InventoryService
    {
        public void UpdateInventory(object sender, OrderEventArgs e)
        {
            Order order = e.Order;

            Console.WriteLine();
            Console.WriteLine("INVENTORY SERVICE");
            Console.WriteLine($"Reducing stock for {order.ProductName}");
        }
    }

    // =========================
    // 7. PROGRAM
    // =========================
    public class Events
    {
        public static void Start()
        {
            var orderService = new OrderService();
            var emailService = new EmailService();
            var smsService = new SmsService();
            var inventoryService = new InventoryService();

            // Subscribe
            orderService.OrderPlaced += emailService.SendOrderEmail;
            orderService.OrderPlaced += smsService.SendOrderSms;
            orderService.OrderPlaced += inventoryService.UpdateInventory;

            // Simulating data received from mobile
            Order mobileOrder = new Order
            {
                OrderId = 1001,
                CustomerName = "Rahul",
                MobileNumber = "9876543210",
                ProductName = "iPhone",
                Amount = 75000
            };

            // Mobile order reaches OrderService
            orderService.PlaceOrder(mobileOrder);
        }
    }
}