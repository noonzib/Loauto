﻿using System;
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
    /// GemControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GemControl : UserControl
    {
        public GemControl(Model.ArmoriesResponseModel.GemsResponseModel.GemModel gemData)
        {
            InitializeComponent();
            this.DataContext = gemData;
            this.ToolTip = gemData.Name;
            //GemLevel.Text = gemData.Level.ToString();
            //GemImage.Source = gemData.Icon;
            //GemImage.Source = new ImageSourceConverter().ConvertFromString(gemData.Icon) as ImageSource;
        }
        public GemControl()
        {
            InitializeComponent();
        }
    }
}
