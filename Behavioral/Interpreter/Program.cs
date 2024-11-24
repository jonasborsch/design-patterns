namespace Interpreter;

// Abstract Expression
public interface IExpression
{
    int Interpret();
}

// Terminal Expression
public class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number) => _number = number;

    public int Interpret() => _number;
}

// Nonterminal Expression
public class AddExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public AddExpression(IExpression left, IExpression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }

    public int Interpret() => _leftExpression.Interpret() + _rightExpression.Interpret();
}

// Usage
class Program
{
    static void Main()
    {
        IExpression expression = new AddExpression(new NumberExpression(5), new NumberExpression(10));
        Console.WriteLine($"Result: {expression.Interpret()}");
    }
}
