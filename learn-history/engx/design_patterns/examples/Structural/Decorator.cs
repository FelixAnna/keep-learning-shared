/**
 * Decorator is a structural design pattern 
 * that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.
 * */
internal class DecoratorTester
{
    public static void Run()
    {
        var notifier = new AlipayNotifierDecorator(
            new WechatNotifierDecorator(
                new ConcreteNotifier()
                )
            );
        notifier.Notify("Hello");
    }
}

file interface INotifier
{
    void Notify(string message);
}

file class ConcreteNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"from: {nameof(ConcreteNotifier)}: {message}");
    }
}

file abstract class BaseNotifierDecorator : INotifier
{
    protected readonly INotifier notifier;

    public BaseNotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void Notify(string message)
    {
        notifier.Notify(message);
        Console.WriteLine($"from: {nameof(BaseNotifierDecorator)}: {message}");
    }
}

file class WechatNotifierDecorator : BaseNotifierDecorator
{
    public WechatNotifierDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Notify(string message)
    {
        base.Notify(message);
        Console.WriteLine($"from: {nameof(WechatNotifierDecorator)}: {message}");
    }
}

file class AlipayNotifierDecorator : BaseNotifierDecorator
{
    public AlipayNotifierDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Notify(string message)
    {
        base.Notify(message);
        Console.WriteLine($"from: {nameof(AlipayNotifierDecorator)}: {message}");
    }
}
