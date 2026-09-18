
namespace CSharpPractice.Programs
{
    public class Find_All_Duplicate_Number_in_an_Array
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
            HashSet<int> duplicates = new HashSet<int>();

            foreach (int num in nums)
                if (!seen.Add(num))
                    duplicates.Add(num);

            if (duplicates.Count > 0)
                Console.WriteLine($"Duplicate Numbers: {string.Join(", ", duplicates)}");
            else
                Console.WriteLine("No duplicate numbers found.");
        }
    }
}
