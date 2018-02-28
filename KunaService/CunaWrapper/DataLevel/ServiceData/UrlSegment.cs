using CunaWrapper.DataLevel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunaWrapper.DataLevel.ServiceData
{
    public class UrlSegment
    {
        public readonly string timestamp = "/timestamp";
        public readonly string tickers = "/tickers";
        public readonly string orderBook = "/order_book";
        public readonly string trades = "/trades";
        public readonly string members = "/members";
        public readonly string me = "/me";
        public readonly string my = "/my";
        public readonly string orders = "/orders";
        public readonly string order = "/order";
        public readonly string delete = "/delete";

        public string MarketPair(MarketPair marketPair)
        {
            var segment = "/" + marketPair.ToString();
            return segment;
        }
    }
}
