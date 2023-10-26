/**
 * Strategy is a behavioral design pattern 
 * that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.
 * */
public class Strategy
{
    public static void Run()
    {
        var context = new Context(new PlayStrategy());
        context.ExecuteStrategy();

        context.SetStrategy(new SleepStrategy());
        context.ExecuteStrategy();

        context.SetStrategy(new StudyStrategy());
        context.ExecuteStrategy();
    }
}

file class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}

file interface IStrategy
{
    void Execute();
}

file class PlayStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("I like to play");
    }
}

file class StudyStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("I like to study");
    }
}

file class SleepStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("I like sleeping");
    }
}