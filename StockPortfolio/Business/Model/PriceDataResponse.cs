using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Model
{
    [DataContract]
    public class PriceDataResponse
    {
        [DataMember]
        public string VwdKey { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Isin { get; set; }
        [DataMember]
        public double? Price { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public double? Open { get; set; }
        [DataMember]
        public double? High { get; set; }
        [DataMember]
        public double? Low { get; set; }
        [DataMember]
        public double? Close { get; set; }
        [DataMember]
        public int? Volume { get; set; }
        [DataMember]
        public double? PreviousClose { get; set; }
        [DataMember]
        public string PreviousCloseTime { get; set; }
    }
}
