using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PcFactory();
            var pc1 = factory.Create("A001");
            var pc2 = factory.Create("A002");
            var pc3 = factory.Create("A003");
            Console.WriteLine();
            pc1.Use();
            pc2.Use();
            pc3.Use();
        }
    }
}