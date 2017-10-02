using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface INeuron
    {
        /// <summary>
        /// Weights of the neuron
        /// Веса нейронов
        /// </summary>
        double[] Weights { get; set; }

        /// <summary>
        /// Offset/bias of neuron (default is 0)
        /// Смещение нейрона / Свободный коэффициент
        /// </summary>
        double Bias { get; set; }

        /// <summary>
        /// Compute state of neuron
        /// Вычислить состояние нейрона
        /// </summary>
        /// <param name="inputVector">Input vector (must be the same dimension as was set in SetDimension)</param>
        /// <returns>State of neuron</returns>
        double activate(double[] inputVector);

        /// <summary>
        /// Compute Sum of the neuron by input vector
        /// </summary>
        /// <param name="inputVector">Input vector (must be the same dimension as was set in SetDimension)</param>
        /// <returns>NET of neuron</returns>
        double computeSum(double[] inputVector);

        /// <summary>
        /// Last calculated state in Activate
        /// Последнее вычисленное состояние
        /// </summary>
        double LastState { get; set; }

        /// <summary>
        /// Last calculated Summa
        /// </summary>
        double LastSum { get; set; }

        IList<INeuron> Childs { get; set; }

        IList<INeuron> Parents { get; set; }

        IFunction ActivationFunction { get; set; }

        double dEdz { get; set; }
    }
}
