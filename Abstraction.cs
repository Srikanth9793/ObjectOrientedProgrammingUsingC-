using System;

// Abstract class — defines what actions a Vehicle can do
public abstract class Vehicle {
    // Abstract methods
    // By default abstract methods are virtual
    public abstract void Start();
    public abstract void Stop();

    // Non Abstract methods
    public void FuelStatus() {
        Console.WriteLine("Fuel level: OK");
    }
}

public class Car : Vehicle {
    public override void Start() {
        Console.WriteLine("Car started with key ignition.");
    }

    public override void Stop() {
        Console.WriteLine("Car stopped safely.");
    }
}

public class ElectricScooter : Vehicle {
    public override void Start() {
        Console.WriteLine("Scooter started with a power button.");
    }

    public override void Stop() {
        Console.WriteLine("Scooter powered off.");
    }
}
