using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.Model
{
    class WeeklyItemModel
    {
    }

    class WeeklyItemHeadersModel
    {
        public List<WeeklyItemHeaderModel> Headers { get; set; }
    }

    class WeeklyItemHeaderModel
    {
        public string Header { get; set; }
        public string HeaderType { get; set; }
    }
}
