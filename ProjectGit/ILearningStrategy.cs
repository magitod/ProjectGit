using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface ILearningStrategy<T>
    {
        /// <summary>
        /// Train neural network
        /// Обучить нейронную сеть
        /// </summary>
        /// <param name="network">Neural network for training</param>
        /// <param name="inputs">Set of input vectors</param>
        /// <param name="outputs">Set of output vectors</param>
        void train(T network, IList<DataItem<double>> data);
    }
}
