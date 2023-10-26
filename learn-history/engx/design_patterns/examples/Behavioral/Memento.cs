/**
 * Memento is a behavioral design pattern 
 * that lets you save and restore the previous state of an object without revealing the details of its implementation.
 * */
public class MementoTester
{
    public static void Run()
    {
        var careTake = new Caretaker();
        careTake.Append("a");
        careTake.Append("b");
        careTake.Append("c");

        careTake.Undo();
        careTake.Undo();
        careTake.Undo();
    }
}

file class Originator
{
    public string State { get; set; }

    public Originator(string state)
    {
        State = state;
    }

    public Memento SaveSnapshot()
    {
        return new Memento(State);
    }

    public void RestoreSnapshot(Memento memento)
    {
        State = memento.State;
    }

    public record struct Memento(string State);
}


file class Caretaker
{
    private Originator originator;
    private Stack<Memento> mementoList;

    public Caretaker()
    {
        originator = new Originator(string.Empty);
        mementoList = new Stack<Memento>();
    }

    public void Append(string text)
    {
        mementoList.Push(originator.SaveSnapshot());

        originator.State += text;
        Console.WriteLine($"originator is: {originator.State}");
    }

    public void Undo()
    {
        originator.RestoreSnapshot(mementoList.Pop());

        Console.WriteLine($"originator is: {originator.State}");
    }
}