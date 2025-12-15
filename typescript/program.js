var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var NegativeAmountError = /** @class */ (function (_super) {
    __extends(NegativeAmountError, _super);
    function NegativeAmountError(message) {
        return _super.call(this, message) || this;
    }
    return NegativeAmountError;
}(Error));
var InsufficientFundsError = /** @class */ (function (_super) {
    __extends(InsufficientFundsError, _super);
    function InsufficientFundsError(message) {
        return _super.call(this, message) || this;
    }
    return InsufficientFundsError;
}(Error));
var BankAccount = /** @class */ (function () {
    function BankAccount(owner, initialBalance) {
        if (initialBalance < 0) {
            throw new NegativeAmountError("Initial balance cannot be negative");
        }
        this.owner = owner;
        this.balance = initialBalance;
    }
    BankAccount.prototype.getOwner = function () {
        return this.owner;
    };
    BankAccount.prototype.getBalance = function () {
        return this.balance;
    };
    BankAccount.prototype.deposit = function (amount) {
        if (amount < 0) {
            throw new NegativeAmountError("Deposit amount cannot be negative");
        }
        this.balance += amount;
    };
    BankAccount.prototype.withdraw = function (amount) {
        if (amount < 0) {
            throw new NegativeAmountError("Withdraw amount cannot be negative");
        }
        else if (amount > this.balance) {
            throw new InsufficientFundsError("Insufficient funds");
        }
        this.balance -= amount;
    };
    return BankAccount;
}());
var account = new BankAccount("John Doe", 1000);
try {
    account.deposit(500);
    account.withdraw(2000);
}
catch (error) {
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
