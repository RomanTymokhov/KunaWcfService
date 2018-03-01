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
        TickerLine GetTickerline(string marketPair);

        [OperationContract]
        OrderBook GetOrderBook(string marketPair);

        [OperationContract]
        List<Trade> GetTrade(string marketPair);
    }
}
