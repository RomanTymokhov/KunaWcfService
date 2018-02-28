using CunaWrapper;
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
        public KunaServise() { }

        public string GetTimestamp()
        {
            CunaClient cunaClient = new CunaClient();
            return cunaClient.GetTimestamp().Result.ToString();
        }
    }
}
