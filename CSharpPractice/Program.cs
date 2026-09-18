using CSharpPractice.AdvanceConcepts;
using CSharpPractice.Concepts;
using CSharpPractice.DesignPatterns;
using CSharpPractice.DSA;
using CSharpPractice.LINQ;
using CSharpPractice.Programs;
using CSharpPractice.SOLID;
using CSharpPractice.TPL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        //string str1 = "str1";
        //string str2 = "str2";
        ////Test(ref str1, out str2);
        //Console.WriteLine($"ref:{str1}, out:{str2}");


        //var numbers = new List<int> { 10, 20, 30, 40 };

        //var sum = numbers.Sum();       // 100
        //var count = numbers.Count();     // 4
        //var min = numbers.Min();       // 10
        //var max = numbers.Max();       // 40
        //var average = numbers.Average();   // 25


        //var numbers2 = new[] { 2, 3, 4, 5 };
        //var result = numbers2.Aggregate((a, b) => a * b);

        //var students = new[]
        //{
        //    new { Name = "John", Skills = new[] { "C#", "SQL" } },
        //    new { Name = "Sam",  Skills = new[] { "Angular", "React" } }
        //};

        //var select_skills = students.Select(x => x.Skills).ToList();
        //var selectMany_skills = students.SelectMany(x => x.Skills).ToList();

        //var a = select_skills;


        //Parallel.For(0, 20, i =>
        //{
        //    int threadId = Thread.CurrentThread.ManagedThreadId;

        //    Console.WriteLine(
        //        $"Iteration: {i}, Thread: {threadId}");

        //    Thread.Sleep(500);
        //});



        //List<Employee> list = new List<Employee>()
        //{
        //    new Employee() { Id = 1, Name = "Ram", Department = "IT" },
        //    new Employee() { Id = 2, Name = "Shyam", Department = "HR" },
        //    new Employee() { Id = 3, Name = "Amit", Department = "Finance" },
        //    new Employee() { Id = 4, Name = "Priya", Department = "IT" },
        //    new Employee() { Id = 5, Name = "Neha", Department = "HR" },
        //    new Employee() { Id = 6, Name = "Rahul", Department = "Sales" },
        //    new Employee() { Id = 7, Name = "Sneha", Department = "Finance" },
        //    new Employee() { Id = 8, Name = "Vijay", Department = "IT" },
        //    new Employee() { Id = 9, Name = "Pooja", Department = "Sales" },
        //    new Employee() { Id = 10, Name = "Arjun", Department = "HR" }
        //};

        //var result = list.GroupBy(a => a.Department).Select(a=> new { Dept = a.Key, Count = a.Count() }).ToList();

        //string[] words = { "eat", "ate", "tea", "joe" };
        //AnagramFinder.FindAnagramsGroups(words);

        ////CharacterFrequency characterFrequency = new CharacterFrequency();
        ////characterFrequency.CharacterFrequencyCount();

        ////ArrayReduction arrayReduction = new ArrayReduction();
        ////arrayReduction.ArrayReductionProgram();

        //BuildTwoBinaryRows.Demo();

        //Record.Run();

        //Show(null);

        //int x = 10;
        //Test(out x);


        //int a = 10, b = 20;
        //MyDelegate myDelegate = Add;
        //int c = myDelegate.Invoke(a, b);



        //Action<string, string> action = (name, message) => {
        //    Console.WriteLine($"{message} {name}");
        //};
        //action.Invoke("Aryan", "Welcome");



        //Func<int, int, int> func = (a, b) =>
        //{
        //    return a + b;            
        //};       
        //Console.WriteLine($"Addition 10 + 20 : { func.Invoke(10, 20) }");

        //Predicate<int> isPrime = (number) =>
        //{
        //    if (number < 2)
        //        return false;

        //    for (int i = 2; i * i <= number; i++)
        //    {
        //        if (number % i == 0)
        //            return false;
        //    }

        //    return true;
        //};

        //Console.WriteLine($"Is This Number Id Prime : { isPrime.Invoke(7)}");

        //SingletonDemo.Demo();

        //Events.Start();

        //Constructors.Start();


        //Find_duplicate_characters_in_a_string.Start("programming P P");

        //Find_the_first_character_that_appears_only_once_in_a_given_string.Start("swiss");

        //Find_the_Missing_Number_in_an_Array.Start([10, 15, 14, 11, 13]);

        //Find_Duplicate_Number_in_an_Array.Start([10, 15, 14, 11, 13, 15]);

        //Find_All_Duplicate_Number_in_an_Array.Start([10, 15, 14, 12, 11, 13, 19, 20, 15, 20, 18, 16, 17, 18, 19, 20]);

        //Find_All_Duplicate_Numbers_and_Their_Frequency_in_an_Array.Start([10, 15, 14, 12, 11, 13, 19, 20, 15, 20, 18, 16, 17, 18, 19, 20]);

        //First_Non_Repeating_Number_in_an_Array.Start([10, 15, 14, 12, 11, 13, 19, 20, 15, 20, 18, 16, 17, 18, 19, 20]);

        //Find_Two_Numbers_Whose_Sum_Equals_Target.Start([10, 6, 15, 3, 7, 20], 13);

        //Move_All_Zeros_To_End_Of_Array.Start([10,9,0,5,4,0,6,8,11,15,0,7]);

        //Second_Largest_Number_Without_Sorting.Start([10, 12, 61, 18, 23, 40, 51 ]);

        //LinqJoins2.Start();

        //AllPopularCSharpPrograms.Start();

        //SolidPrinciples_SRP.Run();

        //TaskCancellationToken.Run().GetAwaiter();

        //ReferenceTypes.Run();

        //Is_And_As.Run();

        //Ref_Out_In_Params.Run();

        //MemoryCleanup.Run();

        //TPL_Task.Run();

        //Yield.Run();

        //Reflection.Run();

        BubbleSort.Run();

        SelectionSort.Run();
    }



    //public int Add(int a, int b) { return a + b; }

    //public double Add(int a, int b) { return a + b; } // ❌

    //static void Show(string x) { }

    //static void Show(int[] x) { }

    //static void Test(int x)
    //{
    //    Console.WriteLine("normal");
    //}

    ////static void Test(ref int x)
    ////{
    ////    Console.WriteLine("ref");
    ////}

    //static void Test(out int x)
    //{
    //    x = 10;
    //} // ❌

    //class Employee
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Department { get; set; }
    //}

    //static bool Test(ref string str1, out string str2)
    //{
    //    str1 = "str1 change";

    //    str2 = "";

    //    return true;
    //}
}
