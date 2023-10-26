/**
 * Prototype is a creational design pattern 
 * that lets you copy existing objects without making your code dependent on their classes.
 * */
public class PrototypeTester
{
    public static void Run()
    {
        var rectangle = new Rectangle() { X1 = 1, Y1=2, Width=3, Height =4};
        var circle = new Circle() { X1 = 2, Y1 = 4, Radius = 6 };

        var clonedRectangle = rectangle.Clone();
        var clonedCircle = circle.Clone();

        Console.WriteLine($"Rectangle: {rectangle.GetArea()}, ClonedRectangle: {clonedRectangle.GetArea()}");
        Console.WriteLine($"Circle: {circle.GetArea()}, ClonedCircle: {clonedCircle.GetArea()}");
    }
}

file interface ICloneable<T> where T : class
{
    T Clone();
}

file abstract class Shape : ICloneable<Shape>
{
    public double X1 { get; set; }
    public double Y1 { get; set; }


    public Shape()
    {
        Console.WriteLine("Optional logic from Shape");
    }

    public Shape(Shape shape) : this()
    {
        X1 = shape.X1;
        Y1 = shape.Y1;
    }

    public abstract Shape Clone();
    public abstract double GetArea();
}


file sealed class Rectangle : Shape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle()
    {
        Console.WriteLine("Optional logic from Rectangle");
    }

    public Rectangle(Rectangle shape) : base(shape) {
        Width = shape.Width;
        Height = shape.Height;
    }

    public override Shape Clone()
    {
        return new Rectangle(this);
    }

    public override double GetArea()
    {
        return Width * Height /2;
    }
}

file sealed class Circle : Shape
{
    public double Radius { get; set; }

    public Circle()
    {
        Console.WriteLine("Optional logic from Circle");
    }

    public Circle(Circle shape) : base(shape)
    {
        Radius = shape.Radius;
    }

    public override Shape Clone()
    {
        return new Circle(this);
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
