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
        string GetTickerline(string marketPair);

        [OperationContract]
        string GetOrderBook(string marketPair);

        [OperationContract]
        string GetTrades(string marketPair);
    }
}
