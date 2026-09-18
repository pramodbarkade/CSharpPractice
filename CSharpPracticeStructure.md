# CSharpPractice Repository Structure

This document is the **source of truth** for organizing the `CSharpPractice` repository.

Any future program added to this repository must follow this structure.

Do not create new top-level folders or reorganize existing folders unless this document is intentionally updated first.

---

## 1. C# Fundamentals

### Core Concepts

* Hello World
* Variables
* Constants
* Data Types
* Value Types
* Reference Types
* Type Inference (`var`)
* Type Conversion
* Explicit Casting
* Implicit Conversion
* Parsing
* `TryParse`
* User Input
* Console Output
* String Interpolation
* Constants vs Readonly

### Operators

* Arithmetic Operators
* Assignment Operators
* Comparison Operators
* Logical Operators
* Bitwise Operators
* Unary Operators
* Increment / Decrement
* Null-Coalescing Operator
* Null-Coalescing Assignment
* Null-Conditional Operator
* Ternary Operator

---

## 2. Control Flow

### Conditions

* `if`
* `if-else`
* Nested `if`
* `else-if`
* Conditional Expressions

### Switch

* `switch`
* Switch with Multiple Cases
* Switch Expressions
* Pattern Matching with Switch
* Relational Patterns
* Property Patterns

### Loops

* `for`
* `while`
* `do-while`
* `foreach`
* Nested Loops
* `break`
* `continue`

---

## 3. Methods

* Basic Methods
* Parameters
* Return Values
* Multiple Parameters
* Optional Parameters
* Named Arguments
* `ref`
* `out`
* `in`
* Method Overloading
* Expression-Bodied Methods
* Local Functions
* Recursive Methods
* Parameter Arrays (`params`)

---

## 4. Arrays

### Basic Arrays

* Single-Dimensional Arrays
* Array Initialization
* Array Traversal
* Array Indexing
* Array Length

### Advanced Arrays

* Multi-Dimensional Arrays
* Jagged Arrays
* Array Copying
* Array Searching
* Array Sorting

### Array Problems

* Find Largest Element
* Find Smallest Element
* Find Sum
* Find Average
* Reverse Array
* Remove Duplicates
* Find Duplicate
* Find Missing Number
* Rotate Array
* Merge Arrays
* Common Array Interview Problems

---

## 5. Strings

### String Basics

* String Creation
* String Concatenation
* String Interpolation
* String Comparison
* String Length
* String Methods
* String Immutability

### StringBuilder

* StringBuilder Basics
* Append
* Insert
* Remove
* Replace

### String Problems

* Reverse String
* Palindrome
* Count Characters
* Count Vowels
* Character Frequency
* Duplicate Characters
* Remove Duplicate Characters
* Anagram
* First Non-Repeating Character
* Common String Interview Problems

---

## 6. Object-Oriented Programming

### Classes and Objects

* Class
* Object
* Fields
* Properties
* Methods
* Constructors
* Constructor Overloading
* Object Initialization
* `this`
* Static Members
* Static Classes

### Four Pillars of OOP

#### Encapsulation

* Encapsulation Basics
* Access Modifiers
* Private Fields
* Properties
* Get / Set
* Controlled Access

#### Abstraction

* Abstract Classes
* Abstract Methods
* Interfaces
* Interface Implementation
* Multiple Interface Implementation

#### Inheritance

* Base Class
* Derived Class
* Single-Level Inheritance
* Multilevel Inheritance
* Hierarchical Inheritance
* `base`
* Constructor Inheritance

#### Polymorphism

* Method Overloading
* Method Overriding
* Virtual Methods
* Abstract Methods
* Runtime Polymorphism
* Compile-Time Polymorphism

### Related OOP Concepts

* Access Modifiers
* Sealed Classes
* Sealed Methods
* Composition
* Association
* Aggregation
* Dependency
* Class Relationships

---

## 7. Structs, Enums and Records

### Structs

* Struct Basics
* Struct vs Class
* Readonly Struct

### Enums

* Enum Basics
* Enum Values
* Enum Parsing
* Enum Flags

### Records

* Record Basics
* Record Class
* Record Struct
* Value-Based Equality
* `with` Expression

---

## 8. Collections

### Non-Generic Collections

* ArrayList
* Hashtable

### Generic Collections

* List<T>
* Dictionary<TKey, TValue>
* HashSet<T>
* Queue<T>
* Stack<T>
* LinkedList<T>

### Sorted Collections

* SortedList
* SortedSet<T>
* SortedDictionary<TKey, TValue>

### Collection Concepts

* Collection Initialization
* Iteration
* Searching
* Sorting
* Adding / Removing
* Contains
* Key-Value Operations

### Collection Comparison

* Array vs List
* List vs LinkedList
* Dictionary vs Hashtable
* HashSet vs List
* Stack vs Queue

---

## 9. Generics

* Generic Classes
* Generic Methods
* Generic Interfaces
* Generic Delegates
* Generic Constraints
* `where`
* Multiple Type Parameters
* Generic Collections
* Generic vs Non-Generic

---

## 10. Exception Handling

* try
* catch
* finally
* Multiple catch Blocks
* Exception Types
* Inner Exception
* `throw`
* `throw;`
* Custom Exceptions
* Exception Filters
* Best Practices
* Common Exception Scenarios

---

## 11. Delegates, Lambdas and Events

### Delegates

* Delegate Basics
* Single-Cast Delegate
* Multi-Cast Delegate
* Generic Delegates

### Built-in Delegates

* Action
* Func
* Predicate

### Lambda Expressions

* Lambda Basics
* Lambda Parameters
* Expression Lambdas
* Statement Lambdas
* Lambda with LINQ

### Events

* Event Basics
* Event Handlers
* Custom Events
* Publisher / Subscriber

---

## 12. LINQ

### Filtering

* Where
* OfType
* Any
* All
* Contains

### Projection

* Select
* SelectMany

### Sorting

* OrderBy
* OrderByDescending
* ThenBy
* ThenByDescending

### Grouping

* GroupBy

### Joining

* Join
* GroupJoin

### Aggregation

* Count
* Sum
* Average
* Min
* Max
* Aggregate

### Element Operators

* First
* FirstOrDefault
* Last
* LastOrDefault
* Single
* SingleOrDefault
* ElementAt

### Partitioning

* Take
* TakeWhile
* Skip
* SkipWhile

### Set Operations

* Distinct
* Union
* Intersect
* Except

### Conversion

* ToList
* ToArray
* ToDictionary

### LINQ Concepts

* Deferred Execution
* Immediate Execution
* Query Syntax
* Method Syntax
* LINQ with Objects
* LINQ Interview Problems

---

## 13. Nullable and Null Handling

* Nullable Value Types
* Nullable Reference Types
* Nullable Operator `?`
* Null-Coalescing `??`
* Null-Coalescing Assignment `??=`
* Null-Conditional `?.`
* Null-Forgiving Operator `!`
* Null Checks
* Pattern-Based Null Checks

---

## 14. Pattern Matching

* Type Pattern
* Constant Pattern
* Relational Pattern
* Logical Pattern
* Property Pattern
* Positional Pattern
* List Pattern
* Pattern Matching with `is`
* Pattern Matching with `switch`

---

## 15. Extension Methods

* Extension Method Basics
* Extension Methods for Classes
* Extension Methods for Interfaces
* Extension Methods with Generics
* Practical Extension Method Examples

---

## 16. File and Directory Handling

### Files

* Create File
* Read File
* Write File
* Append File
* Delete File
* File Information

### Directories

* Create Directory
* Read Directory
* Directory Information
* Delete Directory

### Streams

* FileStream
* StreamReader
* StreamWriter
* MemoryStream

---

## 17. Serialization

* JSON Serialization
* JSON Deserialization
* Object to JSON
* JSON to Object
* System.Text.Json
* Serialization Options
* Handling Nested Objects
* Collections Serialization

---

## 18. Date and Time

* DateTime
* DateOnly
* TimeOnly
* DateTimeOffset
* TimeSpan
* Date Formatting
* Date Parsing
* Date Comparison
* Date Calculation
* UTC vs Local Time

---

## 19. Regular Expressions

* Regex Basics
* Pattern Matching
* Email Validation
* Phone Validation
* Number Extraction
* String Replacement
* Common Regex Examples

---

## 20. Reflection and Attributes

### Reflection

* Assembly
* Type
* Get Types
* Get Methods
* Get Properties
* Get Fields
* Create Instance
* Invoke Method

### Attributes

* Built-in Attributes
* Custom Attributes
* Attribute Parameters
* Reading Attributes with Reflection

### Repository Program Discovery

Reflection is also used by the repository's menu system to discover practice programs dynamically.

New practice programs should follow the existing discovery mechanism instead of being manually added to `Program.cs`.

---

## 21. Memory Management

* Value Type vs Reference Type
* Stack vs Heap
* Boxing
* Unboxing
* Garbage Collection
* Generations
* IDisposable
* using Statement
* using Declaration
* await using
* Finalizers

Keep memory examples simple and educational.

---

## 22. Async and Await

* Task
* async
* await
* Task.Delay
* Returning Task
* Returning Task<T>
* Multiple Async Operations
* Task.WhenAll
* Task.WhenAny
* Exception Handling in Async
* CancellationToken
* Cancellation

---

## 23. Multithreading and Concurrency

* Thread
* Thread Creation
* Thread.Sleep
* Task vs Thread
* Parallel
* Parallel.For
* Parallel.ForEach
* lock
* Thread Safety
* Race Conditions
* Concurrent Collections

Examples should remain small and focused.

---

## 24. Advanced C# Concepts

* `dynamic`
* Tuples
* Deconstruction
* Expression-Bodied Members
* Anonymous Types
* Anonymous Methods
* Local Functions
* `ref`
* `in`
* `out`
* `readonly`
* `const`
* `static`
* Partial Classes
* Partial Methods
* Indexers
* Operator Overloading
* User-Defined Conversions
* `yield`
* Iterators

Only add concepts compatible with the project's target C#/.NET version.

---

## 25. Coding Problems

Coding problems should be organized separately from language-concept demonstrations.

```text
CodingProblems/
├── Easy/
├── Medium/
└── Hard/
```

### Easy

* Number Problems
* String Problems
* Array Problems
* Basic Searching
* Basic Sorting
* Mathematical Problems

### Medium

* Hashing Problems
* Two Pointer Problems
* Sliding Window
* Binary Search
* Array Manipulation
* String Manipulation
* Stack / Queue Problems
* Linked List Problems

### Hard

* Advanced Array Problems
* Advanced String Problems
* Trees
* Graphs
* Dynamic Programming
* Advanced Algorithms

Do not add difficult algorithm topics simply to increase the number of programs.

---

## 26. Interview Practice

This section should contain programs specifically useful for C#/.NET interviews.

Possible categories:

* C# Fundamentals Questions
* OOP Questions
* Collections Questions
* LINQ Questions
* Exception Handling Questions
* Async / Await Questions
* Multithreading Questions
* Coding Questions
* Output-Based Questions
* Scenario-Based Questions

Interview examples should be practical and concise.

---

# Repository Organization Rules

## Rule 1: Follow the Existing Top-Level Structure

Do not create a new top-level folder if an appropriate category already exists.

For example, do not create:

```text
StringPrograms/
```

if strings already belong under:

```text
Strings/
```

---

## Rule 2: Small Concepts Should Stay Small

A simple concept should normally have a simple example.

Avoid creating unnecessary abstractions around examples such as:

```csharp
int a = 10;
int b = 20;
```

The purpose is learning C#, not demonstrating enterprise architecture.

---

## Rule 3: One Main Concept Per Example

Prefer:

```text
MethodOverloading.cs
```

instead of a large file containing:

```text
MethodOverloading
Generics
Delegates
LINQ
Reflection
```

Keep examples focused.

---

## Rule 4: Avoid Duplicates

Before adding a new program:

1. Search the repository.
2. Check whether the concept already exists.
3. If it exists, improve the existing example when appropriate.
4. Add a new example only when there is a meaningful difference.

---

## Rule 5: Preserve Existing Structure

Do not move or rename existing folders merely for cosmetic reasons.

If the current repository structure conflicts with this document, inspect the existing structure first and make the smallest reasonable change.

Do not perform large-scale restructuring without explicit instruction.

---

# Naming Convention

Use meaningful C# names.

Preferred:

```text
EncapsulationExample.cs
InheritanceExample.cs
MethodOverloadingExample.cs
DictionaryExample.cs
LinqFilteringExample.cs
AsyncAwaitExample.cs
```

Avoid:

```text
Test1.cs
Demo.cs
Example1.cs
NewClass.cs
Program1.cs
Temp.cs
```

Use the repository's existing naming convention when it is already consistent.

---

# Practice Program Requirements

Each dynamically discovered practice program should follow the existing repository mechanism.

A program should:

* Have a meaningful name
* Belong to one logical category
* Have one clear learning objective
* Be independently executable from the main menu
* Avoid unnecessary dependencies
* Avoid unnecessary comments
* Avoid unnecessary abstractions

---

# Comment Policy

Comments should be minimal.

### Good

```csharp
// Demonstrates runtime polymorphism.
```

### Avoid

```csharp
// Create a new object of the Employee class.
// This is done by using the new keyword.
// The object is then stored inside the employee variable...
```

Prefer readable code over verbose comments.

Do not add AI-generated sounding commentary.

---

# Adding a New Program

When adding a new program:

1. Identify its concept.
2. Find the matching category in this document.
3. Place the program in the existing corresponding folder.
4. Follow the existing naming convention.
5. Use the existing practice-program discovery mechanism.
6. Do not manually modify `Program.cs` unless the discovery architecture itself needs modification.
7. Verify the program appears in the correct menu.
8. Build and run the project.

---

# Architecture Rule

The repository uses dynamic program discovery.

The main entry point should not contain a manually maintained list of every practice program.

Preferred flow:

```text
Program.cs
    ↓
Program Discovery
    ↓
Reflection
    ↓
Practice Program Attribute / Interface
    ↓
Discover Programs
    ↓
Group by Category
    ↓
Generate Menu
    ↓
Execute Selected Program
```

Adding a new practice program should require adding the program itself, not editing the central menu.

---

# Priority

When deciding whether to add a concept, use this priority:

1. Core C# language concepts
2. OOP
3. Collections
4. LINQ
5. Exception Handling
6. Delegates / Events
7. Generics
8. Modern C#
9. Async / Multithreading
10. .NET fundamentals
11. Advanced C#
12. Coding Problems
13. Interview Practice

Avoid adding obscure concepts before important fundamentals are covered.

---

# Final Principle

`CSharpPractice` is a **structured learning and interview-preparation repository**.

The goal is:

```text
Small Concept
      ↓
Simple Example
      ↓
Related Concepts
      ↓
Practical Example
      ↓
Coding Problem
      ↓
Interview Practice
```

Keep the repository:

* Simple
* Consistent
* Discoverable
* Maintainable
* Interview-oriented
* Easy to extend

**Do not over-engineer it.**