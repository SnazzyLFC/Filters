using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        private ValidationRules.FilterValidationRule FilterValidator;
        private ValidationRules.SignalValidationRule SignalValidator;
        private ValidationRules.Validator Validator;
        private ViewModels.FilterViewModel FilterVM;
        private ViewModels.SignalViewModel SignalVM;
        public MainPage()
        {
            this.InitializeComponent();
            combo.Items.Add("Czebyszew");
            combo.Items.Add("Butterworth");
            FilterValidator = new ValidationRules.FilterValidationRule();
            SignalValidator = new ValidationRules.SignalValidationRule();
            Validator = new ValidationRules.Validator();
            FilterValidator.Error += ErrorHandler;
            SignalValidator.Error += ErrorHandler;
            FilterVM = new ViewModels.FilterViewModel();
            SignalVM = new ViewModels.SignalViewModel();
            frequencyPbox.DataContext = frequencyZbox.DataContext = alphaPbox.DataContext = alphaZbox.DataContext = FilterVM;
            amplitudeCombo.DataContext = pulsationBox.DataContext= SignalVM;
            for (int i = -5; i < 6; i++)
            {
                if (i!=0)
                {
                    amplitudeCombo.Items.Add(i);
                }

            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            List<Models.Singal> Signal = new List<Models.Singal>();
            for (double i = 0; i < 10; i += 0.1)
            {
                Signal.Add(new Models.Singal(1, i));
            }
            //REFLEKSJA!
            string TypeName = "mnis_ver2._0.Models." + combo.SelectedValue;
            Type T = Type.GetType(TypeName);
            var obj = Activator.CreateInstance(T, FilterVM.AlphaP, FilterVM.AlphaZ, FilterVM.FrequencyP, FilterVM.FrequencyZ, Signal);
            //I to tyle refleksji
            myGraph.Draw((Models.Filter)obj);
        }

        private void alphaPbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterValidator.CheckValues(sender as TextBox);           
        }

        private void alphaZbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterValidator.CheckValues(sender as TextBox);
        }

        private void frequencyPbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterValidator.CheckValues(sender as TextBox);
        }

        private void frequencyZbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterValidator.CheckValues(sender as TextBox);
        }

        private void pulsationBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignalValidator.CheckValues(sender as TextBox);
            
        }

        //private void amplitudeBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
           
        //}


        private void ErrorHandler(string Message, TextBox ValueBox)
        {
            StackPanel ParentControl = (StackPanel)ValueBox.Parent;
            TextBlock ErrorMark = new TextBlock();
            ErrorMark.Text = "!";
            ErrorMark.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            ErrorMark.FontWeight = Windows.UI.Text.FontWeights.Bold;
            ErrorMark.FontSize = 39;
            ErrorMark.Height = 23;
            ErrorMark.Width = 15;
            ErrorMark.Margin = new Thickness(20, 0, 0, 0);
            ErrorMark.Name = "ErrorMark";
            //ErrorMark.GotFocus += new RoutedEventHandler(ShowMessage);
            ErrorMark.PointerEntered += (s, e) =>
            {
                var msg = new MessageDialog(Message);
                msg.ShowAsync();
                ValueBox.Focus(FocusState.Programmatic);
                ValueBox.Select(0, ValueBox.Text.Length);
            };
            if (FilterValidator.IsError || SignalValidator.IsError)
            {
                bool flag = true;
                foreach(var child in ParentControl.Children)
                {
                    try
                    {
                        var Child = (TextBlock)child;
                        if (Child.Name == "ErrorMark")
                        {
                            flag = false;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                if (flag)
                {
                    ParentControl.Children.Add(ErrorMark);
                }
                if (OkButton.IsEnabled)
                {
                    OkButton.IsEnabled = false;
                    ValueBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);

                }
            }
            else
            {
                OkButton.IsEnabled = true;
                ValueBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.White);
                foreach (var child in ParentControl.Children)
                {
                    try
                    {
                        var Child = (TextBlock)child;
                        if (Child.Name == "ErrorMark")
                        {
                            ParentControl.Children.Remove(child);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.HelpPage));
        }
    }
}
