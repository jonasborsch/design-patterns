namespace Bridge;

// Implementor Interface
public interface IDevice
{
    bool IsEnabled { get; }
    void Enable();
    void Disable();
    int Volume { get; set; }
}

// Concrete Implementor
public class TV : IDevice
{
    public bool IsEnabled { get; private set; }
    public int Volume { get; set; }

    public void Enable() => IsEnabled = true;
    public void Disable() => IsEnabled = false;
}

// Abstraction
public class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice device) => _device = device;

    public void TogglePower()
    {
        if (_device.IsEnabled)
            _device.Disable();
        else
            _device.Enable();
    }
}

// Refined Abstraction
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device) { }

    public void Mute() => _device.Volume = 0;
}

// Usage
class Program
{
    static void Main()
    {
        IDevice tv = new TV();
        AdvancedRemoteControl remote = new AdvancedRemoteControl(tv);

        remote.TogglePower();
        remote.Mute();

        Console.WriteLine($"TV is on: {tv.IsEnabled}, Volume: {tv.Volume}");
    }
}
