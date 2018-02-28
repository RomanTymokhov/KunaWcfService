using CunaWrapper.DataLevel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunaWrapper.DataLevel.ServiceData
{
    public class UrlParam
    {
        public readonly string accessKey = "access_key=";
        public readonly string tonce = "tonce=";
        public readonly string signature = "signature=";
        public readonly string market = "market=";
        public readonly string id = "id=";
        public readonly string side = "side=";
        public readonly string volume = "volume=";
        public readonly string price = "price=";

        public string MarketPair(MarketPair marketPair)
        {
            var segment = marketPair.ToString();
            return segment;
        }
    }
}
