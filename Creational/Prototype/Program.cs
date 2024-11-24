namespace Prototype;

// Prototype Interface
public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }

    public Shape() { }

    public Shape(Shape source)
    {
        X = source.X;
        Y = source.Y;
    }

    public abstract Shape Clone();
}

// Concrete Prototype
public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle() { }

    public Circle(Circle source) : base(source)
    {
        Radius = source.Radius;
    }

    public override Shape Clone() => new Circle(this);
}

// Usage
class Program
{
    static void Main()
    {
        Circle original = new Circle { X = 5, Y = 10, Radius = 15 };
        Circle clone = (Circle)original.Clone();

        Console.WriteLine($"Original Circle: X={original.X}, Y={original.Y}, Radius={original.Radius}");
        Console.WriteLine($"Cloned Circle: X={clone.X}, Y={clone.Y}, Radius={clone.Radius}");
    }
}
