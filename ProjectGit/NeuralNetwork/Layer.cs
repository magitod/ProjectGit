using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class Layer : ILayer
    {
        double[] lastOutput_;

        public Layer(int inputDimension, INeuron[] neurons)
        {
            InputDimension = inputDimension;
            Neurons = neurons;
        }
        public int InputDimension { get; }

        public double[] LastOutput { get { return lastOutput_; } }

        public INeuron[] Neurons { get; }

        public double[] compute(double[] inputVector)
        {
            double[] output = new double[Neurons.Length];

            for (int i = 0; i < Neurons.Length; i++)
                output[i] = Neurons[i].activate(inputVector);
                       
            lastOutput_ = output;

            return LastOutput;
        }       
    }
}
