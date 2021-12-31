namespace BusinessLogic
{
    public class Product
    {
        public string Name { get; }

        public Product(string name, decimal unitPrice)
        {
            Name = name;
        }
    }
}
