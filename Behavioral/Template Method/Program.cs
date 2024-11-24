namespace Template_Method;

// Abstract Class
public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        BaseOperation1();
        RequiredOperation1();
        BaseOperation2();
        Hook1();
        RequiredOperation2();
        BaseOperation3();
        Hook2();
    }

    protected void BaseOperation1()
    {
        Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
    }

    protected void BaseOperation2()
    {
        Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
    }

    protected void BaseOperation3()
    {
        Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");
    }

    protected abstract void RequiredOperation1();
    protected abstract void RequiredOperation2();

    protected virtual void Hook1() { }
    protected virtual void Hook2() { }
}

// Concrete Classes
public class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass1 says: Implemented Operation1");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass1 says: Implemented Operation2");
    }
}

public class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass2 says: Implemented Operation1");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass2 says: Implemented Operation2");
    }

    protected override void Hook1()
    {
        Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Console.WriteLine("Same client code can work with different subclasses:");

        var concreteClass1 = new ConcreteClass1();
        concreteClass1.TemplateMethod();

        Console.WriteLine();

        var concreteClass2 = new ConcreteClass2();
        concreteClass2.TemplateMethod();
    }
}
