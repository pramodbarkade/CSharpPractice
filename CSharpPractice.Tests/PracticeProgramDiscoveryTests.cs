using CSharpPractice.ProgramDiscovery;

namespace CSharpPractice.Tests;

public class PracticeProgramDiscoveryTests
{
    [Fact]
    public void Discover_FindsAnnotatedProgramsWithoutDuplicateMenuEntries()
    {
        IReadOnlyList<PracticeProgramDescriptor> programs =
            PracticeProgramDiscovery.Discover(typeof(PracticeProgramDiscovery).Assembly);

        Assert.Contains(programs, program => program.Category == "OOP" && program.Name == "Four pillars");
        Assert.Contains(programs, program => program.Category == "C# Fundamentals" && program.Name == "Control flow and methods");
        Assert.Contains(programs, program => program.Category == "Structs, Enums and Records");
        Assert.Contains(programs, program => program.Category == "File and Directory Handling");
        Assert.Contains(programs, program => program.Category == "Date and Time");
        Assert.Contains(programs, program => program.Category == "Multithreading and Concurrency");
        Assert.Equal(
            programs.Count,
            programs.Select(program => (program.Category, program.Name)).Distinct().Count());
    }

    [Fact]
    public async Task DiscoveredProgram_CanRunThroughDescriptor()
    {
        PracticeProgramDescriptor program = PracticeProgramDiscovery
            .Discover(typeof(PracticeProgramDiscovery).Assembly)
            .Single(program => program.Name == "Null handling and deconstruction");

        await program.RunAsync();
    }
}
