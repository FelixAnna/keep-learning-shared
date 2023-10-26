/**
 * Template Method is a behavioral design pattern 
 * that defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.
 * */
internal class TemplateMethod
{
    public static void Run()
    {
        var pdfLoader = new PDFDataLoader();
        var csvLoader = new CSVDataLoader();

        pdfLoader.Load();
        csvLoader.Load();
    }
}


file abstract class DataLoaderTemplate
{
    public void Load() {
        var data = ReadData();
        ValidateData(data);
        Print(data);
    }

    protected abstract string ReadData();
    protected abstract void ValidateData(string data);

    protected virtual void Print(string data)
    {
        Console.WriteLine(data);
    }
}

file class PDFDataLoader : DataLoaderTemplate
{
    protected override string ReadData()
    {
        return $"Data from {nameof(PDFDataLoader)}";
    }

    protected override void ValidateData(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new Exception("Data is null");
        }
    }
}

file class CSVDataLoader : DataLoaderTemplate
{
    protected override string ReadData()
    {
        return $"Data from {nameof(CSVDataLoader)}";
    }

    protected override void ValidateData(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new Exception("Data is null");
        }
    }
}