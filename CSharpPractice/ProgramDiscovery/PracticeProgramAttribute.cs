namespace CSharpPractice.ProgramDiscovery;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class PracticeProgramAttribute : Attribute
{
    public PracticeProgramAttribute(string category, string name)
    {
        Category = category;
        Name = name;
    }

    public string Category { get; }

    public string Name { get; }
}
