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
            this.Pulsation = Pulsation;
            this.Time = Time;
            this.Sine = new List<double>();
            for (int i =0; i<Time; i++)
            {
                Sine.Add(Math.Sin(Pulsation * i));
            }
        }
        /// <summary>
        /// Pulsacja sygnalu.
        /// </summary>
        private double Pulsation;
        public double _pulsation
        {
            get
            {
                return Pulsation;
            }
        }
        /// <summary>
        /// Czas trwania sygnalu.
        /// </summary>
        private double Time;
        /// <summary>
        /// Lista wartości sinusa dla poszczególnych wartości czasu (od 0 do Time) pomnożonych przez pulsację.
        /// </summary>
        public List<double> Sine;
    }
}
