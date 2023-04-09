namespace FactoryMethod
{
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
}