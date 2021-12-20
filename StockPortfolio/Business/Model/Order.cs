using System.Collections.Generic;

namespace StockPortfolio.Business.Model
{
    public class Order
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }
        public string Timestamp { get; set; }
    }
}