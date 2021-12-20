using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockPortfolio.Business.Interface;
using StockPortfolio.Business.TestData;

namespace StockPortfolio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriceDataController : ControllerBase
    {
        private readonly IPriceDataSearch _searchService;
        private readonly CartService _cartService;
        public PriceDataController( IPriceDataSearch searchService, CartService cartService)
        {
            _searchService = searchService;
            _cartService = cartService;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                // First will get the cart the user byId using CartService With some mockdata
                // in perfect scenario we will get the data from our endpoint service that gets the data from the DB
                var shopingcartData = _cartService.GetCart();
                // will prepare our response for the cart base on real data 
                // call stock-data endpoint with a list of vwdkey
                var keys = _cartService.GetAllKeys();

                var searchPriceData = await _searchService.SearchPriceData(keys);

                // Bind Portofolio with data wanted
                var result = _searchService.MapDataToPortfolio(searchPriceData, shopingcartData);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}