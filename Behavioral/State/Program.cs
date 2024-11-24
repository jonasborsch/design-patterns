namespace State;

// State Interface
public interface IState
{
    void Handle(Context context);
}

// Concrete States
public class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("ConcreteStateA handles request.");
        context.State = new ConcreteStateB();
    }
}

public class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("ConcreteStateB handles request.");
        context.State = new ConcreteStateA();
    }
}

// Context
public class Context
{
    public IState State { get; set; }

    public Context(IState state)
    {
        State = state;
    }

    public void Request()
    {
        State.Handle(this);
    }
}

// Usage
class Program
{
    static void Main()
    {
        var context = new Context(new ConcreteStateA());

        context.Request();
        context.Request();
        context.Request();
        context.Request();
    }
}
