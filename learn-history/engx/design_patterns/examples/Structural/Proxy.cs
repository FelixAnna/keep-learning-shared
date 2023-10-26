/**
 * Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object.
 * A proxy controls access to the original object, 
 * allowing you to perform something either before or after the request gets through to the original object.
 * */
internal class Proxy
{
    public static void Run()
    {
        var secureUrl = "https://www.abc.com";
        var unsecureUrl = "http://www.def.com";

        var handler = new SecureRequestHandler(new RequestHandler());
        handler.Process(secureUrl);
        handler.Process(unsecureUrl);
    }
}

file interface IHandler
{
    void Process(string url);
}


file class RequestHandler : IHandler
{
    public void Process(string url)
    {
        Console.WriteLine($"Request handled： {url}");
    }
}

file class SecureRequestHandler : IHandler
{
    private readonly IHandler handler;

    public SecureRequestHandler(IHandler handler)
    {
        this.handler = handler;
    }

    public void Process(string url)
    {
        if(string.IsNullOrEmpty(url) || !url.StartsWith("https"))
        {
            Console.WriteLine($"Unable to handle unsecure url: {url}");
            return;
        }

        handler.Process(url);
    }
}