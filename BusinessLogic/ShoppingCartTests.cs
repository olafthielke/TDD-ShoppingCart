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
            Action add = () => cart.Add(null);
            add.Should().ThrowExactly<MissingProduct>().WithMessage("Must have a product.");
        }

        [Fact]
        public void Given_Zero_Quantity_When_Call_Add_Then_Throw_ZeroQuantity_Exception()
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(new Product(), 0);
            add.Should().ThrowExactly<ZeroQuantity>();
        }
    }


    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int Total { get; } = 0;

        public void Add(object product)
        {
            throw new MissingProduct();
        }
    }

    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        { }
    }
}