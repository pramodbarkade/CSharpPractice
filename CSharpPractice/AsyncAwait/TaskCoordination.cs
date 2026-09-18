namespace CSharpPractice.AsyncAwait;

[PracticeProgram("Async and Await", "WhenAll and WhenAny")]
public sealed class TaskCoordination
{
    public async Task Run()
    {
        Task<int>[] tasks = [CalculateAsync(2), CalculateAsync(3)];
        int[] results = await Task.WhenAll(tasks);
        Console.WriteLine($"WhenAll total: {results.Sum()}");

        Task<int> firstCompleted = await Task.WhenAny(CalculateAsync(1), CalculateAsync(2));
        Console.WriteLine($"WhenAny result: {await firstCompleted}");

        int total = 0;
        object syncRoot = new();
        Parallel.ForEach([1, 2, 3, 4], number =>
        {
            lock (syncRoot)
            {
                total += number;
            }
        });

        Console.WriteLine($"Thread-safe total: {total}");
    }

    private static async Task<int> CalculateAsync(int number)
    {
        await Task.Yield();
        return number * number;
    }
}
