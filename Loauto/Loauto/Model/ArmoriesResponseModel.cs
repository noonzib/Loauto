using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.Model
{
    public class ArmoriesResponseModel
    {
        public class ArmoryProfileModel
        {
            public string CharacterImage { get; set; }
            public int ExpeditionLevel { get; set; }
            public string PvpGradeName { get; set; }
            public int TownLevel { get; set; }
            public string TownName { get; set; }
            public string Title { get; set; }
            public string GuildMemberGrade { get; set; }
            public string GuildName { get; set; }
            public int UsingSkillPoint { get; set; }
            public int TotalSkillPoint { get; set; }

            public StatsModel[] Stats { get; set; }
            public TendenciesModel[] Tendencies{ get; set; }
            public string ServerName { get; set; }
            public string CharacterName { get; set; }
            public int CharacterLevel { get; set; }
            public string CharacterClassName { get; set; }
            public string ItemAvgLevel { get; set; }
            public string ItemMaxLevel { get; set; }
        }

        /// <summary>
        /// 무기/방어구 Model
        /// </summary>
        public class EquipmentModel 
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
            public string Grade { get; set; }
            public string Tooltip { get; set; }
        }
        public class StatsModel
        {
            public string Type { get; set; }
            public string Value { get; set; }
            public string[] Tooltip { get; set; }

        }
        public class TendenciesModel
        {
            public string Type { get; set; }
            public int Point { get; set; }
            public int MaxPoint { get; set; }

        }
        public class CardsResponseModel
        {
            public CardModel[] Cards {get;set;}
            public CardEffectModel[] Effects { get; set; }

            public class CardModel
            {
                public int Slot { get; set; }
                public string Name { get; set; }
                public string Icon { get; set; }
                public int AwakeCount { get; set; }
                public int AwakeTotal { get; set; }
                public string Grade { get; set; }
                public string Tooltip { get; set; }
            }

            public class CardEffectModel
            {
                public int Index { get; set; }
                public int[] CardSlots { get; set; }
                public EffectModel[] Items { get; set; }

            }
        }
        public class EffectModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class GemsResponseModel
        {
            public GemModel[] Gems { get; set; }
            public GemEffectModel[] Effects { get; set; }

            public class GemModel
            {
                public int Slot { get; set; }
                public string Name { get; set; }
                public string Icon { get; set; }
                public int Level { get; set; }
                public string Grade { get; set; }
                public string ToolTip { get; set; }
            }
            public class GemEffectModel
            {
                public int GemSlot { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public string Icon { get; set; }
                public string ToolTip { get; set; }
            }
        }

        public class EngravingsResponseModel
        {
            public EngravingModel[] Engravings { get; set; }
            public EffectModel[] Effects { get; set; }

            public class EngravingModel
            {
                public int Slot { get; set; }
                public string Name { get; set; }
                public string Icon { get; set; }
                public string Tooltip { get; set; }
            }
        }

    }
}
