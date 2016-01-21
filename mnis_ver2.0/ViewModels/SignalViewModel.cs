using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnis_ver2._0.ViewModels
{
    class SignalViewModel
    {
        public SignalViewModel()
        {
            Amplitude = 1;
            Pulsation = 1;

        }
        public int Amplitude { get; set; }
        public double Pulsation { get; set; }
    }
}


