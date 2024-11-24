namespace Proxy;

// Subject Interface
public interface ISubject
{
    void Request();
}

// Real Subject
public class RealSubject : ISubject
{
    public void Request() => Console.WriteLine("RealSubject: Handling Request.");
}

// Proxy
public class Proxy : ISubject
{
    private RealSubject? _realSubject;

    public void Request()
    {
        if (CheckAccess())
        {
            _realSubject = new RealSubject();
            _realSubject.Request();
            LogAccess();
        }
    }

    private bool CheckAccess()
    {
        Console.WriteLine("Proxy: Checking access prior to firing a real request.");
        return true;
    }

    private void LogAccess() => Console.WriteLine("Proxy: Logging the time of request.");
}

// Usage
class Program
{
    static void Main()
    {
        ISubject proxy = new Proxy();
        proxy.Request();
    }
}
