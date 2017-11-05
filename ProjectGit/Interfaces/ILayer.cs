using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface ILayer
    {

        /// <summary>
        /// Compute output of the layer
        /// </summary>
        /// <param name="inputVector">Input vector</param>
        /// <returns>Output vector</returns>
        double[] compute(double[] inputVector);

        /// <summary>
        /// Get last output of the layer
        /// </summary>
        double[] LastOutput { get; }

        /// <summary>
        /// Get neurons of the layer
        /// </summary>
        INeuron[] Neurons { get; }

        /// <summary>
        /// Get input dimension of neurons
        /// </summary>
        int InputDimension { get; }
    }
}
