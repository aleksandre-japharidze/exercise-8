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
        Console.WriteLine("Welcome to the Bank Account Simulator!");
        Console.Write("Please enter the owner's name:");
        string owner = Console.ReadLine();
        try
        {
            Console.Write("Please enter the initial balance:");
            decimal initialBalance = decimal.Parse(Console.ReadLine());
            BankAccount account = new BankAccount(owner, initialBalance);

            Console.WriteLine("Account created successfully. Owner: " + account.Owner);
            Console.Write("Please enter the amount to deposit:");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account.Deposit(depositAmount);
            Console.WriteLine("Deposit successful. New balance: " + account.Balance);
            Console.Write("Please enter the amount to withdraw:");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
            Console.WriteLine("Withdraw successful. New balance: " + account.Balance);
        }
        catch (InsufficientFundsException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NegativeAmountException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            // Handle decimal parsing exceptions
            if (e.Message.Contains("Input string was not in a correct format"))
            {
                throw new FormatException("Invalid input format. Please enter a valid decimal number.");
            }
            else
            {
                throw;
            }
        }
        finally
        {
            Console.WriteLine("Exitting...");
        }
    }
}