using System.Text;

namespace Decorator;

// Component Interface
public interface IDataSource
{
    void WriteData(string data);
    string ReadData();
}

// Concrete Component
public class FileDataSource : IDataSource
{
    private readonly string _filename;

    public FileDataSource(string filename) => _filename = filename;

    public void WriteData(string data) => File.WriteAllText(_filename, data);
    public string ReadData() => File.ReadAllText(_filename);
}

// Base Decorator
public class DataSourceDecorator : IDataSource
{
    protected IDataSource _wrappee;

    public DataSourceDecorator(IDataSource source) => _wrappee = source;

    public virtual void WriteData(string data) => _wrappee.WriteData(data);
    public virtual string ReadData() => _wrappee.ReadData();
}

// Concrete Decorator
public class EncryptionDecorator : DataSourceDecorator
{
    public EncryptionDecorator(IDataSource source) : base(source) { }

    public override void WriteData(string data)
    {
        string encryptedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        base.WriteData(encryptedData);
    }

    public override string ReadData()
    {
        string data = base.ReadData();
        string decryptedData = Encoding.UTF8.GetString(Convert.FromBase64String(data));
        return decryptedData;
    }
}

// Usage
class Program
{
    static void Main()
    {
        IDataSource source = new FileDataSource("data.txt");
        IDataSource encryptedSource = new EncryptionDecorator(source);

        encryptedSource.WriteData("Sensitive Data");
        Console.WriteLine(encryptedSource.ReadData());
    }
}
