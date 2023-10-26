/**
 * Facade is a structural design pattern 
 * that provides a simplified interface to a library, a framework, or any other complex set of classes.
 * */
public class Facade
{
    public static void Run()
    {
        var controlEngine = new ControlEngine();

        Console.WriteLine("Start：");
        controlEngine.Start();

        controlEngine.Stop();
        Console.WriteLine("Stop.");
    }
}

file class ControlEngine
{
    private readonly IEngine _engine;
    private readonly IPlayer _player;
    private readonly ISwitch _switch;
    public ControlEngine() {
        _engine = new DriverEngine();
        _player = new MusicPlayer();
        _switch = new LightSwitch(); 
    }
    public void Start() {
        _engine.Start();
        _switch.TurnOn();
        _player.Play();
    }

    public void Stop()
    {
        _player.Close();
        _switch.TurnOff();
        _engine.Stop();
    }
}

file interface ISwitch
{
    void TurnOn();
    void TurnOff();
}

file interface IEngine
{
    void Start();
    void Stop();
}

file interface IPlayer
{
    void Play();
    void Close();
}

file class LightSwitch : ISwitch
{
    public void TurnOn()
    {
        Console.WriteLine($"{nameof(LightSwitch)}.{nameof(TurnOn)} called.");
    }
    public void TurnOff()
    {
        Console.WriteLine($"{nameof(LightSwitch)}.{nameof(TurnOff)} called.");
    }
}

file class MusicPlayer : IPlayer
{
    public void Play()
    {
        Console.WriteLine($"{nameof(MusicPlayer)}.{nameof(Play)} called.");
    }
    public void Close()
    {
        Console.WriteLine($"{nameof(MusicPlayer)}.{nameof(Close)} called.");
    }
}

file class DriverEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine($"{nameof(DriverEngine)}.{nameof(Start)} called.");
    }
    public void Stop()
    {
        Console.WriteLine($"{nameof(DriverEngine)}.{nameof(Stop)} called.");
    }
}
