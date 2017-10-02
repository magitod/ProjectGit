using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class CoronarySclerosisNeuralNetwork : IMultilayerNeuralNetwork
    {
        ILayer[] layers_;

        public ILayer[] Layers { get { return layers_; } }

        public double[] computeOutput(double[] inputVector)
        {
            throw new NotImplementedException();
        }

        public void train(IList<DataItem<double>> data)
        {
            throw new NotImplementedException();
        }
    }
}
