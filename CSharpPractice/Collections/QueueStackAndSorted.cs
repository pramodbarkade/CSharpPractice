namespace CSharpPractice.Collections;

[PracticeProgram("Collections", "Queue, stack, linked list and sorted collections")]
public sealed class QueueStackAndSorted : IPracticeProgram
{
    public void Run()
    {
        Queue<string> queue = new(["first", "second"]);
        Console.WriteLine($"Queue removes: {queue.Dequeue()}");

        Stack<string> stack = new(["bottom", "top"]);
        Console.WriteLine($"Stack removes: {stack.Pop()}");

        LinkedList<int> linkedList = new([2, 3]);
        linkedList.AddFirst(1);
        Console.WriteLine($"Linked list: {string.Join(", ", linkedList)}");

        SortedDictionary<int, string> sortedDictionary = new()
        {
            [2] = "two",
            [1] = "one"
        };
        Console.WriteLine($"Sorted keys: {string.Join(", ", sortedDictionary.Keys)}");

        SortedSet<int> sortedSet = new([3, 1, 2, 2]);
        Console.WriteLine($"Sorted unique values: {string.Join(", ", sortedSet)}");
    }
}
