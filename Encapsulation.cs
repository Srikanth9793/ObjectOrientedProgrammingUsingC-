using System;

public class BankAccount {
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount) {
        if (amount <= 0) {
            throw new ArgumentNullException("Invalid. Amount should be positive");
        }
            
        Balance += amount;
        Console.WriteLine($"Deposited amount: {amount} and Current Balance is: {Balance}");
    }

    public void WithDrawAmount(decimal amount) {
        if (amount <= 0) {
            throw new ArgumentNullException("Invalid. Amount should be positive");
        }

        if (Balance <= amount) {
            throw new ArgumentNullException("Insufficient Balance");
        }

        Balance -= amount;
        Console.WriteLine($"Withdrawal Amount: {amount} and Avaliable Balance: {Balance}");
    }

    
}