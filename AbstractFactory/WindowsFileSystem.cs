using System;

namespace AbstractFactory
{
    public class WindowsFileSystem : OsFileSystem
    {
        public override string GetFileSeparator()
        {
            return "¥¥";
        }

        public override string GetRootPath()
        {
            return "C:¥¥";
        }

        public override void SaveFile(string fileName)
        {
            var directory = GetRootPath() + "work" + GetFileSeparator() + fileName;
            Console.WriteLine($"save:{directory}");
        }
    }
}