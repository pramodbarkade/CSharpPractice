using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    public class Find_Two_Numbers_Whose_Sum_Equals_Target
    {
        public static void Start(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                Console.WriteLine("Array is null or empty.");
                return;
            }

            Console.WriteLine($"Input Array: {string.Join(", ", nums)}, Target: { target }");

            HashSet<int> seen = new HashSet<int>();
            foreach (int num in nums)
            {
                int needed = target - num;

                if (seen.Contains(needed))
                {
                    Console.WriteLine($"{needed} + {num} = {target}");               
                }
                seen.Add(num);
            }
        }
    }
}
