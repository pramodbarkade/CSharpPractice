using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Fundamentals
{
    [PracticeProgram("C# Fundamentals", "ref, out, in and params")]
    public class Ref_Out_In_Params
    {
        public static void Run()
        {
            string str1 = "str1";

            string str2;

            string str3 = "str3";            

            Demo(ref str1, out str2, in str3, 1, 2);

            Demo(ref str1, out str2, in str3, 1, 2, 3);

            Demo(ref str1, out str2, in str3, 1, 2, 3, 4);

        }

        public static void Demo(ref string str1, out string str2, in string str3, params int[] numbers)
        {
            str2 = "str2";

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

