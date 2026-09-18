using System.Collections.Concurrent;

namespace CSharpPractice.Multithreading;

[PracticeProgram("Multithreading and Concurrency", "Threads and concurrent collections")]
public sealed class ThreadAndConcurrentCollections : IPracticeProgram
{
    public void Run()
    {
        using ManualResetEventSlim completed = new();
        int workerValue = 0;

        Thread worker = new(() =>
        {
            workerValue = 42;
            completed.Set();
        });

        worker.Start();
        completed.Wait();
        worker.Join();
        Console.WriteLine($"Thread result: {workerValue}");

        ConcurrentBag<int> values = new();
        Parallel.For(1, 4, values.Add);
        Console.WriteLine($"Concurrent bag count: {values.Count}");
    }
}
