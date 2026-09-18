namespace CSharpPractice.Fundamentals;

[PracticeProgram("C# Fundamentals", "Variables, constants, types and conversions")]
public sealed class VariablesAndConversions : IPracticeProgram
{
    public void Run()
    {
        const double taxRate = 0.2;
        int itemCount = 3;
        double price = 12.5;
        var total = itemCount * price;
        object boxedTotal = total;
        double unboxedTotal = (double)boxedTotal;

        Console.WriteLine($"Total: {unboxedTotal}");
        Console.WriteLine($"With tax: {unboxedTotal + unboxedTotal * taxRate}");
        Console.WriteLine($"Implicit conversion: {itemCount} -> {(double)itemCount}");
        Console.WriteLine($"Explicit conversion: {(int)price}");

        bool parsed = int.TryParse("42", out int parsedNumber);
        Console.WriteLine($"TryParse succeeded: {parsed}, value: {parsedNumber}");
    }
}
