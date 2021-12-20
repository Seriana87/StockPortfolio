using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Model
{
    public class Portfolio
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double? CurrentPrice { get; set; }
        public double BuyValue { get; set; }
        public double? CurrentValue { get; set; }
        public double? Yield { get; set; }
        public int Quantity { get; set; }
    }
}
