namespace Composite;

// Component Interface
public interface IGraphic
{
    void Draw();
}

// Leaf
public class Circle : IGraphic
{
    public void Draw() => Console.WriteLine("Drawing Circle");
}

// Composite
public class CompositeGraphic : IGraphic
{
    private readonly List<IGraphic> _graphics = new List<IGraphic>();

    public void Add(IGraphic graphic) => _graphics.Add(graphic);
    public void Remove(IGraphic graphic) => _graphics.Remove(graphic);

    public void Draw()
    {
        foreach (var graphic in _graphics)
        {
            graphic.Draw();
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var circle1 = new Circle();
        var circle2 = new Circle();

        var composite = new CompositeGraphic();
        composite.Add(circle1);
        composite.Add(circle2);

        composite.Draw();
    }
}
