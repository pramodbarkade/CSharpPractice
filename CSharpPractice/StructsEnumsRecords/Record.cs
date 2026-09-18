using System;

namespace CSharpPractice.StructsEnumsRecords
{
    [PracticeProgram("Structs, Enums and Records", "Records")]
    public class Record
    {
        public static void Run()
        {
            Console.WriteLine("========== 1. NORMAL CLASS ==========");

            var class1 = new PersonClass("John", 30);
            var class2 = new PersonClass("John", 30);

            Console.WriteLine(class1);
            Console.WriteLine(class2);

            // Normal class uses reference equality by default
            Console.WriteLine($"class1 == class2 : {class1 == class2}"); // False
            Console.WriteLine($"Equals()         : {class1.Equals(class2)}"); // False

            // Same reference
            var class3 = class1;

            Console.WriteLine($"class1 == class3 : {class1 == class3}"); // True
            Console.WriteLine();


            Console.WriteLine("========== 2. RECORD ==========");

            var record1 = new PersonRecord("John", 30);
            var record2 = new PersonRecord("John", 30);

            // record is a REFERENCE TYPE
            // but has VALUE-BASED equality
            Console.WriteLine(record1);
            Console.WriteLine(record2);

            Console.WriteLine($"record1 == record2 : {record1 == record2}"); // True
            Console.WriteLine($"Equals()            : {record1.Equals(record2)}"); // True

            // But they are still two different objects
            Console.WriteLine(
                $"ReferenceEquals : {ReferenceEquals(record1, record2)}"
            ); // False

            Console.WriteLine();


            Console.WriteLine("========== 3. RECORD CLASS ==========");

            var recordClass1 = new PersonRecordClass("Alice", 25);
            var recordClass2 = new PersonRecordClass("Alice", 25);

            // record class is also a REFERENCE TYPE
            // "record" and "record class" mean the same thing
            Console.WriteLine(recordClass1);
            Console.WriteLine(recordClass2);

            Console.WriteLine(
                $"recordClass1 == recordClass2 : {recordClass1 == recordClass2}"
            ); // True

            Console.WriteLine(
                $"ReferenceEquals : {ReferenceEquals(recordClass1, recordClass2)}"
            ); // False

            Console.WriteLine();


            Console.WriteLine("========== 4. RECORD STRUCT ==========");

            var struct1 = new PersonRecordStruct("Bob", 40);
            var struct2 = new PersonRecordStruct("Bob", 40);

            // record struct is a VALUE TYPE
            // and also has VALUE-BASED equality
            Console.WriteLine(struct1);
            Console.WriteLine(struct2);

            Console.WriteLine($"struct1 == struct2 : {struct1 == struct2}"); // True

            Console.WriteLine();


            Console.WriteLine("========== 5. COPY BEHAVIOR ==========");

            var person1 = new PersonRecord("John", 30);

            // Because record is a reference type,
            // this copies the REFERENCE.
            var person2 = person1;

            Console.WriteLine(
                $"ReferenceEquals(person1, person2): {ReferenceEquals(person1, person2)}"
            ); // True


            var point1 = new PersonRecordStruct("David", 50);

            // Because record struct is a value type,
            // this copies the VALUE.
            var point2 = point1;

            Console.WriteLine($"point1 == point2 : {point1 == point2}"); // True

            Console.WriteLine();


            Console.WriteLine("========== 6. WITH EXPRESSION ==========");

            var original = new PersonRecord("John", 30);

            var updated = original with
            {
                Age = 31
            };

            Console.WriteLine($"Original : {original}");
            Console.WriteLine($"Updated  : {updated}");

            Console.WriteLine(
                $"ReferenceEquals : {ReferenceEquals(original, updated)}"
            ); // False

            Console.WriteLine();


            Console.WriteLine("========== 7. RECORD STRUCT MUTABILITY ==========");

            var employee = new MutableEmployee("Sam", 1000);

            Console.WriteLine($"Before : {employee}");

            employee.Salary = 2000;

            Console.WriteLine($"After  : {employee}");

            Console.WriteLine();


            Console.WriteLine("========== SUMMARY ==========");

            Console.WriteLine("class         -> Reference Type + Reference Equality");
            Console.WriteLine("record        -> Reference Type + Value Equality");
            Console.WriteLine("record class  -> Reference Type + Value Equality");
            Console.WriteLine("record struct -> Value Type     + Value Equality");
        }
    }


    // ------------------------------------------------
    // 1. NORMAL CLASS
    // ------------------------------------------------

    public class PersonClass
    {
        public string Name { get; init; }
        public int Age { get; init; }

        public PersonClass(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }


    // ------------------------------------------------
    // 2. RECORD
    //
    // "record" means "record class"
    // Reference type + value-based equality
    // ------------------------------------------------

    public record PersonRecord(string Name, int Age);


    // ------------------------------------------------
    // 3. RECORD CLASS
    //
    // Same category as "record"
    // Explicitly says this is a reference-type record
    // ------------------------------------------------

    public record class PersonRecordClass(string Name, int Age);


    // ------------------------------------------------
    // 4. RECORD STRUCT
    //
    // Value type + value-based equality
    // ------------------------------------------------

    public record struct PersonRecordStruct(string Name, int Age);


    // ------------------------------------------------
    // 5. MUTABLE RECORD STRUCT
    //
    // record does NOT automatically mean immutable
    // ------------------------------------------------

    public record struct MutableEmployee(string Name, decimal Salary);
}
