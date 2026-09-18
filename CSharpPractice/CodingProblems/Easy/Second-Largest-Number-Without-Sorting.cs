
namespace CSharpPractice.CodingProblems
{
    public class Second_Largest_Number_Without_Sorting
    {
        public static void Start(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                Console.WriteLine("Array must contain at least two numbers.");
                return;
            }

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > largest)
                {
                    secondLargest = largest;
                    largest = nums[i];
                }
                else if (nums[i] > secondLargest && nums[i] < largest)
                {
                    secondLargest = nums[i];
                }
            }

            if (secondLargest == int.MinValue)
            {
                Console.WriteLine("Second largest number does not exist.");
                return;
            }

            Console.WriteLine($"Largest Number : {largest}");
            Console.WriteLine($"Second Largest Number : {secondLargest}");
        }
    }
}
