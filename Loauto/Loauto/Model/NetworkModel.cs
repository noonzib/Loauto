using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.Model
{
    public class NetworkModel
    {
        public enum APICategory
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
            AuctionItems,
            #endregion

            #region Guilds
            Rankings,
            #endregion

            #region Markets
            MarketOption,
            MarketItem,
            MarketItems,
            #endregion
        }

        public enum RequestType
        {
            GET,
            POST
        }

        public class MethodModel
        {
            APICategory category;
            RequestType requestMethod;
            string url;
            Type type;

            public string Url { get => url; set => url = value; }
            public Type ResponseType { get => type; set => type = value; }
            internal APICategory Category { get => category; set => category = value; }
            internal RequestType RequestMethod { get => requestMethod; set => requestMethod = value; }
        }
    }
}
