namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Any() ? CalcTotal() : 0;
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            var newItem = new ShoppingCartItem(product, quantity);
            Items.Add(newItem);
        }

        private decimal CalcTotal()
        {
            var total = 0.0m;
            foreach (var item in Items)
                total += item.Subtotal;

            return total;
        }
    }
}
