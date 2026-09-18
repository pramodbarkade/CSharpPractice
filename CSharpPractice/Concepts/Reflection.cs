using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharpPractice.Concepts
{
    public class Reflection
    {
        public static void Run()
        {
            User1 user1 = new User1()
            {
                Id = 1,
                Name = "Ram",
                City = "Mumbai"
            };

            User2 user2 = new User2(2, "Vinay", "Kochi");

            // -----------------------------------------
            // 1. Get Type information
            // -----------------------------------------

            // typeof() works with a type
            Type type1 = typeof(User1);

            // GetType() works with an object
            Type type2 = user1.GetType();

            Console.WriteLine("Type Name:");
            Console.WriteLine(type1.Name);

            Console.WriteLine("\nFull Type Name:");
            Console.WriteLine(type1.FullName);


            // -----------------------------------------
            // 2. Get Properties
            // -----------------------------------------

            Console.WriteLine("\nUser1 Properties:");

            PropertyInfo[] properties = type1.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(
                    $"Name: {property.Name}, " +
                    $"Type: {property.PropertyType.Name}"
                );
            }


            // -----------------------------------------
            // 3. Read property values dynamically
            // -----------------------------------------

            Console.WriteLine("\nUser1 Property Values:");

            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(user1);

                Console.WriteLine($"{property.Name} = {value}");
            }


            // -----------------------------------------
            // 4. Get individual property
            // -----------------------------------------

            PropertyInfo? nameProperty = type1.GetProperty("Name");

            if (nameProperty != null)
            {
                Console.WriteLine("\nName Property:");
                Console.WriteLine($"Property Name: {nameProperty.Name}");
                Console.WriteLine($"Property Type: {nameProperty.PropertyType.Name}");
                Console.WriteLine($"Value: {nameProperty.GetValue(user1)}");
            }


            // -----------------------------------------
            // 5. Get Methods
            // -----------------------------------------

            Console.WriteLine("\nUser1 Methods:");

            MethodInfo[] methods = type1.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }


            // -----------------------------------------
            // 6. Reflection with User2 record
            // -----------------------------------------

            Type user2Type = user2.GetType();

            Console.WriteLine("\nUser2 Properties:");

            foreach (PropertyInfo property in user2Type.GetProperties())
            {
                Console.WriteLine(
                    $"{property.Name} = {property.GetValue(user2)}"
                );
            }


            // -----------------------------------------
            // 7. Create object using Reflection
            // -----------------------------------------

            Console.WriteLine("\nCreate User1 using Reflection:");

            Type userType = typeof(User1);

            object userObject = Activator.CreateInstance(userType)!;

            Console.WriteLine($"Created object type: {userObject.GetType().Name}");
        }
    }


    public class User1
    {
        public required int Id { get; init; }

        public string Name { get; set; } = string.Empty;

        public string? City { get; set; }
    }


    public record User2(int Id, string Name, string City);
}

