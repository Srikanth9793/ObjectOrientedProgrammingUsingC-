using System;

namespace OOPS {
    class Program {

        public static void Main(string[] args) {

            // Encapsulation
            BankAccount ob = new BankAccount();
            ob.Deposit(10000);
            ob.WithDrawAmount(200);

            // Abstraction
            Vehicle car = new Car();
            Vehicle scooter = new ElectricScooter();

            car.Start();       // You don't care HOW it starts
            car.FuelStatus();  // Shared method
            car.Stop();

            scooter.Start();
            scooter.Stop();

            // Inheritance
            Payment payment1 = new CreditCardPayment { Amount = 150.75m, CardNumber = "**** **** **** 1234" };
            Payment payment2 = new PayPalPayment { Amount = 89.99m, Email = "user@example.com" };
            Payment payment3 = new BankTransferPayment { Amount = 500.00m, AccountNumber = "1234567890" };

            payment1.GenerateTransactionId();
            payment1.ProcessPayment();

            Console.WriteLine();

            payment2.GenerateTransactionId();
            payment2.ProcessPayment();

            Console.WriteLine();

            payment3.GenerateTransactionId();
            payment3.ProcessPayment();

            // Polymorphism
            // We create different shapes, but store them all as Shape
            Shape[] shapes = new Shape[]
            {
                new Circle { Radius = 5, Color = "Red" },
                new Rectangle { Width = 10, Height = 4, Color = "Blue" },
                new Triangle { BaseLength = 8, Height = 6, Color = "Green" }
            };

            // Polymorphism: the same method call behaves differently
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}