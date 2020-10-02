using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1Tablicowaniefunkcji
{
    [DebuggerDisplay("{ToString()}")]
    public class Polynomial
    {

        protected int _deg;
        protected int[] _coefficients;
        protected int _divider;
        public Polynomial(int deg)
        {

            _deg = deg;
            _coefficients = new int[deg];
            _divider = 1;
        }

        public Polynomial(Polynomial pol)
        {
            _coefficients = (int[])pol._coefficients.Clone();
            _divider = pol._divider;
            _deg = pol._deg;
        }


        public int Length { get => _coefficients.Length; }
        public int Divider { get => _divider; }
        
        public void DivideBy (int value)
        {
            _divider *= value;
        }
        /// <summary>
        /// uproszczona wersja dodawania wspolczynnikow nie bierze pod uwage dzielnikow
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polynomial operator + (Polynomial x, Polynomial y)
        {
            Polynomial result;
            Polynomial added;
            if(x.Length < y.Length) 
            {
                result = new Polynomial(y);
                added = x;
            }
            else
            {
                result = new Polynomial(x);
                added = y;
            }
            for (int i = 0; i < added.Length; i++)
            {
                result._coefficients[i] += added._coefficients[i]; 
            }
            return result;
        }
        public static Polynomial operator +(Polynomial x,int value)
        {
            var result = new Polynomial(x);
            result._coefficients[0] += value;
            return result;
        }

        public static Polynomial operator * (Polynomial x, int value)
        {
            var result = new Polynomial(x);
            for (int i = 0; i < x.Length; i++)
            {
                result._coefficients[i] *= value;
            }
            return result;
        }

        public static Polynomial operator << (Polynomial x, int value)
        {
            var result = new Polynomial(x.Length + value);
            x._coefficients.CopyTo(result._coefficients, value);
            result._divider = x._divider;
            return result;
        }

        public string sign(int x)
        {
            if (x < 0) return "";
            else return "+";
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("(");
            for (int i = Length-1; i > 1; i--)
            {    
                
                if (_coefficients[i] != 0)
                {
                    result.Append(sign(_coefficients[i]));

                    result.Append($"{_coefficients[i]} x^{i}");

                }
            }
            if (Length >1) result.Append($"{sign(_coefficients[1])}{_coefficients[1]}x");
            result.Append($"{sign(_coefficients[0])}{_coefficients[0]}");
            result.Append($")/{Divider}");
            return result.ToString();
        }
        public double FunctionValueInPoint (double point)
        {
            double functionValue = 0;

            for (int i =0;i<Length;i++ )
            {
                functionValue = functionValue + ((Math.Pow(point,i) * _coefficients[i]) / _divider);
            }
            return functionValue;
            //wygląda na to że stopień wzrasta dwa razy za wolno


        }
        

    }
}
