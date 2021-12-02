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
    }


    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int Total { get; } = 0;
    }
}