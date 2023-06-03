using System;

namespace AbstractFactory
{
    public class WindowsDisplaySystem : OsDisplaySystem
    {
        public override void DisplayOsName()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("*Windows*");
            Console.WriteLine("=======================");
        }

        public override void DisplayString(string str)
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"*{str}*");
            Console.WriteLine("=======================");
        }
    }
}