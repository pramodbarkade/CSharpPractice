using System.Reflection;

namespace CSharpPractice.ProgramDiscovery;

public sealed class PracticeProgramDescriptor
{
    private readonly Type programType;
    private readonly MethodInfo runMethod;

    internal PracticeProgramDescriptor(string category, string name, Type programType, MethodInfo runMethod)
    {
        Category = category;
        Name = name;
        this.programType = programType;
        this.runMethod = runMethod;
    }

    public string Category { get; }

    public string Name { get; }

    public async Task RunAsync()
    {
        object? instance = runMethod.IsStatic ? null : Activator.CreateInstance(programType);
        object? result = runMethod.Invoke(instance, null);

        if (result is Task task)
        {
            await task;
        }
    }
}

public static class PracticeProgramDiscovery
{
    public static IReadOnlyList<PracticeProgramDescriptor> Discover(Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Select(type => new
            {
                Type = type,
                Attribute = type.GetCustomAttribute<PracticeProgramAttribute>()
            })
            .Where(item => item.Attribute is not null)
            .Select(item => CreateDescriptor(item.Type, item.Attribute!))
            .OrderBy(program => program.Category)
            .ThenBy(program => program.Name)
            .ToArray();
    }

    private static PracticeProgramDescriptor CreateDescriptor(Type type, PracticeProgramAttribute attribute)
    {
        MethodInfo? runMethod = type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Where(method => method.Name is "Run" or "Start" or "Demo")
            .Where(method => method.GetParameters().Length == 0)
            .SingleOrDefault(method => method.ReturnType == typeof(void) || typeof(Task).IsAssignableFrom(method.ReturnType));

        if (runMethod is null)
        {
            throw new InvalidOperationException($"{type.FullName} must expose a parameterless Run, Start, or Demo method.");
        }

        return new PracticeProgramDescriptor(attribute.Category, attribute.Name, type, runMethod);
    }
}
