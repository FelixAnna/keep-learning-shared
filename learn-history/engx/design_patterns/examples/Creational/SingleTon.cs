/**
 * Singleton is a creational design pattern 
 * that lets you ensure that a class has only one instance, while providing a global access point to this instance.
 * */
public class SingleTonTester
{
    public static void Run()
    {
        var instanceA = SingleTon.GetInstance();
        var instanceB = SingleTon.GetInstance();

        Console.WriteLine($"InstanceA == InstanceB: {instanceA.GetId() == instanceB.GetId()}");
        Console.WriteLine($"InstanceA: {instanceA.GetId()}, InstanceB: {instanceB.GetId()}");
    }
}

file class SingleTon
{
    private static readonly object objectForLock = new();
    private static SingleTon? singleTon;

    private readonly Guid guid;
    private SingleTon() {
        guid = Guid.NewGuid();
    }

    public static SingleTon GetInstance()
    {
        if (singleTon == null)
        {
            lock (objectForLock)
            {
                if (singleTon == null)
                {
                    var tmp = new SingleTon();
                    Volatile.Write(ref singleTon, tmp);
                }
            }
        }

        return singleTon;
    }

    public static SingleTon GetInstanceOnThread()
    {
        if (singleTon == null)
        {
            singleTon = new SingleTon();
        }

        return singleTon;
    }

    public string GetId() { return guid.ToString(); }
}
