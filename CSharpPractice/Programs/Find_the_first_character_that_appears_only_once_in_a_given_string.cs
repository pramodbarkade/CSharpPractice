using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Programs
{
    internal class Find_the_first_character_that_appears_only_once_in_a_given_string
    {
        public static void Start(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Null or empty string.");
                return;
            }

            var charCount = new Dictionary<char, int>();

            // First pass: count characters
            foreach (char c in str)
            {
                charCount.TryGetValue(c, out int count);
                charCount[c] = count + 1;
            }

            Console.WriteLine($"Input String: {str}");

            // Second pass: find first character with count 1
            foreach (char c in str)
            {
                if (charCount[c] == 1)
                {
                    Console.WriteLine($"find first character with count 1: {c}");
                    return;
                }
            }

            Console.WriteLine("No non-repeating character found.");
        }
    }
}