using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface INeuralNetwork
    {

        /// <summary>
        /// Compute output vector by input vector
        /// </summary>
        /// <param name="inputVector">Input vector (double[])</param>
        /// <returns>Output vector (double[])</returns>
        double[] computeOutput(double[] inputVector);


        /// <summary>
        /// Train network with given inputs and outputs
        /// </summary>
        /// <param name="inputs">Set of input vectors</param>
        /// <param name="outputs">Set if output vectors</param>
        void train(IList<DataItem<double>> data);
    }
}
