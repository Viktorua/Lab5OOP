using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Parabola : IFunction
    {
        public Parabola(double a = 0, double b = 0, double c = 0)
        {
            _multipliers[0] = a;
            _multipliers[1] = b;
            _multipliers[2] = c;
        }
        public double At(int index)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentException("Unccorrect index!");
            }

            return _multipliers[index];
        }

        public double Calculate(double x)
        {
            return _multipliers[0] * Math.Pow(x, 2) + _multipliers[1] * x + _multipliers[2];
        }

        private double[] _multipliers = new double[3];
    }
}
