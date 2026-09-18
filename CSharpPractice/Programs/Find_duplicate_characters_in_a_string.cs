using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Programs
{
    public class Find_duplicate_characters_in_a_string
    {
        public static void Start(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Null or empty string.");
                return;
            }

            var charCounts = new Dictionary<char, int>();

            foreach (char c in str)
            {
                charCounts.TryGetValue(c, out int count);
                charCounts[c] = count + 1;
            }

            Console.WriteLine($"Input String: {str}");
            Console.WriteLine("Duplicate Characters:");

            foreach (var item in charCounts)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine($"{item.Key}={item.Value}");
                }
            }
        }
    }
}
