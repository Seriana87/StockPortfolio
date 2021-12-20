using StockPortfolio.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Interface
{
    public interface IPriceDataSearch
    {
        Task<IEnumerable<PriceDataResponse>> SearchPriceData(List<string> vwdKeys);

        IEnumerable<Portfolio> MapDataToPortfolio(IEnumerable<PriceDataResponse> searchPriceData, Cart shopingCartData);
    }
}
