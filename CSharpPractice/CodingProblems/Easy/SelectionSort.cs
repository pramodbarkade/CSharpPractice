using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    [PracticeProgram("Coding Problems", "Selection sort")]
    public class SelectionSort
    {
        public static void Run()
        {
            int[] arr = [7, 3, 5, 1];

            Console.WriteLine("Selection Sort:");
            Console.WriteLine($"Input       : {string.Join(", ", arr)}");

            int passCount = 0;
            int comparisonCount = 0;
            int swapCount = 0;

            SelectionSortArray(arr, ref passCount, ref comparisonCount, ref swapCount);
            Console.WriteLine($"Output      : {string.Join(", ", arr)}");
            Console.WriteLine($"Passes      : {passCount}");
            Console.WriteLine($"Comparisons : {comparisonCount}");
            Console.WriteLine($"Swaps       : {swapCount}");
        }

        private static void SelectionSortArray(int[] arr, ref int passCount, ref int comparisonCount, ref int swapCount)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    comparisonCount++;

                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex == i)
                    continue;

                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);

                swapCount++;
                passCount++;
            }
        }
    }
}
