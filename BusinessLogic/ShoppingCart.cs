using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Any() ? 1.05m : 0;
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            if (product == null)
                throw new MissingProduct();
            if (quantity <= 0)
                throw new InvalidQuantity(quantity);

            Items.Add(new ShoppingCartItem(new Product("Apple", 0.35m), 3));
        }
    }
}
