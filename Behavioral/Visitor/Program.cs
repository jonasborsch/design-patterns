namespace Visitor;

// Visitor Interface
public interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA elementA);
    void VisitConcreteElementB(ConcreteElementB elementB);
}

// Element Interface
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete Elements
public class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public string ExclusiveMethodOfConcreteElementA()
    {
        return "A";
    }
}

public class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public string SpecialMethodOfConcreteElementB()
    {
        return "B";
    }
}

// Concrete Visitors
public class ConcreteVisitor1 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA elementA)
    {
        Console.WriteLine($"{elementA.ExclusiveMethodOfConcreteElementA()} + ConcreteVisitor1");
    }

    public void VisitConcreteElementB(ConcreteElementB elementB)
    {
        Console.WriteLine($"{elementB.SpecialMethodOfConcreteElementB()} + ConcreteVisitor1");
    }
}

public class ConcreteVisitor2 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA elementA)
    {
        Console.WriteLine($"{elementA.ExclusiveMethodOfConcreteElementA()} + ConcreteVisitor2");
    }

    public void VisitConcreteElementB(ConcreteElementB elementB)
    {
        Console.WriteLine($"{elementB.SpecialMethodOfConcreteElementB()} + ConcreteVisitor2");
    }
}

// Object Structure
public class ObjectStructure
{
    private List<IElement> _elements = new List<IElement>();

    public void Attach(IElement element)
    {
        _elements.Add(element);
    }

    public void Detach(IElement element)
    {
        _elements.Remove(element);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var element in _elements)
        {
            element.Accept(visitor);
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var objectStructure = new ObjectStructure();
        objectStructure.Attach(new ConcreteElementA());
        objectStructure.Attach(new ConcreteElementB());

        var visitor1 = new ConcreteVisitor1();
        var visitor2 = new ConcreteVisitor2();

        Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
        objectStructure.Accept(visitor1);

        Console.WriteLine();

        objectStructure.Accept(visitor2);
    }
}
