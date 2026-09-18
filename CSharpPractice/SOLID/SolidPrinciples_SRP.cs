using System;

namespace CSharpPractice.SOLID
{
    public class SolidPrinciples_SRP
    {
        public static void Run()
        {
            Console.WriteLine("===== WITHOUT SRP =====");

            var employeeWithoutSRP = new EmployeeWithoutSRP
            {
                Name = "Amol",
                BasicSalary = 50000
            };

            decimal salary = employeeWithoutSRP.CalculateSalary();
            Console.WriteLine($"Salary: {salary}");

            employeeWithoutSRP.SaveToDatabase();
            employeeWithoutSRP.SendEmail();


            Console.WriteLine();
            Console.WriteLine("===== WITH SRP =====");

            var employee = new Employee
            {
                Name = "Amol",
                BasicSalary = 50000
            };

            // Responsibility 1: Business logic
            var salaryCalculator = new SalaryCalculator();
            decimal calculatedSalary = salaryCalculator.Calculate(employee);

            Console.WriteLine($"Salary: {calculatedSalary}");

            // Responsibility 2: Database persistence
            var employeeRepository = new EmployeeRepository();
            employeeRepository.Save(employee);

            // Responsibility 3: Email communication
            var emailService = new EmailService();
            emailService.SendSalaryEmail(employee, calculatedSalary);
        }
    }


    // =========================================================
    // ❌ WITHOUT SRP
    // =========================================================

    public class EmployeeWithoutSRP
    {
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }

        // Responsibility 1: Salary calculation
        public decimal CalculateSalary()
        {
            return BasicSalary;
        }

        // Responsibility 2: Database persistence
        public void SaveToDatabase()
        {
            Console.WriteLine($"Saving {Name} to database...");
        }

        // Responsibility 3: Email communication
        public void SendEmail()
        {
            Console.WriteLine($"Sending email to {Name}...");
        }
    }


    // =========================================================
    // ✅ WITH SRP
    // =========================================================

    // Responsibility: Represent Employee data
    public class Employee
    {
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }
    }


    // Responsibility: Calculate employee salary
    public class SalaryCalculator
    {
        public decimal Calculate(Employee employee)
        {
            // Business rules related to salary
            decimal tax = employee.BasicSalary * 0.10m;

            return employee.BasicSalary - tax;
        }
    }


    // Responsibility: Save employee data
    public class EmployeeRepository
    {
        public void Save(Employee employee)
        {
            Console.WriteLine(
                $"Saving employee '{employee.Name}' to database..."
            );
        }
    }


    // Responsibility: Send employee emails
    public class EmailService
    {
        public void SendSalaryEmail(
            Employee employee,
            decimal salary)
        {
            Console.WriteLine(
                $"Sending salary email to {employee.Name}. " +
                $"Salary: {salary}"
            );
        }
    }
}