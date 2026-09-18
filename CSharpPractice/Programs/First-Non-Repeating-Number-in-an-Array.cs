using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPractice.Programs
{
    public class First_Non_Repeating_Number_in_an_Array
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

            foreach (var item in frequency)
            {
                if (item.Value == 1)
                {
                    Console.WriteLine($"Number: {item.Key}, Count: {item.Value}");
                    break;
                }
            }

            if (frequency.Count == 0)
                Console.WriteLine("No duplicate numbers found.");


            Start2();
        }

        public static void Start2()
        {
            int uniqueNumbers = 10_000;

            Random random = new Random(12345);

            List<int> list = new List<int>();

            // =====================================================
            // CREATE INPUT
            // =====================================================

            // Add every number once
            for (int i = 1; i <= uniqueNumbers; i++)
            {
                list.Add(i);
            }

            // Randomly select numbers that will become duplicates
            int duplicateCount = 2000;

            HashSet<int> selectedDuplicates = new HashSet<int>();

            while (selectedDuplicates.Count < duplicateCount)
            {
                int number = random.Next(1, uniqueNumbers + 1);
                selectedDuplicates.Add(number);
            }

            // Add duplicate copies
            foreach (int number in selectedDuplicates)
            {
                list.Add(number);
            }

            // =====================================================
            // SHUFFLE ARRAY
            // =====================================================

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                (list[i], list[j]) = (list[j], list[i]);
            }

            int[] nums = list.ToArray();

            Console.WriteLine($"Unique Numbers     : {uniqueNumbers:N0}");
            Console.WriteLine($"Expected Duplicates: {duplicateCount:N0}");
            Console.WriteLine($"Array Size         : {nums.Length:N0}");
            Console.WriteLine();


            // =====================================================
            // METHOD 1: NESTED LOOP
            // =====================================================

            Stopwatch sw = Stopwatch.StartNew();

            HashSet<int> nestedDuplicates = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        nestedDuplicates.Add(nums[i]);
                        break;
                    }
                }
            }

            sw.Stop();

            double nestedTime = sw.Elapsed.TotalMilliseconds;

            Console.WriteLine("========== NESTED LOOP ==========");
            Console.WriteLine($"Duplicates Found : {nestedDuplicates.Count:N0}");
            Console.WriteLine($"Time             : {nestedTime:N3} ms");


            // =====================================================
            // METHOD 2: DICTIONARY
            // =====================================================

            sw.Restart();

            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                frequency.TryGetValue(num, out int count);
                frequency[num] = count + 1;
            }

            List<int> dictionaryDuplicates = new List<int>();

            foreach (var item in frequency)
            {
                if (item.Value > 1)
                {
                    dictionaryDuplicates.Add(item.Key);
                }
            }

            sw.Stop();

            double dictionaryTime = sw.Elapsed.TotalMilliseconds;

            Console.WriteLine();

            Console.WriteLine("========== DICTIONARY ==========");
            Console.WriteLine($"Duplicates Found : {dictionaryDuplicates.Count:N0}");
            Console.WriteLine($"Time             : {dictionaryTime:N3} ms");


            // =====================================================
            // COMPARISON
            // =====================================================

            Console.WriteLine();
            Console.WriteLine("========== COMPARISON ==========");

            if (nestedTime > dictionaryTime)
            {
                Console.WriteLine(
                    $"Dictionary is approximately " +
                    $"{nestedTime / dictionaryTime:N2}x faster.");
            }
            else
            {
                Console.WriteLine(
                    $"Nested Loop is approximately " +
                    $"{dictionaryTime / nestedTime:N2}x faster.");
            }


            // =====================================================
            // VERIFY RESULTS
            // =====================================================

            bool sameResult =
                nestedDuplicates.SetEquals(dictionaryDuplicates);

            Console.WriteLine($"Results Match     : {sameResult}");
        }
    }
}
