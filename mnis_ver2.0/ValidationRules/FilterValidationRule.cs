using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace mnis_ver2._0.ValidationRules
{
    public class FilterValidationRule
    {
        private int min = 0;
        private int max = 100;
        public bool IsError { get; set; }
        public delegate void UpdaterHandler(string message);
        public event UpdaterHandler Error;
        public void CheckValues(string value)
        {
            string Message;
            if (value == "")
            {
                IsError = true;
                Message = "Nie podano żadnej wartości";
                return;
            }
            try
            {
                double tempvalue = double.Parse(value);
                if (tempvalue < 0 || tempvalue > 100)
                {
                    //BadData: Show statement (bad range of data) and disable ok button
                    Message = "Wartość musi zawierać się między" + min.ToString() + " i" + max.ToString();
                    IsError = true;
                }
                else
                {
                    IsError = false;
                    Message = "";
                }
            }
            catch
            {
                //BadData: Show statement (it is not a number) and disable ok button
                Message = "Podana wartość nie jest liczbą!";
                IsError = true;
            }
            Error?.Invoke(Message);
        }
    }
}
