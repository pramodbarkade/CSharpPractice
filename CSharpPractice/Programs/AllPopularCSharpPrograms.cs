using System.Text;

namespace CSharpPractice.Programs
{
    public class AllPopularCSharpPrograms
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\n===== C# LOGIC PROGRAMS =====");
                Console.WriteLine("1. Even / Odd");
                Console.WriteLine("2. Positive / Negative / Zero");
                Console.WriteLine("3. Swap Two Numbers");
                Console.WriteLine("4. Largest of 3 Numbers");
                Console.WriteLine("5. Factorial");
                Console.WriteLine("6. Sum 1 to N");
                Console.WriteLine("7. Reverse Number");
                Console.WriteLine("8. Sum of Digits");
                Console.WriteLine("9. Palindrome Number");
                Console.WriteLine("10. Prime Number");
                Console.WriteLine("11. Fibonacci Series");
                Console.WriteLine("12. Armstrong Number");
                Console.WriteLine("13. GCD / HCF");
                Console.WriteLine("14. LCM");
                Console.WriteLine("15. Reverse String");
                Console.WriteLine("16. Palindrome String");
                Console.WriteLine("17. Count Vowels");
                Console.WriteLine("18. Count Words");
                Console.WriteLine("19. Remove Duplicate Characters");
                Console.WriteLine("20. Anagram");
                Console.WriteLine("21. Character Frequency");
                Console.WriteLine("22. Array Max / Min");
                Console.WriteLine("23. Array Sum / Average");
                Console.WriteLine("24. Sort Array");
                Console.WriteLine("25. Remove Array Duplicates");
                Console.WriteLine("26. Find Array Duplicates");
                Console.WriteLine("27. Second Largest");
                Console.WriteLine("28. Even / Odd Array Elements");
                Console.WriteLine("29. Missing Number");
                Console.WriteLine("30. Star Pattern");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: EvenOdd(); break;
                    case 2: PositiveNegative(); break;
                    case 3: Swap(); break;
                    case 4: Largest(); break;
                    case 5: Factorial(); break;
                    case 6: SumN(); break;
                    case 7: ReverseNumber(); break;
                    case 8: SumDigits(); break;
                    case 9: PalindromeNumber(); break;
                    case 10: Prime(); break;
                    case 11: Fibonacci(); break;
                    case 12: Armstrong(); break;
                    case 13: GCD(); break;
                    case 14: LCM(); break;
                    case 15: ReverseString(); break;
                    case 16: PalindromeString(); break;
                    case 17: CountVowels(); break;
                    case 18: CountWords(); break;
                    case 19: RemoveDuplicateChars(); break;
                    case 20: Anagram(); break;
                    case 21: CharacterFrequency(); break;
                    case 22: ArrayMaxMin(); break;
                    case 23: ArraySumAverage(); break;
                    case 24: SortArray(); break;
                    case 25: RemoveArrayDuplicates(); break;
                    case 26: FindArrayDuplicates(); break;
                    case 27: SecondLargest(); break;
                    case 28: EvenOddArray(); break;
                    case 29: MissingNumber(); break;
                    case 30: StarPattern(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        // 1. Even / Odd
        static void EvenOdd()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(n % 2 == 0 ? "Even" : "Odd");
        }

        // 2. Positive / Negative / Zero
        static void PositiveNegative()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(n > 0 ? "Positive" :
                              n < 0 ? "Negative" : "Zero");
        }

        // 3. Swap
        static void Swap()
        {
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());

            // 1. Tuple Assignment
            int a1 = a, b1 = b;
            (a1, b1) = (b1, a1);
            Console.WriteLine($"Tuple Assignment  > A = {a1}, B = {b1}");

            // 2. Temporary Variable
            int a2 = a, b2 = b;
            int temp = a2;
            a2 = b2;
            b2 = temp;
            Console.WriteLine($"Temp Variable     > A = {a2}, B = {b2}");

            // 3. Addition / Subtraction
            int a3 = a, b3 = b;
            a3 = a3 + b3;
            b3 = a3 - b3;
            a3 = a3 - b3;

            Console.WriteLine($"Addition Method   > A = {a3}, B = {b3}");
        }

        // 4. Largest of 3
        static void Largest()
        {
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Enter C: ");
            int c = int.Parse(Console.ReadLine());

            // 1. Math.Max
            int largest1 = Math.Max(a, Math.Max(b, c));

            Console.WriteLine(
                $"Math.Max       > Largest = {largest1}");

            // 2. If Else
            int largest2;

            if (a >= b && a >= c)
                largest2 = a;
            else if (b >= a && b >= c)
                largest2 = b;
            else
                largest2 = c;
            Console.WriteLine($"If Else        > Largest = {largest2}");


            // 3. Ternary Operator
            int largest3 = a >= b
                ? (a >= c ? a : c)
                : (b >= c ? b : c);
            Console.WriteLine($"Ternary        > Largest = {largest3}");

            // 4. LINQ
            int largest4 = new[] { a, b, c }.Max();

            Console.WriteLine($"LINQ Max       > Largest = {largest4}");
        }

        // 5. Factorial
        static void Factorial()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            long fact = 1;

            for (int i = 1; i <= n; i++)
                fact *= i;

            Console.WriteLine("Factorial = " + fact);
        }

        // 6. Sum 1 to N
        static void SumN()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            int sum = n * (n + 1) / 2;

            Console.WriteLine("Sum = " + sum);
        }

        // 7. Reverse Number
        static void ReverseNumber()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            int rev = 0;

            while (n != 0)
            {
                // Step 1: Get last digit
                int lastDigit = n % 10;

                // Step 2: Make space in reverse number
                rev = rev * 10;

                // Step 3: Add last digit
                rev = rev + lastDigit;

                // Step 4: Remove last digit from original number
                n = n / 10;
            }

            Console.WriteLine("Reverse = " + rev);
        }

        // 8. Sum of Digits
        static void SumDigits()
        {
            Console.Write("Enter number: ");
            int n = Math.Abs(int.Parse(Console.ReadLine()));

            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            Console.WriteLine("Sum = " + sum);
        }

        // 9. Palindrome Number
        static void PalindromeNumber()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            int original = n;
            int temp = Math.Abs(n);
            int rev = 0;

            while (temp > 0)
            {
                rev = rev * 10 + temp % 10;
                temp /= 10;
            }

            Console.WriteLine(n >= 0 && original == rev
                ? "Palindrome"
                : "Not Palindrome");
        }

        // 10. Prime
        static void Prime()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            bool prime = n >= 2;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }

            Console.WriteLine(prime ? "Prime" : "Not Prime");
        }

        // 11. Fibonacci
        static void Fibonacci()
        {
            Console.Write("Enter number of terms: ");
            int n = int.Parse(Console.ReadLine());

            long first = 0;
            long second = 1;

            for (int i = 0; i < n; i++)
            {
                // Step 1: Print current number
                Console.Write(first + " ");

                // Step 2: Add two numbers
                long next = first + second;

                // Step 3: Move second to first
                first = second;

                // Step 4: Move next to second
                second = next;
            }

            Console.WriteLine();
        }

        // 12. Armstrong
        static void Armstrong()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("Not Armstrong");
                return;
            }

            int original = n;

            // Copy n because we don't want to destroy original
            int temp = n;

            // Count how many digits
            int digits = n.ToString().Length;

            // Store final addition
            int sum = 0;

            do
            {
                // Step 1: Get last digit
                int digit = temp % 10;

                // Step 2: Calculate digit power
                int power = (int)Math.Pow(digit, digits);

                // Step 3: Add it to sum
                sum = sum + power;

                // Step 4: Remove last digit
                temp = temp / 10;
            }
            while (temp > 0);

            Console.WriteLine(sum == original
                ? "Armstrong"
                : "Not Armstrong");
        }

        // 13. GCD / HCF
        static void GCD()
        {
            Console.Write("Enter A: ");
            int a = Math.Abs(int.Parse(Console.ReadLine()));

            Console.Write("Enter B: ");
            int b = Math.Abs(int.Parse(Console.ReadLine()));

            while (b != 0)
            {
                // Step 1: Find remainder
                int remainder = a % b;

                // Step 2: Move b to a
                a = b;

                // Step 3: Move remainder to b
                b = remainder;
            }

            Console.WriteLine("GCD = " + a);

            // Coprime check
            if (a == 1)
            {
                Console.WriteLine("Numbers are Coprime");
            }
            else
            {
                Console.WriteLine("Numbers are NOT Coprime");
            }
        }

        // 14. LCM
        static void LCM()
        {
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());

            // Start from the bigger number
            int lcm = Math.Max(a, b);

            while (true)
            {
                // Check if both divide exactly
                if (lcm % a == 0 && lcm % b == 0)
                {
                    break;
                }

                // Try next number
                lcm++;
            }

            Console.WriteLine("LCM = " + lcm);
        }

        // 15. Reverse String
        static void ReverseString()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            // =====================================
            // Way 1: LINQ Reverse() - Built-in
            // =====================================
            string reverse1 = new string(str.Reverse().ToArray());
            Console.WriteLine("LINQ Reverse     = " + reverse1);


            // =====================================
            // Way 2: Array.Reverse() - Built-in
            // =====================================
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            string reverse2 = new string(chars);
            Console.WriteLine("Array Reverse    = " + reverse2);


            // =====================================
            // Way 3: Manual For Loop
            // =====================================
            string reverse3 = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse3 = reverse3 + str[i];
            }
            Console.WriteLine("For Loop Reverse = " + reverse3);


            // =====================================
            // Way 4: Manual While Loop
            // =====================================
            string reverse4 = "";
            int index = str.Length - 1;
            while (index >= 0)
            {
                reverse4 = reverse4 + str[index];
                index--;
            }
            Console.WriteLine("While Reverse    = " + reverse4);


            // =====================================
            // Way 5: StringBuilder
            // =====================================
            StringBuilder reverse5 = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse5.Append(str[i]);
            }
            Console.WriteLine("StringBuilder    = " + reverse5);
        }

        // 16. Palindrome String
        static void PalindromeString()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            string clean = str.ToLower().Replace(" ", "");

            Console.WriteLine("\nOriginal : " + str);
            Console.WriteLine("Cleaned  : " + clean);

            // ==========================================
            // Way 1: SequenceEqual + Reverse
            // ==========================================
            bool way1 = clean.SequenceEqual(clean.Reverse());

            Console.WriteLine("\nWay 1 - SequenceEqual:");
            Console.WriteLine(way1 ? "Palindrome" : "Not Palindrome");


            // ==========================================
            // Way 2: Array.Reverse
            // ==========================================
            char[] chars = clean.ToCharArray();
            Array.Reverse(chars);
            string reversedArray = new string(chars);
            bool way2 = clean == reversedArray;
            Console.WriteLine("\nWay 2 - Array.Reverse:");
            Console.WriteLine(way2 ? "Palindrome" : "Not Palindrome");


            // ==========================================
            // Way 3: For Loop
            // ==========================================
            bool way3 = true;

            for (int i = 0; i < clean.Length / 2; i++)
            {
                if (clean[i] != clean[clean.Length - 1 - i])
                {
                    way3 = false;
                    break;
                }
            }
            Console.WriteLine("\nWay 3 - For Loop:");
            Console.WriteLine(way3 ? "Palindrome" : "Not Palindrome");


            // ==========================================
            // Way 4: Two Pointers / While Loop
            // ==========================================
            int left = 0;
            int right = clean.Length - 1;
            bool way4 = true;
            while (left < right)
            {
                if (clean[left] != clean[right])
                {
                    way4 = false;
                    break;
                }
                left++;
                right--;
            }
            Console.WriteLine("\nWay 4 - Two Pointers:");
            Console.WriteLine(way4 ? "Palindrome" : "Not Palindrome");


            // ==========================================
            // Way 5: Manual Reverse String
            // ==========================================
            string reversedManual = "";
            for (int i = clean.Length - 1; i >= 0; i--)
            {
                reversedManual += clean[i];
            }
            bool way5 = clean == reversedManual;
            Console.WriteLine("\nWay 5 - Manual Reverse:");
            Console.WriteLine(way5 ? "Palindrome" : "Not Palindrome");


            // ==========================================
            // Way 6: LINQ Reverse + ToArray
            // ==========================================
            string reversedLinq = new string(clean.Reverse().ToArray());
            bool way6 = clean == reversedLinq;
            Console.WriteLine("\nWay 6 - LINQ Reverse:");
            Console.WriteLine(way6 ? "Palindrome" : "Not Palindrome");

            Console.WriteLine(way3 ? "Final Result: Palindrome" : "Final Result: Not Palindrome");
        }

        // 17. Count Vowels
        static void CountVowels()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            // ==========================================
            // Way 1: LINQ Count + Contains
            // ==========================================
            int count1 = str.Count(c => "aeiouAEIOU".Contains(c));

            Console.WriteLine("\nWay 1 - LINQ Count:");
            Console.WriteLine("Vowels = " + count1);


            // ==========================================
            // Way 2: For Loop + Contains
            // ==========================================
            int count2 = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if ("aeiouAEIOU".Contains(str[i]))
                {
                    count2++;
                }
            }

            Console.WriteLine("\nWay 2 - For Loop:");
            Console.WriteLine("Vowels = " + count2);


            // ==========================================
            // Way 3: Foreach Loop
            // ==========================================
            int count3 = 0;

            foreach (char c in str)
            {
                char ch = char.ToLower(c);

                if (ch == 'a' ||
                    ch == 'e' ||
                    ch == 'i' ||
                    ch == 'o' ||
                    ch == 'u')
                {
                    count3++;
                }
            }

            Console.WriteLine("\nWay 3 - Foreach Loop:");
            Console.WriteLine("Vowels = " + count3);


            // ==========================================
            // Way 4: Switch Statement
            // ==========================================
            int count4 = 0;

            foreach (char c in str.ToLower())
            {
                switch (c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        count4++;
                        break;
                }
            }

            Console.WriteLine("\nWay 4 - Switch Statement:");
            Console.WriteLine("Vowels = " + count4);


            // ==========================================
            // Way 5: IndexOf
            // ==========================================
            int count5 = 0;

            foreach (char c in str)
            {
                if ("aeiouAEIOU".IndexOf(c) >= 0)
                {
                    count5++;
                }
            }

            Console.WriteLine("\nWay 5 - IndexOf:");
            Console.WriteLine("Vowels = " + count5);


            // ==========================================
            // Way 6: HashSet
            // ==========================================
            HashSet<char> vowels = new HashSet<char>
            {
                'a', 'e', 'i', 'o', 'u',
                'A', 'E', 'I', 'O', 'U'
            };

            int count6 = 0;

            foreach (char c in str)
            {
                if (vowels.Contains(c))
                {
                    count6++;
                }
            }

            Console.WriteLine("\nWay 6 - HashSet:");
            Console.WriteLine("Vowels = " + count6);


            // ==========================================
            // Way 7: LINQ Where
            // ==========================================
            int count7 = str
                .Where(c => "aeiouAEIOU".Contains(c))
                .Count();

            Console.WriteLine("\nWay 7 - LINQ Where:");
            Console.WriteLine("Vowels = " + count7);


            // ==========================================
            // Final Result
            // ==========================================
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Final Vowel Count = " + count1);
        }

        // 18. Count Words
        static void CountWords()
        {
            Console.Write("Enter sentence: ");
            string str = Console.ReadLine();

            // ==========================================
            // Way 1: Split + RemoveEmptyEntries
            // ==========================================
            int count1 = str.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            ).Length;

            Console.WriteLine("\nWay 1 - Split:");
            Console.WriteLine("Words = " + count1);


            // ==========================================
            // Way 2: Split with Multiple Whitespaces
            // Handles spaces, tabs, new lines
            // ==========================================
            int count2 = str.Split(
                new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            ).Length;

            Console.WriteLine("\nWay 2 - Split Multiple Whitespaces:");
            Console.WriteLine("Words = " + count2);


            // ==========================================
            // Way 3: For Loop
            // Count when entering a new word
            // ==========================================
            int count3 = 0;
            bool inWord = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsWhiteSpace(str[i]))
                {
                    if (!inWord)
                    {
                        count3++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }
            }

            Console.WriteLine("\nWay 3 - For Loop:");
            Console.WriteLine("Words = " + count3);


            // ==========================================
            // Way 4: Foreach Loop
            // ==========================================
            int count4 = 0;
            bool insideWord = false;

            foreach (char c in str)
            {
                if (!char.IsWhiteSpace(c))
                {
                    if (!insideWord)
                    {
                        count4++;
                        insideWord = true;
                    }
                }
                else
                {
                    insideWord = false;
                }
            }

            Console.WriteLine("\nWay 4 - Foreach Loop:");
            Console.WriteLine("Words = " + count4);


            // ==========================================
            // Way 5: LINQ
            // ==========================================
            int count5 = str
                .Split(' ')
                .Count(word => !string.IsNullOrWhiteSpace(word));

            Console.WriteLine("\nWay 5 - LINQ:");
            Console.WriteLine("Words = " + count5);


            // ==========================================
            // Way 6: Regex
            // \S+ = one or more non-whitespace characters
            // ==========================================
            int count6 = System.Text.RegularExpressions.Regex
                .Matches(str, @"\S+")
                .Count;

            Console.WriteLine("\nWay 6 - Regex:");
            Console.WriteLine("Words = " + count6);


            // ==========================================
            // Way 7: While Loop
            // ==========================================
            int count7 = 0;
            int index = 0;

            while (index < str.Length)
            {
                // Skip whitespace
                while (index < str.Length &&
                       char.IsWhiteSpace(str[index]))
                {
                    index++;
                }

                // Found a word
                if (index < str.Length)
                {
                    count7++;

                    // Skip the current word
                    while (index < str.Length &&
                           !char.IsWhiteSpace(str[index]))
                    {
                        index++;
                    }
                }
            }

            Console.WriteLine("\nWay 7 - While Loop:");
            Console.WriteLine("Words = " + count7);


            // ==========================================
            // Way 8: Count Word Starts using LINQ
            // ==========================================
            int count8 = str
                .Where((c, i) =>
                    !char.IsWhiteSpace(c) && (i == 0 || char.IsWhiteSpace(str[i - 1])))
                .Count();

            Console.WriteLine("\nWay 8 - LINQ Word Starts:");
            Console.WriteLine("Words = " + count8);


            // ==========================================
            // Final Result
            // ==========================================
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Final Word Count = " + count3);
        }

        // 19. Remove Duplicate Characters
        static void RemoveDuplicateChars()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            // ==========================================
            // Way 1: LINQ Distinct
            // ==========================================
            string result1 = new string(str.Distinct().ToArray());
            Console.WriteLine("LINQ Result = " + result1);


            // ==========================================
            // Way 2: HashSet + StringBuilder
            // More efficient / robust for large strings
            // ==========================================
            HashSet<char> seen = new HashSet<char>();
            StringBuilder result2 = new StringBuilder();
            foreach (char c in str)
            {
                if (seen.Add(c))
                {
                    result2.Append(c);
                }
            }
            Console.WriteLine("HashSet Result = " + result2);
        }

        // 20. Anagram
        static void Anagram()
        {
            Console.Write("Enter first string: ");
            string s1 = Console.ReadLine()
                               .Replace(" ", "")
                               .ToLower();

            Console.Write("Enter second string: ");
            string s2 = Console.ReadLine()
                               .Replace(" ", "")
                               .ToLower();

            // ==========================================
            // Way 1: Sorting + SequenceEqual
            // Time: O(n log n)
            // ==========================================
            bool result1 = s1.OrderBy(c => c).SequenceEqual(s2.OrderBy(c => c));
            Console.WriteLine("\nWay 1 - Sorting:");
            Console.WriteLine(result1 ? "Anagram" : "Not Anagram");

            // ==========================================
            // Way 2: Dictionary / Frequency Count
            // Time: O(n) average
            // ==========================================
            bool result2 = true;
            if (s1.Length != s2.Length)
            {
                result2 = false;
            }
            else
            {
                Dictionary<char, int> frequency = new Dictionary<char, int>();
                // Count characters from first string
                foreach (char c in s1)
                {
                    frequency.TryGetValue(c, out int count);
                    frequency[c] = count + 1;
                }
                // Subtract characters from second string
                foreach (char c in s2)
                {
                    if (!frequency.TryGetValue(c, out int count) || count == 0)
                    {
                        result2 = false;
                        break;
                    }
                    frequency[c] = count - 1;
                }
            }
            Console.WriteLine("\nWay 2 - Dictionary:");
            Console.WriteLine(result2 ? "Anagram" : "Not Anagram");
        }

        // 21. Character Frequency
        static void CharacterFrequency()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            var result = str
                .Where(c => c != ' ')
                .GroupBy(c => c);

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"{item.Key} = {item.Count()}");
            }
        }

        // Helper method for array input
        static int[] ReadArray()
        {
            Console.Write("Enter numbers separated by space: ");

            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        // 22. Array Max / Min
        static void ArrayMaxMin()
        {
            int[] arr = ReadArray();

            Console.WriteLine("Max = " + arr.Max());
            Console.WriteLine("Min = " + arr.Min());
        }

        // 23. Array Sum / Average
        static void ArraySumAverage()
        {
            int[] arr = ReadArray();

            Console.WriteLine("Sum = " + arr.Sum());
            Console.WriteLine("Average = " + arr.Average());
        }

        // 24. Sort Array
        static void SortArray()
        {
            int[] arr = ReadArray();

            Array.Sort(arr);

            Console.WriteLine(
                "Ascending: " + string.Join(" ", arr));

            Array.Reverse(arr);

            Console.WriteLine(
                "Descending: " + string.Join(" ", arr));
        }

        // 25. Remove Array Duplicates
        static void RemoveArrayDuplicates()
        {
            int[] arr = ReadArray();

            int[] result = arr.Distinct().ToArray();

            Console.WriteLine(
                string.Join(" ", result));
        }

        // 26. Find Array Duplicates
        static void FindArrayDuplicates()
        {
            int[] arr = ReadArray();

            var duplicates = arr
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            Console.WriteLine(
                "Duplicates: " +
                string.Join(" ", duplicates));
        }

        // 27. Second Largest
        static void SecondLargest()
        {
            int[] arr = ReadArray();

            int[] unique = arr
                .Distinct()
                .OrderByDescending(x => x)
                .ToArray();

            if (unique.Length < 2)
                Console.WriteLine("No second largest value.");
            else
                Console.WriteLine(
                    "Second Largest = " + unique[1]);
        }

        // 28. Even / Odd Array
        static void EvenOddArray()
        {
            int[] arr = ReadArray();

            var even = arr.Where(x => x % 2 == 0);
            var odd = arr.Where(x => x % 2 != 0);

            Console.WriteLine("Even: " + string.Join(" ", even));

            Console.WriteLine("Odd: " + string.Join(" ", odd));
        }

        // 29. Missing Number from 1 to N
        static void MissingNumber()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter numbers from 1 to N with one missing:");

            int[] arr = ReadArray();

            long expected = (long)n * (n + 1) / 2;
            long actual = arr.Sum(x => (long)x);

            Console.WriteLine("Missing Number = " + (expected - actual));
        }

        // 30. Star Pattern
        static void StarPattern()
        {
            Console.Write("Enter rows: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }
    }
}