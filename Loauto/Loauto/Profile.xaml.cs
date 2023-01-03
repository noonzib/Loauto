using Loauto.CustomControl;
using Loauto.Model;
using Loauto.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Loauto.Model.ArmoriesResponseModel;

namespace Loauto
{
    /// <summary>
    /// Profile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();

            this.Visibility = Visibility.Collapsed;
            //DataContextChanged += Profile_DataContextChanged;
            NetworkManager.Singleton.ReceivedResponse += Singleton_ReceivedResponse;
        }

        private ArmoryProfileModel currentProfile;

        public ArmoryProfileModel CurrentProfile { 
            get => currentProfile;
            set { 
                currentProfile = value;
                if (currentProfile == null) this.Visibility = Visibility.Collapsed;
                else this.Visibility = Visibility.Visible;
            }
        }


        private void Singleton_ReceivedResponse(object sender, ReceiveResponseEventArgs e)
        {
            //if (e.Result == null) return;
            switch (e.Api)
            {
                case NetworkModel.RESTAPI.Profiles:
                    InitProfile(e.Result);
                    break;
                case NetworkModel.RESTAPI.Gems:
                    InitGem(e.Result);
                    break;
                case NetworkModel.RESTAPI.Engravings:
                    InitEngraving(e.Result);
                    break;
                case NetworkModel.RESTAPI.Cards:
                    InitCard(e.Result);
                    break;
                case NetworkModel.RESTAPI.Equipment:
                    InitEquipment(e.Result);
                    break;
            }
        }

        private void InitEquipment(object result)
        {
            var data = result as List<EquipmentModel>;
            EquipmentPanel.Children.Clear();
            if (data == null) return;
            int count = 0;
            foreach (var item in data)
            {
                EquipmentControl equipment = new EquipmentControl(item);
                equipment.Height = 110;
                EquipmentPanel.Children.Add(equipment);
                count++;
                if (count > 5) break;
            }
        }

        private void InitCard(object result)
        {
            CardEffectList.Items.Clear();
            var data = result as CardsResponseModel;
            if (data == null) return;
            foreach (var item in data.Effects[0].Items)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"{item.Name} - {item.Description}";
                CardEffectList.Items.Add(textBlock);
            }
        }

        private void InitEngraving(object result)
        {
            EngravingPanel.Children.Clear();
            var data = result as EngravingsResponseModel;
            if (data == null) return;
            foreach(var effect in data.Effects)
            {
                Chip chip = new Chip();
                chip.Content= effect.Name;
                chip.ToolTip = effect.Description;
                chip.Style = FindResource("MaterialDesignOutlineChip") as Style;
                chip.VerticalAlignment = VerticalAlignment.Center;
                chip.HorizontalAlignment = HorizontalAlignment.Center;
                EngravingPanel.Children.Add(chip);
            }

        }

        private void InitGem(object result)
        {
            GemPanel.Children.Clear();
            var data = result as GemsResponseModel;
            if (data == null) return;
            foreach(var gemData in data.Gems)
            {
                GemControl gem = new GemControl(gemData);
                GemPanel.Children.Add(gem);
            }
        }

        private void InitProfile(object result)
        {
            var profile = result as ArmoryProfileModel;
            CurrentProfile = profile;
            if (profile == null) return;
            InitInfoPanel(profile);
            InitStats(profile);
            InitTendencies(profile);
        }

        private void InitTendencies(ArmoryProfileModel profile)
        {
            TendencePanel.Children.Clear();
            foreach (var current in profile.Tendencies)
            {
                string format = $"{current.Type}: {current.Point}";
                Chip chip = new Chip();
                chip.Content = format;
                chip.Style = FindResource("MaterialDesignOutlineChip") as Style;
                chip.VerticalAlignment = VerticalAlignment.Center;
                chip.HorizontalAlignment = HorizontalAlignment.Center;
                TendencePanel.Children.Add(chip);
            }
        }

        private void InitStats(ArmoryProfileModel profile)
        {
            foreach(var current in profile.Stats)
            {
                switch (current.Type)
                {
                    case "치명":
                        CriticalChip.Content = "치명: " + current.Value;
                        //CriticalChip.ToolTip = current.Tooltip;
                        break;
                    case "특화":
                        SpecializationChip.Content = "특화: " + current.Value;
                        break;
                    case "제압":
                        SubdueChip.Content = "제압: "+ current.Value;
                        break;
                    case "신속":
                        SwiftnessChip.Content = "신속: " + current.Value;
                        break;
                    case "인내":
                        EnduranceChip.Content = "인내: " + current.Value;
                        break;
                    case "숙련":
                        PracticeChip.Content = "숙련: " + current.Value;
                        break;

                }
            }
        }

        private void InitInfoPanel(ArmoryProfileModel profile)
        {
            string itemLevel = "아이템 레벨: " + profile.ItemAvgLevel;
            string expeditionLevel = "원정대 레벨: " + profile.ExpeditionLevel;
            string guild = "길드: " + profile.GuildName;
            string characterLevel = "전투 레벨: " + profile.CharacterLevel;
            InfoPanel.Children.Clear();
            CharacterNameTextBlock.Text = profile.CharacterName;
            AddInfoItem(profile.CharacterClassName);
            AddInfoItem(profile.ServerName);
            AddInfoItem(itemLevel);
            AddInfoItem(expeditionLevel);
            AddInfoItem(guild);
            AddInfoItem(characterLevel);
        }

        private void AddInfoItem(string data)
        {
            Chip chip = new Chip();
            chip.Content = data;
            chip.Style = FindResource("MaterialDesignOutlineChip") as Style;
            InfoPanel.Children.Add(chip);
        }
    }
}
