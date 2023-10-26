namespace SeleniumTest.DesignPatterns;

/**
 * Bridge is a structural design pattern 
 * that lets you split a large class or a set of closely related classes into two separate hierarchies ( abstraction and implementation )
 * which can be developed independently of each other.
 * */
internal class Bridge
{
    public static void Run()
    {
        var blueAbstraction = new Abstraction(new Blue());

        var text = "Test Bridge";
        blueAbstraction.DrawLight(text);
        blueAbstraction.DrawDeep(text);

        Console.ResetColor();
    }
}

file class Abstraction
{
    private readonly IImplementation implementation;

    public Abstraction(IImplementation implementation)
    {
        this.implementation = implementation;
    }

    public void DrawLight(string text)
    {
        Console.BackgroundColor = implementation.GetLightColor();
        Console.WriteLine(text);
    }

    public void DrawDeep(string text)
    {
        Console.BackgroundColor = implementation.GetDeepColor();
        Console.WriteLine(text);
    }
}

file interface IImplementation
{
    ConsoleColor GetLightColor();

    ConsoleColor GetDeepColor();
}

file class Blue : IImplementation
{
    public ConsoleColor GetDeepColor()
    {
        return ConsoleColor.DarkBlue;
    }

    public ConsoleColor GetLightColor()
    {
        return ConsoleColor.Blue;
    }
}
