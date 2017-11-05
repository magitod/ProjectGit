using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface IMetrics<T>
    {
        double calculate(T[] v1, T[] v2);

        /// <summary>
        /// Calculate value of partial derivative by v2[v2Index]
        /// </summary>
        T calculatePartialDerivaitveByV2Index(T[] v1, T[] v2, int v2Index);
    }
}
