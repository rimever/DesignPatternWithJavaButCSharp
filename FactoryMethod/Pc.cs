using System;

namespace FactoryMethod
{
    public class Pc : Product
    {
        public string SerialNumber { get; }

        public Pc(string serialNumber)
        {
            Console.WriteLine($"{serialNumber}のPCを作ります。");
            SerialNumber = serialNumber;
        }
        public override void Use()
        {
            Console.WriteLine($"{SerialNumber}のPCを使います。");
        }
    }
}