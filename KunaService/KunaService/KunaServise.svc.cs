using CunaWrapper;
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
        CunaClient cunaClient = new CunaClient();

        //public relizations Kuna

        public string GetTimestamp()
        {
            return cunaClient.GetTimestamp().Result.ToString();
        }

        public string GetTickerline(string marketPair)
        {
            return cunaClient.GetTickerLine(CunaLogic.EnumConvert(marketPair)).Result.ToString();
        }

        public string GetOrderBook(string marketPair)
        {
            return cunaClient.GetOrderBook(CunaLogic.EnumConvert(marketPair)).Result.ToString();
        }

        public string GetTrades(string marketPair)
        {
            return cunaClient.GetTrades(CunaLogic.EnumConvert(marketPair)).Result.ToString();
        }
    }
}
