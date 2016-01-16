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

namespace mnis_ver2._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ValidationRules.FilterValidationRule Validator;
        private ViewModels.FilterViewModel FilterVM;
        public MainPage()
        {
            this.InitializeComponent();
            combo.Items.Add("Czebyszew");
            combo.Items.Add("Butterworth");
            FilterVM = new ViewModels.FilterViewModel();
            Validator = new ValidationRules.FilterValidationRule();
            Validator.Error += ErrorHandler; 
            frequencyPbox.DataContext = frequencyZbox.DataContext = alphaPbox.DataContext = alphaZbox.DataContext = FilterVM;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            List<Models.Singal> Signal = new List<Models.Singal>();
            for (double i = 0; i < 10; i += 0.1)
            {
                Signal.Add(new Models.Singal(1, i));
            }
            Models.Czebyszew Filtr = new Models.Czebyszew(1, 10, 12, 1, Signal);
        }

        private void alphaPbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string value = (sender as TextBox).Text;
            Validator.CheckValues(sender as TextBox);           
        }

        private void alphaZbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frequencyPbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frequencyZbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pulsationBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void amplitudeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void ErrorHandler(string Message, TextBox ValueBox)
        {
            if(Validator.IsError)
            {
                OkButton.IsEnabled = false;
                ValueBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                //ValueBox.BorderThickness = Windows.UI.Th;
            }
            else
            {
                OkButton.IsEnabled = true;
                ValueBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.White);
            }

        }
    }
}
