/**
 * Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. 
 * The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.
 * */
internal class Mediator
{
    public static void Run()
    {
        var iMediator = new ConcreteMediator();
        var selectAllButton = new SelectAllButton(iMediator);
        var checkBoxes = new CheckBox[] { new CheckBox(iMediator), new CheckBox(iMediator) };
        iMediator.Button = selectAllButton;
        iMediator.Boxes = checkBoxes;

        selectAllButton.Update();
        selectAllButton.Update();
        selectAllButton.Update();
    }
}

file interface IMediator
{
    void Notify(Component sender, string data);
}

file class ConcreteMediator : IMediator
{
    public SelectAllButton Button { get; set; }
    public IList<CheckBox> Boxes { get; set; }

    public void Notify(Component sender, string data)
    {
        Console.WriteLine($"{data} clicked");
        if (sender is SelectAllButton)
        {
            foreach (var box in Boxes)
            {
                box.Update();
                Console.WriteLine(box.IsChecked);
            }
        }
        else
        {
            Console.WriteLine("Checkbox clicked");
        }
    }
}

file abstract class Component
{
    protected IMediator mediator;

    public Component(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void Update();
}

file class SelectAllButton : Component
{
    public SelectAllButton(IMediator mediator) : base(mediator)
    {
    }

    public override void Update()
    {
        mediator.Notify(this, nameof(SelectAllButton));
    }
}

file class CheckBox : Component
{
    public bool IsChecked { get; set; }   
    public CheckBox(IMediator mediator) : base(mediator)
    {
    }
    public void Update2()
    {
        IsChecked = !IsChecked;
        mediator.Notify(this, nameof(CheckBox));
    }

    public override void Update()
    {
        IsChecked = !IsChecked;
    }
}