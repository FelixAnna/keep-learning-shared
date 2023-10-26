/**
 * Command is a behavioral design pattern 
 * that turns a request into a stand-alone object that contains all information about the request. 
 * This transformation lets you pass requests as a method arguments, delay or queue a request’s execution, and support undoable operations.
 * */
public class Command
{
    public static void Run()
    {
        var commands = GetCommand(5);
        var history = new Stack<ICommand>();

        foreach(var cmd in commands)
        {
            cmd.Execute();
            history.Push(cmd);
        }

        foreach(var cmd in history)
        {
            cmd.Undo();
        }
    }

    private static IEnumerable<ICommand> GetCommand(int count)
    {
        for (int i = 0; i<count; i++)
        {
            switch (i % 3)
            {
                case 0:
                    yield return new CopyCommand();
                    break;
                case 1:
                    yield return new PasteCommand();
                    break;
                default:
                    yield return new DeleteCommand();
                    break;
            }
        }
    }
}

interface ICommand
{
    void Undo();
    void Execute();
}

file class CopyCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{nameof(Execute)}: {nameof(CopyCommand)}");
    }

    public void Undo()
    {
        Console.WriteLine($"{nameof(Undo)}: {nameof(CopyCommand)}");
    }
}

file class PasteCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{nameof(Execute)}: {nameof(PasteCommand)}");
    }

    public void Undo()
    {
        Console.WriteLine($"{nameof(Undo)}: {nameof(PasteCommand)}");
    }
}

file class DeleteCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{nameof(Execute)}: {nameof(DeleteCommand)}");
    }

    public void Undo()
    {
        Console.WriteLine($"{nameof(Undo)}: {nameof(DeleteCommand)}");
    }
}

