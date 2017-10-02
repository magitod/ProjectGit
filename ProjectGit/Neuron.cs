using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class Neuron : INeuron
    {
        double[] weights_ = null;

        IList<INeuron> childs_ = null;
        IList<INeuron> parents_ = null;

        public Neuron(double[] weihgts, IList<INeuron> childs, IList<INeuron> parents)
        {
            weights_ = weihgts;
            childs_ = childs;
            parents_ = parents;
        }

        public IFunction ActivationFunction { get; set; }

        public double[] Weights { get { return weights_; } }

        public double Bias { get; set; }

        public IList<INeuron> Childs { get { return childs_; } }

        public IList<INeuron> Parents { get { return parents_; } }

        public double dEdz { get; set; }

        public double LastState { get; set; }

        public double LastSum { get; set; }

        public double activate(double[] inputVector)
        {
            throw new NotImplementedException();
        }

        public double computeSum(double[] inputVector)
        {          
            double sum = Bias;
            for(int i = 0; i < Weights.Length; i++)
            {
                sum += Weights[i] * inputVector[i];
            }
            return sum;
        }
    }
}
