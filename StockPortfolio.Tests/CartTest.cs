using StockPortfolio.Business.Model;
using StockPortfolio.Business.TestData;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockPortfolio.Tests
{
    public class CartTest
    {
        private CartService _cartService;

        public CartTest()
        {
            _cartService = new CartService();
        }

        [Fact]
        public void Add_OrdersToCart()
        {
            var orders = new Order
            {
                Products = new Product
                {
                    Id = 1,
                    Symbol = "ABN.NL",
                    Name = "ABN AMRO",
                    PriceBought = 21
                },
                Quantity = 10,
                Timestamp = DateTime.Now.ToString()
            };
            var cart = new Cart();

            _cartService.AddOrderToCart(orders, cart);

            Assert.NotNull(cart.Order);

        }
    }
}
