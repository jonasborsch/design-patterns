namespace Singleton;

public class Singleton
{
    private static Singleton? _instance;
    private static readonly object _lock = new object();

    // Private constructor to prevent instantiation
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Singleton();
                }
            }
            return _instance;
        }
    }

    public void DoSomething() => Console.WriteLine("Singleton instance is working.");
}

// Usage
class Program
{
    static void Main()
    {
        Singleton singleton = Singleton.Instance;
        singleton.DoSomething();
    }
}
