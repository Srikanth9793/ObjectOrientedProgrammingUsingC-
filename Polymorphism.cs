using System;

public abstract class Shape
{
    public string Color { get; set; } = "Black";

    public void SetColor(string color)
    {
        Color = color;
    }

    public abstract void Draw();
}

public class Circle : Shape {
    public double Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} Circle with radius {Radius}");
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} Rectangle with width {Width} and height {Height}");
    }
}

public class Triangle : Shape
{
    public double BaseLength { get; set; }
    public double Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} Triangle with base {BaseLength} and height {Height}");
    }
}
