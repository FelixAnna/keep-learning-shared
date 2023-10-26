/**
* Flyweight is a structural design pattern 
* that lets you fit more objects into the available amount of RAM 
* by sharing common parts of state between multiple objects instead of keeping all of the data in each object.
**/
public class Flyweight
{
    public static void Run()
    {
        var treeFactory = new TreeFactory();
        var trees = new List<Tree>();

        var forestTreeCount = 1000;
        for (int i = 0; i < forestTreeCount; i++)
        {
            for (int j = 0; j < forestTreeCount; j++)
            {
                var tree = treeFactory.GetTree($"tree{i % 10}", $"texture{i % 10}");
                trees.Add(new Tree(tree, i, j));
            }
        };
        Console.WriteLine($"tree count:  {trees.Count}");
        trees.First().Draw();
        trees.Last().Draw();
    }
}

file class TreeType
{
    private readonly string name;
    private readonly string texture;

    public TreeType(string name, string texture)
    {
        this.name = name;
        this.texture = texture;
    }

    public override string ToString()
    {
        return $"tree type: {name}, {texture}";
    }
}

file class TreeFactory
{
    private readonly Dictionary<string, TreeType> treeDicts;

    public TreeFactory()
    {
        treeDicts = new Dictionary<string, TreeType>();
    }

    public TreeType GetTree(string name, string texture)
    {
        if (!treeDicts.ContainsKey(name))
        {
            treeDicts.Add(name, new TreeType(name,texture));
        }

        return treeDicts[name];
    }
}

file class Tree
{
    private readonly TreeType type;

    private readonly int x;
    private readonly int y;

    public Tree(TreeType type, int x, int y)
    {
        this.type = type;
        this.x = x;
        this.y = y;
    }

    public void Draw()
    {
        Console.WriteLine($"type: {type}, x: {x}, y: {y}");
    }
}