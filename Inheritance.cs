using System;

public abstract class Payment {
    public decimal Amount {get; set;}
    public string TranscationId { get; private set; } = default!;

    public void GenerateTransactionId() {
        TranscationId = Guid.NewGuid().ToString();
        Console.WriteLine($"Transcation Id: {TranscationId}");
    }

    public abstract void ProcessPayment();

}

public class CreditCardPayment : Payment {
    public string CardNumber { get; set; } = default!;

    public override void ProcessPayment() {
        Console.WriteLine("Processing Credit Card Payment...");
        Console.WriteLine($"Charging card: {CardNumber}");
        Console.WriteLine($"Amount: ${Amount}");
    }

}

public class PayPalPayment : Payment
{
    public string Email { get; set; } = default!;

    public override void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal Payment...");
        Console.WriteLine($"Paying through account: {Email}");
        Console.WriteLine($"Amount: ${Amount}");
    }
}


public class BankTransferPayment : Payment
{
    public string AccountNumber { get; set; } = default!;

    public override void ProcessPayment()
    {
        Console.WriteLine("Processing Bank Transfer...");
        Console.WriteLine($"Transferring from account: {AccountNumber}");
        Console.WriteLine($"Amount: ${Amount}");
    }
}
