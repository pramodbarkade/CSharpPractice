namespace CSharpPractice.Fundamentals;

[PracticeProgram("C# Fundamentals", "Control flow and methods")]
public sealed class ControlFlowAndMethods : IPracticeProgram
{
    public void Run()
    {
        int firstNumber = 7;
        int secondNumber = 3;
        const int comparisonTarget = 5;

        Console.WriteLine($"Addition: {firstNumber + secondNumber}");
        Console.WriteLine($"Greater than target: {firstNumber > comparisonTarget}");
        Console.WriteLine($"Both numbers are positive: {firstNumber > 0 && secondNumber > 0}");
        Console.WriteLine($"Conditional result: {(firstNumber % 2 == 0 ? "Even" : "Odd")}");

        string category = firstNumber switch
        {
            > 10 => "Large",
            > 5 => "Medium",
            _ => "Small"
        };

        Console.WriteLine($"Switch expression category: {category}");

        for (int number = 1; number <= 3; number++)
        {
            Console.WriteLine($"for: {number}");
        }

        int countdown = 3;
        while (countdown > 0)
        {
            Console.WriteLine($"while: {countdown}");
            countdown--;
        }

        int[] scores = [80, 90, 75];
        foreach (int score in scores)
        {
            Console.WriteLine($"foreach score: {score}");
        }

        Console.WriteLine($"Sum from 1 to 5: {SumTo(5)}");
        Console.WriteLine($"Factorial of 5: {Factorial(5)}");
    }

    private static int SumTo(int number)
    {
        return number <= 0 ? 0 : number + SumTo(number - 1);
    }

    private static int Factorial(int number)
    {
        return number <= 1 ? 1 : number * Factorial(number - 1);
    }
}
