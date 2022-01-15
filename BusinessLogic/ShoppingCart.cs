namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Sum(i => i.Subtotal);
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            var newItem = new ShoppingCartItem(product, quantity);
            Items.Add(newItem);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
