using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnis_ver2._0.Models
{
    public class Singal
    {
        public Singal(double Pulsation, double Time)
        {
            this._pulsation = Pulsation;
            this._time = Time;
            this.Sine = Math.Sin(Pulsation * Time);
            
        }
        /// <summary>
        /// Pulsacja sygnalu.
        /// </summary>
        private double _pulsation;
        public double Pulsation
        {
            get
            {
                return _pulsation;
            }
        }
        /// <summary>
        /// Czas trwania sygnalu.
        /// </summary>
        private double _time;
        public double Time
        {
            get
            {
                return _time;
            }
        }
        /// <summary>
        /// Lista wartości sinusa dla poszczególnych wartości czasu (od 0 do Time) pomnożonych przez pulsację.
        /// </summary>
        public double Sine { get; set; }
    }
}
