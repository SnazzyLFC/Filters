using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mnis_ver2._0.ViewModels
{
    class FilterViewModel
    {
        //private ValidationRules.FilterValidationRule _validator = new ValidationRules.FilterValidationRule();
        private double _alphaZ;
        public double AlphaZ { get; set; }
        public double AlphaP { get; set; }
        public double FrequencyP { get; set; }
        public double FrequencyZ { get; set; }

        public bool IsError = false;
    }
}
