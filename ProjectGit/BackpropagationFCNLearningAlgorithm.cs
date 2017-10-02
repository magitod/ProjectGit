using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    internal class BackpropagationFCNLearningAlgorithm : ILearningStrategy<IMultilayerNeuralNetwork>
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

        public void train(IMultilayerNeuralNetwork network, IList<DataItem<double>> data)
        {
            if (config_.BatchSize < 1 || config_.BatchSize > data.Count)
            {
                config_.BatchSize = data.Count;
            }
            double currentError = Single.MaxValue;
            double lastError = 0;
            int epochNumber = 0;
            //Logger.Instance.Log("Start learning...");


            do
            {
                lastError = currentError;
                DateTime dtStart = DateTime.Now;

                //preparation for epoche
                int[] trainingIndices = new int[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    trainingIndices[i] = i;
                }
                if (config_.BatchSize > 0)
                {
                    trainingIndices = shuffle(trainingIndices);
                }


                int currentIndex = 0;
                do
                {
                    #region initialize accumulated error for batch, for weights and biases

                    double[][][] nablaWeights = new double[network.Layers.Length][][];
                    double[][] nablaBiases = new double[network.Layers.Length][];

                    for (int i = 0; i < network.Layers.Length; i++)
                    {
                        nablaBiases[i] = new double[network.Layers[i].Neurons.Length];
                        nablaWeights[i] = new double[network.Layers[i].Neurons.Length][];
                        for (int j = 0; j < network.Layers[i].Neurons.Length; j++)
                        {
                            nablaBiases[i][j] = 0;
                            nablaWeights[i][j] = new double[network.Layers[i].Neurons[j].Weights.Length];
                            for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                            {
                                nablaWeights[i][j][k] = 0;
                            }
                        }
                    }

                    #endregion

                    //process one batch
                    for (int inBatchIndex = currentIndex; inBatchIndex < currentIndex + config_.BatchSize && inBatchIndex < data.Count; inBatchIndex++)
                    {
                        //forward pass
                        double[] realOutput = network.computeOutput(data[trainingIndices[inBatchIndex]].Input);

                        //backward pass, error propagation
                        //last layer
                        //.......................................ОБРАБОТКА ПОСЛЕДНЕГО СЛОЯ

                        for (int j = 0; j < network.Layers[network.Layers.Length - 1].Neurons.Length; j++)
                        {
                            network.Layers[network.Layers.Length - 1].Neurons[j].dEdz =
                                config_.ErrorFunction.calculatePartialDerivaitveByV2Index(data[inBatchIndex].Output, realOutput, j) *
                                network.Layers[network.Layers.Length - 1].Neurons[j].ActivationFunction.computeFirstDerivative(network.Layers[network.Layers.Length - 1].Neurons[j].LastSum);

                            nablaBiases[network.Layers.Length - 1][j] += 
                                config_.LearningRate *
                                network.Layers[network.Layers.Length - 1].Neurons[j].dEdz;

                            for (int i = 0; i < network.Layers[network.Layers.Length - 1].Neurons[j].Weights.Length; i++)
                            {
                                nablaWeights[network.Layers.Length - 1][j][i] +=
                                    config_.LearningRate * 
                                    (network.Layers[network.Layers.Length - 1].Neurons[j].dEdz *
                                    (network.Layers.Length > 1 ? network.Layers[network.Layers.Length - 1 - 1].Neurons[i].LastState : data[inBatchIndex].Input[i]) +
                                    config_.RegularizationFactor *
                                    network.Layers[network.Layers.Length - 1].Neurons[j].Weights[i] / 
                                    data.Count);
                            }
                        }

                        //hidden layers
                        //.......................................ОБРАБОТКА СКРЫТЫХ СЛОЕВ

                        for (int hiddenLayerIndex = network.Layers.Length - 2; hiddenLayerIndex >= 0; hiddenLayerIndex--)
                        {
                            for (int j = 0; j < network.Layers[hiddenLayerIndex].Neurons.Length; j++)
                            {
                                network.Layers[hiddenLayerIndex].Neurons[j].dEdz = 0;
                                for (int k = 0; k < network.Layers[hiddenLayerIndex + 1].Neurons.Length; k++)
                                {
                                    network.Layers[hiddenLayerIndex].Neurons[j].dEdz +=
                                        network.Layers[hiddenLayerIndex + 1].Neurons[k].Weights[j] *
                                        network.Layers[hiddenLayerIndex + 1].Neurons[k].dEdz;
                                }
                                network.Layers[hiddenLayerIndex].Neurons[j].dEdz *=
                                    network.Layers[hiddenLayerIndex].Neurons[j].ActivationFunction.
                                        computeFirstDerivative(
                                            network.Layers[hiddenLayerIndex].Neurons[j].LastSum
                                        );

                                nablaBiases[hiddenLayerIndex][j] += config_.LearningRate *
                                                                    network.Layers[hiddenLayerIndex].Neurons[j].dEdz;

                                for (int i = 0; i < network.Layers[hiddenLayerIndex].Neurons[j].Weights.Length; i++)
                                {
                                    nablaWeights[hiddenLayerIndex][j][i] += config_.LearningRate * (
                                        network.Layers[hiddenLayerIndex].Neurons[j].dEdz *
                                        (hiddenLayerIndex > 0 ? network.Layers[hiddenLayerIndex - 1].Neurons[i].LastState : data[inBatchIndex].Input[i])
                                            +
                                        config_.RegularizationFactor * network.Layers[hiddenLayerIndex].Neurons[j].Weights[i] / data.Count
                                        );
                                }
                            }
                        }
                    }

                    //update weights and bias
                    for (int layerIndex = 0; layerIndex < network.Layers.Length; layerIndex++)
                    {
                        for (int neuronIndex = 0; neuronIndex < network.Layers[layerIndex].Neurons.Length; neuronIndex++)
                        {
                            network.Layers[layerIndex].Neurons[neuronIndex].Bias -= nablaBiases[layerIndex][neuronIndex];
                            for (int weightIndex = 0; weightIndex < network.Layers[layerIndex].Neurons[neuronIndex].Weights.Length; weightIndex++)
                            {
                                network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex] -=
                                    nablaWeights[layerIndex][neuronIndex][weightIndex];
                            }
                        }
                    }

                    currentIndex += config_.BatchSize;
                } while (currentIndex < data.Count);

                //recalculating error on all data
                //real error
                currentError = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    double[] realOutput = network.computeOutput(data[i].Input);
                    currentError += config_.ErrorFunction.calculate(data[i].Output, realOutput);
                }
                currentError *= 1d / data.Count;
                //regularization term
                if (Math.Abs(config_.RegularizationFactor - 0d) > Double.Epsilon)
                {
                    double reg = 0;
                    for (int layerIndex = 0; layerIndex < network.Layers.Length; layerIndex++)
                    {
                        for (int neuronIndex = 0; neuronIndex < network.Layers[layerIndex].Neurons.Length; neuronIndex++)
                        {
                            for (int weightIndex = 0; weightIndex < network.Layers[layerIndex].Neurons[neuronIndex].Weights.Length; weightIndex++)
                            {
                                reg += network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex] *
                                        network.Layers[layerIndex].Neurons[neuronIndex].Weights[weightIndex];
                            }
                        }
                    }
                    currentError += config_.RegularizationFactor * reg / (2 * data.Count);
                }

                epochNumber++;
                //Logger.Instance.Log("Eposh #" + epochNumber.ToString() +
                //                    " finished; current error is " + currentError.ToString() +
                //                    "; it takes: " +
                //                    (DateTime.Now - dtStart).Duration().ToString());



            } while (
                epochNumber < config_.MaxEpoches &&
                currentError > config_.MinError &&
                Math.Abs(currentError - lastError) > config_.MinErrorChange
              );
        }

    }
}
