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

        public ILayer[] Layers { get; set; }

        public double[] computeOutput(double[] inputVector)
        {
            double[] output = inputVector;
            for(int i = 0; i < Layers.Length; i++)
            {
                output = Layers[i].compute(output);
            }
            return output;
        }

        public void train(IList<DataItem<double>> data)
        {
            throw new NotImplementedException();
        }
    }
}
