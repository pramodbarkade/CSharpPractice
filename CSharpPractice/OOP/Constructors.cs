
namespace CSharpPractice.OOP
{
    // ============================================================
    // 1. INTERFACE
    // ============================================================
    // Interfaces do not have normal instance constructors.
    // A class implementing an interface calls its own constructor.

    public interface IEmployee
    {
        void Work();
    }


    // ============================================================
    // 2. ABSTRACT CLASS
    // ============================================================
    // Abstract classes CAN have constructors.
    // When a derived object is created, the base constructor runs first.
    // ============================================================

    public abstract class Person
    {
        public string Name { get; set; }

        protected Person()
        {
            Console.WriteLine("Abstract Person default constructor called");
        }

        protected Person(string name)
        {
            Name = name;
            Console.WriteLine("Abstract Person Parameterized constructor called");
        }

        public abstract void Display();
    }


    // ============================================================
    // 3. NORMAL CLASS
    // Parameterless + Parameterized + Copy Constructor
    // ============================================================

    public class Employee : Person, IEmployee
    {
        public int Id { get; set; }


        // --------------------------------------------------------
        // Parameterless Constructor
        // --------------------------------------------------------

        public Employee() : base("Unknown")
        {
            Console.WriteLine("Employee parameterless constructor called");
        }


        // --------------------------------------------------------
        // Parameterized Constructor
        // --------------------------------------------------------

        public Employee(int id, string name) : base(name)
        {
            Id = id;

            Console.WriteLine("Employee parameterized constructor called");
        }


        // --------------------------------------------------------
        // Copy Constructor
        // --------------------------------------------------------

        public Employee(Employee other) : base(other.Name)
        {
            Id = other.Id;

            Console.WriteLine("Employee copy constructor called");
        }


        public override void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }


        public void Work()
        {
            Console.WriteLine($"{Name} is working");
        }
    }


    // ============================================================
    // 4. CONSTRUCTOR OVERLOADING + THIS() CHAINING
    // ============================================================

    public class Customer
    {
        public int Id;
        public string Name;


        public Customer() : this(0, "Unknown")
        {
            Console.WriteLine("Customer parameterless constructor");
        }


        public Customer(string name) : this(0, name)
        {
            Console.WriteLine("Customer one-parameter constructor");
        }


        public Customer(int id, string name)
        {
            Id = id;
            Name = name;

            Console.WriteLine("Customer two-parameter constructor");
        }
    }


    // ============================================================
    // 5. STATIC CONSTRUCTOR
    // ============================================================

    public class Company
    {
        public static string CompanyName;


        // Static constructor
        // No access modifier
        // No parameters
        // Automatically called once
        static Company()
        {
            CompanyName = "ABC Company";

            Console.WriteLine("Company STATIC constructor called");
        }


        // Instance constructor
        public Company()
        {
            Console.WriteLine("Company INSTANCE constructor called");
        }
    }


    // ============================================================
    // 6. PRIVATE CONSTRUCTOR
    // ============================================================

    public class Database
    {
        private Database()
        {
            Console.WriteLine("Database PRIVATE constructor called");
        }


        public static Database Create()
        {
            return new Database();
        }
    }


    // ============================================================
    // 7. STATIC CLASS
    // ============================================================
    // Static classes cannot be instantiated.
    // They cannot have instance constructors.
    // They can have a static constructor.
    // ============================================================

    public static class AppSettings
    {
        public static string AppName;


        static AppSettings()
        {            AppName = "Constructor Demo";

            Console.WriteLine("AppSettings STATIC constructor called");
        }


        public static void Display()
        {
            Console.WriteLine(AppName);
        }
    }


    // ============================================================
    // 8. INHERITANCE CONSTRUCTOR CALLING SEQUENCE
    // ============================================================

    public class GrandParent
    {
        public GrandParent()
        {
            Console.WriteLine("1. GrandParent constructor");
        }
    }


    public class Parent : GrandParent
    {
        public Parent()
        {
            Console.WriteLine("2. Parent constructor");
        }
    }


    public class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("3. Child constructor");
        }
    }


    // ============================================================
    // 9. BASE() CONSTRUCTOR
    // ============================================================

    public class Vehicle
    {
        public Vehicle(string type)
        {
            Console.WriteLine($"Vehicle constructor: {type}");
        }
    }


    public class Car : Vehicle
    {
        public Car() : base("Car")
        {
            Console.WriteLine("Car constructor");
        }
    }


    // ============================================================
    // 10. PRIMARY CONSTRUCTOR - C# 12+
    // ============================================================

    public class Student(int id, string name)
    {
        public void Display()
        {
            Console.WriteLine($"Student: {id} - {name}");
        }
    }


    // ============================================================
    // PROGRAM
    // ============================================================

    [PracticeProgram("OOP", "Constructors")]
    public class Constructors
    {
        public static void Start()
        {
            Console.WriteLine("\n===== 1. PARAMETERLESS CONSTRUCTOR =====");

            Employee e1 = new Employee();

            e1.Display();


            Console.WriteLine("\n===== 2. PARAMETERIZED CONSTRUCTOR =====");

            Employee e2 = new Employee(101, "John");

            e2.Display();


            Console.WriteLine("\n===== 3. COPY CONSTRUCTOR =====");

            Employee e3 = new Employee(e2);

            e3.Display();


            Console.WriteLine("\n===== 4. INTERFACE METHOD =====");

            IEmployee employee = new Employee(102, "David");

            employee.Work();


            Console.WriteLine("\n===== 5. CONSTRUCTOR OVERLOADING =====");

            Customer c1 = new Customer();

            Console.WriteLine();

            Customer c2 = new Customer("Alice");

            Console.WriteLine();

            Customer c3 = new Customer(10, "Bob");


            Console.WriteLine("\n===== 6. STATIC CONSTRUCTOR =====");

            Console.WriteLine(Company.CompanyName);

            Company company1 = new Company();
            Company company2 = new Company();


            Console.WriteLine("\n===== 7. PRIVATE CONSTRUCTOR =====");

            Database db = Database.Create();


            Console.WriteLine("\n===== 8. STATIC CLASS =====");

            AppSettings.Display();


            Console.WriteLine("\n===== 9. INHERITANCE CALLING SEQUENCE =====");

            Child child = new Child();


            Console.WriteLine("\n===== 10. BASE() CONSTRUCTOR =====");

            Car car = new Car();


            Console.WriteLine("\n===== 11. PRIMARY CONSTRUCTOR =====");

            Student student = new Student(1, "Sam");

            student.Display();
        }
    }
}
