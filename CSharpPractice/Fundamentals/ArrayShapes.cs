namespace CSharpPractice.Fundamentals;

[PracticeProgram("Arrays", "One-dimensional, multidimensional and jagged arrays")]
public sealed class ArrayShapes : IPracticeProgram
{
    public void Run()
    {
        int[] oneDimensional = [4, 1, 3, 2];
        int[,] multidimensional =
        {
            { 1, 2 },
            { 3, 4 }
        };
        int[][] jagged =
        [
            [1, 2],
            [3, 4, 5]
        ];

        Console.WriteLine($"One-dimensional length: {oneDimensional.Length}");
        Console.WriteLine($"One-dimensional minimum: {oneDimensional.Min()}");
        Console.WriteLine($"Two-dimensional value [1, 0]: {multidimensional[1, 0]}");
        Console.WriteLine($"Jagged row 2 length: {jagged[1].Length}");

        Array.Sort(oneDimensional);
        Console.WriteLine($"Sorted values: {string.Join(", ", oneDimensional)}");
        Console.WriteLine($"Index of 3: {Array.IndexOf(oneDimensional, 3)}");
    }
}
