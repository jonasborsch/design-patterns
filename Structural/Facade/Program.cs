namespace Facade;

// Subsystem Classes
public class SubsystemA
{
    public void OperationA() => Console.WriteLine("Subsystem A Operation");
}

public class SubsystemB
{
    public void OperationB() => Console.WriteLine("Subsystem B Operation");
}

public class SubsystemC
{
    public void OperationC() => Console.WriteLine("Subsystem C Operation");
}

// Facade
public class Facade
{
    private readonly SubsystemA _a;
    private readonly SubsystemB _b;
    private readonly SubsystemC _c;

    public Facade()
    {
        _a = new SubsystemA();
        _b = new SubsystemB();
        _c = new SubsystemC();
    }

    public void Operation()
    {
        Console.WriteLine("Facade initializes subsystems:");
        _a.OperationA();
        _b.OperationB();
        _c.OperationC();
    }
}

// Usage
class Program
{
    static void Main()
    {
        Facade facade = new Facade();
        facade.Operation();
    }
}
