using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace CSharpPractice.Collections
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }

    public class CollectionInterfaces
    {
        static async Task Main()
        {
            // =========================================================
            // 1. IEnumerable
            // =========================================================

            Console.WriteLine("===== 1. IEnumerable =====");

            IEnumerable oldCollection = new ArrayList
            {
                "Rahul",
                "Amit",
                "Priya"
            };
           
            foreach (object item in oldCollection)
            {
                Console.WriteLine(item);
            }


            // =========================================================
            // 2. IEnumerable<T>
            // =========================================================

            Console.WriteLine("\n===== 2. IEnumerable<T> =====");

            IEnumerable<int> numbers = new List<int>
            {
                10, 20, 30, 40
            };

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 3. IEnumerator
            // =========================================================

            Console.WriteLine("\n===== 3. IEnumerator =====");

            ArrayList oldNumbers = new ArrayList
            {
                100, 200, 300
            };

            IEnumerator enumerator = oldNumbers.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }


            // =========================================================
            // 4. IEnumerator<T>
            // =========================================================

            Console.WriteLine("\n===== 4. IEnumerator<T> =====");

            List<int> numberList = new List<int>
            {
                1000, 2000, 3000
            };

            IEnumerator<int> genericEnumerator =                numberList.GetEnumerator();

            while (genericEnumerator.MoveNext())
            {
                Console.WriteLine(                    genericEnumerator.Current                );
            }

            genericEnumerator.Dispose();


            // =========================================================
            // 5. ICollection
            // =========================================================

            Console.WriteLine("\n===== 5. ICollection =====");

            ICollection oldCollection2 = new ArrayList { 10, 20, 30 };
            Console.WriteLine($"Count: {oldCollection2.Count}");

            foreach (object item in oldCollection2)
            {
                Console.WriteLine(item);
            }


            // =========================================================
            // 6. ICollection<T>
            // =========================================================

            Console.WriteLine("\n===== 6. ICollection<T> =====");

            ICollection<string> names =                new List<string>();

            names.Add("Rahul");
            names.Add("Amit");
            names.Add("Priya");

            Console.WriteLine(
                $"Count: {names.Count}"
            );

            Console.WriteLine(
                $"Contains Amit: {names.Contains("Amit")}"
            );

            names.Remove("Amit");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }


            // =========================================================
            // 7. IList
            // =========================================================

            Console.WriteLine("\n===== 7. IList =====");

            IList oldList = new ArrayList();

            oldList.Add("A");
            oldList.Add("B");
            oldList.Add("C");

            Console.WriteLine($"Index 0: {oldList[0]}");

            oldList[0] = "X";

            oldList.Insert(1, "Y");

            foreach (object item in oldList)
            {
                Console.WriteLine(item);
            }


            // =========================================================
            // 8. IList<T>
            // =========================================================

            Console.WriteLine("\n===== 8. IList<T> =====");

            IList<string> list =                new List<string>
                {
                    "Rahul",
                    "Amit",
                    "Priya"
                };

            Console.WriteLine(
                $"Index 0: {list[0]}"
            );

            list[0] = "John";

            list.Insert(1, "Neha");

            list.RemoveAt(2);

            foreach (string name in list)
            {
                Console.WriteLine(name);
            }


            // =========================================================
            // 9. IReadOnlyCollection<T>
            // =========================================================

            Console.WriteLine(                "\n===== 9. IReadOnlyCollection<T> ====="            );

            List<string> employeeNames =                new List<string>                {
                    "Rahul",
                    "Amit",
                    "Priya"
                };

            IReadOnlyCollection<string> readOnlyCollection = employeeNames;

            Console.WriteLine($"Count: {readOnlyCollection.Count}");

            foreach (string name in readOnlyCollection)
            {
                Console.WriteLine(name);
            }

            // Not available:
            //
            // readOnlyCollection.Add("John");
            // readOnlyCollection.Remove("Rahul");


            // =========================================================
            // 10. IReadOnlyList<T>
            // =========================================================

            Console.WriteLine("\n===== 10. IReadOnlyList<T> =====");

            IReadOnlyList<string>                readOnlyList =                    employeeNames;

            Console.WriteLine(                $"Index 0: {readOnlyList[0]}"            );

            Console.WriteLine(                $"Index 1: {readOnlyList[1]}"            );

            Console.WriteLine(                $"Count: {readOnlyList.Count}"            );

            // Not available:
            //
            // readOnlyList[0] = "John";
            // readOnlyList.Add("John");


            // =========================================================
            // 11. IDictionary
            // =========================================================

            Console.WriteLine("\n===== 11. IDictionary =====");

            IDictionary oldDictionary = new Hashtable();

            oldDictionary.Add(101, "Rahul");
            oldDictionary.Add(102, "Amit");
            oldDictionary.Add(103, "Priya");

            Console.WriteLine(                oldDictionary[101]            );

            foreach (DictionaryEntry item in oldDictionary)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }


            // =========================================================
            // 12. IDictionary<TKey,TValue>
            // =========================================================

            Console.WriteLine(                "\n===== 12. IDictionary<TKey,TValue> ====="            );

            IDictionary<int, string>                dictionary =                    new Dictionary<int, string>();

            dictionary.Add(101, "Rahul");
            dictionary.Add(102, "Amit");
            dictionary.Add(103, "Priya");

            Console.WriteLine(dictionary[101]);

            dictionary[101] = "John";

            if (dictionary.ContainsKey(102))
            {
                Console.WriteLine("Key 102 exists");
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }


            // =========================================================
            // 13. IReadOnlyDictionary<TKey,TValue>
            // =========================================================

            Console.WriteLine(
                "\n===== 13. IReadOnlyDictionary<TKey,TValue> ====="
            );

            IReadOnlyDictionary<int, string> readOnlyDictionary = (IReadOnlyDictionary<int, string>)dictionary;

            Console.WriteLine(
                $"Count: {readOnlyDictionary.Count}"
            );

            Console.WriteLine(
                readOnlyDictionary[101]
            );

            if (readOnlyDictionary.ContainsKey(102))
            {
                Console.WriteLine(
                    "Employee 102 exists"
                );
            }

            foreach (var item in readOnlyDictionary)
            {
                Console.WriteLine(
                    $"{item.Key} = {item.Value}"
                );
            }

            // Not available:
            //
            // readOnlyDictionary.Add(104, "John");
            // readOnlyDictionary.Remove(101);


            // =========================================================
            // 14. ISet<T>
            // =========================================================

            Console.WriteLine(
                "\n===== 14. ISet<T> ====="
            );

            ISet<int> set =
                new HashSet<int>();

            set.Add(10);
            set.Add(20);
            set.Add(30);

            // Duplicate
            set.Add(10);

            Console.WriteLine(
                $"Count: {set.Count}"
            );

            Console.WriteLine(
                $"Contains 20: {set.Contains(20)}"
            );

            foreach (int number in set)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 15. IReadOnlySet<T>
            // =========================================================

            Console.WriteLine(
                "\n===== 15. IReadOnlySet<T> ====="
            );

            IReadOnlySet<int> readOnlySet = (IReadOnlySet<int>)set;

            Console.WriteLine(
                $"Count: {readOnlySet.Count}"
            );

            Console.WriteLine(
                $"Contains 20: " +
                $"{readOnlySet.Contains(20)}"
            );

            foreach (int number in readOnlySet)
            {
                Console.WriteLine(number);
            }

            // Not available:
            //
            // readOnlySet.Add(40);
            // readOnlySet.Remove(20);


            // =========================================================
            // 16. IAsyncEnumerable<T>
            // =========================================================

            Console.WriteLine("\n===== 16. IAsyncEnumerable<T> =====");

            await foreach (int number in GetNumbersAsync())
            {
                Console.WriteLine(number);
            }

            // =========================================================
            // 17. IAsyncEnumerator<T>
            // =========================================================

            Console.WriteLine("\n===== 17. IAsyncEnumerator<T> =====");

            IAsyncEnumerator<int> asyncEnumerator = GetNumbersAsync().GetAsyncEnumerator();

            try
            {
                while (await asyncEnumerator.MoveNextAsync())
                {
                    Console.WriteLine(asyncEnumerator.Current);
                }
            }
            finally
            {
                await asyncEnumerator.DisposeAsync();
            }

            // =========================================================
            // 18. IProducerConsumerCollection<T>
            // =========================================================

            Console.WriteLine("\n===== 18. IProducerConsumerCollection<T> =====");

            IProducerConsumerCollection<int> concurrentCollection = new ConcurrentQueue<int>();

            concurrentCollection.TryAdd(10);
            concurrentCollection.TryAdd(20);
            concurrentCollection.TryAdd(30);

            while (concurrentCollection.TryTake(out int number))
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 19. IImmutableList<T>
            // =========================================================

            Console.WriteLine("\n===== 19. IImmutableList<T> =====");

            IImmutableList<int> immutableList = ImmutableList.Create(10, 20, 30);

            IImmutableList<int> newImmutableList = immutableList.Add(40);

            Console.WriteLine("Original:");

            foreach (int number in immutableList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("New:");

            foreach (int number in newImmutableList)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 20. IImmutableDictionary<TKey,TValue>
            // =========================================================

            Console.WriteLine(
                "\n===== 20. IImmutableDictionary<TKey,TValue> ====="
            );

            IImmutableDictionary<int, string>
                immutableDictionary =
                    ImmutableDictionary<int, string>
                        .Empty;

            immutableDictionary =
                immutableDictionary.Add(
                    101,
                    "Rahul"
                );

            immutableDictionary =
                immutableDictionary.Add(
                    102,
                    "Amit"
                );

            IImmutableDictionary<int, string>
                updatedDictionary =
                    immutableDictionary.SetItem(
                        101,
                        "John"
                    );

            Console.WriteLine(
                $"Original: " +
                $"{immutableDictionary[101]}"
            );

            Console.WriteLine(
                $"Updated: " +
                $"{updatedDictionary[101]}"
            );


            // =========================================================
            // 21. IImmutableSet<T>
            // =========================================================

            Console.WriteLine(
                "\n===== 21. IImmutableSet<T> ====="
            );

            IImmutableSet<int>
                immutableSet =
                    ImmutableHashSet.Create(
                        10,
                        20,
                        30
                    );

            IImmutableSet<int>
                newImmutableSet =
                    immutableSet.Add(40);

            Console.WriteLine("Original:");

            foreach (int number in immutableSet)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("New:");

            foreach (int number in newImmutableSet)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 22. IImmutableQueue<T>
            // =========================================================

            Console.WriteLine(
                "\n===== 22. IImmutableQueue<T> ====="
            );

            IImmutableQueue<int>
                immutableQueue =
                    ImmutableQueue<int>.Empty;

            immutableQueue =
                immutableQueue.Enqueue(10);

            immutableQueue =
                immutableQueue.Enqueue(20);

            immutableQueue =
                immutableQueue.Enqueue(30);

            immutableQueue =
                immutableQueue.Dequeue(
                    out int removed
                );

            Console.WriteLine(
                $"Removed: {removed}"
            );

            foreach (int number in immutableQueue)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // 23. IImmutableStack<T>
            // =========================================================

            Console.WriteLine(
                "\n===== 23. IImmutableStack<T> ====="
            );

            IImmutableStack<int>
                immutableStack =
                    ImmutableStack<int>.Empty;

            immutableStack =
                immutableStack.Push(10);

            immutableStack =
                immutableStack.Push(20);

            immutableStack =
                immutableStack.Push(30);

            immutableStack =
                immutableStack.Pop(
                    out int removedStackItem
                );

            Console.WriteLine(
                $"Removed: {removedStackItem}"
            );

            foreach (int number in immutableStack)
            {
                Console.WriteLine(number);
            }


            // =========================================================
            // END
            // =========================================================

            Console.WriteLine(
                "\n===== ALL COLLECTION INTERFACES COMPLETED ====="
            );
        }

        // =============================================================
        // Async sequence used by IAsyncEnumerable<T>
        // =============================================================

        static async IAsyncEnumerable<int> GetNumbersAsync()
        {
            for (int i = 1; i <= 3; i++)
            {
                await Task.Delay(100);

                yield return i * 10;
            }
        }
    }
}