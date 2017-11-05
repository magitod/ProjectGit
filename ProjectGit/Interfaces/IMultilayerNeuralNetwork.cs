using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface IMultilayerNeuralNetwork : INeuralNetwork
    {
        /// <summary>
        /// Get array of layers of network
        /// </summary>
        ILayer[] Layers { get; }
    }
}
