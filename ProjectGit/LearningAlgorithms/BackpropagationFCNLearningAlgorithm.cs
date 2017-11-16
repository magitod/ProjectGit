using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    internal class BackpropagationFCNLearningAlgorithm : ILearningStrategy<IMultilayerNeuralNetwork, LearningAlgorithmResult>
    {
        LearningAlgorithmConfig config_ = null;
        private Random random_ = null;

        private int[] shuffle(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (random_.NextDouble() >= 0.3d)
                {
                    int newIndex = random_.Next(arr.Length);
                    int tmp = arr[i];
                    arr[i] = arr[newIndex];
                    arr[newIndex] = tmp;
                }
            }
            return arr;
        }

        public BackpropagationFCNLearningAlgorithm(LearningAlgorithmConfig config)
        {
            config_ = config;
            random_ = new Random();
        }
        /// <summary>
        /// Обучение нейронной сети по обучающей выборке
        /// </summary>
        /// <param name="network">Нейронная сеть</param>
        /// <param name="data">Обучающая выборка</param>
        /// <returns>Возвращает LeaningAlgorithmResult </returns>
        public LearningAlgorithmResult train(IMultilayerNeuralNetwork network, IList<DataItem<double>> data)
        {
            #region -> Инициализируем параметры алгоритма

            double currentError = Single.MaxValue;
            double lastError = 0;
            int epochNumber = 0;
            DateTime dtStart = DateTime.Now;
            List<double> error_curve = new List<double>();

            if (config_.BatchSize < 1 ||
                config_.BatchSize > data.Count
            )
            {
                config_.BatchSize = data.Count;
            }

            #endregion

            #region -> Работа алгоритма обучения

            do {
                lastError = currentError;

                #region -> Обработка пакетов

                //index of dataitem
                int currentIndex = 0;

                //preparation for epoche
                int[] trainingIndices = new int[data.Count];
                for (int i = 0; i < data.Count; i++)
                    trainingIndices[i] = i;

                if (config_.BatchSize > 0)
                    //trainingIndices = shuffle(trainingIndices);

                do {
                    #region -> Инициализация аккумулированной ошибки весов (initialize accumulated Error for Weights, Biases)

                    double[][][] NablaWeights = new double[network.Layers.Length][][];
                    double[][] NablaBiases = new double[network.Layers.Length][];

                    for (int i = 0; i < network.Layers.Length; i++)
                    {
                        NablaBiases[i] = new double[network.Layers[i].Neurons.Length];
                        NablaWeights[i] = new double[network.Layers[i].Neurons.Length][];

                        for (int j = 0; j < network.Layers[i].Neurons.Length; j++)
                        {
                            NablaBiases[i][j] = 0;
                            NablaWeights[i][j] = new double[network.Layers[i].Neurons[j].Weights.Length];

                            for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                                NablaWeights[i][j][k] = 0;

                        }
                    }

                    #endregion

                    #region -> Обработка одного пакета (process one batch)

                    for (int i = currentIndex; 
                         i < currentIndex + config_.BatchSize && 
                         i < data.Count; 
                         i++
                    ){
                        double[] realOutput;
                        #region -> Прямое распространение сигналов (forward pass)

                            realOutput = network.computeOutput(data[trainingIndices[i]].Input);

                        #endregion
                        #region -> Обратное распространение ошибки (backward pass, error propagation)

                        #region -> ОБРАБОТКА ПОСЛЕДНЕГО СЛОЯ (last layer)

                        int _lastLayerIndex = network.Layers.Length - 1;
                        for (int j = 0; j < network.Layers[_lastLayerIndex].Neurons.Length; j++)
                        {
                            #region -> Вычисление ошибки выходного нейрона

                            network.Layers[_lastLayerIndex].Neurons[j].LastError =
                                config_.ErrorFunction.calculatePartialDerivaitveByV2Index( 
                                    data[i].Output, 
                                    realOutput, 
                                    j 
                                ) *
                                network.Layers[_lastLayerIndex].Neurons[j].ActivationFunction.computeFirstDerivative(
                                        network.Layers[_lastLayerIndex].Neurons[j].LastSum
                                );

                            #endregion
                            #region -> Вычисление градиентов весов нейрона

                            NablaBiases[_lastLayerIndex][j] += 
                                config_.LearningRate * 
                                network.Layers[_lastLayerIndex].Neurons[j].LastError;

                            for (int y = 0; y < network.Layers[_lastLayerIndex].Neurons[j].Weights.Length; y++)
                            {
                                NablaWeights[_lastLayerIndex][j][y] +=
                                    config_.LearningRate *
                                    (
                                        network.Layers[_lastLayerIndex].Neurons[j].LastError *
                                        ((network.Layers.Length > 1) ?
                                            network.Layers[_lastLayerIndex - 1].Neurons[y].LastState :
                                            data[i].Input[y]
                                        ) +
                                        config_.RegularizationFactor *
                                        network.Layers[_lastLayerIndex].Neurons[j].Weights[y] /
                                        data.Count
                                    );
                            }

                            #endregion
                        }

                        #endregion
                        #region -> ОБРАБОТКА СКРЫТЫХ СЛОЕВ (hidden layers)

                        for (int _hiddenLayerIndex = network.Layers.Length - 2; 
                             _hiddenLayerIndex >= 0; 
                             _hiddenLayerIndex--
                        ){
                            for (int j = 0; j < network.Layers[_hiddenLayerIndex].Neurons.Length; j++)
                            {
                                #region -> Вычисление ошибки сткрытого нейрона

                                network.Layers[_hiddenLayerIndex].Neurons[j].LastError = 0;
                                for (int k = 0; k < network.Layers[_hiddenLayerIndex + 1].Neurons.Length; k++)                              
                                    network.Layers[_hiddenLayerIndex].Neurons[j].LastError +=
                                        network.Layers[_hiddenLayerIndex + 1].Neurons[k].Weights[j] *
                                        network.Layers[_hiddenLayerIndex + 1].Neurons[k].LastError;
                                
                                network.Layers[_hiddenLayerIndex].Neurons[j].LastError *=
                                    network.Layers[_hiddenLayerIndex].Neurons[j].ActivationFunction.computeFirstDerivative(
                                        network.Layers[_hiddenLayerIndex].Neurons[j].LastSum
                                    );

                                #endregion
                                #region -> Вычисление градиентов весов нейрона

                                NablaBiases[_hiddenLayerIndex][j] += 
                                    config_.LearningRate *
                                    network.Layers[_hiddenLayerIndex].Neurons[j].LastError;

                                for (int y = 0; y < network.Layers[_hiddenLayerIndex].Neurons[j].Weights.Length; y++)
                                {
                                    NablaWeights[_hiddenLayerIndex][j][y] += 
                                        config_.LearningRate * 
                                        (
                                            network.Layers[_hiddenLayerIndex].Neurons[j].LastError *
                                            ( (_hiddenLayerIndex > 0) ? 
                                                network.Layers[_hiddenLayerIndex - 1].Neurons[y].LastState : 
                                                data[i].Input[y] 
                                            ) +
                                            config_.RegularizationFactor * 
                                            network.Layers[_hiddenLayerIndex].Neurons[j].Weights[y] / 
                                            data.Count
                                        );
                                }

                                #endregion
                            }
                        }
                        #endregion

                        #endregion
                    }

                    #endregion

                    #region -> Обновление весов (update weights and bias of neurons)

                    int size = Math.Min(config_.BatchSize, data.Count - currentIndex);
                    for (int layerIndex = 0; layerIndex < network.Layers.Length; layerIndex++)
                    {
                        for (int neuronIndex = 0; neuronIndex < network.Layers[layerIndex].Neurons.Length; neuronIndex++)
                        {
                            network.Layers[layerIndex].Neurons[neuronIndex].Bias -= NablaBiases[layerIndex][neuronIndex] / size;

                            for (int weightIndex = 0; weightIndex < network.Layers[layerIndex].Neurons[neuronIndex].Weights.Length; weightIndex++)
                                network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex] -= NablaWeights[layerIndex][neuronIndex][weightIndex] / size;
                        }
                    }

                    #endregion

                    currentIndex += config_.BatchSize;
                } while (currentIndex < data.Count);

                #endregion

                #region -> Вычисление ошибки на всей выборке (recalculating error on all data)

                //real error
                currentError = 0;

                for (int i = 0; i < data.Count; i++)
                {
                    double[] realOutput = network.computeOutput(data[i].Input);
                    currentError += config_.ErrorFunction.calculate(data[i].Output, realOutput);
                }

                currentError *= 1d / data.Count;

                #endregion

                #region -> Регуляризация (regularization)

                //regularization term
                if (Math.Abs(config_.RegularizationFactor - 0d) > Double.Epsilon)
                {
                    double reg = 0;
                    for (int layerIndex = 0; layerIndex < network.Layers.Length; layerIndex++)
                        for (int neuronIndex = 0; neuronIndex < network.Layers[layerIndex].Neurons.Length; neuronIndex++)
                        {
                            for (int weightIndex = 0; weightIndex < network.Layers[layerIndex].Neurons[neuronIndex].Weights.Length; weightIndex++)
                                reg += network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex] *
                                        network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex];
                        }
                                                                      
                    currentError += config_.RegularizationFactor * reg / (2 * data.Count);
                }

                #endregion

                error_curve.Add(currentError);
                epochNumber++;
            } while (
                epochNumber < config_.MaxEpoches &&
                currentError > config_.MinError &&
                Math.Abs(currentError - lastError) > config_.MinErrorChange
            );

            #endregion

            #region -> Инициализируем результат обучения

            LearningAlgorithmResult result = new LearningAlgorithmResult();
            result.Epoches = epochNumber;
            result.Error = currentError;
            result.Duration = Convert.ToDouble((DateTime.Now - dtStart).Duration().TotalMilliseconds / 1000.0);
            result.ErrorCurve = error_curve;

            #endregion

            return result;
        }

    }
}
