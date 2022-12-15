using Loauto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static Loauto.Model.NetworkModel;

namespace Loauto.ViewModel
{

    class NetworkManager
    {

        private static HttpClient client = new HttpClient();
        private Dictionary<RESTAPI, MethodModel> methodDictionary;

        #region APIKEY
        private static string _JWT = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDEwNTYifQ.aFP_eLbMioC4npamlJn-e9PmjCNccORHiec09TGP4CxsJNti-kpd68T5wdDoAnUn9dy7cAUBcRj886AVNep5vwknjUdLOoQRBWgc9DoKFelB8uAXUotZhPwdyhzXe0vVtstpl_KTCO61BR87wuDEqddwDbJYueHzoOkKAwqLr5-aaygiCGo3msfbv_F5ZMON-FNJGVmMPP1UxoPmvtFsPaCIWmGe5hXJ-8K5ekW6270wyjw48uGOGekjKjQJROrBuiJl5THZExq3u-Q2Yboik4l2FOs_bKNezx4E7P1Af2uWFpu9NPDJ3kjBiWMHkEDSfy2qtAnJo3T2o5b0ZWu_nw";
        private string apiKey = $"bearer {_JWT}";
        #endregion
        public string ApiKey { get => apiKey; }
        internal Dictionary<RESTAPI, MethodModel> MethodDictionary { get => methodDictionary; set => methodDictionary = value; }

        public NetworkManager()
        {
            InitDefaultHeaders();
            InitAPIDictionary();
        }

        private void InitAPIDictionary()
        {
            MethodDictionary = new Dictionary<RESTAPI, MethodModel>();
            MethodDictionary.Add(RESTAPI.News, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.News, Url = "news/event" });

            MethodDictionary.Add(RESTAPI.Characters, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Characters, Url = "characters/{0}/siblings", ResponseType=typeof(List<CharactersResponseModel.CharacterInfoModel>) });

            MethodDictionary.Add(RESTAPI.Profiles, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/profiles", ResponseType = typeof(ArmoriesResponseModel.ArmoryProfileModel) });
            MethodDictionary.Add(RESTAPI.Equipment, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/equipment", ResponseType=typeof(List<ArmoriesResponseModel.EquipmentModel>)});
            MethodDictionary.Add(RESTAPI.Avatars, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/avatars" });
            MethodDictionary.Add(RESTAPI.CombatSkills, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/combat-skills" });
            MethodDictionary.Add(RESTAPI.Engravings, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/engravings", ResponseType=typeof(ArmoriesResponseModel.EngravingsResponseModel) });
            MethodDictionary.Add(RESTAPI.Cards, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/cards", ResponseType=typeof(ArmoriesResponseModel.CardsResponseModel) });
            MethodDictionary.Add(RESTAPI.Gems, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/gems", ResponseType = typeof(ArmoriesResponseModel.GemsResponseModel) });
            MethodDictionary.Add(RESTAPI.Colosseums, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/colosseums" });
            MethodDictionary.Add(RESTAPI.Collectibles, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Armories, Url = "armories/characters/{0}/collectibles" });

            MethodDictionary.Add(RESTAPI.AuctionOptions, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Auction, Url = "auctions/options" });
            MethodDictionary.Add(RESTAPI.AuctionItems, new MethodModel() { RequestMethod = RequestType.POST, Category = APICategory.Auction, Url = "auctions/items" });

            MethodDictionary.Add(RESTAPI.Rankings, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Guilds, Url = "guilds/ranking" });

            MethodDictionary.Add(RESTAPI.MarketOption, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Markets, Url = "markets/options" });
            MethodDictionary.Add(RESTAPI.MarketItem, new MethodModel() { RequestMethod = RequestType.GET, Category = APICategory.Markets, Url = "markets/items/{0}" });
            MethodDictionary.Add(RESTAPI.MarketItems, new MethodModel() { RequestMethod = RequestType.POST, Category = APICategory.Markets, Url = "markets/items" });
        }

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

        public async Task<object> SendRequest(RESTAPI api, string subpath=null, List<KeyValuePair<string, string>> urlParameter=null, object parameter=null)
        {
            var sendmodel = MethodDictionary[api];
            string path = sendmodel.Url;
            if (subpath != null)
            {
                var urlPath = HttpUtility.UrlEncode(subpath);
                path = string.Format(path, urlPath);
            }
            var response = await client.GetAsync(path);

            
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            var result = JsonSerializer.Deserialize(responseBody, sendmodel.ResponseType);

            return result;
        }

            
        // 타입과 메소드를 연결
        // 메소드와 URL를 연결
    }
}
