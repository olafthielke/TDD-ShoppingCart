﻿using BusinessLogic.Exceptions;
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

        [Theory]
        [InlineData("Apple", 2, 3)]
        [InlineData("Banana", 0.75, 5)]
        [InlineData("Cantaloupe", 2.5, 11)]
        public void Given_Have_Quantity_Of_A_Product_When_Call_Add_Then_Have_Product_In_Cart(string productName,
            decimal unitPrice, int quantity)
        {
            var cart = new ShoppingCart();
            cart.Add(new Product(productName, unitPrice), quantity);
            VerifyCart(cart, 1, quantity * unitPrice);
            VerifyCartItem(cart.Items.First(), productName, unitPrice, quantity);
        }

        [Fact]
        public void Given_Have_Two_Products_When_Call_Add_Then_Have_Two_Products_In_Cart()
        {
            var cart = new ShoppingCart();
            cart.Add(Apple, 5);
            cart.Add(Banana, 8);
            VerifyCart(cart, 2, 5 * Apple.UnitPrice + 8 * Banana.UnitPrice);
            VerifyCartItem(cart.Items[0], Apple, 5);
            VerifyCartItem(cart.Items[1], Banana, 8);
        }

        [Fact]
        public void Given_Have_Three_Products_When_Call_Add_Then_Have_Three_Products_In_Cart()
        {
            var cart = new ShoppingCart();
            cart.Add(Cantaloupe, 10);
            cart.Add(Banana, 20);
            cart.Add(Apple, 30);
            VerifyCart(cart, 3, 10 * Cantaloupe.UnitPrice + 20 * Banana.UnitPrice + 30 * Apple.UnitPrice);
            VerifyCartItem(cart.Items[0], Cantaloupe, 10);
            VerifyCartItem(cart.Items[1], Banana, 20);
            VerifyCartItem(cart.Items[2], Apple, 30);
        }

        [Fact]
        public void Can_Call_Clear_On_Cart()
        {
            var cart = new ShoppingCart();
            cart.Clear();
        }


        private readonly static Product Apple = new Product("Apple", 0.35m);
        private readonly static Product Banana = new Product("Banana", 0.75m);
        private readonly static Product Cantaloupe = new Product("Cantaloupe", 2.5m);


        private static void VerifyCart(ShoppingCart cart, int itemsCount, decimal total)
        {
            cart.ItemsCount.Should().Be(itemsCount);
            cart.Total.Should().Be(total);
        }

        private static void VerifyCartItem(ShoppingCartItem item,
            Product product, int quantity)
        {
            item.Product.Should().BeEquivalentTo(product);
            item.Quantity.Should().Be(quantity);
        }

        private static void VerifyCartItem(ShoppingCartItem item,
            string productName, decimal unitPrice, int quantity)
        {
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Quantity.Should().Be(quantity);
        }
    }
}