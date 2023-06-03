// See https://aka.ms/new-console-template for more information

var factory = SettingFactory.GetFactory();
var userId = factory.GetSetting("userId");
Console.WriteLine(userId.JapaneseValue);
Console.WriteLine(userId.EnglishValue);

Console.WriteLine();

var userId2 = factory.GetSetting("userId");
Console.WriteLine(userId2.JapaneseValue);
Console.WriteLine(userId2.EnglishValue);
Console.WriteLine();

var password = factory.GetSetting("password");
Console.WriteLine(password.JapaneseValue);
Console.WriteLine(password.EnglishValue);

public class Setting
{
    public required string Key { get; init; }
    public required string JapaneseValue { get; init; }
    public required string EnglishValue { get; init; }
}

public class Database
{
    private static Dictionary<string, Setting> database = new()
    {
        {
            "userId", new Setting()
            {
                Key = "userId",
                JapaneseValue = "ユーザーID",
                EnglishValue = "USER_ID"
            }
        },
        {
            "password", new Setting()
            {
                Key = "password",
                JapaneseValue = "パスワード",
                EnglishValue = "password"
            }
        }
    };

    public static Setting GetSetting(string key)
    {
        return database[key];
    }
}

class SettingFactory
{
    private Dictionary<string, Setting> _pool = new();
    private static SettingFactory _factory = new SettingFactory();

    private SettingFactory()
    {
        
    }

    public static SettingFactory GetFactory() => _factory;

    public Setting GetSetting(string key)
    {
        Setting result = null;
        var exist = _pool.ContainsKey(key);
        if (exist)
        {
            result = _pool[key];
        }
        else
        {
            Console.WriteLine("データベースから取得中:" + key);
            result = Database.GetSetting(key);
            if (result == null)
            {
                return null;
            }
            else
            {
                _pool.Add(key,result);
            }
        }

        return result;
    }
}