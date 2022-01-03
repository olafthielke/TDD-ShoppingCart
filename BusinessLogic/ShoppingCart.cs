using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Any() ? Items[0].Subtotal : 0;
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            if (product == null)
                throw new MissingProduct();
            if (quantity <= 0)
                throw new InvalidQuantity(quantity);

            Items.Add(new ShoppingCartItem(product, quantity));
        }
    }
}
