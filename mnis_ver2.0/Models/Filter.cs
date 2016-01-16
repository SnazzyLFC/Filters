using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace mnis_ver2._0.Models
{
    //czesc
    /// <summary>
    /// Klasa Filter jest abstrakcyjną klasą-matką dla wszystkich filtrów.
    /// </summary>
    public abstract class Filter
    {
        /// <summary>
        /// Kontruktor klasy Filter
        /// </summary>
        /// <param name="AlphaP">Wartość inicjalizująca dla maksumalnego tłumienia sygnału w paśmie przenoszenia [dB]</param>
        /// <param name="AlphaZ">Wartość inicjalizująca dla minimalnego tłumienia w paśmie zaporowym [dB]</param>
        /// <param name="FrequencyP">Wartość inicjalizująca dla krawędzmi pasma przenoszenia [Hz]/param>
        /// <param name="FrequencyZ">Wartość inicjalizująca dla krawędzi pasma zaporowego [Hz]</param>
        public List<Singal> signal { get; set; }
        public Singal Signal = new Singal(1, 10);
        public Filter (double AlphaP, double AlphaZ, double FrequencyP, double FrequencyZ, List<Singal> Signal)
        {
            this.AlphaP = AlphaP;
            this.AlphaZ = AlphaZ;
            this.FrequencyP = FrequencyP;
            this.FrequencyZ = FrequencyZ;
            this.signal = Signal;
        }
        /// <summary>
        /// Maksymalne tłumienie sygnału w paśmie przenoszenia [dB]
        /// </summary>
        public double AlphaP { get; set; }
        /// <summary>
        /// Minimalne tłumienie w paśmie zaporowym [dB]
        /// </summary>
        public double AlphaZ { get; set; }
        /// <summary>
        /// Krawędź pasma przenoszenia [Hz]
        /// </summary>
        public double FrequencyP { get; set; }
        /// <summary>
        /// Krawędź pasma zaporowego [Hz]
        /// </summary>
        public double FrequencyZ { get; set; }


        public double OmegaP { get; set; }
        public double OmegaZ { get; set; }
        public double RzadTemp { get; set; }
        public int Rzad { get; set; }
        public double Omega0 { get; set; }
        public Complex transmitancja = new Complex(0, 0);
        

    }
}
