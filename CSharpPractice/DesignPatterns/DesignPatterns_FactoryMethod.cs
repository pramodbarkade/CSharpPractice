using System;

namespace CSharpPractice.DesignPatterns
{
    [PracticeProgram("Design Patterns", "Factory method")]
    public class DesignPatterns_FactoryMethod
    {
        public static void Run()
        {
            // ============================================
            // FACTORY METHOD
            // ============================================

            Console.WriteLine();
            Console.WriteLine("=== Factory Method ===");

            // Email notification
            NotificationService emailService = new EmailNotificationService();

            emailService.Send("Order confirmed");

            Console.WriteLine();

            // SMS notification
            NotificationService smsService = new SmsNotificationService();

            smsService.Send("Order confirmed");
        }
    }


    // ====================================================
    // FACTORY METHOD
    // ====================================================


    // Abstract Product
    public interface INotification
    {
        void Send(string message);
    }


    // Concrete Product - Email
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }


    // Concrete Product - SMS
    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }


    // Creator
    public abstract class NotificationService
    {
        // Factory Method
        protected abstract INotification CreateNotification();

        public void Send(string message)
        {
            INotification notification = CreateNotification();

            notification.Send(message);
        }
    }


    // Concrete Creator - Email
    public class EmailNotificationService : NotificationService
    {
        protected override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }


    // Concrete Creator - SMS
    public class SmsNotificationService : NotificationService
    {
        protected override INotification CreateNotification()
        {
            return new SmsNotification();
        }
    }
}