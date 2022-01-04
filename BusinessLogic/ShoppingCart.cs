namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Any() ? Items[0].Subtotal : 0;
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            var newItem = new ShoppingCartItem(product, quantity);
            Items.Add(newItem);
        }
    }
}
