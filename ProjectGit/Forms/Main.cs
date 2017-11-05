using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Reflection;

namespace ProjectGit
{
    public partial class Main : Form
    {
        CoronarySclerosisClassificator classificator_;
        List<uint> neuronsOfHiddenLayers_;
        NeuralNetwork network_;
        BackpropagationFCNLearningAlgorithm algorithm_;

        ROC_analysis roc_analysis_;
        List<ClassificationResult> classification_results_;

        bool isLoadedSystem = false;
        
        public double CutOffPoint { get; set; }
        public LearningAlgorithmConfig StudyConfig { get; set; }

        DataTable train_data_table;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region -> Создание классификатора

            classificator_ = new CoronarySclerosisClassificator();

            #endregion

            #region -> Создание таблицы с обучающей выборкой

            train_data_table = classificator_.createTableTrainSelection();
            dgv_train_selection.DataSource = train_data_table;
            for (int j = 0; j < classificator_.DataConfig.Input.Length; j++)          
                dgv_train_selection.Columns[classificator_.DataConfig.Input[j].Name].HeaderText = classificator_.DataConfig.Input[j].AlternativeName;        
            for (int j = 0; j < classificator_.DataConfig.Output.Length; j++)          
                dgv_train_selection.Columns[classificator_.DataConfig.Output[j].Name].HeaderText = classificator_.DataConfig.Output[j].AlternativeName;
            for (int j = 0; j < classificator_.ResultConfig.Length; j++)
                dgv_train_selection.Columns[classificator_.ResultConfig[j].Name].HeaderText = classificator_.ResultConfig[j].AlternativeName;

            #endregion

            #region -> Установка количества нейронов скрытых слоев

            neuronsOfHiddenLayers_ = (new uint[] { 9, 3 }).ToList();

            #endregion

            #region -> Создание нейронной сети  

            network_ = classificator_.createNeuralNetwork(neuronsOfHiddenLayers_);
         
            #endregion

            #region -> Установка конфига обучения

            LearningAlgorithmConfig config = new LearningAlgorithmConfig();
            config.ErrorFunction = new HalfSquaredEuclidianDistance();
            config.LearningRate = 0.05;
            config.BatchSize = 1;
            config.MinError = 0;
            config.MinErrorChange = 0.000001;
            config.MaxEpoches = 20000;
            config.RegularizationFactor = 0.5;
            StudyConfig = config;

            #endregion

            #region -> Создание алгоритма обучения

            algorithm_ = new BackpropagationFCNLearningAlgorithm(StudyConfig);

            #endregion

            #region -> Установка точки отсечения

            CutOffPoint = 0.6;

            #endregion

            isLoadedSystem = false;

            randomizeWeights();
            updateVisualLayerWeights();
            updateVisualStudyConfig();
            updateVisualCutOffPoint();

            isLoadedSystem = true;

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

        void updateVisualLayerWeights()
        {
            for (int i = 0; i < network_.Layers.Length; i++)
                cb_layer_weights.Items.Add(i + 1);
        }
        void updateVisualStudyConfig()
        {
            learningRate_config.Value = Convert.ToDecimal(StudyConfig.LearningRate);
            error_config.Value = Convert.ToDecimal(StudyConfig.MinError);
            errorChange_config.Value = Convert.ToDecimal(StudyConfig.MinErrorChange);
            epohes_config.Value = Convert.ToDecimal(StudyConfig.MaxEpoches);
            regularization_config.Value = Convert.ToDecimal(StudyConfig.RegularizationFactor);
        }
        void updateVisualCutOffPoint()
        {
            cutoffpointt_config.Value = Convert.ToDecimal(CutOffPoint);
        }
        void updateVisualTrainData()
        {
            for (int i = 0; i < classificator_.TrainData.Count; i++)
            {
                double[] output = network_.computeOutput(classificator_.TrainData[i].Input);

                for (int j = 0; j < classificator_.ResultConfig.Length; j++)
                    train_data_table.Rows[i][classificator_.ResultConfig[j].Name] = output[j].ToString("F6");
            }

            update_layer_weights();
        }
        void updateVisualClassification()
        {
            tb_accuracy.Text = roc_analysis_.ConfusionMatrix.Accuracy(0).ToString("F6");
            tb_precision.Text = roc_analysis_.ConfusionMatrix.Precision(0).ToString("F6");
            tb_recall.Text = roc_analysis_.ConfusionMatrix.Recall(0).ToString("F6");
            tb_specificity.Text = roc_analysis_.ConfusionMatrix.Specificity(0).ToString("F6");
            dgv_classific.DataSource = getDataConfusionMatrix(roc_analysis_.ConfusionMatrix);
        }
        void randomizeWeights()
        {
            network_.randomize(-1.0, 1.0);

            int indexOut = 0;
            classification_results_ = classificator_.TrainData.Select(x => new ClassificationResult(network_.computeOutput(x.Input)[indexOut], (uint)x.Output[indexOut])).ToList();
            roc_analysis_ = new ROC_analysis(classification_results_);
            roc_analysis_.setCutOffPoint(CutOffPoint);

            updateVisualTrainData();
            updateVisualClassification();
        }
        DataTable getDataConfusionMatrix(ConfusionMatrix matrix)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < matrix.Size; ++i)
                dt.Columns.Add(new DataColumn(i.ToString()));

            for (int i = 0; i < matrix.Size; ++i)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < matrix.Size; ++j)
                    row[j] = matrix.Matrix[i, j];

                dt.Rows.Add(row);
            }

            return dt;
        }

        void makeStudy()
        {
            LearningAlgorithmResult result = algorithm_.train(network_, classificator_.TrainData);
            textBox1.Text = result.Epoches.ToString();
            textBox2.Text = result.Duration.ToString() + " c";
            textBox3.Text = result.Error.ToString();

            int indexOut = 0;
            classification_results_ = classificator_.TrainData.Select(x => new ClassificationResult(network_.computeOutput(x.Input)[indexOut], (uint)x.Output[indexOut])).ToList();
            roc_analysis_ = new ROC_analysis(classification_results_);
            roc_analysis_.setCutOffPoint(CutOffPoint);

            updateVisualClassification();
            updateVisualTrainData();
        }

        private void btn_train_Click(object sender, EventArgs e)
        {
            makeStudy();
        }

        private void btn_init_weights_Click(object sender, EventArgs e)
        {
            randomizeWeights();
        }

        void update_layer_weights()
        {
            if (cb_layer_weights.SelectedIndex != -1)
            {
                dgv_layer_weights.DataSource = createTableWeightsOfLayer(network_.Layers[cb_layer_weights.SelectedIndex]);
                lb_name_layer.Text = "Слой - " + cb_layer_weights.SelectedItem.ToString();
            }
            else
            {
                dgv_layer_weights.DataSource = null;
                lb_name_layer.Text = string.Empty;
            }
        }


        public void LoadChart(Chart chart, List<DataPoint> points)
        {
            chart.ChartAreas[0].AxisX.Minimum = 0.0;
            chart.ChartAreas[0].AxisX.Maximum = 1.0;
            chart.ChartAreas[0].AxisY.Minimum = 0.0;
            chart.ChartAreas[0].AxisY.Maximum = 1.0;
            chart.Series.Clear();
            int index_series = 0;

            chart.Series.Add(new Series());
            chart.Series[index_series].ChartType = SeriesChartType.Line;
            chart.Series[index_series].LegendText = "ROC - кривая";

            for(int i = 0; i < points.Count; ++i) {
                chart.Series[index_series].Points.Add(points[i]);
            }
        }

        private void cb_layer_weights_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_layer_weights();
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            randomizeWeights();
        }

        private void epohes_config_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                StudyConfig.MaxEpoches = Convert.ToInt32(epohes_config.Value);
            }
        }

        private void error_config_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                StudyConfig.MinError = Convert.ToDouble(error_config.Value);
            }
        }

        private void errorChange_config_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                StudyConfig.MinErrorChange = Convert.ToDouble(errorChange_config.Value);
            }
        }

        private void learningRate_config_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                StudyConfig.LearningRate = Convert.ToDouble(learningRate_config.Value);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                CutOffPoint = Convert.ToDouble(cutoffpointt_config.Value);
                roc_analysis_.setCutOffPoint(CutOffPoint);
                updateVisualClassification();
            }
        }
    }   
}
