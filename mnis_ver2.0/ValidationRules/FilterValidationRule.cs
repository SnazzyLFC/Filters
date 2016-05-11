using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace mnis_ver2._0.ValidationRules
{
    public class FilterValidationRule : Validator
    {
        private int min = 0;
        private int max = 100;
        private double alphaP;
        private double alphaZ;
        public delegate void UpdaterHandler(string message, TextBox valueBox);
        public event UpdaterHandler Error;

        public void CheckValues(TextBox ValueBox)
        {
            string value = ValueBox.Text;
            string name = ValueBox.Name;

            string Message;
            if (value == "")
            {
                IsError = true;
                Message = "Nie podano żadnej wartości";
            }
            else
            {
                try
                {
                    double tempvalue = double.Parse(value);
                    if (tempvalue < min || tempvalue > max)
                    {
                        //BadData: Show statement (bad range of data) and disable ok button
                        Message = "Wartość musi zawierać się między " + min.ToString() + " i " + max.ToString();
                        IsError = true;
                    }
                    else
                    {
                        switch (name)
                        {
                            case "alphaPbox":
                                alphaP = tempvalue;
                                break;
                            case "alphaZbox":
                                alphaZ = tempvalue;
                                break;
                        }
                        IsError = false;
                        Message = "";
                        //if (alphaZ>alphaP)
                        //{
                        //    IsError = true;
                        //    Message = "Minimalne tłumienie nie może być mniejsze od maksymalnego";
                        //}
                    }
                }
                catch
                {
                    //BadData: Show statement (it is not a number) and disable ok button
                    Message = "Podana wartość nie jest liczbą!";
                    IsError = true;
                }
            }
            Error?.Invoke(Message, ValueBox);
        }
    }
}
