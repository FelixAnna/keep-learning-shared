/**
 * Observer is a behavioral design pattern 
 * that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.
 * */
public class Observer
{
    public static void Run()
    {
        var subject = new Subject();

        var screenListener = new ScreenListener(subject);
        var encodedListener = new EncodedListener(subject);

        subject.SetMessage("Hello");
        subject.SetMessage("something is ready");
    }
}

file class Subject
{
    private List<IListener> listeners;

    public Subject() {
        listeners = new List<IListener>();
    }

    public void Subscribe(IListener listener)
    {
        listeners.Add(listener);
    }

    public void SetMessage(string message)
    {
        Console.WriteLine(message);
        NotifySubscribers(message);
    }

    private void NotifySubscribers(string message)
    {
        foreach (var listener in listeners)
        {
            listener.Update(message);
        }
    }
}

file interface IListener
{
    void Update(string message);
}

file abstract class Listener : IListener {
    protected Subject subject;

    public Listener(Subject subject)
    {
        this.subject = subject;
        subject.Subscribe(this);
    }

    public abstract void Update(string message);
}


file class ScreenListener : Listener
{
    public ScreenListener(Subject subject) : base(subject)
    {
    }

    public override void Update(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Screen: {message}");
        Console.ResetColor();
    }
}

file class EncodedListener : Listener
{
    public EncodedListener(Subject subject) : base(subject)
    {
    }

    public override void Update(string message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"Encoded: {message.GetHashCode()}");
        Console.ResetColor();
    }
}
