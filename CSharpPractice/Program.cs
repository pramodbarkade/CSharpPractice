using System.Reflection;

internal static class Program
{
    private static async Task Main()
    {
        IReadOnlyList<PracticeProgramDescriptor> programs =
            PracticeProgramDiscovery.Discover(Assembly.GetExecutingAssembly());

        while (true)
        {
            string[] categories = programs
                .Select(program => program.Category)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(category => category)
                .ToArray();

            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("              C# Practice");
            Console.WriteLine("========================================");

            for (int index = 0; index < categories.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {categories[index]}");
            }

            Console.WriteLine("0. Exit");

            int categoryChoice = ReadChoice("\nSelect a category: ");
            if (categoryChoice == 0)
            {
                return;
            }

            if (categoryChoice < 1 || categoryChoice > categories.Length)
            {
                Console.WriteLine("Invalid choice.");
                Pause();
                continue;
            }

            string selectedCategory = categories[categoryChoice - 1];
            PracticeProgramDescriptor[] categoryPrograms = programs
                .Where(program => program.Category == selectedCategory)
                .OrderBy(program => program.Name)
                .ToArray();

            Console.Clear();
            Console.WriteLine($"========================================");
            Console.WriteLine($"              {selectedCategory}");
            Console.WriteLine($"========================================");

            for (int index = 0; index < categoryPrograms.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {categoryPrograms[index].Name}");
            }

            Console.WriteLine("0. Back");

            int programChoice = ReadChoice("\nSelect a program: ");
            if (programChoice == 0)
            {
                continue;
            }

            if (programChoice < 1 || programChoice > categoryPrograms.Length)
            {
                Console.WriteLine("Invalid choice.");
                Pause();
                continue;
            }

            await RunProgram(categoryPrograms[programChoice - 1]);
        }
    }

    private static async Task RunProgram(PracticeProgramDescriptor program)
    {
        Console.Clear();
        Console.WriteLine($"{program.Category} / {program.Name}");
        Console.WriteLine(new string('-', program.Category.Length + program.Name.Length + 3));

        try
        {
            await program.RunAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"The example raised {exception.GetType().Name}: {exception.Message}");
        }

        Pause();
    }

    private static int ReadChoice(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int choice) ? choice : -1;
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
