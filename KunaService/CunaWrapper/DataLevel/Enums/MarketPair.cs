using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CunaWrapper.DataLevel.Enums
{
    //При добавлении новой пары на биржу сюда добавляется его тикер
    //После добавления тикера, также необходимо добавить новый клас в папку DataLaer сервиса
    //и реализовать методы в классах TradeLineLoader & SqlDbProvider

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MarketPair
    {
        btcuah,
        ethuah,
        bchuah,
        wavesuah,
        xrpuah,
        gbguah,
        golgbg,
        kunbtc,
        bchbtc,
        rmcbtc,
        rbtc,
        arnbtc,
        evrbtc,
        b2bbtc
    }
}
