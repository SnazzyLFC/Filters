using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnis_ver2._0.Models
{
    public class Singal
    {
        public Singal(double Pulsation, double Time) //,int Amplitude)
        {
            this._pulsation = Pulsation;
            //this._amplitude = Amplitude;
            this._time = Time;
            this.Sine = Math.Sin(Pulsation * Time);
            //this.ListOfSinus.Add(Math.Sin(Pulsation * Time));
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

        public double Sine { get; set; }
        //public List<double> ListOfSinus = new List<double>();

        private int _amplitude;
        public int Amplitude
        {
            get
            {
                return _amplitude;
            }
        }
    }
}
