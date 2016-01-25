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
    //TO DO:
    //zmienić to gówno

    public sealed partial class Graph : UserControl
    {
        public class Helper
        {
            public double Sine { get; set; }
            public double Time { get; set; }
        }
        public Graph()
        {

            this.InitializeComponent();

        }

        private List<Helper> CountOutputValue(Models.Filter Filter)
        {
            List<Helper> Output = new List<Helper>();
            int j = 0;
            for (double i=0; i<10; i+=0.1)
            {
                double temp = Filter.signal[j].Sine * Filter.transmitancja.Magnitude;
                Helper temp2 = new Helper();
                temp2.Sine = temp;
                temp2.Time = i - Filter.transmitancja.Phase;
                Output.Add(temp2);
                j++;
            }
            return Output;
        }
        public void Draw(Models.Filter FilterModel)
        {
            List<Models.Singal> Signal = new List<Models.Singal>();
            for (double i = 0; i < 10; i += 0.1)
            {
                Signal.Add(new Models.Singal(1, i));
            }
            (lineGraph.Series[0] as LineSeries).ItemsSource = Signal;
            (lineGraph.Series[1] as LineSeries).ItemsSource = CountOutputValue(FilterModel);
        }
    }
}
