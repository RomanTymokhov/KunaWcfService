using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CunaWrapper.DataLevel.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MarketPair
    {
        btcuah,
        ethuah,
        xrpuah,
        ltcuah,
        zecuah,
        dashuah,
        bchuah,
        xlmuah,
        eosuah,
        wavesuah,
        tusduah,
        gbguah,
        golgbg,
        kunbtc,
        bchbtc
    }
}
