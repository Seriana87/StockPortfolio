using StockPortfolio.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPortfolio.Business.TestData
{

    public class ProductService
    {
        private List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Symbol = "ABN.NL",
                Name = "ABN AMRO",
                PriceBought = 21
            },
            new Product
            {
                Id = 2,
                Symbol = "INGA.NL",
                Name = "ING Group",
                PriceBought = 13.821
            },
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int productId)
        {
            return _products.FirstOrDefault(x => x.Id == productId);
        }
    }
}
