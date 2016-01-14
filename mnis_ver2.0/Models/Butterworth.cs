using System;
using System.Collections.Generic;
using System.Numerics;

namespace mnis_ver2._0.Models
{
    public class Butterworth : Filter
    {
        //Konstruktor wylicza transmitancjê w postaci G(jw)
        public Butterworth(double a, double b, double c, double d) : base(a, b, c, d)
        {
            OmegaP = 2 * Math.PI * FrequencyP;
            OmegaZ = 2 * Math.PI * FrequencyZ;
            RzadTemp = (Math.Log10(Math.Pow(10, AlphaP / 10) - 1) - Math.Log10(Math.Pow(10, AlphaZ / 10) - 1)) / 2 * Math.Log10(OmegaP / OmegaZ);
            Rzad = (int)Math.Ceiling(RzadTemp);
            Omega0=OmegaP/Math.Pow(( (Math.Pow(10,AlphaP/10)-1) ),1/(2*Rzad));
            //Omega z sygna³u !
            Complex p = new Complex(0, Omega / Omega0);

            switch (Rzad)
            {
                case 1:
                    transmitancja = 1 / (1 + 1 * p + p);
                    break;

                case 2:
                    transmitancja = 1 / (1 + 1.4142136 * p + 1 * Math.Pow(p.Imaginary, 2) + Math.Pow(p.Imaginary, 2));
                    break;

                case 3:
                    transmitancja = 1 / (1 + 2 * p + 2 * Math.Pow(p.Imaginary, 2) + 1 * Math.Pow(p.Imaginary, 3) + Math.Pow(p.Imaginary, 3));
                    break;

                case 4:
                    transmitancja = 1 / (1 + 2.6131259 * p + 3.4142136 * Math.Pow(p.Imaginary, 2) + 2.6131259 * Math.Pow(p.Imaginary, 3) + 1 * Math.Pow(p.Imaginary, 4) + Math.Pow(p.Imaginary, 4));
                    break;

                case 5:
                    transmitancja = 1 / (1 + 3.2360680 * p + 5.2360680 * Math.Pow(p.Imaginary, 2) + 5.2360680 * Math.Pow(p.Imaginary, 3) + 3.2360680 * Math.Pow(p.Imaginary, 4) + 1 * Math.Pow(p.Imaginary, 5) + Math.Pow(p.Imaginary, 5));
                    break;

                case 6:
                    transmitancja = 1 / (1 + 3.8637033 * p + 7.4641016 * Math.Pow(p.Imaginary, 2) + 9.1416202 * Math.Pow(p.Imaginary, 3) + 7.4641016 * Math.Pow(p.Imaginary, 4) + 3.8637033 * Math.Pow(p.Imaginary, 5) + 1 * Math.Pow(p.Imaginary, 6) + Math.Pow(p.Imaginary, 6));
                    break;

                case 7:
                    transmitancja = 1 / (1 + 4.4939592 * p + 10.097835 * Math.Pow(p.Imaginary, 2) + 14.591794 * Math.Pow(p.Imaginary, 3) + 14.591794 * Math.Pow(p.Imaginary, 4) + 10.097835 * Math.Pow(p.Imaginary, 5) + 4.4939592 * Math.Pow(p.Imaginary, 6) + 1 * Math.Pow(p.Imaginary, 7) + Math.Pow(p.Imaginary, 7));
                    break;

                case 8:
                    transmitancja = 1 / (1 + 5.1258309 * p + 13.137071 * Math.Pow(p.Imaginary, 2) + 21.846151 * Math.Pow(p.Imaginary, 3) + 25.688356 * Math.Pow(p.Imaginary, 4) + 21.846151 * Math.Pow(p.Imaginary, 5) + 13.137071 * Math.Pow(p.Imaginary, 6) + 5.1258309 * Math.Pow(p.Imaginary, 7) + 1 * Math.Pow(p.Imaginary, 8) + Math.Pow(p.Imaginary, 8));
                    break;

                case 9:
                    transmitancja = 1 / (1 + 1.7887705 * p + 16.581719 * Math.Pow(p.Imaginary, 2) + 31.163437 * Math.Pow(p.Imaginary, 3) + 41.986386 * Math.Pow(p.Imaginary, 4) + 41.986386 * Math.Pow(p.Imaginary, 5) + 31.163437 * Math.Pow(p.Imaginary, 6) + 16.581719 * Math.Pow(p.Imaginary, 7) + 5.7587705 * Math.Pow(p.Imaginary, 8) + Math.Pow(p.Imaginary, 9) + Math.Pow(p.Imaginary, 9));
                    break;

                case 10:
                    transmitancja = 1 / (1 + 6.3924532 * p + 20.431729 * Math.Pow(p.Imaginary, 2) + 42.802061 * Math.Pow(p.Imaginary, 3) + 64.882396 * Math.Pow(p.Imaginary, 4) + 74.233429 * Math.Pow(p.Imaginary, 5) + 64.882396 * Math.Pow(p.Imaginary, 6) + 42.802061 * Math.Pow(p.Imaginary, 7) + 20.431729 * Math.Pow(p.Imaginary, 8) + 6.3924532 * Math.Pow(p.Imaginary, 9) + Math.Pow(p.Imaginary, 9));
                    break;

            }
        }

    }
}
