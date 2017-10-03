using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ProjectGit
{
    public partial class Main : Form
    {       
        List<DataItem<double>> data_;
        DataItem<string> data_info_rus_;
        DataItem<string> data_info_eng_;
        string[] result_info_;
        DataTable table_train_selection_;

        CoronarySclerosisNeuralNetwork network_;
        int[] countNeuronsOfLayer;
        int countLayers;
        int[] countWeightsOfNeuron;
        SigmoidFunction function = new SigmoidFunction(1.0);
        LearningAlgorithmConfig config_;
        BackpropagationFCNLearningAlgorithm algorithm_;
        

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data_info_eng_ = new DataItem<string>(
                                   new string[] { "age", "gender", "arterialHypertension", "aorticSclerosis" },
                                   new string[] { "coronarySclerosis" }
                               );
            data_info_rus_ = new DataItem<string>(
                                new string[] { "Возраст", "Пол", "АГ", "АС" },
                                new string[] { "КС" }
                            );
            result_info_ = new string[] { "P" };

            //Чтение обучающей выборки
            data_ = readTrainSelection();

            //Создание таблицы с данными обучающей выборки
            table_train_selection_ = createTableTrainSelection();

            //Вывод данных таблицы
            dataGridView1.DataSource = table_train_selection_;
            for (int j = 0; j < data_info_eng_.Input.Length; j++)          
                dataGridView1.Columns[data_info_eng_.Input[j]].HeaderText = data_info_rus_.Input[j];        
            for (int j = 0; j < data_info_eng_.Output.Length; j++)          
                dataGridView1.Columns[data_info_eng_.Output[j]].HeaderText = data_info_rus_.Output[j];

            //Настройка нейросети
            countNeuronsOfLayer = new int[] { 9, 2, data_info_eng_.Output.Length };
            countLayers = countNeuronsOfLayer.Length;
            countWeightsOfNeuron = new int[countLayers];
            countWeightsOfNeuron[0] = data_info_eng_.Input.Length;
            for (int i = 0; i < countLayers - 1; i++)
                countWeightsOfNeuron[i + 1] = countNeuronsOfLayer[i];
            //Создание нейронной сети
            network_ = createNeuralNetwork();

            config_ = new LearningAlgorithmConfig();
            config_.ErrorFunction = new HalfSquaredEuclidianDistance();
            config_.LearningRate = 0.2;
            config_.BatchSize = -1;
            config_.MinError = 0.00000001;
            config_.MinErrorChange = 0.00000001;
            config_.MaxEpoches = 1000;
            config_.RegularizationFactor = 0;

            algorithm_ = new BackpropagationFCNLearningAlgorithm(config_);
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
                            new double[] { age, gender, arterialHypertension, aorticSclerosis}, 
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
        DataTable createTableTrainSelection()
        {
            DataTable table = new DataTable();

            foreach (string column in data_info_eng_.Input)
                table.Columns.Add(new DataColumn(column));
            foreach (string column in data_info_eng_.Output)
                table.Columns.Add(new DataColumn(column));
            foreach (string column in result_info_)
                table.Columns.Add(new DataColumn(column));

            for (int i = 0; i < data_.Count; i++)
            {
                DataRow row = table.NewRow();

                for (int j = 0; j < data_info_eng_.Input.Length; j++)               
                    row[data_info_eng_.Input[j]] = data_[i].Input[j];            
                for (int j = 0; j < data_info_eng_.Output.Length; j++)                
                    row[data_info_eng_.Output[j]] = data_[i].Output[j];
                
                table.Rows.Add(row);
            }

            return table;
        }
        CoronarySclerosisNeuralNetwork createNeuralNetwork()
        {
            CoronarySclerosisNeuralNetwork network = new CoronarySclerosisNeuralNetwork();          

            Layer[] layers = new Layer[countLayers];
            Random random = new Random();          

            for(int i = 0; i < countLayers; i++)
            {
                Neuron[] neurons = new Neuron[countNeuronsOfLayer[i]];
                for (int j = 0; j < neurons.Length; j++)
                {
                    neurons[j] = new Neuron();

                    double[] weights = new double[countWeightsOfNeuron[i]];
                    for (int k = 0; k < weights.Length; k++)
                        weights[k] = random.NextDouble();

                    neurons[j].Bias = random.NextDouble();
                    neurons[j].Weights = weights;
                    neurons[j].ActivationFunction = function;
                }

                layers[i] = new Layer(countWeightsOfNeuron[i], neurons);
            }

            network.Layers = layers;

            return network;
        }
        void reloadWeightsOfNeurons( IMultilayerNeuralNetwork network)
        {
            Random random = new Random();
            for (int i = 0; i < network.Layers.Length; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Length; j++)
                {
                    double[] weights = new double[network.Layers[i].Neurons[j].Weights.Length];
                    for (int k = 0; k < weights.Length; k++)
                        weights[k] = random.NextDouble();
                    network.Layers[i].Neurons[j].Weights = weights;
                }
            }
        }
        public DataTable createTableWeightsOfLayer(ILayer layer)
        {
            DataTable dt = new DataTable();
            string[] names = new string[1 + layer.Neurons.Length];
            names[0] = "input";
            for (int i = 0; i < layer.Neurons.Length; i++)
                names[1 + i] = "n" + (i + 1).ToString();
            for (int i = 0; i < names.Length; i++)
                dt.Columns.Add(new DataColumn(names[i]));

            
            for (int i = 0; i < layer.InputDimension; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = "input " + (i + 1).ToString();
                for (int j = 0; j < layer.Neurons.Length; j++)
                {
                    row[1 + j] = layer.Neurons[j].Weights[i];
                }
                dt.Rows.Add(row);
            }

            DataRow rowBias = dt.NewRow();
            rowBias[0] = "bias";
            for (int j = 0; j < layer.Neurons.Length; j++)
            {
                rowBias[1 + j] = layer.Neurons[j].Bias;
            }
            dt.Rows.Add(rowBias);

            return dt; 
            
        }

        void updateData()
        {
            dgv_layer_1.DataSource = createTableWeightsOfLayer(network_.Layers[0]);
            dgv_layer_2.DataSource = createTableWeightsOfLayer(network_.Layers[1]);
            dgv_layer_3.DataSource = createTableWeightsOfLayer(network_.Layers[2]);

            for (int i = 0; i < data_.Count; i++)
            {
                table_train_selection_.Rows[i][result_info_[0]] = network_.computeOutput(data_[i].Input)[0];
            }
        }

        private void btn_train_Click(object sender, EventArgs e)
        {
            reloadWeightsOfNeurons(network_);
            algorithm_.train(network_, data_);
            updateData();
        }
    }   
}
