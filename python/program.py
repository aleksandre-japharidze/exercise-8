class NegativeAmountError(Exception):
    def __init__(self, amount):
        self.amount = amount
        super().__init__(f"Negative amount error: {amount} is not allowed.")

class InsufficientFundsError(Exception):
    def __init__(self, balance, amount):
        self.balance = balance
        self.amount = amount
        super().__init__(f"Insufficient funds: Cannot withdraw {amount} from balance of {balance}.")

class BankAccount:
    def __init__(self, owner, initial_balance=0):
        if initial_balance < 0:
            raise NegativeAmountError(initial_balance)
        self.__owner = owner
        self.__balance = initial_balance

    def deposit(self, amount):
        if amount < 0:
            raise NegativeAmountError(amount)
        self.__balance += amount

    def withdraw(self, amount):
        if amount < 0:
            raise NegativeAmountError(amount)
        if amount > self.balance:
            raise InsufficientFundsError(self.balance, amount)
        self.balance -= amount

bank_account = BankAccount("Alice", 1000)
try:
    bank_account.deposit(500)
    print(f"Deposit successful. New balance: {bank_account._BankAccount__balance}")
    bank_account.withdraw(2000)
except NegativeAmountError as nae:
    print(nae)
except InsufficientFundsError as ife:
    print(ife)
finally:
    print(f"Final balance: {bank_account._BankAccount__balance}")