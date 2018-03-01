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
            Console.WriteLine(kunaServise.GetTickerlineAsync("xrpuah").Result);
            Console.WriteLine("OrderBook:");
            Console.WriteLine(kunaServise.GetOrderBookAsync("bchuah").Result);
            Console.WriteLine("Trades:");
            Console.WriteLine(kunaServise.GetTradesAsync("wavesuah").Result);
        }
    }
}
