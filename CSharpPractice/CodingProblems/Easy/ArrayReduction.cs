namespace CSharpPractice.CodingProblems
{
    public class ArrayReduction
    {
        public void ArrayReductionProgram()
        {
            int[] numbers = { 5, 3 };

            for (int i = 0; i < numbers.Length; i++)
            {
                // Check if current element is at least 2
                if (numbers[i] >= 2)
                {
                    numbers[i] -= 2;

                    // Ensure there is a next element before reducing it
                    if (i + 1 < numbers.Length)
                    {
                        numbers[i + 1] -= 1;
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
