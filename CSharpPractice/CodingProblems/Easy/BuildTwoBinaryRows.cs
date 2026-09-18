namespace CSharpPractice.CodingProblems
{
    [PracticeProgram("Coding Problems", "Build two binary rows")]
    public class BuildTwoBinaryRows
    {
        public static void Demo()
        {
            int num1 = 3, num2 = 4;
            int[] items = { 1, 1, 1, 2, 2 };

            int[] row1 = new int[items.Length];
            int[] row2 = new int[items.Length];

            int twos = 0, total = 0;

            foreach (int x in items)
            {
                total += x;
                if (x == 2) twos++;
            }

            int need = num1 - twos;

            if (total != num1 + num2 || need < 0)
            {
                Console.WriteLine("Not possible");
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == 2)
                    row1[i] = row2[i] = 1;

                else if (items[i] == 1)
                {
                    if (need > 0)
                    {
                        row1[i] = 1;
                        need--;
                    }
                    else
                        row2[i] = 1;
                }
            }

            if (need > 0)
            {
                Console.WriteLine("Not possible");
                return;
            }

            Console.WriteLine("Row1: " + string.Join(" ", row1));
            Console.WriteLine("Row2: " + string.Join(" ", row2));
        }
    }
}