/**
* Factory Method is a creational design pattern,
* that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.
* */
public class FactoryTester
{
    public static void Run()
    {
        IFactory factoryA = new FactoryA();
        IFactory factoryB = new FactoryB();

        var productA = factoryA.CreateProduct();
        var productB = factoryB.CreateProduct();

       Console.WriteLine($"product A: {productA.Name}, {productA.Price}");
       Console.WriteLine($"product B: {productB.Name}, {productB.Price}");
    }
}

file interface IFactory {
    IProduct CreateProduct();
}

file class FactoryA : IFactory
{
    public virtual IProduct CreateProduct() => new ProductA() { Name = "A", Price = 100};
}

file class FactoryB : IFactory
{
    public IProduct CreateProduct() => new ProductB() { Name = "B", Price = 200 };
}

file class FactoryA2 : FactoryA
{
    public override ProductA CreateProduct()  //example： when override, we can use a derived type
    {
        return new ProductA();
    }
}

file interface IProduct
{
    string Name { get; set; }
    float Price { get; set; }
}

file class ProductA : IProduct
{
    public string Name { get; set; }
    public float Price { get; set; }
}

file class ProductB : IProduct
{
    public string Name { get; set; }
    public float Price { get; set; } = 1.0f;
}
