using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.Model
{
    class CharactersResponseModel
    {
        public CharacterInfoModel[] Characters { get; set; }
        public class CharacterInfoModel
        {
            public string ServerName { get; set;}
            public string CharacterName { get; set; }
            public int CharacterLevel { get; set; }
            public string CharacterClassName{ get; set; }
            public string ItemAvgLevel { get; set; }
            public string ItemMaxLevel { get; set; }
        }
    }
}
