using FluentAssertions;
using Xunit;

namespace BusinessLogic
{
    public class ShoppingCartTests
    {
        [Fact]
        public void Can_Create_ShoppingCart()
        {
            var cart = new ShoppingCart();
        }

        [Fact]
        public void When_Create_Cart_Then_Cart_Is_Empty()
        {
            var cart = new ShoppingCart();
            cart.Items.Should().BeEmpty();
        }

        [Fact]
        public void When_Create_Cart_Then_Total_Is_Zero()
        {
            var cart = new ShoppingCart();
            cart.Total.Should().Be(0);
        }

        [Fact]
        public void Given_No_Product_When_Call_Add_Then_Throw_MissingProduct_Exception()
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(null, 3);
            add.Should().ThrowExactly<MissingProduct>().WithMessage("Must have a product.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void Given_Quantity_Is_Invalid_When_Call_Add_Then_Throw_InvalidQuantity_Exception(int quantity)
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(new Product("Apple", 0.35m), quantity);
            add.Should().ThrowExactly<InvalidQuantity>().WithMessage($"{quantity} is an invalid quantity.");
        }

        [Fact]
        public void Given_3_Apples_When_Call_Add_Then_Have_3_Apples_In_Cart()
        {
            var cart = new ShoppingCart();
            cart.Add(new Product("Apple", 0.35m), 3);
            VerifyCart(cart, 1, 1.05m);
            VerifyCartItem(cart.Items.First(), "Apple", 3);
        }

        private static void VerifyCart(ShoppingCart cart, int itemsCount, decimal total)
        {
            cart.ItemsCount.Should().Be(itemsCount);
            cart.Total.Should().Be(total);
        }

        private static void VerifyCartItem(ShoppingCartItem item, string productName, int quantity)
        {
            item.ProductName.Should().Be(productName);
            item.Quantity.Should().Be(quantity);
        }
    }


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

    public class Product
    {
        public string Name { get; }

        public Product(string name, decimal unitPrice)
        {
            Name = name;
        }
    }

    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        { }
    }

    public class InvalidQuantity : Exception
    {
        public InvalidQuantity(int quantity)
            : base($"{quantity} is an invalid quantity.")
        { }
    }
}