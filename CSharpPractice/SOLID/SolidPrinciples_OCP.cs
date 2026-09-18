using System;
using System.Collections.Generic;

namespace CSharpPractice.SOLID
{
    [PracticeProgram("SOLID", "Open/Closed")]
    public class SolidPrinciples_OCP
    {
        public static void Run()
        {
            Console.WriteLine("===== WITHOUT OCP =====");

            var regularCustomer = new Customer_Without_OCP()
            {
                Name = "Amol",
                CustomerType = "Regular"
            };

            var premiumCustomer = new Customer_Without_OCP()
            {
                Name = "Rahul",
                CustomerType = "Premium"
            };

            var regularDiscountCalculator = new DiscountCalculatorWithoutOCP();
            Console.WriteLine($"Regular Discount: " + $"{regularDiscountCalculator.Calculate(regularCustomer, 1000)}");
            Console.WriteLine($"Premium Discount: " + $"{regularDiscountCalculator.Calculate(premiumCustomer, 1000)}");


            Console.WriteLine();
            Console.WriteLine("===== WITH OCP =====");

            var regularCustomerOCP = new Customer
            {
                Name = "Amol"
            };

            var premiumCustomerOCP = new Customer
            {
                Name = "Rahul"
            };

            var discountCalculator = new DiscountCalculator();

            var regularDiscount = new RegularDiscount();
            Console.WriteLine($"Regular Discount: " + $"{discountCalculator.Calculate(regularCustomerOCP, 1000, regularDiscount)}");

            var premiumDiscount = new PremiumDiscount();
            Console.WriteLine($"Premium Discount: " + $"{discountCalculator.Calculate(premiumCustomerOCP, 1000, premiumDiscount)}");

            var vipDiscount = new VipDiscount();
            Console.WriteLine($"VIP Discount: " + $"{discountCalculator.Calculate(regularCustomerOCP, 1000, vipDiscount)}");
        }
    }


    // =========================================================
    // ❌ WITHOUT OCP
    // =========================================================

    public class Customer_Without_OCP
    {
        public string? Name { get; set; }

        public string CustomerType { get; set; }
    }


    public class DiscountCalculatorWithoutOCP
    {
        public decimal Calculate(Customer_Without_OCP customer, decimal amount)
        {
            if (customer.CustomerType == "Regular")
            {
                return amount * 0.05m;
            }
            else if (customer.CustomerType == "Premium")
            {
                return amount * 0.10m;
            }
            else if (customer.CustomerType == "VIP")
            {
                return amount * 0.20m;
            }

            return 0;
        }
    }


    // =========================================================
    // Problem:
    //
    // Every time we introduce a new customer type:
    //
    //     Gold
    //     Silver
    //     Employee
    //     Corporate
    //
    // We have to MODIFY DiscountCalculatorWithoutOCP.
    //
    // That violates OCP.
    // =========================================================



    // =========================================================
    // ✅ WITH OCP
    // =========================================================

    // Customer contains only customer information.
    public class Customer
    {
        public string Name { get; set; }
    }


    // =========================================================
    // Discount abstraction
    // =========================================================

    public interface IDiscount
    {
        decimal Calculate(decimal amount);
    }


    // =========================================================
    // Existing implementations
    // =========================================================

    public class RegularDiscount : IDiscount
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.05m;
        }
    }


    public class PremiumDiscount : IDiscount
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.10m;
        }
    }


    public class VipDiscount : IDiscount
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.20m;
        }
    }


    // =========================================================
    // Discount Calculator
    // =========================================================

    public class DiscountCalculator
    {
        public decimal Calculate(Customer customer, decimal amount, IDiscount discount)
        {
            return discount.Calculate(amount);
        }
    }
}