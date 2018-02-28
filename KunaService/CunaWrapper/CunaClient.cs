using CunaWrapper.DataLevel.Enums;
using CunaWrapper.DataLevel.RciveData;
using CunaWrapper.DataLevel.ServiceData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CunaWrapper
{
    public class CunaClient
    {
        private HttpClient httpClient;

        private UrlSegment urlSegment;
        private UrlParam urlParam;

        private const string baseAdres = "https://kuna.io/api/v2";

        public CunaClient()
        {
            httpClient = new HttpClient();
            urlSegment = new UrlSegment();
            urlParam = new UrlParam();
        }

        #region Personal Methods



        #endregion

        #region Publik Methods

        protected async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        public async Task<int> GetTimestamp()
        {
            var sb = baseAdres + urlSegment.timestamp;

            return await GetJsonAsync<int>(sb);
        }

        public async Task<TickerLine> GetTickerLine(MarketPair pair)
        {
            var sb = baseAdres + urlSegment.tickers + urlSegment.MarketPair(pair);

            return await GetJsonAsync<TickerLine>(sb);
        }

        public async Task<OrderBook> GetOrderBook(MarketPair pair)
        {
            var sb = baseAdres + urlSegment.orderBook + "?" + urlParam.market + urlParam.MarketPair(pair);

            return await GetJsonAsync<OrderBook>(sb);
        }

        public async Task<List<Trade>> GetTrades(MarketPair pair)
        {
            var sb = baseAdres + urlSegment.trades + "?" + urlParam.market + urlParam.MarketPair(pair);

            return await GetJsonAsync<List<Trade>>(sb);
        }

        #endregion
    }
}
