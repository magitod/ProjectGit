using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class Layer : ILayer
    {
        int inputDimension_;
        double[] lastOutput_;
        INeuron[] neurons_;

        public Layer(int inputDimension, INeuron[] neurons)
        {
            inputDimension_ = inputDimension;
            neurons_ = neurons;
        }
        public int InputDimension { get { return inputDimension_; } }

        public double[] LastOutput { get { return lastOutput_; } }

        public INeuron[] Neurons { get { return neurons_; } }

        public double[] compute(double[] inputVector)
        {
            double[] output = new double[Neurons.Length];

            for (int i = 0; i < Neurons.Length; i++)
            {
                double sum = Neurons[i].computeSum(inputVector);
                output[i] = Neurons[i].activate(new double[] { sum });
            }
            
            lastOutput_ = output;

            return LastOutput;
        }       
    }
}
