using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class CoronarySclerosisNeuralNetwork : IMultilayerNeuralNetwork
    {
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

        public void randomize(double left,  double right)
        {
            Random random = new Random();
            double k = (right - left);
            double b = left;

            for(int l = 0; l < Layers.Length; l++)
            { 
                for(int n = 0; n < Layers[l].Neurons.Length; n++)
                { 
                    for(int i = 0; i < Layers[l].Neurons[n].Weights.Length; i++)
                    {
                        Layers[l].Neurons[n].Weights[i] = k * random.NextDouble() + b;
                    }
                    Layers[l].Neurons[n].Bias = k * random.NextDouble() + b;
                }
            }
        }
    }
}
