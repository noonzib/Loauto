using Loauto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Loauto.ViewModel
{
    partial class MainWindowViewModel:ViewModelBase
    {

        private string _searchKeyword;
        private readonly ICollectionView _demoItemsView;
        private int _selectedIndex;
        private bool _controlsEnabled = true;
        private MenuItemModel _selectedItem;


        public MainWindowViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemModel>(new[]
            {
                new MenuItemModel(
                    "Home",
                    typeof(Home)
                ),
                new MenuItemModel(
                    "Search",
                    typeof(Search),
                    new SearchViewModel()
                ),
                new MenuItemModel(
                    "Engravings",
                    typeof(Home)
                ),
            });


            _demoItemsView = CollectionViewSource.GetDefaultView(MenuItems);
            _demoItemsView.Filter = DemoItemsFilter;
        }

        public ObservableCollection<MenuItemModel> MenuItems { get; }

        public MenuItemModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public bool ControlsEnabled
        {
            get => _controlsEnabled;
            set => SetProperty(ref _controlsEnabled, value);
        }

        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                if (SetProperty(ref _searchKeyword, value))
                {
                    _demoItemsView.Refresh();
                }
            }
        }

        private bool DemoItemsFilter(object obj)
        {
            if (string.IsNullOrWhiteSpace(_searchKeyword))
            {
                return true;
            }

            return obj is MenuItemModel item
                   && item.Name.ToLower().Contains(_searchKeyword.ToLower());
        }

    }


}
