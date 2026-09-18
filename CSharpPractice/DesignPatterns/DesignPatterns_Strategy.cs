using System;

namespace CSharpPractice.DesignPatterns
{
    [PracticeProgram("Design Patterns", "Strategy")]
    public class DesignPatterns_Strategy
    {
        public static void Run()
        {
            // ============================================
            // STRATEGY PATTERN
            // ============================================

            Console.WriteLine("=== Strategy Pattern ===");

            // Email strategy
            IPaymentStrategy emailPayment = new CreditCardPayment();

            PaymentService paymentService = new PaymentService(emailPayment);

            paymentService.Pay(1000);

            Console.WriteLine();

            // UPI strategy
            IPaymentStrategy upiPayment = new UpiPayment();

            paymentService =
                new PaymentService(upiPayment);

            paymentService.Pay(2000);
        }
    }


    // ============================================
    // STRATEGY
    // ============================================

    // Strategy
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }


    // Concrete Strategy
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card");
        }
    }


    // Concrete Strategy
    public class UpiPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }


    // Context
    public class PaymentService
    {
        private readonly IPaymentStrategy _paymentStrategy;

        public PaymentService(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Pay(decimal amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}