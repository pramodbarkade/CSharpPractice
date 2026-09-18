using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Concepts
{
    public interface IModernInterface
    {
        // 1. Traditional abstract instance method
        // Implementing class MUST implement this.
        void Save();


        // 2. Default interface implementation - C# 8+
        // Implementing class does NOT have to implement this.
        void Log()
        {
            Console.WriteLine("Default Log");

            // Private interface method can be called from
            // another method inside the interface.
            WriteInternal();
        }


        // 3. Property
        // Implementing class MUST implement this.
        string Name { get; set; }


        // 4. Read-only property
        // Implementing class MUST provide get.
        int Id { get; }


        // 5. Indexer
        // Implementing class MUST implement this.
        string this[int index] { get; }


        // 6. Event
        // Implementing class MUST implement this.
        event EventHandler? Changed;


        // 7. Constant
        // Belongs to the interface type.
        const int MaxCount = 100;


        // 8. Static field
        static int Count = 0;


        // 9. Static property
        static string ApplicationName { get; set; } = "Demo";


        // 10. Static method
        static void Print()
        {
            Console.WriteLine("Static Print");

            // Private static interface method can be
            // accessed from inside the interface.
            StaticHelper();
        }


        // 11. Private instance method - C# 8+
        private void WriteInternal()
        {
            Console.WriteLine("Private interface helper");
        }


        // 12. Private static method
        private static void StaticHelper()
        {
            Console.WriteLine("Private static interface helper");
        }


        // 13. Static abstract member - C# 11+
        // Implementing class MUST provide this.
        static abstract IModernInterface Create();


        // 14. Static virtual member - C# 11+
        // Has a default implementation.
        static virtual string Description()
        {
            return "Default description";
        }


        // 15. Nested type
        public class Helper
        {
            public void Execute()
            {
                Console.WriteLine("Nested Helper Execute");
            }
        }
    }


    public class ModernInterface : IModernInterface
    {
        // ------------------------------------------------
        // Implement abstract interface method
        // ------------------------------------------------
        public void Save()
        {
            Console.WriteLine("Saving...");
        }


        // ------------------------------------------------
        // Implement property
        // ------------------------------------------------
        public string Name { get; set; } = "John";


        // ------------------------------------------------
        // Implement read-only property
        // ------------------------------------------------
        public int Id { get; } = 101;


        // ------------------------------------------------
        // Implement indexer
        // ------------------------------------------------
        public string this[int index]
        {
            get
            {
                return $"Value at index {index}";
            }
        }


        // ------------------------------------------------
        // Implement event
        // ------------------------------------------------
        public event EventHandler? Changed;


        // Helper method to raise event
        public void Update()
        {
            Console.WriteLine("Updating...");

            Changed?.Invoke(this, EventArgs.Empty);
        }


        // ------------------------------------------------
        // Implement static abstract member
        // ------------------------------------------------
        public static IModernInterface Create()
        {
            return new ModernInterface();
        }


        // ------------------------------------------------
        // OPTIONAL:
        // Override static virtual interface member
        // ------------------------------------------------
        public static string Description()
        {
            return "ModernInterface implementation";
        }


        public void Check()
        {
            Console.WriteLine("Check method");
        }
    }


    public class ModernInterfaceDemo
    {
        public static void Run()
        {
            Console.WriteLine("========== INSTANCE MEMBERS ==========");

            var obj = new ModernInterface();

            obj.Save();

            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Id);

            Console.WriteLine(obj[5]);

            obj.Check();


            Console.WriteLine();
            Console.WriteLine("========== DEFAULT INTERFACE METHOD ==========");

            // IMPORTANT:
            //
            // Log() has a default implementation in the interface,
            // but it does NOT become a normal member of ModernInterface.

            // obj.Log(); // ❌ Compile-time error

            IModernInterface service = obj;

            service.Log(); // ✅ Default Log
                           //    Private interface helper


            Console.WriteLine();
            Console.WriteLine("========== EVENT ==========");

            obj.Changed += (sender, e) =>
            {
                Console.WriteLine("Changed event received!");
            };

            obj.Update();


            Console.WriteLine();
            Console.WriteLine("========== CONSTANT ==========");

            Console.WriteLine(IModernInterface.MaxCount);


            Console.WriteLine();
            Console.WriteLine("========== STATIC FIELD ==========");

            Console.WriteLine(IModernInterface.Count);

            IModernInterface.Count++;

            Console.WriteLine(IModernInterface.Count);


            Console.WriteLine();
            Console.WriteLine("========== STATIC PROPERTY ==========");

            Console.WriteLine(IModernInterface.ApplicationName);

            IModernInterface.ApplicationName = "My Application";

            Console.WriteLine(IModernInterface.ApplicationName);


            Console.WriteLine();
            Console.WriteLine("========== STATIC METHOD ==========");

            IModernInterface.Print();


            Console.WriteLine();
            Console.WriteLine("========== STATIC ABSTRACT ==========");

            // Static abstract member is implemented by the class.

            IModernInterface created = ModernInterface.Create();

            created.Save();


            Console.WriteLine();
            Console.WriteLine("========== STATIC VIRTUAL ==========");

            Console.WriteLine(ModernInterface.Description());


            Console.WriteLine();
            Console.WriteLine("========== NESTED TYPE ==========");

            var helper = new IModernInterface.Helper();

            helper.Execute();


            Console.WriteLine();
            Console.WriteLine("========== PRIVATE MEMBERS ==========");

            // ❌ NOT accessible from outside interface

            // service.WriteInternal();
            // IModernInterface.StaticHelper();

            // They can only be used by code inside IModernInterface.
        }
    }
}
