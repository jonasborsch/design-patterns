namespace Adapter;

// Target Interface
public interface ITarget
{
    string GetRequest();
}

// Adaptee Class
public class Adaptee
{
    public string GetSpecificRequest() => "Specific request.";
}

// Adapter Class
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee) => _adaptee = adaptee;

    public string GetRequest() => $"This is '{_adaptee.GetSpecificRequest()}'";
}

// Usage
class Program
{
    static void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine(target.GetRequest());
    }
}
