using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    public class Find_the_Missing_Number_in_an_Array
    {
        public static void Start(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                Console.WriteLine("Null or empty nums array.");
                return;
            }

            int min = nums.Min();
            int max = nums.Max();

            Console.WriteLine($"Input nums array: {string.Join(", ", nums)}");

            // ============================================================
            // METHOD 1: SUM FORMULA
            // ============================================================

            Console.WriteLine("\n========== METHOD 1: SUM FORMULA ==========");

            // There should be nums.Length + 1 numbers
            // Example: 10, 11, 12, 13, 14, 15 = 6 numbers
            int expectedCount = nums.Length + 1;

            // Since 11 is missing:
            // min = 10
            // max = 15
            // Expected range = 10 to 15

            Console.WriteLine($"Array Length       : {nums.Length}");
            Console.WriteLine($"Expected Count     : {nums.Length} + 1 = {expectedCount}");
            Console.WriteLine($"Min                : {min}");
            Console.WriteLine($"Max                : {max}");

            // Sum from 1 to max
            long sumToMax = (long)max * (max + 1) / 2;

            // Sum from 1 to (min - 1)
            long sumBeforeMin = (long)(min - 1) * min / 2;

            // Sum from min to max
            long expectedSum = sumToMax - sumBeforeMin;

            Console.WriteLine("\n--- Expected Sum Calculation ---");

            Console.WriteLine($"Range              : {min} to {max}");

            Console.WriteLine("\nSum from 1 to Max:");
            Console.WriteLine($"Formula            : max * (max + 1) / 2");
            Console.WriteLine($"                   : {max} * ({max} + 1) / 2");
            Console.WriteLine($"                   : {max} * {max + 1} / 2");
            Console.WriteLine($"                   : {(long)max * (max + 1)} / 2");
            Console.WriteLine($"                   : {sumToMax}");

            Console.WriteLine("\nSum before Min:");
            Console.WriteLine($"Formula            : (min - 1) * min / 2");
            Console.WriteLine($"                   : ({min} - 1) * {min} / 2");
            Console.WriteLine($"                   : {min - 1} * {min} / 2");
            Console.WriteLine($"                   : {(long)(min - 1) * min} / 2");
            Console.WriteLine($"                   : {sumBeforeMin}");

            Console.WriteLine("\nExpected Sum:");
            Console.WriteLine($"                   : {sumToMax} - {sumBeforeMin}");
            Console.WriteLine($"Expected Sum       : {expectedSum}");

            // Actual array sum
            long actualSum = 0;

            Console.WriteLine("\n--- Actual Sum Calculation ---");

            foreach (int num in nums)
            {
                long before = actualSum;

                actualSum += num;

                Console.WriteLine(
                    $"{before} + {num} = {actualSum}");
            }

            Console.WriteLine($"\nExpected Sum       : {expectedSum}");
            Console.WriteLine($"Actual Sum         : {actualSum}");

            long missingNumber = expectedSum - actualSum;

            Console.WriteLine(
                $"Missing Calculation: {expectedSum} - {actualSum} = {missingNumber}");

            Console.WriteLine(
                $"O(n) Missing Number : {missingNumber}");


            // ============================================================
            // METHOD 2: XOR
            // ============================================================

            Console.WriteLine("\n========== METHOD 2: XOR ==========");

            int xor = 0;

            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");

            Console.WriteLine("\n--- XOR Expected Range ---");

            for (int i = min; i <= max; i++)
            {
                int before = xor;

                xor ^= i;

                Console.WriteLine(
                    $"{before} ^ {i} = {xor}   |   " +
                    $"{Convert.ToString(before, 2).PadLeft(8, '0')} ^ " +
                    $"{Convert.ToString(i, 2).PadLeft(8, '0')} = " +
                    $"{Convert.ToString(xor, 2).PadLeft(8, '0')}");
            }

            Console.WriteLine("\n--- XOR Actual Array ---");

            foreach (int num in nums)
            {
                int before = xor;

                xor ^= num;

                Console.WriteLine(
                    $"{before} ^ {num} = {xor}   |   " +
                    $"{Convert.ToString(before, 2).PadLeft(8, '0')} ^ " +
                    $"{Convert.ToString(num, 2).PadLeft(8, '0')} = " +
                    $"{Convert.ToString(xor, 2).PadLeft(8, '0')}");
            }

            Console.WriteLine($"\n(XOR ^) Missing Number: {xor}");
        }
    }
}
