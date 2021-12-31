namespace BusinessLogic
{
    public class ShoppingCartItem
    {
        public Product Product { get; }
        public int Quantity { get; }
        public string ProductName => Product.Name;

        public ShoppingCartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
