using Loauto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Loauto
{
    /// <summary>
    /// TodoList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WeeklyTaskManager : UserControl
    {
        public WeeklyTaskManager()
        {
            InitializeComponent();

            InitColumns();
        }

        private void InitColumns()
        {
            WeeklyItemHeadersModel weeklyItemHeaders = new WeeklyItemHeadersModel();
            List<WeeklyItemHeaderModel> headers = new List<WeeklyItemHeaderModel>();
            weeklyItemHeaders.Headers = headers;
            WeeklyItemHeaderModel header1 = new WeeklyItemHeaderModel()
            {
                Header = "Name",
                HeaderType = typeof(string).ToString(),
            };
            WeeklyItemHeaderModel header2 = new WeeklyItemHeaderModel()
            {
                Header = "Name",
                HeaderType = typeof(string).ToString(),
            };
            WeeklyItemHeaderModel header3 = new WeeklyItemHeaderModel()
            {
                Header = "Name",
                HeaderType = typeof(string).ToString(),
            };
            WeeklyItemHeaderModel header4 = new WeeklyItemHeaderModel()
            {
                Header = "Name",
                HeaderType = typeof(string).ToString(),
            };
            headers.Add(header1);
            headers.Add(header2);
            headers.Add(header3);
            headers.Add(header4);

            string jsonString = JsonSerializer.Serialize(weeklyItemHeaders);
            Console.WriteLine(jsonString);
        }
    }

}
