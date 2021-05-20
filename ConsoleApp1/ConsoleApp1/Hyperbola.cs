using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Hyperbola : IFunction
    {
        public Hyperbola(double multiplier)
        {
            _multiplier = multiplier;
        }

        public double At(int index)
        {
            if (index != 0)
            {
                throw new ArgumentException("Unccorrect index!");
            }

            return _multiplier;
        }

        public double Calculate(double x)
        {
            if (x == 0)
            {
                throw new ArgumentException("Division by zero!");
            }
            else
            {
                return _multiplier / x;
            }
        }


        private double _multiplier;
    }
}
