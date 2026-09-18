using System;

namespace CSharpPractice.OOP
{
    // ============================================================
    // INTERFACE
    // Abstract classes can implement interfaces.
    // ============================================================

    public interface IEntity
    {
        int Id { get; }
        void Display();
    }


    // ============================================================
    // ABSTRACT BASE CLASS
    // ============================================================

    public abstract class Animal : IEntity
    {
        // --------------------------------------------------------
        // 1. CONSTANT
        // --------------------------------------------------------

        public const int MaximumAge = 100;


        // --------------------------------------------------------
        // 2. STATIC FIELD
        // Shared between all Animal objects.
        // --------------------------------------------------------

        public static int TotalAnimals;


        // --------------------------------------------------------
        // 3. PRIVATE INSTANCE FIELD
        //
        // Abstract classes CAN contain instance state.
        // Interfaces cannot have instance fields.
        // --------------------------------------------------------

        private string _name;


        // --------------------------------------------------------
        // 4. PROTECTED FIELD
        //
        // Accessible from derived classes.
        // --------------------------------------------------------

        protected int Age;


        // --------------------------------------------------------
        // 5. STATIC CONSTRUCTOR
        //
        // Runs once before the type is first used.
        // --------------------------------------------------------

        static Animal()
        {
            Console.WriteLine("Animal static constructor");

            TotalAnimals = 0;
        }


        // --------------------------------------------------------
        // 6. INSTANCE CONSTRUCTOR
        //
        // Abstract classes CAN have constructors even though
        // they cannot be instantiated directly.
        // --------------------------------------------------------

        protected Animal(int id, string name, int age)
        {
            Console.WriteLine("Animal constructor");

            Id = id;
            _name = name;
            Age = age;

            TotalAnimals++;
        }


        // --------------------------------------------------------
        // 7. NORMAL PROPERTY
        // --------------------------------------------------------

        public string Name
        {
            get => _name;

            set
            {
                ValidateName(value);
                _name = value;
            }
        }


        // --------------------------------------------------------
        // 8. GET-ONLY PROPERTY
        // --------------------------------------------------------

        public int Id { get; }


        // --------------------------------------------------------
        // 9. INIT PROPERTY
        //
        // Modern C# feature.
        // --------------------------------------------------------

        public string? Color { get; init; }


        // --------------------------------------------------------
        // 10. REQUIRED PROPERTY
        //
        // Modern C# feature.
        //
        // Caller must initialize this property.
        // --------------------------------------------------------

        public required string Category { get; init; }


        // --------------------------------------------------------
        // 11. ABSTRACT PROPERTY
        //
        // No implementation here.
        //
        // Concrete derived class MUST implement it.
        // --------------------------------------------------------

        public abstract string Species { get; }


        // --------------------------------------------------------
        // 12. ABSTRACT METHOD
        //
        // Concrete derived class MUST override.
        // --------------------------------------------------------

        public abstract void MakeSound();


        // --------------------------------------------------------
        // 13. NORMAL / CONCRETE METHOD
        //
        // Derived class automatically inherits this.
        // --------------------------------------------------------

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }


        // --------------------------------------------------------
        // 14. VIRTUAL METHOD
        //
        // Has default implementation.
        //
        // Derived class MAY override.
        // --------------------------------------------------------

        public virtual void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }


        // --------------------------------------------------------
        // 15. PROTECTED METHOD
        //
        // Available inside derived classes.
        // --------------------------------------------------------

        protected void Breathe()
        {
            Console.WriteLine($"{Name} is breathing.");
        }


        // --------------------------------------------------------
        // 16. PRIVATE METHOD
        //
        // Only Animal itself can access this.
        // --------------------------------------------------------

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Name cannot be empty.",
                    nameof(name)
                );
            }
        }


        // --------------------------------------------------------
        // 17. STATIC METHOD
        // --------------------------------------------------------

        public static void ShowTotalAnimals()
        {
            Console.WriteLine(
                $"Total animals created: {TotalAnimals}"
            );
        }


        // --------------------------------------------------------
        // 18. EVENT
        // --------------------------------------------------------

        public event EventHandler? Changed;


        // --------------------------------------------------------
        // 19. PROTECTED EVENT RAISER
        //
        // Derived classes can raise the event through this method.
        // --------------------------------------------------------

        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }


        // --------------------------------------------------------
        // 20. INDEXER
        // --------------------------------------------------------

        public string this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Name,
                    1 => Species,
                    2 => Age.ToString(),
                    _ => "Unknown"
                };
            }
        }


        // --------------------------------------------------------
        // 21. INTERFACE IMPLEMENTATION
        // --------------------------------------------------------

        public virtual void Display()
        {
            Console.WriteLine(
                $"Id       : {Id}\n" +
                $"Name     : {Name}\n" +
                $"Age      : {Age}\n" +
                $"Species  : {Species}\n" +
                $"Category : {Category}\n" +
                $"Color    : {Color}"
            );
        }


        // --------------------------------------------------------
        // 22. NESTED CLASS
        // --------------------------------------------------------

        public class Helper
        {
            public void Execute()
            {
                Console.WriteLine(
                    "Animal.Helper.Execute()"
                );
            }
        }
    }


    // ============================================================
    // ABSTRACT DERIVED CLASS
    //
    // An abstract derived class does NOT have to implement
    // all inherited abstract members.
    // ============================================================

    public abstract class Mammal : Animal
    {
        protected Mammal(
            int id,
            string name,
            int age)
            : base(id, name, age)
        {
            Console.WriteLine("Mammal constructor");
        }


        // Implementing one inherited abstract member.
        public override string Species => "Mammal";


        // MakeSound() is intentionally NOT implemented.
        //
        // This is allowed because Mammal itself is abstract.

        public virtual void Walk()
        {
            Console.WriteLine($"{Name} is walking.");
        }
    }


    // ============================================================
    // CONCRETE DERIVED CLASS
    // ============================================================

    public class Dog : Mammal
    {        public Dog(            int id,            string name,            int age)            : base(id, name, age)
        {
            Console.WriteLine("Dog constructor");
        }


        // --------------------------------------------------------
        // MUST implement remaining abstract method.
        // --------------------------------------------------------

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: Woof!");
        }


        // --------------------------------------------------------
        // Override virtual method.
        // --------------------------------------------------------

        public override void Sleep()
        {
            Console.WriteLine(
                $"{Name} is sleeping in the dog bed."
            );
        }


        // --------------------------------------------------------
        // SEALED OVERRIDE
        //
        // Derived classes cannot override Walk() again.
        // --------------------------------------------------------

        public sealed override void Walk()
        {
            Console.WriteLine($"{Name} walks on four legs.");
        }


        public void Run()
        {
            // Protected base-class member
            Breathe();

            Console.WriteLine(
                $"{Name} is running at age {Age}."
            );

            // Raise inherited event
            OnChanged();
        }
    }


    // ============================================================
    // FURTHER DERIVED CLASS
    // ============================================================

    public class Puppy : Dog
    {
        public Puppy(int id, string name, int age) : base(id, name, age)
        {
            Console.WriteLine("Puppy constructor");
        }


        // ❌ NOT ALLOWED
        //
        // Dog sealed the Walk() override.
        //
        // public override void Walk()
        // {
        // }


        // MakeSound can still be overridden because Dog did
        // not seal it.

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: tiny woof!");
        }
    }


    // ============================================================
    // DEMO
    // ============================================================

    [PracticeProgram("OOP", "Abstract classes")]
    public static class AbstractClassDemo
    {
        public static void Run()
        {
            Console.WriteLine(
                "========== ABSTRACT CLASS DEMO =========="
            );


            // ----------------------------------------------------
            // 1. Cannot instantiate abstract class
            // ----------------------------------------------------

            // ❌
            // Animal animal = new Animal(...);

            // ❌
            // Mammal mammal = new Mammal(...);


            Console.WriteLine();
            Console.WriteLine(
                "========== CREATE DOG =========="
            );


            // ----------------------------------------------------
            // 2. Create concrete derived class
            // ----------------------------------------------------

            var dog = new Dog(
                id: 1,
                name: "Bruno",
                age: 5)
            {
                // required property
                Category = "Domestic",

                // init property
                Color = "Brown"
            };


            // Constructor order:
            //
            // Animal constructor
            // Mammal constructor
            // Dog constructor


            Console.WriteLine();
            Console.WriteLine(
                "========== PROPERTIES =========="
            );

            Console.WriteLine(dog.Id);
            Console.WriteLine(dog.Name);
            Console.WriteLine(dog.Species);
            Console.WriteLine(dog.Category);
            Console.WriteLine(dog.Color);


            Console.WriteLine();
            Console.WriteLine(
                "========== ABSTRACT METHOD =========="
            );

            dog.MakeSound();


            Console.WriteLine();
            Console.WriteLine(
                "========== NORMAL METHOD =========="
            );

            dog.Eat();


            Console.WriteLine();
            Console.WriteLine(
                "========== VIRTUAL METHOD =========="
            );

            dog.Sleep();


            Console.WriteLine();
            Console.WriteLine(
                "========== SEALED OVERRIDE =========="
            );

            dog.Walk();


            Console.WriteLine();
            Console.WriteLine(
                "========== EVENT =========="
            );

            dog.Changed += (sender, e) =>
            {
                Console.WriteLine(
                    "Animal Changed event received!"
                );
            };

            dog.Run();


            Console.WriteLine();
            Console.WriteLine(
                "========== INDEXER =========="
            );

            Console.WriteLine($"dog[0] = {dog[0]}");
            Console.WriteLine($"dog[1] = {dog[1]}");
            Console.WriteLine($"dog[2] = {dog[2]}");


            Console.WriteLine();
            Console.WriteLine(
                "========== STATIC =========="
            );

            Animal.ShowTotalAnimals();

            Console.WriteLine(
                $"Maximum Age: {Animal.MaximumAge}"
            );


            Console.WriteLine();
            Console.WriteLine(
                "========== NESTED CLASS =========="
            );

            var helper = new Animal.Helper();

            helper.Execute();


            Console.WriteLine();
            Console.WriteLine(
                "========== POLYMORPHISM =========="
            );


            // Base reference -> derived object
            Animal animal = dog;

            animal.MakeSound();
            // Dog.MakeSound()

            animal.Sleep();
            // Dog.Sleep()

            animal.Eat();
            // Animal.Eat()


            Console.WriteLine();
            Console.WriteLine(
                "========== INTERFACE =========="
            );

            IEntity entity = dog;

            entity.Display();


            Console.WriteLine();
            Console.WriteLine(
                "========== PUPPY =========="
            );

            Animal puppy = new Puppy(
                id: 2,
                name: "Max",
                age: 1)
            {
                Category = "Domestic",
                Color = "White"
            };

            puppy.MakeSound();


            Console.WriteLine();
            Console.WriteLine(
                "========== TOTAL OBJECTS =========="
            );

            Animal.ShowTotalAnimals();


            Console.WriteLine();
            Console.WriteLine(
                "========== SUMMARY =========="
            );

            Console.WriteLine(
                """
                Abstract class supports:

                ✓ Instance fields
                ✓ Static fields
                ✓ Constants

                ✓ Instance constructors
                ✓ Static constructors

                ✓ Normal properties
                ✓ init properties
                ✓ required properties
                ✓ Abstract properties

                ✓ Abstract methods
                ✓ Normal methods
                ✓ Virtual methods
                ✓ Override methods
                ✓ Sealed overrides

                ✓ Private methods
                ✓ Protected methods
                ✓ Public methods
                ✓ Static methods

                ✓ Events
                ✓ Indexers
                ✓ Nested types

                ✓ Interface implementation
                ✓ Inheritance
                ✓ Multilevel inheritance
                ✓ Runtime polymorphism

                Cannot:

                ✗ Instantiate abstract class directly
                ✗ Declare private abstract method
                ✗ Declare abstract constructor
                ✗ Use abstract static instance-style member
                ✗ Inherit from multiple classes
                """
            );
        }
    }
}