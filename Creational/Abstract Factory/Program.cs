namespace Abstract_Factory;

// Abstract Product Interfaces
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

// Concrete Products for Windows
public class WinButton : IButton
{
    public void Render() => Console.WriteLine("Render Windows Button");
}

public class WinCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Render Windows Checkbox");
}

// Concrete Products for Mac
public class MacButton : IButton
{
    public void Render() => Console.WriteLine("Render Mac Button");
}

public class MacCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Render Mac Checkbox");
}

// Abstract Factory Interface
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WinFactory : IGUIFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Client
public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Render()
    {
        _button.Render();
        _checkbox.Render();
    }
}

// Usage
class Program
{
    static void Main()
    {
        IGUIFactory factory;

        // Assume we get the OS type from configuration
        string osType = "Windows";

        if (osType == "Windows")
            factory = new WinFactory();
        else
            factory = new MacFactory();

        var app = new Application(factory);
        app.Render();
    }
}
