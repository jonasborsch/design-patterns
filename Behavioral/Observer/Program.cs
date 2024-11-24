namespace Observer;

// Subject Interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
public class Subject : ISubject
{
    public int State { get; set; } = 0;

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached an observer.");
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        Console.WriteLine("Subject: Detached an observer.");
        _observers.Remove(observer);
    }

    public void Notify()
    {
        Console.WriteLine("Subject: Notifying observers...");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("\nSubject: I'm doing something important.");
        State = new Random().Next(0, 10);

        Console.WriteLine($"Subject: My state has just changed to: {State}");
        Notify();
    }
}

// Observer Interface
public interface IObserver
{
    void Update(ISubject subject);
}

// Concrete Observers
public class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State < 5)
        {
            Console.WriteLine("ConcreteObserverA: Reacted to the event.");
        }
    }
}

public class ConcreteObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State >= 5)
        {
            Console.WriteLine("ConcreteObserverB: Reacted to the event.");
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var subject = new Subject();

        var observerA = new ConcreteObserverA();
        subject.Attach(observerA);

        var observerB = new ConcreteObserverB();
        subject.Attach(observerB);

        subject.SomeBusinessLogic();
        subject.SomeBusinessLogic();

        subject.Detach(observerB);

        subject.SomeBusinessLogic();
    }
}
