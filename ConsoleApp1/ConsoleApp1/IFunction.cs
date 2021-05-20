using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    interface IFunction
    {
        double Calculate(double x);
        double At(int index);
    }
}
