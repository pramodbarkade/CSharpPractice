namespace CSharpPractice.ExceptionHandling;

[PracticeProgram("Exception Handling", "Custom exceptions and exception filters")]
public sealed class CustomExceptionsAndFilters : IPracticeProgram
{
    public void Run()
    {
        try
        {
            ValidateAge(15);
        }
        catch (AgeNotAllowedException exception) when (exception.Age < 18)
        {
            Console.WriteLine($"Filtered exception: {exception.Message}");
        }
    }

    private static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new AgeNotAllowedException(age);
        }
    }

    private sealed class AgeNotAllowedException : Exception
    {
        public AgeNotAllowedException(int age)
            : base($"Age {age} is not allowed.")
        {
            Age = age;
        }

        public int Age { get; }
    }
}
