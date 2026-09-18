namespace CSharpPractice.StructsEnumsRecords;

[PracticeProgram("Structs, Enums and Records", "Structs, enums and flags")]
public sealed class StructsAndEnums : IPracticeProgram
{
    public void Run()
    {
        Point point = new(3, 4);
        Console.WriteLine($"Point: ({point.X}, {point.Y})");

        OrderStatus status = OrderStatus.Paid;
        Console.WriteLine($"Status: {status}, value: {(int)status}");
        Console.WriteLine($"Parsed status: {Enum.Parse<OrderStatus>("Shipped")}");

        Permission permissions = Permission.Read | Permission.Write;
        Console.WriteLine($"Can write: {permissions.HasFlag(Permission.Write)}");
    }

    private readonly record struct Point(int X, int Y);

    private enum OrderStatus
    {
        Pending,
        Paid,
        Shipped
    }

    [Flags]
    private enum Permission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4
    }
}
