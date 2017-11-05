using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface INeuron
    {
        double[] Weights { get; set; }

        double Bias { get; set; }

        double activate(double[] inputVector);

        double computeSum(double[] inputVector);

        double LastState { get; set; }

        double LastSum { get; set; }

        double LastError { get; set; }

        IList<INeuron> Childs { get; set; }

        IList<INeuron> Parents { get; set; }

        IFunction ActivationFunction { get; set; }
    }
}
