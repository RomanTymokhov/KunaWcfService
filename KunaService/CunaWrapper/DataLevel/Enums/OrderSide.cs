using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CunaWrapper.DataLevel.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderSide
    {
        buy,
        sell
    }
}
