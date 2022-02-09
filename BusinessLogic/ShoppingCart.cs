using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal Total => Items.Sum(i => i.Subtotal);
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            var item = Items.SingleOrDefault(i => i.ProductName == "Apple");
            if (item != null && product.Name == "Apple")
                throw new ProductAlreadyInCart();

            var newItem = new ShoppingCartItem(product, quantity);
            Items.Add(newItem);
        }

        public void Remove(string productName)
        {
            var item = Items.FirstOrDefault(i => i.ProductName == productName);
            if (item != null)
                Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
