﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    class Neuron : INeuron
    {
        public Neuron()
        {

        }
        public Neuron(double[] weihgts, IList<INeuron> childs, IList<INeuron> parents)
        {
            Weights = weihgts;
            Childs = childs;
            Parents = parents;
        }
        public double[] Weights { get; set; }

        public double Bias { get; set; }
        public IFunction ActivationFunction { get; set; }

        public IList<INeuron> Childs { get; set; }

        public IList<INeuron> Parents { get; set; }

        public double LastError { get; set; }

        public double LastState { get; set; }

        public double LastSum { get; set; }
    
        public double activate(double[] inputVector)
        {
            double state = ActivationFunction.compute(computeSum(inputVector));
            LastState = state;
            return LastState;
        }

        public double computeSum(double[] inputVector)
        {          
            double sum = Bias;

            for(int i = 0; i < Weights.Length; i++)            
                sum += Weights[i] * inputVector[i];
            
            LastSum = sum;
            return LastSum;
        }
    }
}