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

        [Fact]
        public void Given_Zero_Quantity_When_Call_Add_Then_Throw_ZeroQuantity_Exception()
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(new Product(), 0);
            add.Should().ThrowExactly<ZeroQuantity>().WithMessage("Zero is not a valid quantity.");
        }

        [Fact]
        public void Given_Quantity_Is_Negative_1_When_Call_Add_Then_Throw_NegativeQuantity_Exception()
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(new Product(), -1);
            add.Should().ThrowExactly<NegativeQuantity>();
        }
    }


    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int Total { get; } = 0;

        public void Add(Product product, int quantity)
        {
            if (product == null)
                throw new MissingProduct();
            if (quantity == 0)
                throw new ZeroQuantity();
            throw new NegativeQuantity();
        }
    }

    public class Product
    {

    }

    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        { }
    }

    public class ZeroQuantity : Exception
    {
        public ZeroQuantity()
            : base("Zero is not a valid quantity.")
        { }
    }

    public class NegativeQuantity : Exception
    {

    }
}