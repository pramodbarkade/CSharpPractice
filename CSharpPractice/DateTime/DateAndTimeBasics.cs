namespace CSharpPractice.DateTime;

[PracticeProgram("Date and Time", "DateTime, DateOnly, TimeOnly and DateTimeOffset")]
public sealed class DateAndTimeBasics : IPracticeProgram
{
    public void Run()
    {
        System.DateTime dateTime = new(2026, 9, 18, 14, 30, 0, DateTimeKind.Utc);
        DateOnly date = DateOnly.FromDateTime(dateTime);
        TimeOnly time = TimeOnly.FromDateTime(dateTime);
        DateTimeOffset offset = new(dateTime);

        Console.WriteLine($"Date: {date:yyyy-MM-dd}");
        Console.WriteLine($"Time: {time:HH:mm}");
        Console.WriteLine($"UTC offset: {offset.Offset}");
        Console.WriteLine($"Seven days later: {date.AddDays(7)}");
    }
}
