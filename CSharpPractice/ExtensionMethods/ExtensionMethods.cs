namespace CSharpPractice.ExtensionMethods;

[PracticeProgram("Extension Methods", "Extension methods for strings and collections")]
public sealed class ExtensionMethods : IPracticeProgram
{
    public void Run()
    {
        string name = "  csharp practice  ";
        int[] numbers = [1, 2, 3, 4];

        Console.WriteLine(name.ToTitleCase());
        Console.WriteLine($"Sum: {numbers.SumItems()}");
    }
}

internal static class PracticeExtensions
{
    public static string ToTitleCase(this string value)
    {
        return value.Trim().ToUpperInvariant();
    }

    public static int SumItems<T>(this IEnumerable<T> values) where T : struct, IConvertible
    {
        return values.Sum(value => value.ToInt32(null));
    }
}
