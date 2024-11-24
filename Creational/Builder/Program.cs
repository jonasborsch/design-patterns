namespace Builder;

// Product
public class House
{
    public string? Walls { get; set; }
    public string? Roof { get; set; }
    public string? Doors { get; set; }
    public string? Windows { get; set; }
}

// Builder Interface
public interface IHouseBuilder
{
    void BuildWalls();
    void BuildRoof();
    void BuildDoors();
    void BuildWindows();
    House GetHouse();
}

// Concrete Builder
public class StoneHouseBuilder : IHouseBuilder
{
    private readonly House _house = new();

    public void BuildWalls() => _house.Walls = "Stone Walls";
    public void BuildRoof() => _house.Roof = "Stone Roof";
    public void BuildDoors() => _house.Doors = "Wooden Doors";
    public void BuildWindows() => _house.Windows = "Glass Windows";
    public House GetHouse() => _house;
}

// Director
public class Engineer
{
    private readonly IHouseBuilder _builder;

    public Engineer(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructHouse()
    {
        _builder.BuildWalls();
        _builder.BuildRoof();
        _builder.BuildDoors();
        _builder.BuildWindows();
    }
}

// Usage
class Program
{
    static void Main()
    {
        var builder = new StoneHouseBuilder();
        var engineer = new Engineer(builder);
        engineer.ConstructHouse();
        var house = builder.GetHouse();

        Console.WriteLine($"House built with: {house.Walls}, {house.Roof}, {house.Doors}, {house.Windows}");
    }
}
