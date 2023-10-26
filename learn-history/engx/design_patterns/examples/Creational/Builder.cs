/**
* Builder is a creational design pattern that lets you construct complex objects step by step. 
* The pattern allows you to produce different types and representations of an object using the same construction code.
**/
public class BuilderTester
{
    public static void Run()
    {
        var product = new ProductBuilder().SetName("Humberg").SetDescription("Delicious").SetBrand("Lovely").Build();

        //ArgumentNullException.ThrowIfNull(product.Description);
        Console.WriteLine($"Name:{product.Name}, Description:{product.Description}, Brand: {product.Brand}");
    }
}

file class Product
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Brand { get; set; }
}

file class ProductBuilder
{
    private Product product;
    public ProductBuilder() {
        product = new Product();
    }

    public ProductBuilder SetName(string name)
    {
        product.Name = name;
        return this;
    }

    public ProductBuilder SetDescription(string description)
    {
        product.Description = description;
        return this;
    }
    public ProductBuilder SetBrand(string brand)
    {
        product.Brand = brand;
        return this;
    }

    public Product Build()
    {
        return product;
    }
}
