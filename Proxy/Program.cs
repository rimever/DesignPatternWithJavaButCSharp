// See https://aka.ms/new-console-template for more information

var sampleText = new TextProxy();
sampleText.SetFilePath("sample.txt");
sampleText.PrintAll();


public interface IText
{
    /// <summary>
    /// ファイルパスを取得
    /// </summary>
    /// <returns></returns>
    public string GetFilePath();

    /// <summary>
    /// ファイルパスをセット
    /// </summary>
    /// <param name="filePath"></param>
    public void SetFilePath(string filePath);

    /// <summary>
    /// ファイルの中身を表示
    /// </summary>
    public void PrintAll();
}

public class RealText : IText
{
    private string _filePath;

    public RealText(string filePath)
    {
        _filePath = filePath;
    }

    public string GetFilePath()
    {
        return _filePath;
    }

    public void SetFilePath(string filePath)
    {
        _filePath = filePath;
    }

    public void PrintAll()
    {
        Console.WriteLine("これはサンプルのテキストです。");
    }
}

public class TextProxy : IText
{
    private readonly string _filePath;
    private RealText? _real;

    public TextProxy()
    {
    }

    public TextProxy(string filePath)
    {
        _filePath = filePath;
    }
    public string GetFilePath()
    {
        return _filePath;
    }

    public void SetFilePath(string filePath)
    {
        _real?.SetFilePath(filePath);
    }

    public void PrintAll()
    {
        Realize();
        _real?.PrintAll();
    }

    private void Realize()
    {
        if (_real != null) return;
        Console.WriteLine("本人のインスタンスを生成します。");
        _real = new RealText(_filePath);
    }
}