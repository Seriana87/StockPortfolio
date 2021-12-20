using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StockPortfolio.Business.Interface;
using StockPortfolio.Business.Model;
using StockPortfolio.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Service
{
    public class PriceDataService : IPriceDataSearch
    {
        private readonly string _baseUri;
        private readonly HttpClient _http;
        public PriceDataService(IConfiguration configuration, HttpClient http)
        {
            _http = http;
            _baseUri = configuration["API_Vwdservices"];
        }

        public async Task<IEnumerable<PriceDataResponse>> SearchPriceData(List<string> vwdKeys)
        {
            var queryParam = string.Join("&vwdkey=", vwdKeys);
            var url = $@"{_baseUri}/internal/intake-test/sample-data/price-data?vwdkey={queryParam}";

            var response = await HttpClientHelper.SendRequestAsync("", _http, HttpMethod.Get, url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Could not GET data from {url}. Error: {content}");
            }

            return JsonConvert.DeserializeObject<IEnumerable<PriceDataResponse>>(content);
        }

        public IEnumerable<Portfolio> MapDataToPortfolio(IEnumerable<PriceDataResponse> searchPriceData, Cart shopingCartData)
        {
            List<Portfolio> portfolios = new List<Portfolio>();
            foreach (var item in searchPriceData)
            {
                var port = new Portfolio();
                var shopingCartOrderSingle = shopingCartData.Order.Where(x => x.Products.Symbol == item.VwdKey).FirstOrDefault();

                port.Name = shopingCartOrderSingle.Products.Name;
                port.Symbol = shopingCartOrderSingle.Products.Symbol;
                port.CurrentPrice = item.Price;
                port.Quantity = shopingCartOrderSingle.Quantity;
                port.BuyValue = shopingCartOrderSingle.Products.PriceBought == null ? null : shopingCartOrderSingle.Products.PriceBought * shopingCartOrderSingle.Quantity;
                port.CurrentValue = (item.Price == null) ? null : (double?)Decimal.Multiply(shopingCartOrderSingle.Quantity,(decimal) item.Price);
                port.Yield = (port.CurrentValue == null || port.BuyValue == null) ? null : ((port.CurrentValue - port.BuyValue) / port.BuyValue) * 100;
                portfolios.Add(port);
            }
            return portfolios;
        }
    }
}
