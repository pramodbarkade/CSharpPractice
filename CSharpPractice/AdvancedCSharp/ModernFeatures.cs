namespace CSharpPractice.AdvancedCSharp;

[PracticeProgram("Nullable and Null Handling", "Null handling and deconstruction")]
public sealed class ModernFeatures : IPracticeProgram
{
    public void Run()
    {
        string? optionalName = null;
        Console.WriteLine(optionalName ?? "Guest");
        Console.WriteLine($"Name length: {optionalName?.Length ?? 0}");

        object value = 42;
        string description = value switch
        {
            int number when number > 0 => $"Positive integer: {number}",
            string text => $"Text: {text}",
            _ => "Other value"
        };

        Console.WriteLine(description);

        var person = new Person("Asha", 30);
        var (name, age) = person;
        Console.WriteLine($"Deconstructed person: {name}, {age}");
    }

    private sealed record Person(string Name, int Age);
}
