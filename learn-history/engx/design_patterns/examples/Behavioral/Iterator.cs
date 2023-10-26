/**
 * Iterator is a behavioral design pattern 
 * that lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).
 * */
public class Iterator
{
    public static void Run() {
        var tree = new Tree(1);
        tree.Left = new Tree(2);
        tree.Left.Left = new Tree(3);
        tree.Middle = new Tree(4);
        tree.Middle.Right = new Tree(5);
        tree.Right = new Tree(6);
        tree.Right.Left = new Tree(7);
        tree.Right.Right = new Tree(8);
        var iterator = new TreeIterator(tree);

        while (iterator.HasNext())
        {
            var current = iterator.GetNext();
            Console.WriteLine($"Tree value: {current.Value}");
        }
    }
}

file sealed class TreeIterator
{
    private readonly Tree _tree;

    private readonly Stack<Tree> stack;

    public TreeIterator(Tree tree)
    {
        _tree = tree;
        stack = new Stack<Tree>();
        stack.Push(_tree);
    }

    public bool HasNext()
    {
        if(stack.Count == 0)
        {
            return false;
        }

        
        return true;
    }

    public Tree GetNext()
    {
        var currentTree = stack.Pop();

        if (currentTree.Right != null) stack.Push(currentTree.Right);
        if (currentTree.Middle != null) stack.Push(currentTree.Middle);
        if (currentTree.Left != null) stack.Push(currentTree.Left);

        return currentTree;
    }
}


file class Tree
{
    public int Value { get; }

    public Tree(int value)
    {
        Value = value;
    }

    public Tree? Left;
    public Tree? Right;
    public Tree? Middle;
}
