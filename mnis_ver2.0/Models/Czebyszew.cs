using System;
using System.Collections.Generic;
using System.Numerics;


namespace mnis_ver2._0.Models
{
    public class Czebyszew : Filter
    {
        private static int count_b = 10;
        private static int count_c2= 10;

        public Czebyszew(double a, double b, double c, double d) : base(a, b, c, d)
        {
            List<double> _b = new List<double>();
            List<double> _c2 = new List<double>();
            
            double E;

            OmegaP = 2 * Math.PI * FrequencyP;
            OmegaZ = 2 * Math.PI * FrequencyZ;
            Omega0 = OmegaP;

            Complex p = new Complex(0, Omega / Omega0);

            E = Math.Sqrt(Math.Pow(10, 0.1 * AlphaP) - 1);

            RzadTemp = Math.Pow(Math.Cosh(Math.Sqrt((Math.Pow(10, 0.1 * AlphaZ) - 1) / (Math.Pow(10, 0.1 * AlphaP) - 1))), -1) / Math.Pow(Math.Cosh(OmegaZ / OmegaP), -1);
            Rzad = (int)Math.Ceiling(RzadTemp);

            for (int i = 0; i < count_b; i++)
            {
                _b.Add(2 * Math.Sin((Math.PI + 2 * Math.PI * i) / 2 * Rzad) * Math.Sinh((Math.Pow(Math.Sinh(1 / E), -1)) / Rzad));
            }

            for (int i = 0; i < count_c2; i++)
            {
                _c2.Add(Math.Pow(Math.Cosh((Math.Pow(Math.Sinh(1 / E), -1)) / Rzad), 2) - Math.Pow(Math.Sin((Math.PI + 2 * i * Math.PI) / 2 * Rzad), 2));
            }


            transmitancja = 1;

            if (Rzad % 2 == 0)
            {

                for (int i = 0; i < Rzad / 2; i++)
                {
                    transmitancja = transmitancja * _c2[i] / (Math.Pow(p.Imaginary, 2) + _b[i] * p + _c2[i]);
                }

                transmitancja = transmitancja * 1 / (Math.Sqrt(1 + Math.Pow(E, 2)));
            }

            if (Rzad % 2 == 1)
            {

                for (int i = 0; i < Rzad / 2; i++)
                {
                    transmitancja = transmitancja * _c2[i] / (Math.Pow(p.Imaginary, 2) + _b[i] * p + _c2[i]);
                }
                transmitancja = transmitancja * (_b[(Rzad - 1) / 2]) / (p * Omega0 + _b[(Rzad - 1) / 2]);

            }
        }

    }
}
