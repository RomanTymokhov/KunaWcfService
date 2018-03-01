using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.KunaService;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            KunaServiseClient kunaServise = new KunaServiseClient();

            Console.WriteLine(kunaServise.GetTimestampAsync().Result);
            Console.WriteLine("TickerLine:");
            Console.WriteLine(kunaServise.GetTickerlineAsync("xrpuah").Result.ticker.buy);
            Console.WriteLine("OrderBook:");
            foreach (var item in kunaServise.GetOrderBookAsync("bchuah").Result.bids)
            {
                Console.WriteLine("orderId: " + item.orderId + " -- " + " order price " + item.price);
            }
            Console.WriteLine("Trades:");
            foreach (var item in kunaServise.GetTradeAsync("wavesuah").Result)
            {
                Console.WriteLine("marketPair: " + item.marketPair + " volume " + item.volume);
            }
        }
    }
}
