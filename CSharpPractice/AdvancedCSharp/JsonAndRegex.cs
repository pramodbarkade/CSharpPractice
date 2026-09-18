using System.Text.Json;
using System.Text.RegularExpressions;

namespace CSharpPractice.AdvancedCSharp;

[PracticeProgram("Advanced .NET", "JSON serialization and regular expressions")]
public sealed class JsonAndRegex : IPracticeProgram
{
    public void Run()
    {
        var product = new Product("Keyboard", 49.99m);
        string json = JsonSerializer.Serialize(product);
        Product? restored = JsonSerializer.Deserialize<Product>(json);

        Console.WriteLine(json);
        Console.WriteLine($"Deserialized product: {restored?.Name}");

        MatchCollection numbers = Regex.Matches("Order 42 has 3 items", "\\d+");
        Console.WriteLine($"Numbers found: {string.Join(", ", numbers.Select(match => match.Value))}");
    }

    private sealed record Product(string Name, decimal Price);
}
