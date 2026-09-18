using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.CodingProblems
{
    [PracticeProgram("Coding Problems", "Kth largest element")]
    public class KthLargestElement
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            var minHeap = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                minHeap.Enqueue(num, num);

                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }

            return minHeap.Peek();
        }

        public static void Run()
        {
            int[] nums = { 7, 10, 4, 3, 20, 15 };
            int k = 3;

            Console.WriteLine(FindKthLargest(nums, k));

            Console.WriteLine(FindKthLargest_2nd_Approach(nums, k));            
        }


        public static int FindKthLargest_2nd_Approach(int[] nums, int k)
        {
            if (nums == null || k <= 0 || k > nums.Length)
                throw new ArgumentOutOfRangeException(nameof(k));

            int targetIndex = nums.Length - k;

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int pivotIndex = Partition(nums, left, right);

                if (pivotIndex == targetIndex)
                    return nums[pivotIndex];

                if (pivotIndex < targetIndex)
                    left = pivotIndex + 1;
                else
                    right = pivotIndex - 1;
            }

            throw new InvalidOperationException();
        }

        private static int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int smallerIndex = left;

            for (int i = left; i < right; i++)
            {
                if (nums[i] <= pivot)
                {
                    (nums[i], nums[smallerIndex]) =
                        (nums[smallerIndex], nums[i]);

                    smallerIndex++;
                }
            }

            (nums[smallerIndex], nums[right]) =
                (nums[right], nums[smallerIndex]);

            return smallerIndex;
        }
    }
}
