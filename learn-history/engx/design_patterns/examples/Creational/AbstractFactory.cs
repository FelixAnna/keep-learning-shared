/**
* Abstract Factory Method is a creational design pattern,
* that lets you produce families of related objects without specifying their concrete classes.
* */
public class AbstractFactoryTester
{
    public static void Run()
    {
        IFactory woodenFactory = new WoodenFactory();
        IFactory metalFactory = new MetalFactory();

        var woodenProductA = woodenFactory.CreateProductA();
        var woodenProductB = woodenFactory.CreateProductB();
        var metalProductA = metalFactory.CreateProductA();
        var metalProductB = metalFactory.CreateProductB();

        Console.WriteLine($"Wooden product A: {woodenProductA.Name}, {woodenProductA.Price}");
        Console.WriteLine($"Wooden product B: {woodenProductB.Name}, {woodenProductB.Price}");
        Console.WriteLine($"Metal product A: {metalProductA.Name}, {metalProductA.Price}");
        Console.WriteLine($"Metal product B: {metalProductB.Name}, {metalProductB.Price}");
    }
}

file interface IFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

file class WoodenFactory : IFactory
{
    public virtual IProductA CreateProductA() => new WoodenProductA() { Name = "WoodenA", Price = 100 };
    public virtual IProductB CreateProductB() => new WoodenProductB() { Name = "WoodenB", Price = 200 };
}

file class MetalFactory : IFactory
{

    public virtual IProductA CreateProductA() => new WoodenProductA() { Name = "MetalA", Price = 300 };
    public virtual IProductB CreateProductB() => new WoodenProductB() { Name = "MetalnB", Price = 400 };
}

file interface IProductA
{
    string Name { get; set; }
    float Price { get; set; }
}

file interface IProductB
{
    string Name { get; set; }
    float Price { get; set; }
}


file class WoodenProductA : IProductA
{
    public string Name { get; set; }
    public float Price { get; set; }
}

file class MetalProductA : IProductA
{
    public string Name { get; set; }
    public float Price { get; set; }
}

file class WoodenProductB : IProductB
{
    public string Name { get; set; }
    public float Price { get; set; } = 1.0f;
}

file class MetalProductB : IProductB
{
    public string Name { get; set; }
    public float Price { get; set; } = 1.0f;
}
