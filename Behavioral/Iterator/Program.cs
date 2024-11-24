namespace Iterator;

// Aggregate Interface
public interface IAggregate
{
    IIterator CreateIterator();
}

// Iterator Interface
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Concrete Aggregate
public class Collection : IAggregate
{
    private readonly List<object> _items = new List<object>();

    public void AddItem(object item) => _items.Add(item);

    public IIterator CreateIterator() => new Iterator(this);

    public int Count => _items.Count;

    public object this[int index] => _items[index];
}

// Concrete Iterator
public class Iterator : IIterator
{
    private readonly Collection _collection;
    private int _current = 0;

    public Iterator(Collection collection) => _collection = collection;

    public bool HasNext() => _current < _collection.Count;

    public object Next() => _collection[_current++];
}

// Usage
class Program
{
    static void Main()
    {
        var collection = new Collection();
        collection.AddItem("Item 1");
        collection.AddItem("Item 2");
        collection.AddItem("Item 3");

        var iterator = collection.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}
