using Loauto.Model;
using Newtonsoft.Json.Linq;
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

namespace Loauto.CustomControl
{
    /// <summary>
    /// EquipmentControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EquipmentControl : UserControl
    {
        //private ArmoriesResponseModel.EquipmentModel item;

        public EquipmentControl()
        {
            InitializeComponent();
        }

        public EquipmentControl(ArmoriesResponseModel.EquipmentModel item)
        {
            InitializeComponent();
            //this.item = item;
            this.DataContext = item;
            string tooltip = item.Tooltip;
            tooltip = tooltip.Replace("\r\n","").Replace("\r\n", "\\\"");
            var jobject = JObject.Parse(tooltip);
            var quailty = jobject["Element_001"]["value"]["qualityValue"];
            Console.WriteLine(tooltip);
            Console.WriteLine(quailty);
            QualityProgress.Value = (int)quailty;
            QualityTextBlock.Text = (string)quailty;
        }
    }
}
