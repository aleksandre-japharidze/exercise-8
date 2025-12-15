class NegativeAmountException : Exception
{
    public NegativeAmountException()
    {
    }

    public NegativeAmountException(string message) : base(message)
    {
    }

    public NegativeAmountException(string message, Exception inner) : base(message, inner)
    {
    }
}

class InsufficientFundsException : Exception
{
    public InsufficientFundsException()
    {
    }

    public InsufficientFundsException(string message) : base(message)
    {
    }

    public InsufficientFundsException(string message, Exception inner) : base(message, inner)
    {
    }
}

class BankAccount
{
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new NegativeAmountException("Initial balance cannot be negative");
        }
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Deposit amount cannot be negative");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Withdraw amount cannot be negative");
        }
        else if (amount > Balance)
        {
            throw new InsufficientFundsException("Insufficient funds");
        }

        Balance -= amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("John Doe", 1000);
        try
        {
            account.Deposit(500);
            account.Withdraw(2000);
        }
        catch (InsufficientFundsException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NegativeAmountException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Account balance: " + account.Balance);
        }
    }
}