using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Concepts
{
    [PracticeProgram("Modern C#", "is and as")]
    public class Is_And_As
    {
        public static void Run()
        {
            string str = "Hello";
            if (str is string)
            {
                var str2 = str as object;
            }

            object value = 100;
            string text = value as string;
            Console.WriteLine(text is null); // true
        }
    }
}
