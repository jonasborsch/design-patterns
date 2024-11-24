namespace Memento;

// Memento
public class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

// Originator
public class Originator
{
    public string State { get; set; }

    public Memento Save()
    {
        return new Memento(State);
    }

    public void Restore(Memento memento)
    {
        State = memento.State;
    }
}

// Caretaker
public class Caretaker
{
    private readonly List<Memento> _history = new List<Memento>();
    private Originator _originator;

    public Caretaker(Originator originator)
    {
        _originator = originator;
    }

    public void Backup()
    {
        Console.WriteLine("Saving state...");
        _history.Add(_originator.Save());
    }

    public void Undo()
    {
        if (_history.Count == 0) return;

        var memento = _history.Last();
        _history.Remove(memento);

        Console.WriteLine("Restoring state...");
        _originator.Restore(memento);
    }

    public void ShowHistory()
    {
        Console.WriteLine("History:");
        foreach (var memento in _history)
        {
            Console.WriteLine(memento.State);
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker(originator);

        originator.State = "State1";
        caretaker.Backup();

        originator.State = "State2";
        caretaker.Backup();

        originator.State = "State3";
        caretaker.Backup();

        Console.WriteLine($"Current State: {originator.State}");

        caretaker.Undo();
        Console.WriteLine($"Restored State: {originator.State}");

        caretaker.Undo();
        Console.WriteLine($"Restored State: {originator.State}");
    }
}
