using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.AdvancedCSharp
{
    [PracticeProgram("Advanced C#", "Yield")]
    public class Yield
    {     
        public static void Run()
        {
            List<int> GetNumbers()
            {
                var numbers = new List<int>();

                for (int i = 1; i <= 5; i++)
                {
                    numbers.Add(i);
                }

                return numbers;
            }

            foreach (var number in GetNumbers())
            {
                Console.WriteLine(number);
            }

            IEnumerable<int> GetNumbers1()
            {
                for (int i = 1; i <= 5; i++)
                {
                    yield return i;
                }
            }

            foreach (var number in GetNumbers1())
            {
                Console.WriteLine(number);
            }
        }
    }
}
