namespace CSharpPractice.AdvancedCSharp;

[PracticeProgram("Advanced C# Concepts", "dynamic, expression-bodied members and operator overloading")]
public sealed class AdvancedLanguageFeatures : IPracticeProgram
{
    public void Run()
    {
        dynamic value = 10;
        Console.WriteLine($"Dynamic value: {value + 5}");

        Money first = new(12.50m);
        Money second = new(7.50m);
        Console.WriteLine($"Operator result: {(first + second).Amount:C}");
    }

    private readonly record struct Money(decimal Amount)
    {
        public static Money operator +(Money left, Money right) => new(left.Amount + right.Amount);
    }
}
