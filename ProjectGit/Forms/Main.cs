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
        bool isRandomizedWeights = true;
        bool isCreatedNetwork = false;
        
        public double CutOffPoint { get; set; }
        public double PercentDividedData { get; set; }
        public int TypeValidSelection { get; set; }
        public LearningAlgorithmConfig StudyConfig { get; set; }

        DataTable train_data_table;
        DataTable test_data_table;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region -> Создание классификатора

            classificator_ = new CoronarySclerosisClassificator();
            PercentDividedData = 0.4;
            percentDivideData.Value = Convert.ToDecimal(PercentDividedData);
            classificator_.divideData(PercentDividedData);

            #endregion

            #region -> Создание таблицы с обучающей выборкой

            train_data_table = classificator_.createTableSelection();
            createRowsData(train_data_table, classificator_.TrainData);
            dgv_train_selection.DataSource = train_data_table;
            installLanguage(dgv_train_selection);          

            #endregion

            #region -> Создание таблицы с тестовой выборкой

            test_data_table = classificator_.createTableSelection();
            createRowsData(test_data_table, classificator_.TrainData);
            dgv_test_selection.DataSource = test_data_table;
            installLanguage(dgv_test_selection);          

            #endregion

            #region -> Установка количества нейронов скрытых слоев

            neuronsOfHiddenLayers_ = (new uint[] { 3 }).ToList();

            #endregion

            #region -> Создание нейронной сети  

            network_ = classificator_.createNeuralNetwork(neuronsOfHiddenLayers_);
            isCreatedNetwork = true;
         
            #endregion

            #region -> Установка конфига обучения

            LearningAlgorithmConfig config = new LearningAlgorithmConfig();
            config.ErrorFunction = new HalfSquaredEuclidianDistance();
            config.LearningRate = 0.05;
            config.BatchSize = 5;
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

            CutOffPoint = 0.74;

            #endregion

            isLoadedSystem = false;

            load_cb_selection();
            randomizeWeights();
            updateVisualLayerWeights();
            updateVisualStudyConfig();
            updateVisualCutOffPoint();

            isLoadedSystem = true;

        }

        void load_cb_selection()
        {
            string[] items = new string[] { "Вся выборка", "Обучающая выборка", "Тестовая выборка" };
            cb_selection.Items.Clear();
            cb_selection.Items.AddRange(items);
            cb_selection.SelectedIndex = 2;
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

        void installLanguage(DataGridView dgv)
        {
            for (int j = 0; j < classificator_.DataConfig.Input.Length; j++)
                dgv.Columns[classificator_.DataConfig.Input[j].Name].HeaderText = classificator_.DataConfig.Input[j].AlternativeName;
            for (int j = 0; j < classificator_.DataConfig.Output.Length; j++)
                dgv.Columns[classificator_.DataConfig.Output[j].Name].HeaderText = classificator_.DataConfig.Output[j].AlternativeName;
            for (int j = 0; j < classificator_.ResultConfig.Length; j++)
                dgv.Columns[classificator_.ResultConfig[j].Name].HeaderText = classificator_.ResultConfig[j].AlternativeName;
        }
        void createRowsData(DataTable dt, CoronarySclerosisData data)
        {
            dt.Clear();
            for (int i = 0; i < data.Value.Count; i++)
            {
                DataRow row = dt.NewRow();

                for (int j = 0; j < classificator_.DataConfig.Input.Length; j++)
                    row[classificator_.DataConfig.Input[j].Name] = data.Value[i].Input[j];
                for (int j = 0; j < classificator_.DataConfig.Output.Length; j++)
                    row[classificator_.DataConfig.Output[j].Name] = data.Value[i].Output[j];

                if (isCreatedNetwork)
                {
                    double[] output = network_.computeOutput(data.Value[i].Input);

                    for (int j = 0; j < classificator_.ResultConfig.Length; j++)
                        row[classificator_.ResultConfig[j].Name] = output[j].ToString("F6");
                }

                dt.Rows.Add(row);
            }
            
        }
    
        void updateVisualData()
        {
            //TrainData
            createRowsData(train_data_table, classificator_.TrainData);

            //TestData
            createRowsData(test_data_table, classificator_.TrainData);

            update_layer_weights();
        }
        void updateVisualClassification()
        {
            uint indexClass = 0;
            tb_accuracy.Text = roc_analysis_.ConfusionMatrix.Accuracy(indexClass).ToString("F6");
            tb_precision.Text = roc_analysis_.ConfusionMatrix.Precision(indexClass).ToString("F6");
            tb_recall.Text = roc_analysis_.ConfusionMatrix.Recall(indexClass).ToString("F6");
            tb_specificity.Text = roc_analysis_.ConfusionMatrix.Specificity(indexClass).ToString("F6");
            dgv_classific.DataSource = getDataConfusionMatrix(roc_analysis_.ConfusionMatrix);
        }
        void updateClassificationResults(int type_selection)
        {
            CoronarySclerosisData data = null;
            bool isAccepted = true;
            switch (type_selection)
            {
                case 0: data = classificator_.Data; break;
                case 1: data = classificator_.TrainData; break;
                case 2: data = classificator_.TestData; break;
                default: isAccepted = false;  break;
            }
            if (isAccepted)
            {
                classification_results_ = createClassificationResults(data);
                roc_analysis_ = new ROC_analysis(classification_results_);
                roc_analysis_.setCutOffPoint(CutOffPoint);
                List<DataPoint> points = roc_analysis_.create_roc_curve();
                LoadChart(chart_classific, points);
                tb_uac_config.Text = roc_analysis_.calculate_uac(points).ToString("F6");
            }
        }
        void randomizeWeights()
        {
            double epselon = 1;
            network_.randomize(0, epselon);
            isRandomizedWeights = true;

            updateClassificationResults(TypeValidSelection);
            updateVisualData();
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

        List<ClassificationResult> createClassificationResults(CoronarySclerosisData data)
        {
            //#Change
            int indexOut = 0;
            List<ClassificationResult> result = data.Value.Select(
                x => new ClassificationResult(
                    network_.computeOutput(x.Input)[indexOut], 
                    1 - (uint)x.Output[indexOut]
                )
            ).ToList();
            return result;
        }
        void makeStudy()
        {
            LearningAlgorithmResult result = algorithm_.train(network_, classificator_.TrainData.Value);
            textBox1.Text = result.Epoches.ToString();
            textBox2.Text = result.Duration.ToString() + " c";
            textBox3.Text = result.Error.ToString();

            error_curve.Series.Clear();
            error_curve.ChartAreas[0].AxisX.Minimum = 1;
            error_curve.ChartAreas[0].AxisX.Maximum = result.Epoches;
            error_curve.ChartAreas[0].AxisY.Minimum = result.ErrorCurve.Min();
            int index_series = 0;
            error_curve.Series.Add(new Series());
            error_curve.Series[index_series].ChartType = SeriesChartType.Line;
            error_curve.Series[index_series].LegendText = "Кривая ошибки";

            for (int i = 0; i < result.ErrorCurve.Count; ++i)
            {
                error_curve.Series[index_series].Points.AddXY(i + 1, result.ErrorCurve[i]);
            }

            isRandomizedWeights = false;

            updateClassificationResults(TypeValidSelection);
            updateVisualClassification();
            updateVisualData();
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
        private void cutoffpointt_config_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadedSystem)
            {
                CutOffPoint = Convert.ToDouble(cutoffpointt_config.Value);
                roc_analysis_.setCutOffPoint(CutOffPoint);
                updateVisualClassification();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * roc_analysis_.makeMinCrossValidation(300, CutOffPoint);
            MessageBox.Show("Precision " + roc_analysis_.CrossPrecision.ToString("F6") + "\n" +
                "Recall " + roc_analysis_.CrossRecall.ToString("F6") + "\n" + 
                "Specificity " + roc_analysis_.CrossSpecificity.ToString("F6"));
            */
            
            
        }

        private void btn_divide_selection_Click(object sender, EventArgs e)
        {
            PercentDividedData = Convert.ToDouble(percentDivideData.Value);
            classificator_.divideData(PercentDividedData);
            updateVisualData();
        }

        private void cb_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isLoadedSystem)
            {
                TypeValidSelection = cb_selection.SelectedIndex;
                updateClassificationResults(TypeValidSelection);
                updateVisualClassification();
            }
        }

        private void btn_search_optimal_cutoffpoint_Click(object sender, EventArgs e)
        {
            SearchOptimalCutOffPointResult result = roc_analysis_.callculateOptimalCutOffPoint(0.0005, 20000);
            cutoffpointt_config.Value = Convert.ToDecimal(result.OptimalCutOffPoint);
            roc_analysis_.setCutOffPoint(CutOffPoint);
            updateVisualClassification();
            /*
            MessageBox.Show(result.Duration.ToString() + "\n" +
               result.Epoches.ToString() + "\n" +
               result.Different.ToString());*/
            /*
            List<double> result = roc_analysis_.Differents;
            chart_classific.Series.Clear();
            chart_classific.ChartAreas[0].AxisX.Minimum = 1;
            chart_classific.ChartAreas[0].AxisX.Maximum = roc_analysis_.Epoches;
            chart_classific.ChartAreas[0].AxisY.Minimum = result.Min();
            chart_classific.ChartAreas[0].AxisY.Maximum = result.Max();
            int index_series = 0;
            chart_classific.Series.Add(new Series());
            chart_classific.Series[index_series].ChartType = SeriesChartType.Line;
            chart_classific.Series[index_series].LegendText = "Кривая ошибки";

            for (int i = 0; i < result.Count; ++i)
            {
                chart_classific.Series[index_series].Points.AddXY(i + 1, result[i]);
            }
            */
        }
    }   
}
