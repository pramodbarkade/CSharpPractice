using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.TPL
{
    public class TaskCancellationToken
    {
        public static async Task Run()
        {
            using CancellationTokenSource cts = new CancellationTokenSource();

            // Start the work
            Task workTask = DoWorkAsync(cts.Token);

            // Wait 3 seconds
            await Task.Delay(3000);

            // Request cancellation
            Console.WriteLine("Requesting cancellation...");
            cts.Cancel();

            try
            {
                await workTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Work was cancelled.");
            }

            Console.WriteLine("Program finished.");
        }

        public static async Task DoWorkAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                // Check if cancellation was requested
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Working... {i}");

                await Task.Delay(1000, token);
            }
        }
    }
}

