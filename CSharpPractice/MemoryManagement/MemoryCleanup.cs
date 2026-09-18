
namespace CSharpPractice.MemoryManagement
{
    [PracticeProgram("Memory Management", "Garbage collection and IDisposable")]
    public class MemoryCleanup
    {
        public static void Run()
        {
            Console.WriteLine("=== 1. Object becomes unreachable ===");

            CreateObject();
            // The object created inside CreateObject() is now
            // eligible for GC if nothing else references it.


            Console.WriteLine("\n=== 2. Remove reference ===");

            Person2 person = new Person2("John");

            Console.WriteLine(person.Name);

            person = null;

            // The Person object is now eligible for GC
            // assuming there are no other references to it.


            Console.WriteLine("\n=== 3. IDisposable / Dispose ===");

            using (Resource resource = new Resource())
            {
                resource.Use();
            }

            // Dispose() was automatically called here.


            Console.WriteLine("\n=== 4. Explicit Dispose ===");

            Resource resource2 = new Resource();

            resource2.Use();
            resource2.Dispose();


            Console.WriteLine("\n=== 5. Finalizer ===");

            CreateFinalizableObject();

            // Object becomes unreachable after this method.
            // Its finalizer may run during a future GC.


            Console.WriteLine("\n=== 6. Force GC ===");

            GC.Collect();

            GC.WaitForPendingFinalizers();

            Console.WriteLine("GC completed");


            Console.WriteLine("\n=== 7. GC information ===");

            Console.WriteLine(
                $"Generation: {GC.GetGeneration(new Person2("Test"))}"
            );

            Console.WriteLine(
                $"Managed memory: {GC.GetTotalMemory(false)} bytes"
            );
        }


        // ----------------------------------------
        // 1. Object goes out of scope
        // ----------------------------------------

        static void CreateObject()
        {
            Person2 person = new Person2("John");

            Console.WriteLine(person.Name);

        } // person goes out of scope here


        // ----------------------------------------
        // 5. Object with finalizer
        // ----------------------------------------

        static void CreateFinalizableObject()
        {
            FinalizableResource resource =
                new FinalizableResource();

            Console.WriteLine("Finalizable object created");

        } // resource becomes unreachable
    }


    // ----------------------------------------
    // Normal managed object
    // ----------------------------------------

    public class Person2
    {
        public string Name { get; set; }

        public Person2(string name)
        {
            Name = name;
        }
    }


    // ----------------------------------------
    // IDisposable example
    // ----------------------------------------

    public class Resource : IDisposable
    {
        private bool disposed;

        public void Use()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(Resource));

            Console.WriteLine("Using resource...");
        }

        public void Dispose()
        {
            if (disposed)
                return;

            Console.WriteLine("Dispose() called");

            // Release unmanaged/external resources here.

            disposed = true;

            GC.SuppressFinalize(this);
        }
    }


    // ----------------------------------------
    // Finalizer example
    // ----------------------------------------

    public class FinalizableResource
    {
        ~FinalizableResource()
        {
            Console.WriteLine("Finalizer called");
        }
    }
}

