namespace CSharpPractice.DelegatesLambdasEvents;

 [PracticeProgram("Delegates, Lambdas and Events", "Delegates, Action, Func, Predicate and lambdas")]
public sealed class DelegatesAndLambdas : IPracticeProgram
{
    private delegate int Operation(int left, int right);

    public void Run()
    {
        Operation add = Add;
        Operation multiply = (left, right) => left * right;
        Action<string> print = message => Console.WriteLine(message);
        Func<int, int, int> subtract = (left, right) => left - right;
        Predicate<int> isEven = number => number % 2 == 0;

        print($"Custom delegate: {add(2, 3)}");
        print($"Lambda delegate: {multiply(2, 3)}");
        print($"Func result: {subtract(8, 3)}");
        print($"Predicate result: {isEven(4)}");

        Operation multicast = add;
        multicast += multiply;
        print($"Multicast delegate final result: {multicast(2, 3)}");
    }

    private static int Add(int left, int right)
    {
        return left + right;
    }
}
