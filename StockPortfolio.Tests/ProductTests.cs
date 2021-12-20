using StockPortfolio.Business.TestData;
using System;
using Xunit;

namespace StockPortfolio.Tests
{
    public class ProductTests
    {
        private ProductService _productService;

        public ProductTests()
        {
            _productService = new ProductService();
        }

        [Fact]
        public void Can_Retrieve_Products()
        {
            var products = _productService.GetAll();

            Assert.NotEmpty(products);
        }

        [Fact]
        public void Can_Retrieve_Product_By_Id()
        {
            var product = _productService.Get(1);

            Assert.NotNull(product);
        }
    }
}
