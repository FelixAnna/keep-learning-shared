/**
 * State is a behavioral design pattern 
 * that lets an object alter its behavior when its internal state changes. 
 * It appears as if the object changed its class.
 * */
public class State
{
    public static void Run()
    {
        var machine = new StateMachine(new InitialState());

        machine.DoAction();
        machine.DoAction();
        machine.DoAction();
        machine.DoAction();
    }
}

file interface IState
{
    void Handle();
}

file class InitialState : IState
{
    public void Handle()
    {
        Console.WriteLine($"{nameof(InitialState)}");
    }
}

file class MiddleState : IState
{
    public void Handle()
    {
        Console.WriteLine($"{nameof(MiddleState)}");
    }
}

file class FinishedState : IState
{
    public void Handle()
    {
        Console.WriteLine($"{nameof(FinishedState)}");
    }
}

file class StateMachine
{
    private IState State;

    public StateMachine(IState state)
    {
        State = state;
    }

    public void DoAction()
    {
        State.Handle();

        switch (State)
        {
            case InitialState _:
                State = new MiddleState();
                break;
            case MiddleState _:
                State = new FinishedState();
                break;
            case FinishedState _:
                State = new InitialState();
                break;
            default:
                break;
        }
    }
}