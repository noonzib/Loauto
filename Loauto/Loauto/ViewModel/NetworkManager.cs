using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.ViewModel
{

    class NetworkManager
    {
        private static HttpClient client = new HttpClient();

        public NetworkManager()
        {
            InitDefaultHeaders();
            InitAPIDictionary();
        }

        private void InitAPIDictionary()
        {

        }

        private static string _JWT = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDEwNTYifQ.aFP_eLbMioC4npamlJn-e9PmjCNccORHiec09TGP4CxsJNti-kpd68T5wdDoAnUn9dy7cAUBcRj886AVNep5vwknjUdLOoQRBWgc9DoKFelB8uAXUotZhPwdyhzXe0vVtstpl_KTCO61BR87wuDEqddwDbJYueHzoOkKAwqLr5-aaygiCGo3msfbv_F5ZMON-FNJGVmMPP1UxoPmvtFsPaCIWmGe5hXJ-8K5ekW6270wyjw48uGOGekjKjQJROrBuiJl5THZExq3u-Q2Yboik4l2FOs_bKNezx4E7P1Af2uWFpu9NPDJ3kjBiWMHkEDSfy2qtAnJo3T2o5b0ZWu_nw";
        private string apiKey = $"bearer {_JWT}";

        public string ApiKey { get => apiKey; }

        private void InitDefaultHeaders()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("authorization", $"{ApiKey}");
            client.BaseAddress = new Uri("https://developer-lostark.game.onstove.com/");
        }

        public async Task RequestEventList() {
            var response = await client.GetAsync("news/events");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }

        public enum ServiceType
        {
            News,
            Characters,
            Armories,
            Auction,
            Guilds,
            Markets,
        }

        public enum RESTAPI
        {
            #region News
            News,
            #endregion
            //
            #region Characters
            Characters,
            #endregion

            #region Armories
            Profiles,
            Equipment,
            Avatars,
            CombatSkills,
            Engravings,
            Cards,
            Gems,
            Colosseums,
            Collectibles,
            #endregion

            #region Auctions
            AuctionOptions,
            AuctionsItems,
            #endregion

            #region Guilds
            Rankings,
            #endregion

            #region Markets
            MarketOption,
            Item,
            items,
            #endregion
        }

        public enum HttpMethod
        {
            GET,
            POST
        }

        public class MethodModel
        {
            ServiceType type;
            HttpMethod sendMethod;
            string url;
        }

        public Dictionary<RESTAPI, MethodModel> MethodDictionary;
            
        // 타입과 메소드를 연결
        // 메소드와 URL를 연결
    }
}
