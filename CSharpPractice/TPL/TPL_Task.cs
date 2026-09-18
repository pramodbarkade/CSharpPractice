using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.TPL
{
    public class TPL_Task
    {
        public static async Task Run()
        {
            var task = Task.Run(() => { return 0; });

            var result = task.Result;


            var task1 = Task.Run(() => { return 1; });
            var task2 = Task.Run(() => { return 2; });
            var task3 = Task.Run(() => { return 3; });
            await Task.WhenAll(task1, task2, task3);

            var resultTask1 = await task1;
            var resultTask2 = await task2;
            var resultTask3 = await task3;
        }
    }
}
