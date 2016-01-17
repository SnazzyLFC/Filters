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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace mnis_ver2._0.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HelpPage : Page
    {
        public HelpPage()
        {
            this.InitializeComponent();
            webViewControl.Navigate(new Uri("http://lfc.pl"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webViewControl.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webViewControl.GoForward();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
