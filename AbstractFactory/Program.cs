namespace AbstractFactory
{
    static class Program
    {
        static void Main(string[] args)
        {
            var className = typeof(WindowsFactory).FullName;
            var factory = OsFactory.GetFactory(className);
            var displaySystem = factory.CreateDisplaySystem();
            displaySystem.DisplayOsName();
            displaySystem.DisplayString("sample");
            var fileSystem = factory.CreateFileSystem();
            fileSystem.SaveFile("sample.txt");
        }
    }
}