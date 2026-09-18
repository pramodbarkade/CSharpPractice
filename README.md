# CSharpPractice

A focused collection of C# language examples, .NET demonstrations, algorithms, and interview preparation programs.

## Run

From the repository root:

```bash
dotnet run --project CSharpPractice/CSharpPractice.csproj
```

The application scans the executable assembly for classes marked with `PracticeProgramAttribute`. Categories and programs are generated from that metadata, so moving a practice file does not require a `Program.cs` registration change.

## Final Structure

```text
CSharpPractice/
├── AdvancedCSharp/          Advanced C# and .NET examples
├── AsyncAwait/              Task and cancellation examples
├── Collections/             Collection examples
├── CodingProblems/
│   ├── Easy/                Basic coding and sorting problems
│   └── Medium/              Hashing and interview problems
├── DateTime/                Date and time examples
├── DelegatesLambdasEvents/  Delegates, lambdas, and events
├── DesignPatterns/          Design pattern examples
├── ExceptionHandling/       Exception examples
├── ExtensionMethods/        Extension method examples
├── FileDirectoryHandling/   File, directory, and stream examples
├── Fundamentals/            Variables, operators, methods, and arrays
├── Generics/                Generic types and methods
├── LINQ/                    LINQ examples
├── MemoryManagement/        References, GC, and IDisposable
├── Multithreading/          Threads and concurrent collections
├── OOP/                     Classes, inheritance, abstraction, and interfaces
├── PatternMatching/         Pattern matching examples
├── ProgramDiscovery/        Reflection-based menu infrastructure
├── ReflectionAttributes/    Reflection examples
├── SOLID/                   SOLID principle examples
├── Strings/                 String and StringBuilder examples
└── StructsEnumsRecords/     Struct, enum, and record examples
```

`CSharpPracticeStructure.md` is the canonical taxonomy. The repository preserves existing useful examples while placing them in the closest applicable category. The `CSharpPractice.Tests` project contains xUnit tests for reusable algorithms and discovery.
