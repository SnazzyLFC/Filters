using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace mnis_ver2._0.Views
{
    public sealed partial class Graph : UserControl
    {
        public Graph()
        {
            this.InitializeComponent();
            List<Models.Singal> Signal = new List<Models.Singal>();
            for (double i =0; i<10; i+=0.1)
            {
                Signal.Add(new Models.Singal(1, i));
            }
            (lineGraph.Series[0] as LineSeries).ItemsSource = Signal;
        }
    }
}
