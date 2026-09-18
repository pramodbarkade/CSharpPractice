using System;

namespace CSharpPractice.String
{
    public class StringSplit
    {
        public static void Run()
        {
            // ==================================================
            // 1. Split by Single Character
            // ==================================================
            string str1 = "Apple,Banana,Mango";

            string[] result1 = str1.Split(',');

            Console.WriteLine("1. Split by Single Character:");

            foreach (string item in result1)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 2. Split by Multiple Characters
            // ==================================================
            string str2 = "Apple,Banana;Mango Orange";

            string[] result2 = str2.Split(',', ';', ' ');

            Console.WriteLine("\n2. Split by Multiple Characters:");

            foreach (string item in result2)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 3. StringSplitOptions.None
            // Keeps Empty Entries
            // ==================================================
            string str3 = "Apple,,Banana,,Mango";

            string[] result3 = str3.Split(',', StringSplitOptions.None);

            Console.WriteLine("\n3. StringSplitOptions.None:");

            foreach (string item in result3)
            {
                Console.WriteLine($"[{item}]");
            }


            // ==================================================
            // 4. RemoveEmptyEntries
            // ==================================================
            string str4 = "Apple,,Banana,,Mango";

            string[] result4 = str4.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("\n4. RemoveEmptyEntries:");

            foreach (string item in result4)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 5. TrimEntries
            // Removes whitespace around each result
            // ==================================================
            string str5 = "Apple, Banana , Mango ";

            string[] result5 = str5.Split(
                ',',
                StringSplitOptions.TrimEntries
            );

            Console.WriteLine("\n5. TrimEntries:");

            foreach (string item in result5)
            {
                Console.WriteLine($"[{item}]");
            }


            // ==================================================
            // 6. Combine Options
            // RemoveEmptyEntries + TrimEntries
            // ==================================================
            string str6 = "Apple, , Banana,   , Mango";

            string[] result6 = str6.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries |
                StringSplitOptions.TrimEntries
            );

            Console.WriteLine("\n6. Combined Options:");

            foreach (string item in result6)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 7. Split with Count
            // Maximum number of returned elements
            // ==================================================
            string str7 = "One,Two,Three,Four";

            string[] result7 = str7.Split(
                ',',
                2
            );

            Console.WriteLine("\n7. Split with Count:");

            foreach (string item in result7)
            {
                Console.WriteLine(item);
            }

            // Output:
            // One
            // Two,Three,Four


            // ==================================================
            // 8. Separator + Count + Options
            // ==================================================
            string str8 = "One, , Two, Three";

            string[] result8 = str8.Split(
                ',',
                2,
                StringSplitOptions.RemoveEmptyEntries |
                StringSplitOptions.TrimEntries
            );

            Console.WriteLine("\n8. Separator + Count + Options:");

            foreach (string item in result8)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 9. Split by String Separator
            // ==================================================
            string str9 = "Apple--Banana--Mango";

            string[] result9 = str9.Split(
                "--",
                StringSplitOptions.None
            );

            Console.WriteLine("\n9. Split by String Separator:");

            foreach (string item in result9)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 10. String Separator + RemoveEmptyEntries
            // ==================================================
            string str10 = "Apple----Banana--Mango";

            string[] result10 = str10.Split(
                "--",
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine(
                "\n10. String Separator + RemoveEmptyEntries:"
            );

            foreach (string item in result10)
            {
                Console.WriteLine(item);
            }


            // ==================================================
            // 11. Split Words by Space
            // ==================================================
            string str11 = "Hello   World   CSharp";

            string[] result11 = str11.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("\n11. Split Words:");

            foreach (string word in result11)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Word Count = " + result11.Length);


            // ==================================================
            // 12. Split by Different Whitespace Characters
            // Space, Tab, New Line
            // ==================================================
            string str12 = "Hello World\tCSharp\nProgramming";

            string[] result12 = str12.Split(
                new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("\n12. Split by Whitespace:");

            foreach (string word in result12)
            {
                Console.WriteLine(word);
            }


            // ==================================================
            // 13. Split User Input
            // ==================================================
            Console.WriteLine("\n13. User Input:");

            Console.Write("Enter comma-separated values: ");

            string input = Console.ReadLine();

            string[] values = input.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries |
                StringSplitOptions.TrimEntries
            );

            Console.WriteLine("Values:");

            foreach (string value in values)
            {
                Console.WriteLine(value);
            }


            // ==================================================
            // 14. Count Words using Split
            // ==================================================
            Console.Write("\nEnter a sentence: ");

            string sentence = Console.ReadLine();

            string[] words = sentence.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("Words = " + words.Length);
        }
    }
}