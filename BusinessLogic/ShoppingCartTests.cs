using BusinessLogic.Exceptions;
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

        [Fact]
        public void Given_5_Bananas_When_Call_Add_Then_Have_5_Bananas_In_Cart()
        {
            var cart = new ShoppingCart();
            cart.Add(new Product("Banana", 0.75m), 5);
            VerifyCart(cart, 1, 3.75m);
            VerifyCartItem(cart.Items.First(), "Banana", 5);
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
}