namespace Flyweight;

// Flyweight Interface
public interface ITreeType
{
    void Draw(int x, int y);
}

// Concrete Flyweight
public class TreeType : ITreeType
{
    private readonly string _name;
    private readonly string _color;
    private readonly string _texture;

    public TreeType(string name, string color, string texture)
    {
        _name = name;
        _color = color;
        _texture = texture;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing {_name} tree at ({x}, {y}) with color {_color} and texture {_texture}");
    }
}

// Flyweight Factory
public class TreeFactory
{
    private static Dictionary<string, ITreeType> _treeTypes = new Dictionary<string, ITreeType>();

    public static ITreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";
        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }
        return _treeTypes[key];
    }
}

// Context
public class Tree
{
    private int _x, _y;
    private ITreeType _type;

    public Tree(int x, int y, ITreeType type)
    {
        _x = x;
        _y = y;
        _type = type;
    }

    public void Draw() => _type.Draw(_x, _y);
}

// Usage
class Program
{
    static void Main()
    {
        List<Tree> forest = new List<Tree>();

        // Create many trees with shared TreeType objects
        for (int i = 0; i < 1000; i++)
        {
            ITreeType type = TreeFactory.GetTreeType("Pine", "Green", "Rough");
            Tree tree = new Tree(i, i * 2, type);
            forest.Add(tree);
        }

        // Draw the forest
        foreach (var tree in forest)
        {
            tree.Draw();
        }
    }
}
