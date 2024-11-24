namespace Chain_of_Responsibility;

// Handler Interface
public abstract class Handler
{
    protected Handler? _nextHandler;

    public void SetNext(Handler handler) => _nextHandler = handler;

    public abstract void Handle(string request);
}

// Concrete Handlers
public class ConcreteHandlerA : Handler
{
    public override void Handle(string request)
    {
        if (request == "A")
            Console.WriteLine("Handler A handled the request.");
        else
            _nextHandler?.Handle(request);
    }
}

public class ConcreteHandlerB : Handler
{
    public override void Handle(string request)
    {
        if (request == "B")
            Console.WriteLine("Handler B handled the request.");
        else
            _nextHandler?.Handle(request);
    }
}

// Usage
class Program
{
    static void Main()
    {
        var handlerA = new ConcreteHandlerA();
        var handlerB = new ConcreteHandlerB();

        handlerA.SetNext(handlerB);

        handlerA.Handle("B");
    }
}
