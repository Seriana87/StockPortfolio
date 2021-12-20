using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Order> Order { get; set; }
        public double TotalPrice { get; set; }
    }
}
