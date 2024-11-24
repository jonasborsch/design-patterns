namespace Command;

// Command Interface
public interface ICommand
{
    void Execute();
}

// Receiver
public class Receiver
{
    public void Action() => Console.WriteLine("Receiver: Performing an action.");
}

// Concrete Command
public class ConcreteCommand : ICommand
{
    private readonly Receiver _receiver;

    public ConcreteCommand(Receiver receiver) => _receiver = receiver;

    public void Execute() => _receiver.Action();
}

// Invoker
public class Invoker
{
    private ICommand? _command;

    public void SetCommand(ICommand command) => _command = command;

    public void ExecuteCommand() => _command?.Execute();
}

// Usage
class Program
{
    static void Main()
    {
        Receiver receiver = new Receiver();
        ICommand command = new ConcreteCommand(receiver);
        Invoker invoker = new Invoker();

        invoker.SetCommand(command);
        invoker.ExecuteCommand();
    }
}
