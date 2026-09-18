namespace CSharpPractice.FileDirectoryHandling;

[PracticeProgram("File and Directory Handling", "Files, directories and streams")]
public sealed class FileAndDirectoryBasics : IPracticeProgram
{
    public void Run()
    {
        string directory = Path.Combine(Path.GetTempPath(), "CSharpPractice");
        string file = Path.Combine(directory, "notes.txt");

        Directory.CreateDirectory(directory);
        File.WriteAllText(file, "first line");
        File.AppendAllText(file, Environment.NewLine + "second line");

        Console.WriteLine(File.ReadAllText(file));
        Console.WriteLine($"File exists: {File.Exists(file)}");

        File.Delete(file);
        Directory.Delete(directory);
    }
}
