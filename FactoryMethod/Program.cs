using System;
using System.Collections.Generic;

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

    public abstract class Product
    {
        public abstract void Use();
    }

    public abstract class Factory
    {
        public Product Create(string serialNumber)
        {
            var product = CreateProduct(serialNumber);
            RegisterProduct(product);
            return product;
        }

        protected abstract void RegisterProduct(Product product);

        protected abstract Product CreateProduct(string serialNumber);
    }

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

    public class PcFactory : Factory
    {
        public List<string> SerialNumberList { private set; get; } = new();

        protected override void RegisterProduct(Product product)
        {
            SerialNumberList.Add((product as Pc)?.SerialNumber);
        }

        protected override Product CreateProduct(string serialNumber)
        {
            return new Pc(serialNumber);
        }
    }
}