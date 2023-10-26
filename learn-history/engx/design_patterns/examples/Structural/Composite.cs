/**
 * Composite is a structural design pattern， 
 * let you compose objects into tree structures and then work with these structures as if they were individual objects.
 * */
public class CompositeTester
{
    public static void Run()
    {
        var btnOk = new PrimaryButton() { Id = "123", Name = "OK" };
        var btnCancel = new PrimaryButton() { Id = "125", Name = "Cancel" };

        var panel = new Panel
        {
            Id = "126",
            Name = "panelConfirm",
            Components = new[] { btnOk, btnCancel }
        };

        panel.Render();
    }
}

file interface IComponent
{
    void Render();
}

#region component
file abstract class Button : IComponent
{
    public required string Name { get; set; }
    public required string Id { get; set; }
    public virtual void Render()
    {
        Console.WriteLine($"Render: {Id}， Id: {Name}");
    }

    public abstract void Click();
}

file sealed class PrimaryButton : Button
{
    public override void Click()
    {
        Console.WriteLine($"{nameof(PrimaryButton)} Clicked: {Id}， Id: {Name}");
    }
}
#endregion

#region composite
file abstract class Composite : IComponent
{
    public required string Name { get; set; }
    public required string Id { get; set; }

    public IEnumerable<IComponent>? Components { get; set; }

    public virtual void Render()
    {
        RenderComposite();

        foreach (var component in Components)
        {
            component.Render();
        }
    }

    public virtual void RenderComposite()
    {
        Console.WriteLine($"Composite Render: {Id}， Id: {Name}");
    }
}

file class Panel : Composite
{
    public override void RenderComposite()
    {
        Console.WriteLine($"{nameof(Panel)} Render: {Id}， Id: {Name}");
    }
}
#endregion
