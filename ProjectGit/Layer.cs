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

        public int InputDimension { get { return inputDimension_; } }

        public double[] LastOutput { get { return lastOutput_; } }

        public INeuron[] Neurons { get { return neurons_; } }

        public double[] compute(double[] inputVector)
        {
            throw new NotImplementedException();
        }
    }
}
