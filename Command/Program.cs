// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;

var path = "sample.txt";
var before = new MacroCommand();
var fileCheck = new FileCheckCommand(path);
var dbCheck = new DbCheckCommand();
before.AddCommand(fileCheck);
before.AddCommand(dbCheck);
before.Execute();

var main = new MacroCommand();
var fileWrite = new FileWriteCommand(path);
main.AddCommand(fileWrite);
main.Execute();


public interface ICommand
{
    /// <summary>
    /// なんらかの処理を実行するメソッド
    /// </summary>
    public void Execute();
}

public class FileUtil {
    public static bool ExistCheck(string path)
    {
        var result = File.Exists(path);
        return result;
    }

    public static void DeleteFile(string path)
    {
        Console.WriteLine($"Delete file:{path}");
    }

    public static void CreateFile(string path)
    {
        Console.WriteLine($"Create file:{path}");
    }

    public static void Write(string path, List<string> list)
    {
        Console.WriteLine("write file");
    }
}

public class DbUtil
{
    public static bool Connect()
    {
        var result = false;
        var random = new Random().NextDouble();
        if (random >= 0.5)
        {
            result = true;
            Console.WriteLine("DB connect success");
        }
        else
        {
            Console.WriteLine("DB connect failed");
        }

        return result;
    }

    public static List<string> GetEmployeeList()
    {
        var list = new List<string>
        {
            "山田,30才",
            "田中,25才",
            "田村,34才"
        };
        return list;
    }
}

public class FileCheckCommand : ICommand
{
    private readonly string _path;

    public FileCheckCommand(string path)
    {
        _path = path;
    }
    public void Execute()
    {
        Console.WriteLine("Start file check");
        var existResult = FileUtil.ExistCheck(_path);
        if (existResult)
        {
            FileUtil.DeleteFile(_path);
        }
        Console.WriteLine("End file check");
    }
}

public class FileWriteCommand : ICommand
{
    private readonly string _path;

    public FileWriteCommand(string path)
    {
        _path = path;
    }
    public void Execute()
    {
        Console.WriteLine("Start file write");
        var list = DbUtil.GetEmployeeList();
        FileUtil.CreateFile(_path);
        FileUtil.Write(_path,list);
        Console.WriteLine("End file write");
    }
}

public class DbCheckCommand : ICommand
{
    public void Execute()
    {
        var check = DbUtil.Connect();
        Console.WriteLine("connect db");
    }
}

public class MacroCommand : ICommand
{
    private readonly List<ICommand> _commandList = new();

    public void Execute()
    {
        foreach (var command in _commandList)
        {
            command.Execute();
        }
    }

    public void AddCommand(ICommand command)
    {
        _commandList.Add(command);
    }
}