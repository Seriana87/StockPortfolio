using StockPortfolio.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPortfolio.Business.TestData
{
    public class CartService
    {
        internal Cart GetCart()
        {
            var cart = new Cart();

            var orders = new List<Order>
            {
                new Order
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
                },
                 new Order
                 {
                    Products = new Product
                    {
                        Id = 2,
                        Symbol = "INGA.NL",
                        Name = "ING Group",
                        PriceBought = 13.821
                    },
                    Quantity = 10,
                    Timestamp = DateTime.Now.ToString()
                 }
            };
            cart.Order = orders;
            cart.TotalPrice = CalculateTotalPrice(orders);
            return cart;
        }

        private double CalculateTotalPrice(List<Order> orders)
        {
           double total = orders.Sum((item => (item.Products.PriceBought * item.Quantity)));
           return total;
        }

        public List<string> GetAllKeys() 
        {
            var cart = GetCart();
            var keys = cart.Order.Select(item => item.Products.Symbol).ToList();
            return keys;
        }

        public void AddOrderToCart(Order orderToAdd, Cart cart)
        {
            var orders = new List<Order>();
            orders.Add(orderToAdd);

            cart.Order = orders;
        }

    }
}
