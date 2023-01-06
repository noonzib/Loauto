using Loauto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.ViewModel
{
    class WeeklyTaskManagerViewModel : ViewModelBase
    {
        public ObservableCollection<WeeklyItemModel> WeeklyItems { get; }
        public List<ColumnModel> Headers { get; }
    }

    public class ColumnModel
    {
        public string header;
        public Type colType;
    }
}
