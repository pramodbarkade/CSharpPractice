using System.Runtime.CompilerServices;

namespace CSharpPractice.MemoryManagement
{
    [PracticeProgram("Memory Management", "Reference types")]
    public class ReferenceTypes
    {
        public static void Run()
        {
            Person1 person1 = new Person1();
            person1.Name = "Test";

            Person1 person2 = person1;
            person2.Name = "Test2";
         
            Person1 person3 = new Person1();
            person3.Name = "Test";

            Console.WriteLine($"object.ReferenceEquals:{object.ReferenceEquals(person1, person2)}");

            Console.WriteLine($"person1.Name:{person1.Name}, person2.Name:{person1.Name}");

            Console.WriteLine($"person1 identity: {RuntimeHelpers.GetHashCode(person1)}");

            Console.WriteLine($"person2 identity: {RuntimeHelpers.GetHashCode(person2)}");

            Console.WriteLine($"person3 identity: {RuntimeHelpers.GetHashCode(person3)}");
        }
    }

    public class Person1
    {
        public string Name { get; set; }
    }
}
