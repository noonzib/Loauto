using Loauto.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Loauto.ViewModel
{
    class SearchViewModel
    {
        public NetworkCommand RequestNetworkCommand { get; set; }
        public SearchViewModel()
        {
            RequestNetworkCommand = new NetworkCommand(RequestCharacters, AddMessage);

            NetworkManager.Singleton.ReceivedResponse += Singleton_ReceivedResponse;
        }

        private void Singleton_ReceivedResponse(object sender, ReceiveResponseEventArgs e)
        {
        
        }

        public void RequestProfile(string message)
        {
            MessageBox.Show(message);
        }

        public bool AddMessage(string message)
        {
            if (message.Length == 0) return false;
            return true;
        }

        public void RequestCharacters(string name)
        {
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Profiles, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Equipment, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Avatars, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.CombatSkills, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Engravings, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Cards, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Gems, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Colosseums, name);
            NetworkManager.Singleton.SendRequest(Model.NetworkModel.RESTAPI.Collectibles, name);

        }
    }
}
