using System.Text;

namespace CSharpPractice.Strings;

[PracticeProgram("Strings", "StringBuilder append, insert, replace and remove")]
public sealed class StringBuilderBasics : IPracticeProgram
{
    public void Run()
    {
        StringBuilder message = new("C# practice");
        message.Append(" examples");
        message.Insert(0, "Daily ");
        message.Replace("practice", "interview practice");
        message.Remove(0, "Daily ".Length);

        Console.WriteLine(message);
    }
}
