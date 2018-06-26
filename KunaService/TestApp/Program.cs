using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.KunaServ_1;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            KunaServiseClient kunaServise = new KunaServiseClient();

            Console.WriteLine(kunaServise.GetTimestampAsync().Result);
            Console.WriteLine("TickerLine:");
            Console.WriteLine(kunaServise.GetTickerlineAsync(MarketPair.btcuah).Result.ticker.buy);
            Console.WriteLine("OrderBook:");
            foreach (var item in kunaServise.GetOrderBookAsync(MarketPair.kunbtc).Result.bids)
            {
                Console.WriteLine("orderId: " + item.orderId + " -- " + " order price " + item.price);
            }
            Console.WriteLine("Trades:");
            foreach (var item in kunaServise.GetTradeAsync(MarketPair.wavesuah).Result)
            {
                Console.WriteLine("marketPair: " + item.marketPair + " volume " + item.volume);
            }
        }
    }
}
