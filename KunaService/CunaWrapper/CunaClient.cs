using CunaWrapper.DataLevel.Enums;
using CunaWrapper.DataLevel.RciveData;
using CunaWrapper.DataLevel.ServiceData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CunaWrapper
{
    public class CunaClient
    {
        private HttpClient httpClient;

        private string publicKey;
        private string secretKey;

        private UrlSegment urlSegment;
        private UrlParam urlParam;

        private const string baseUrl = "https://kuna.io";
        private const string baseSegment = "/api/v2";

        public CunaClient()
        {
            IniInitialization();
        }

        public CunaClient(Credentials credentials)
        {
            publicKey = credentials.PublicKey;
            secretKey = credentials.SecretKey;

            IniInitialization();
        }

        private void IniInitialization()
        {
            httpClient = new HttpClient();
            urlSegment = new UrlSegment();
            urlParam = new UrlParam();
        }
            

        protected async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> PostJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.PostAsync("POST",
               new StringContent(requestUri, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();

            // deserialise async
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }


        public string RequestUri(string path, Dictionary<string, string> args)
        {
            args["access_key"] = publicKey;
            args["tonce"] = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            args["signature"] = GenerateSignature(path, args);

            return BuildPostData(args, true);
        }

        private string GenerateSignature(string path, Dictionary<string, string> args)
        {
            var uri = baseSegment + "/" + path;
            var sortetDict = new SortedDictionary<string, string>(args);
            var sortedArgs = BuildPostData(sortetDict, true);
            var msg = "POST" + "|" + uri + "|" + sortedArgs;  // "HTTP-verb|URI|params"
            var key = Encoding.ASCII.GetBytes(secretKey);
            var msgBytes = Encoding.ASCII.GetBytes(msg);
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashmessage = hmac.ComputeHash(msgBytes);
                return BitConverter.ToString(hashmessage).Replace("-", string.Empty).ToLower();
            }
        }

        private static string BuildPostData(IDictionary<string, string> dict, bool escape = true)
        {
            return string.Join("&", dict.Select(kvp =>
                 string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
        }


        #region Personal Methods

        public async Task<List<Order>> GetActiveOrders(MarketPair pair)
        {
            var path = urlSegment.orders;
            var args = new Dictionary<string, string>
            {
                ["market"] = pair.ToString()
            };

            return await PostJsonAsync<List<Order>>(baseUrl + RequestUri(path, args));
        }


        #endregion

        #region Publik Methods

        public async Task<int> GetTimestamp()
        {
            var sb = baseUrl + baseSegment + urlSegment.timestamp;

            return await GetJsonAsync<int>(sb);
        }

        public async Task<TickerLine> GetTickerLine(MarketPair pair)
        {
            var sb = baseUrl + baseSegment + urlSegment.tickers + urlSegment.MarketPair(pair);

            return await GetJsonAsync<TickerLine>(sb);
        }

        public async Task<OrderBook> GetOrderBook(MarketPair pair)
        {
            var sb = baseUrl + baseSegment + urlSegment.orderBook + "?" + urlParam.market + urlParam.MarketPair(pair);

            return await GetJsonAsync<OrderBook>(sb);
        }

        public async Task<List<Trade>> GetTrades(MarketPair pair)
        {
            var sb = baseUrl + baseSegment + urlSegment.trades + "?" + urlParam.market + urlParam.MarketPair(pair);

            return await GetJsonAsync<List<Trade>>(sb);
        }

        #endregion
    }
}
