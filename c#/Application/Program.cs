class NegativeAmountException : Exception
{
    public NegativeAmountException()
    {
    }

    public NegativeAmountException(string message)
        : base(message)
    {
    }

    public NegativeAmountException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

class InsufficientFundsException : Exception
{
    public InsufficientFundsException()
    {
    }

    public InsufficientFundsException(string message)
        : base(message)
    {
    }

    public InsufficientFundsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

class BankAccount
{
    public BankAccount(string owner, decimal initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public string Owner { get; set; }
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Deposit amount cannot be negative.");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Withdrawal amount cannot be negative.");
        }

        if (amount > Balance)
        {
            throw new InsufficientFundsException("Insufficient funds for this withdrawal.");
        }

        Balance -= amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("Alice", 1000);

        try
        {
            account.Deposit(500);
            Console.WriteLine($"Balance after deposit: {account.Balance}");

            account.Withdraw(2000);
            Console.WriteLine($"Balance after withdrawal: {account.Balance}");
        } catch (NegativeAmountException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } finally
        {
            Console.WriteLine($"Final balance: {account.Balance}");
        }
    }
}