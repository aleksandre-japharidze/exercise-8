class NegativeAmountError extends Error {
    constructor(message: string) {
        super(message);
    }
}

class InsufficientFundsError extends Error {
    constructor(message: string) {
        super(message);
    }
}

class BankAccount {
    private owner: string;
    private balance: number;

    constructor(owner: string, initialBalance: number) {
        if (initialBalance < 0) {
            throw new NegativeAmountError("Initial balance cannot be negative");
        }
        this.owner = owner;
        this.balance = initialBalance;
    }

    public getOwner(): string {
        return this.owner;
    }

    public getBalance(): number {
        return this.balance;
    }

    public deposit(amount: number) {
        if (amount < 0) {
            throw new NegativeAmountError("Deposit amount cannot be negative");
        }
        this.balance += amount;
    }

    public withdraw(amount: number) {
        if (amount < 0) {
            throw new NegativeAmountError("Withdraw amount cannot be negative");
        }
        else if (amount > this.balance) {
            throw new InsufficientFundsError("Insufficient funds");
        }
        this.balance -= amount;
    }
}

const account = new BankAccount("John Doe", 1000);
try {
    account.deposit(500);
    account.withdraw(2000);
}
catch (error: any) {
    if (error instanceof NegativeAmountError) {
        console.log(error.message);
    }
    else if (error instanceof InsufficientFundsError) {
        console.log(error.message);
    }
    else {
        console.log(error.message);
    }
}
finally {
    console.log("Account balance: " + account.getBalance());
}