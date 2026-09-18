using System;

namespace CSharpPractice.SOLID
{
    public class SolidPrinciples_DIP
    {
        public static void Run()
        {
            // =====================================================
            // ❌ WITHOUT DIP
            // =====================================================

            Console.WriteLine("===== WITHOUT DIP =====");

            var orderServiceWithoutDIP =
                new OrderServiceWithoutDIP();

            orderServiceWithoutDIP.PlaceOrder();


            // =====================================================
            // ✅ WITH DIP
            // =====================================================

            Console.WriteLine();
            Console.WriteLine("===== WITH DIP =====");

            INotificationService emailService =
                new EmailNotificationService();

            var orderService =
                new OrderService(emailService);

            orderService.PlaceOrder();


            Console.WriteLine();
            Console.WriteLine("===== WITH DIP - SMS =====");

            // We can change the notification mechanism
            // without modifying OrderService.

            INotificationService smsService =
                new SmsNotificationService();

            var orderServiceWithSms =
                new OrderService(smsService);

            orderServiceWithSms.PlaceOrder();
        }
    }


    // =========================================================
    // ❌ WITHOUT DIP
    // =========================================================

    // High-level class
    public class OrderServiceWithoutDIP
    {
        public void PlaceOrder()
        {
            Console.WriteLine("Order placed.");

            // ❌ Direct dependency on concrete class.
            var emailService =
                new EmailNotificationService_Without_DIP();

            emailService.Send(
                "Order confirmation sent."
            );
        }
    }


    // Low-level class
    public class EmailNotificationService_Without_DIP
    {
        public void Send(string message)
        {
            Console.WriteLine(
                $"Email: {message}"
            );
        }
    }


    // =========================================================
    // Problem:
    //
    // OrderServiceWithoutDIP
    //          ↓
    // EmailNotificationService
    //
    // OrderService is directly dependent on
    // a concrete EmailNotificationService.
    //
    // If tomorrow we want SMS:
    //
    // OrderServiceWithoutDIP must be modified.
    //
    // If tomorrow we want WhatsApp:
    //
    // OrderServiceWithoutDIP must be modified.
    //
    // ❌ Tight coupling
    // =========================================================



    // =========================================================
    // ✅ WITH DIP
    // =========================================================

    // Abstraction
    public interface INotificationService
    {
        void Send(string message);
    }


    // Low-level implementation 1
    public class EmailNotificationService
        : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine(
                $"Email: {message}"
            );
        }
    }


    // Low-level implementation 2
    public class SmsNotificationService
        : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine(
                $"SMS: {message}"
            );
        }
    }


    // High-level class
    public class OrderService
    {
        private readonly INotificationService _notificationService;


        // Dependency Injection
        public OrderService(
            INotificationService notificationService)
        {
            _notificationService =
                notificationService;
        }


        public void PlaceOrder()
        {
            Console.WriteLine("Order placed.");

            _notificationService.Send(
                "Order confirmation sent."
            );
        }
    }
}