using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    internal class SigmoidFunction : IFunction
    {

        private double alpha_ = 1.0;
        internal SigmoidFunction()
        {

        }
        internal SigmoidFunction(double alpha)
        {
            alpha_ = alpha;
        }

        public double compute(double x)
        {
            double r = (1.0 / (1.0 + Math.Exp(-alpha_ * x)));
            return r;
        }

        public double computeFirstDerivative(double x)
        {
            double f = this.compute(x);
            return alpha_ * f * (1 - f);
        }
    }
}
