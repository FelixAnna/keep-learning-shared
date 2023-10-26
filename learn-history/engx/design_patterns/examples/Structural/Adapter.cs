using System.Xml;

/**
* Adapter is a structural design pattern 
* that allows objects with incompatible interfaces to collaborate.
* */
internal class AdapterTester
{
    public static void Run()
    {
        IDataReader jsonReader = new JsonDataReader();
        IDataReader xmlDataReader = new DataLoaderAdapter(new XMLLoader());

        TestAccessDataReader(jsonReader, "test");
        TestAccessDataReader(xmlDataReader, "test");

    }

    private static void TestAccessDataReader(IDataReader reader, string text)
    {
        var result = reader.Read(text);
        Console.WriteLine(result.ToString());
    }
}


file interface IDataloader
{
    XmlDocument Load(string text);
}

file class XMLLoader : IDataloader
{
    public XmlDocument Load(string text)
    {
        var xmlContent = $"""<xml>{text}</xml>""";
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlContent);
        return xmlDocument;
    }
}

internal interface IDataReader
{
    string Read(string text);
}

file class JsonDataReader : IDataReader
{
    public string Read(string text)
    {
        return $"""text: {text}""";
    }
}

file class DataLoaderAdapter : IDataReader
{
    private readonly IDataloader loader;

    public DataLoaderAdapter(IDataloader loader)
    {
        this.loader = loader;
    }

    public string Read(string text)
    {
        var content = loader.Load(text);
        return content.OuterXml;
    }
}
