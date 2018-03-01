using CunaWrapper.DataLevel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunaWrapper.DataLevel.ServiceData
{
    public static class CunaLogic
    {
        public static MarketPair EnumConvert(string enumStr)
        {
            MarketPair pair = new MarketPair();

            if (enumStr == MarketPair.rbtc.ToString()) pair = MarketPair.rbtc;
            if (enumStr == MarketPair.xrpuah.ToString()) pair = MarketPair.xrpuah;
            if (enumStr == MarketPair.arnbtc.ToString()) pair = MarketPair.arnbtc;
            if (enumStr == MarketPair.bchbtc.ToString()) pair = MarketPair.bchbtc;
            if (enumStr == MarketPair.btcuah.ToString()) pair = MarketPair.btcuah;
            if (enumStr == MarketPair.ethuah.ToString()) pair = MarketPair.ethuah;
            if (enumStr == MarketPair.evrbtc.ToString()) pair = MarketPair.evrbtc;
            if (enumStr == MarketPair.gbguah.ToString()) pair = MarketPair.gbguah;
            if (enumStr == MarketPair.golgbg.ToString()) pair = MarketPair.golgbg;
            if (enumStr == MarketPair.kunbtc.ToString()) pair = MarketPair.kunbtc;
            if (enumStr == MarketPair.rmcbtc.ToString()) pair = MarketPair.rmcbtc;
            if (enumStr == MarketPair.wavesuah.ToString()) pair = MarketPair.wavesuah;

            return pair;
        }
    }
}
