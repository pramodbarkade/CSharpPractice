
namespace CSharpPractice.Programs
{
    public class Find_Duplicate_Number_in_an_Array
    {
        public static void Start(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                Console.WriteLine("Array is null or empty.");
                return;
            }

            Console.WriteLine($"Input Array: {string.Join(", ", nums)}");

            HashSet<int> seen = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!seen.Add(num))
                {
                    Console.WriteLine($"Duplicate Number: {num}");
                    return;
                }
            }

            Console.WriteLine("No duplicate number found.");
        }
    }
}
