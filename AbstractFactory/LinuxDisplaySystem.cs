using System;

namespace AbstractFactory
{
    public class LinuxDisplaySystem : OsDisplaySystem
    {
        public override void DisplayOsName()
        {
            Console.WriteLine("+++Linux+++");
        }

        public override void DisplayString(string str)
        {
            Console.WriteLine($"+++{str}+++");
        }
    }
}