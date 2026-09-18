namespace CSharpPractice.Fundamentals;

[PracticeProgram("C# Fundamentals", "Arithmetic, comparison, logical and bitwise operators")]
public sealed class Operators : IPracticeProgram
{
    public void Run()
    {
        int left = 6;
        int right = 3;

        Console.WriteLine($"Arithmetic: {left + right}, {left - right}, {left * right}, {left / right}");
        Console.WriteLine($"Assignment: {left += right}");
        Console.WriteLine($"Comparison: {left > right}");
        Console.WriteLine($"Logical: {left > 0 && right > 0}");
        Console.WriteLine($"Bitwise AND: {left & right}");
        Console.WriteLine($"Unary negation: {-right}");
        Console.WriteLine($"Increment: {++right}");
        Console.WriteLine($"Conditional: {(left % 2 == 0 ? "even" : "odd")}");
        Console.WriteLine($"Null-coalescing: {((string?)null ?? "fallback")}");
    }
}
