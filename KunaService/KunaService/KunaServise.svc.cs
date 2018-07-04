using CunaWrapper;
using CunaWrapper.DataLevel.Enums;
using CunaWrapper.DataLevel.RciveData;
using CunaWrapper.DataLevel.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KunaService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "KunaServise" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы KunaServise.svc или KunaServise.svc.cs в обозревателе решений и начните отладку.
    public class KunaServise : IKunaServise
    {
        //private realization
        public List<Order> GetActiveOrders(Credentials credentials, MarketPair pair)
        {
            var cunaClient = new CunaClient(credentials);
            return cunaClient.GetActiveOrders(pair).Result;
        }

        //public relizations Kuna
        public string GetTimestamp()
        {
            var cunaClient = new CunaClient();
            return cunaClient.GetTimestamp().Result.ToString();
        }

        public TickerLine GetTickerline(MarketPair marketPair)
        {
            var cunaClient = new CunaClient();
            return cunaClient.GetTickerLine(marketPair).Result;
        }

        public OrderBook GetOrderBook(MarketPair marketPair)
        {
            var cunaClient = new CunaClient();
            return cunaClient.GetOrderBook(marketPair).Result;
        }

        public List<Trade> GetTrade(MarketPair marketPair)
        {
            var cunaClient = new CunaClient();
            return cunaClient.GetTrades(marketPair).Result;
        }
    }
}
