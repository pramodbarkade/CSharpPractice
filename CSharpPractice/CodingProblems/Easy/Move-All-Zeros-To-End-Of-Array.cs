using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    public class Move_All_Zeros_To_End_Of_Array
    {
        public static void Start(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                Console.WriteLine("Array is null or empty.");
                return;
            }

            Console.WriteLine($"Input Array : {string.Join(", ", nums)}");

            int index = 0;

            // Move all non-zero numbers to the front
            foreach (int num in nums)
            {
                if (num != 0)
                {
                    nums[index] = num;
                    index++;
                }
            }

            // Fill remaining positions with zeros
            while (index < nums.Length)
            {
                nums[index] = 0;
                index++;
            }

            Console.WriteLine($"Output Array: {string.Join(", ", nums)}");
        }
    }
}
