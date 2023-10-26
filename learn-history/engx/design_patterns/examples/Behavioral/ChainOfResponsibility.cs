/**
 * Chain of Responsibility is a behavioral design pattern that lets you pass requests along a chain of handlers. 
 * Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
 * */
public class ChainOfResponsibility
{
    public static void Run()
    {
        var authHandler = new AuthenticationHandler();
        var cacheHandler = new CacheHandler();
        var controller = new ControllerHandler();
        authHandler.SetNext(cacheHandler).SetNext(cacheHandler).SetNext(controller);

        authHandler.Execute("admin user");
        authHandler.Execute("admin user");
        authHandler.Execute("annoymous user");
    }
}

file interface IHandler
{
    IHandler SetNext(IHandler hander);
    void Execute(string argument)
    {
        Console.WriteLine($"Default implementation: {argument}");
    }
}

file abstract class AbstractHandler : IHandler
{
    protected IHandler? _handler;
    public IHandler SetNext(IHandler hander)
    {
        _handler = hander;
        return _handler;
    }
    public virtual void Execute(string argument)
    {
        if (_handler != null)
        {
            _handler.Execute(argument);
            return;
        }
    }
}

file class ControllerHandler : AbstractHandler
{
    public override void Execute(string argument)
    {
        Console.WriteLine($"{nameof(ControllerHandler)} implementation: {argument}");
    }
}

file class CacheHandler : AbstractHandler
{
    Dictionary<string, string> _cache = new Dictionary<string, string>();
    public override void Execute(string argument)
    {
        Console.WriteLine($"Entered: {nameof(CacheHandler)}");
        if (_cache.ContainsKey(argument))
        {
            Console.WriteLine($"Found by {nameof(CacheHandler)} in cache: {argument}");
            return;
        }

        _cache.Add(argument, argument);
        base.Execute(argument);
    }
}

file class AuthenticationHandler : AbstractHandler
{
    public override void Execute(string argument)
    {
        Console.WriteLine($"Entered: {nameof(AuthenticationHandler)}");
        if (!argument.Contains("admin"))
        {
            Console.WriteLine($"Authenticate by {nameof(AuthenticationHandler)} failed: {argument}");
            return;
        }

        base.Execute(argument);
    }
}
