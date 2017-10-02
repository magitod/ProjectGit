using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class Neuron : INeuron
    {
        double[] weights_;
        double bias_;

        IFunction activationFunction_;

        IList<INeuron> childs_;
        IList<INeuron> parents_;

        double lastState_;
        double lastSum_;
        double dEdz_;

        public IFunction ActivationFunction { get { return activationFunction_; } set { activationFunction_ = value; } }

        public double[] Weights { get { return weights_; } }

        public double Bias { get { return bias_; } set { bias_ = value; } }

        public IList<INeuron> Childs { get { return childs_; } }

        public IList<INeuron> Parents { get { return parents_; } }

        public double dEdz { get { return dEdz_; } set { dEdz_ = value; } }

        public double LastState { get { return lastState_; } set { lastState_ = value; } }

        public double LastSum { get { return lastSum_; } set { lastSum_ = value; } }

        public double activate(double[] inputVector)
        {
            throw new NotImplementedException();
        }

        public double computeSum(double[] inputVector)
        {
            throw new NotImplementedException();
        }
    }
}
