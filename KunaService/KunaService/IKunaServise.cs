using CunaWrapper.DataLevel.Enums;
using CunaWrapper.DataLevel.RciveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KunaService
{
    [ServiceContract]
    public interface IKunaServise
    {
        //public contracts KunaEx
        [OperationContract]
        string GetTimestamp();

        [OperationContract]
        TickerLine GetTickerline(MarketPair marketPair);

        [OperationContract]
        OrderBook GetOrderBook(MarketPair marketPair);

        [OperationContract]
        List<Trade> GetTrade(MarketPair marketPair);
    }
}
