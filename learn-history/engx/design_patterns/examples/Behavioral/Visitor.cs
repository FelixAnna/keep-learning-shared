/**
 * Visitor is a behavioral design pattern 
 * that lets you separate algorithms from the objects on which they operate.
 * */
internal class Visitor
{
    public static void Run() {
        var engineer = new Engineer() { Name = "Emma", Salary= 10000};
        var manager = new Manager() { Name = "Lily", Salary = 20000 };

        var visitor = new EmployeeBonusVisitor();

        engineer.Accept(visitor);
        manager.Accept(visitor);
    }
}

file interface IVisitor
{
    void Visit<T>(T engineer) where T:Employee;
}

file class EmployeeBonusVisitor : IVisitor
{
    public void Visit<T>(T engineer) where T : Employee
    {
        var bonus = engineer.Salary * ((engineer is Manager)?2:1);
        Console.WriteLine($"Bonus: {bonus}");
    }
}

file abstract class Employee
{
    public required string Name { get; set; } = null!;
    public required int Salary { get; set; }

    public virtual void OnBoard()
    {
        Console.WriteLine($"Hello everyone, i am ${Name}");
    }

    public virtual void LayOff()
    {
        Console.WriteLine($"From: ${Name}, see you");
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit((dynamic)this);
    }
}

file class Engineer : Employee
{
    public override void LayOff()
    {
        Console.WriteLine($"From: ${Name}, see you later");
    }
}

file class Manager : Employee
{
    public override void OnBoard()
    {
        Console.WriteLine($"Hello everyone, i am ${Name}");
    }
}
