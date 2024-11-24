namespace Factory_Method;

// Product Interface
public interface IProduct
{
    void Use();
}

// Concrete Products
public class ConcreteProductA : IProduct
{
    public void Use() => Console.WriteLine("Using Product A");
}

public class ConcreteProductB : IProduct
{
    public void Use() => Console.WriteLine("Using Product B");
}

// Creator Abstract Class
public abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public void Operation()
    {
        var product = FactoryMethod();
        product.Use();
    }
}

// Concrete Creators
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductA();
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductB();
}

// Usage
class Program
{
    static void Main()
    {
        Creator creator = new ConcreteCreatorA();
        creator.Operation();

        creator = new ConcreteCreatorB();
        creator.Operation();
    }
}
