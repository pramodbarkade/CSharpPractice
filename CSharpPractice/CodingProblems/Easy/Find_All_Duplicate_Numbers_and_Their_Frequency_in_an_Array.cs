using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    public class Find_All_Duplicate_Numbers_and_Their_Frequency_in_an_Array
    {
        public static void Start(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                Console.WriteLine("Array is null or empty.");
                return;
            }

            Console.WriteLine($"Input Array: {string.Join(", ", nums)}");

            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                frequency.TryGetValue(num, out int count);
                frequency[num] = count + 1;
            }

            bool foundDuplicate = false;

            foreach (var item in frequency)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine($"Number: {item.Key}, Count: {item.Value}");

                    foundDuplicate = true;
                }
            }

            if (!foundDuplicate)
                Console.WriteLine("No duplicate numbers found.");
        }
    }
}
