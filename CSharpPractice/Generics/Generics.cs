using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Generics
{
    [PracticeProgram("Generics", "Generic types and methods")]
    public class Generics
    {
        public static void Run()
        {
            // =====================================================
            // 1. GENERIC CLASS
            // =====================================================

            Repository<User> userRepository = new Repository<User>();

            userRepository.Add(new User
            {
                Id = 1,
                Name = "John"
            });

            userRepository.Add(new User
            {
                Id = 2,
                Name = "David"
            });

            User user = userRepository.Get(0);

            Console.WriteLine(user.Name);


            // =====================================================
            // 2. GENERIC METHOD
            // =====================================================

            Print(100);         // T = int
            Print("Hello");     // T = string
            Print(true);        // T = bool


            // =====================================================
            // 3. GENERIC METHOD WITH TWO TYPES
            // =====================================================

            PrintPair(10, "John");

            // T1 = int
            // T2 = string


            // =====================================================
            // 4. GENERIC CONSTRAINT: where T : class
            // =====================================================

            ClassRepository<User> classRepository =
                new ClassRepository<User>();

            // ClassRepository<int> ❌
            // int is a struct, not a class


            // =====================================================
            // 5. GENERIC CONSTRAINT: where T : struct
            // =====================================================

            StructProcessor<int> intProcessor =
                new StructProcessor<int>();

            // StructProcessor<User> ❌
            // User is a class


            // =====================================================
            // 6. GENERIC CONSTRAINT: where T : new()
            // =====================================================

            Factory<User> factory = new Factory<User>();

            User newUser = factory.Create();

            Console.WriteLine(newUser.Name);


            // =====================================================
            // 7. MULTIPLE GENERIC CONSTRAINTS
            // =====================================================

            EntityRepository<User> entityRepository =
                new EntityRepository<User>();

            User createdUser = entityRepository.Create();

            Console.WriteLine(createdUser.Id);
        }


        // =========================================================
        // GENERIC METHOD
        // =========================================================

        public static void Print<T>(T value)
        {
            Console.WriteLine(value);
        }


        // =========================================================
        // GENERIC METHOD WITH MULTIPLE TYPE PARAMETERS
        // =========================================================

        public static void PrintPair<T1, T2>(T1 first, T2 second)
        {
            Console.WriteLine($"First: {first}");
            Console.WriteLine($"Second: {second}");
        }
    }


    // =============================================================
    // GENERIC CLASS
    // =============================================================

    public class Repository<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T Get(int index)
        {
            return _items[index];
        }
    }


    // =============================================================
    // CONSTRAINT: T MUST BE A CLASS
    // =============================================================

    public class ClassRepository<T>
        where T : class
    {
        public void Save(T item)
        {
            Console.WriteLine("Saving class object");
        }
    }


    // =============================================================
    // CONSTRAINT: T MUST BE A STRUCT
    // =============================================================

    public class StructProcessor<T>
        where T : struct
    {
        public void Process(T value)
        {
            Console.WriteLine($"Processing struct: {value}");
        }
    }


    // =============================================================
    // CONSTRAINT: T MUST HAVE A PARAMETERLESS CONSTRUCTOR
    // =============================================================

    public class Factory<T>
        where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }


    // =============================================================
    // MULTIPLE CONSTRAINTS
    // T must:
    // 1. Be a class
    // 2. Have a parameterless constructor
    // =============================================================

    public class EntityRepository<T>
        where T : class, new()
    {
        public T Create()
        {
            return new T();
        }
    }


    // =============================================================
    // SAMPLE CLASS
    // =============================================================

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
    }
}