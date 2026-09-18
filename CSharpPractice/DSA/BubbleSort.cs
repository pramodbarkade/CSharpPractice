using System;
using System.Text;
using System.Linq;


namespace CSharpPractice.DSA
{
    public class BubbleSort
    {
        public static void Run()
        {
            int[] arr = [7, 3, 5, 1];
            Console.WriteLine($"BubbleSort :");
            Console.WriteLine($"Input  : {string.Join(", ", arr)}");

            int outerCount = 0;
            int innerCount = 0;

            BubbleSortArray(arr, ref outerCount, ref innerCount);

            Console.WriteLine($"Output : {string.Join(", ", arr)}");
            Console.WriteLine($"Passes : {outerCount}");
            Console.WriteLine($"Comparisons : {innerCount}");
        }

        private static void BubbleSortArray(int[] arr, ref int outerCount, ref int innerCount)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    innerCount++;

                    if (arr[j] <= arr[j + 1])
                        continue;

                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                    swapped = true;
                }

                outerCount++;

                // Array is already sorted
                if (!swapped)
                    break;
            }
        }
    }
}
