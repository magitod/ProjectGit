using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectGit
{
    public class CoronarySclerosisData
    {
        public CoronarySclerosisData(List<DataItem<double>> data)
        {
            Value = data;
        }
        public List<DataItem<double>> Value { get; }
    }
    public class CoronarySclerosisClassificator
    {      
        List<DataItem<double>> data_;
        List<DataItem<double>> train_data_;
        List<DataItem<double>> test_data_;

        
        DataItem<DataParameter> data_config_ = new DataItem<DataParameter>(
            new DataParameter[] {
                new DataParameter("age", "Возраст"),
                new DataParameter("gender", "Пол"),
                new DataParameter("arterialHypertension", "АГ"),
                new DataParameter("aorticSclerosis", "АС")
            },
            new DataParameter[]
            {
                new DataParameter("coronarySclerosis", "КС")
            }
        );

        
        DataParameter[] result_config_ = new DataParameter[] {
            new DataParameter("result", "P")
        };

        /// <summary>
        /// Описание данных
        /// </summary>
        public DataItem<DataParameter> DataConfig { get { return data_config_; } }

        /// <summary>
        /// Описание резульата системы
        /// </summary>
        public DataParameter[] ResultConfig { get { return result_config_; } }

        /// <summary>
        /// Общая выборка
        /// </summary>
        public CoronarySclerosisData Data { get { return new CoronarySclerosisData(data_); } }

        /// <summary>
        /// Обучающая выборка
        /// </summary>
        public CoronarySclerosisData TrainData { get { return new CoronarySclerosisData(train_data_); } }

        /// <summary>
        /// Тестовая выборка
        /// </summary>
        public CoronarySclerosisData TestData { get { return new CoronarySclerosisData(test_data_); } }




        public CoronarySclerosisClassificator()
        {
            data_ = readTrainSelection();
            train_data_ = new List<DataItem<double>>();
            test_data_ = new List<DataItem<double>>();
        }

        public NeuralNetwork createNeuralNetwork(List<uint> neuronsOfHiddenLayers)
        {
            NeuralNetwork network = new NeuralNetwork();
            Layer[] layers = new Layer[neuronsOfHiddenLayers.Count + 1];
            int[] countNeuronsOfLayers = new int[layers.Length];
            int[] countInputsOfLayers = new int[layers.Length];

            countInputsOfLayers[0] = DataConfig.Input.Length;
            countNeuronsOfLayers[layers.Length - 1] = DataConfig.Output.Length;
            for (int i = 0; i < neuronsOfHiddenLayers.Count; i++)
            {
                countNeuronsOfLayers[i] = (int)neuronsOfHiddenLayers[i];
                countInputsOfLayers[i + 1] = (int)neuronsOfHiddenLayers[i];
            }

            IFunction function = new SigmoidFunction(1.0);
            Random random = new Random();
            for (int i = 0; i < layers.Length; i++)
            {
                Neuron[] neurons = new Neuron[countNeuronsOfLayers[i]];
                for (int j = 0; j < neurons.Length; j++)
                {
                    neurons[j] = new Neuron();
                    neurons[j].Weights = new double[countInputsOfLayers[i]];
                    neurons[j].ActivationFunction = function;
                }

                layers[i] = new Layer(countInputsOfLayers[i], neurons);
            }

            network.Layers = layers;

            return network;
        }

        public DataTable createTableSelection()
        {
            DataTable table = new DataTable();

            foreach (DataParameter parameter in DataConfig.Input)
                table.Columns.Add(new DataColumn(parameter.Name));
            foreach (DataParameter parameter in DataConfig.Output)
                table.Columns.Add(new DataColumn(parameter.Name));
            foreach (DataParameter parameter in ResultConfig)
                table.Columns.Add(new DataColumn(parameter.Name));

            return table;
        }

        public bool divideData(double percentTrain)
        {
            train_data_.Clear();
            test_data_.Clear();

            List<int> listID = new List<int>();
            for (int i = 0; i < data_.Count; ++i)
                listID.Add(i);

            Random random = new Random();

            if(percentTrain < 0.0 && percentTrain > 1.0)
            {
                return false;
            }

            int countTrain = (int) Math.Round(data_.Count * percentTrain, 0);
            while (train_data_.Count < countTrain)
            {                 
                    int index = random.Next(0, listID.Count);
                    train_data_.Add(data_[listID[index]]);
                    listID.RemoveAt(index);
            }

            int countTest = data_.Count - countTrain;
            while (test_data_.Count < countTest)
            {
                int index = random.Next(0, listID.Count);
                test_data_.Add(data_[listID[index]]);
                listID.RemoveAt(index);
            }

            return true;


        }
        List<DataItem<double>> readTrainSelection()
        {
            List<DataItem<double>> dataList = new List<DataItem<double>>();


            string[] items = Properties.Resources.TrainSelection.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                string[] elements = item.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                bool flag = true;
                int id = -1;
                double age = 0;
                int gender = 1;
                int arterialHypertension = 0;
                int aorticSclerosis = 0;
                int coronarySclerosis = 0;
                try
                {
                    int.TryParse(elements[0], out id);
                    double.TryParse(elements[1], out age);
                    int.TryParse(elements[2], out gender);
                    int.TryParse(elements[3], out arterialHypertension);
                    if (elements[4] == " ")
                        flag = false;
                    int.TryParse(elements[4], out aorticSclerosis);
                    int.TryParse(elements[5], out coronarySclerosis);
                }
                catch
                {
                    flag = false;
                }

                if (flag)
                {
                    dataList.Add(
                        new DataItem<double>(
                            new double[] { age, gender, arterialHypertension, aorticSclerosis },
                            new double[] { coronarySclerosis }
                        )
                    );
                }
            }

            double _min = dataList.Min(x => x.Input[0]);
            double _max = dataList.Max(x => x.Input[0]);
            double _denominator = _max - _min;
            if (_denominator != 0)
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    dataList[i].Input[0] = ((dataList[i].Input[0] - _min) / _denominator);
                }
            }

            return dataList;

        }
    }
}
