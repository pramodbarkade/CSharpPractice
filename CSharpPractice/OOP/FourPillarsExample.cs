namespace CSharpPractice.OOP;

[PracticeProgram("OOP", "Four pillars")]
public sealed class FourPillarsExample : IPracticeProgram
{
    public void Run()
    {
        Animal animal = new Dog("Milo");
        animal.Describe();

        var account = new BankAccount(100);
        account.Deposit(50);
        Console.WriteLine($"Encapsulated balance: {account.Balance}");
    }

    private abstract class Animal
    {
        protected Animal(string name)
        {
            Name = name;
        }

        protected string Name { get; }

        public abstract void Describe();
    }

    private sealed class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void Describe()
        {
            Console.WriteLine($"Polymorphism: {Name} says woof");
        }
    }

    private sealed class BankAccount
    {
        public BankAccount(decimal openingBalance)
        {
            Balance = openingBalance;
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            Balance += amount;
        }
    }
}
