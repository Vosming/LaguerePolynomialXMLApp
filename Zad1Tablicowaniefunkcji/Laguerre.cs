using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1Tablicowaniefunkcji
{
    public class Laguerre
    {
        protected int _deg;
        protected Polynomial _polynomial;
        public Laguerre ( int deg)
        {
            _deg = deg;
            _polynomial = CreateLaguerrePolynomial(deg);
        }

        protected Polynomial CreateLaguerrePolynomial(int deg)
        {
            var L0 = new Polynomial(1) + 1;
            var test = L0.ToString();
            var L1 = ((L0 * -1)<<1) + 1;
            var L2 = (L1 << 1) * -1 + L1 * 3 + L0 * -1;
            L2.DivideBy(2);
            int n = 1;
            if (_deg < 0)
                throw new Exception("Bad Laguerre polynomial : deg < 0");
            if (_deg == 0) return L0;
            else if (_deg == 1) return L1;
            else
            {
                while (n < _deg)
                {
                    L2 = (L1 << 1) * -1 + L1 * (2*n+1) + (L0 * (-1*(n*(n))));
                    L2.DivideBy(n+1); ;
                    L0 = L1; L1 = L2; n++;
                }
                return L2;
            }
        }

        public Polynomial Polynomial { get => _polynomial; }
        public static Func<double, int, double> CalculateAnalitycal { get; internal set; }

        public double CalculateAnalytical(double x, int deg)
        {
            double L0 = 1.0; double L1 = 1.0 - x;
            double L2 = (x * x - 4 * x + 2.0) / 2.0;
            int n = 1;
            if (deg < 0)
                throw new Exception("Bad Laguerre polynomial : deg < 0");
            if (deg == 0) return L0;
            else if (deg == 1) return L1;
            else
            {
                while (n < deg)
                {
                    L2 = ((2.0 * n + 1.0 - x) * L1 - n * L0) / (n + 1);
                    L0 = L1; L1 = L2; n++;
                }
                return L2;
            }
        }
    }
}
