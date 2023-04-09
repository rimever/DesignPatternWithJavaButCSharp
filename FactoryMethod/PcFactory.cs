using System.Collections.Generic;

namespace FactoryMethod
{
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