using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface IFunction
    {
        double compute(double x);
        double computeFirstDerivative(double x);
    }
}
