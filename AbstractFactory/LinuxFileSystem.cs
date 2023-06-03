using System;

namespace AbstractFactory
{
    public class LinuxFileSystem : OsFileSystem
    {
        public override string GetFileSeparator()
        {
            return "/";
        }

        public override string GetRootPath()
        {
            return "/";
        }

        public override void SaveFile(string fileName)
        {
            var directory = GetRootPath() + "usr" + GetFileSeparator() + fileName;
            Console.WriteLine($"save:{directory}");
        }
    }
}