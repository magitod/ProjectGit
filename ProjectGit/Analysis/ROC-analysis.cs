using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace ProjectGit
{
    public class SearchOptimalCutOffPointResult
    {
        public int Epoches { get; set; }
        public double Duration { get; set; }
        public double Different { get; set; }
        public List<double> DifferntCurve { get; set; }
        public double OptimalCutOffPoint { get; set; }
    }
    public class ROC_analysis
    {             
        List<ClassificationResult> classification_results_;
        ConfusionMatrix matrix_;
        double cut_off_point_;

        /// <summary>
        /// Матрица неточности по точке отсечения
        /// </summary>
        public ConfusionMatrix ConfusionMatrix { get { return matrix_; } }

        /// <summary>
        /// Точка отсечения
        /// </summary>
        public double CutOffPoint { get { return cut_off_point_; } }

        public ROC_analysis(List<ClassificationResult> classification_results)
        {
            matrix_ = new ConfusionMatrix(2);
            classification_results_ = classification_results;
        }

        public void setCutOffPoint(double cut_off_point)
        {
            matrix_.clear();
            cut_off_point_ = cut_off_point;

            for (int i = 0; i < classification_results_.Count; ++i)
            {
                classification_results_[i].makeCalculationClass(cut_off_point);
                matrix_.add(classification_results_[i]);
            }
        }


        #region -> CrossValidation

        double cross_precision_;
        double cross_recall_;
        double cross_specificity_;

        public double CrossPrecision { get { return cross_precision_; } }
        public double CrossRecall { get { return cross_recall_; } }
        public double CrossSpecificity { get { return cross_specificity_; } }

        ConfusionMatrix computeCrossMatrix(List<int> listID, double cut_off_point)
        {
            ConfusionMatrix cross_matrix_ = new ConfusionMatrix(2);

            for (int i = 0; i < listID.Count; ++i)
            {
                classification_results_[listID[i]].makeCalculationClass(cut_off_point);
                cross_matrix_.add(classification_results_[listID[i]]);
            }

            return cross_matrix_;
        }

        List<List<int>> createBatches(int sizeBatch)
        {
            List<int> listID = new List<int>();
            for (int i = 0; i < classification_results_.Count; ++i)
                listID.Add(i);

            List<List<int>> batches = new List<List<int>>();
            Random rnm = new Random();

            if (sizeBatch <= 0)
                sizeBatch = listID.Count;

            while (listID.Count >= sizeBatch)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < sizeBatch; ++i)
                {
                    int id = rnm.Next(0, listID.Count);
                    list.Add(listID[id]);
                    listID.RemoveAt(id);
                }
                batches.Add(list);
            }
            return batches;
        }

        public void makeAverageCrossValidation(int sizeBatch, double cut_off_point)
        {
            List<List<int>> batches = createBatches(sizeBatch);
            double 
                precision = 0, 
                recall = 0,
                specificity = 0;

            for (int i = 0; i < batches.Count; ++i)
            {
                ConfusionMatrix matrix = computeCrossMatrix(batches[i], cut_off_point);
                precision += matrix.Precision(0);
                recall += matrix.Recall(0);
                specificity += matrix.Specificity(0);
            }

            precision /= batches.Count;
            recall /= batches.Count;
            specificity /= batches.Count;

            cross_precision_ = precision;
            cross_recall_ = recall;
            cross_specificity_ = specificity;

        }

        public void makeMinCrossValidation(int sizeBatch, double cut_off_point)
        {
            List<List<int>> batches = createBatches(sizeBatch);
            double precision = 1, recall = 1, specificity = 1;

            for (int i = 0; i < batches.Count; ++i)
            {
                ConfusionMatrix matrix = computeCrossMatrix(batches[i], cut_off_point);
                precision = Math.Min(precision, matrix.Precision(0));
                recall = Math.Min(recall, matrix.Recall(0));
                specificity = Math.Min(specificity, matrix.Specificity(0));
            }

            cross_precision_ = precision;
            cross_recall_ = recall;
            cross_specificity_ = specificity;

        }

        #endregion



        public List<DataPoint> get_calculated_value_desc()
        {
            List<DataPoint> roc_curve = new List<DataPoint>();
            classification_results_ = classification_results_.OrderByDescending(x => x.CalculatedValue).Select(x => x).ToList();

            int countItems = classification_results_.Count();

            for (int i = 0; i < countItems; i++)
            {
                roc_curve.Add(new DataPoint((i + 1.0) / countItems, classification_results_[i].CalculatedValue));
            }
            return roc_curve;
        }


        #region -> roc-analysis



        #endregion


        public List<DataPoint> create_roc_curve()
        {
            List<DataPoint> roc_curve = new List<DataPoint>();
            List<ClassificationResult> data_result = classification_results_.OrderBy(x => x.CalculatedValue).Select(x => x).ToList();
            

            double cut_off_point_min = 0.0;
            double cut_off_point_max = 1.0;
            double value_step = 0.01;
            int last_index = 0;

            ConfusionMatrix matrix = new ConfusionMatrix(2);
            for (int i = 0; i < data_result.Count; ++i)
            {
                data_result[i].makeCalculationClass(cut_off_point_min);
                matrix.add(data_result[i]);
            }


            for (
                double point = cut_off_point_min; 
                point <= cut_off_point_max; 
                point += value_step
            ) {               
                for (int i = last_index; i < data_result.Count; ++i)
                {
                    if(data_result[i].CalculatedValue > point)
                    {
                        last_index = i;
                        break;
                    }
                    matrix.remove(data_result[i]);
                    data_result[i].makeCalculationClass(point);
                    matrix.add(data_result[i]);
                }

                double x = 1.0 - matrix.Specificity(0);
                double y = matrix.Recall(0);
                roc_curve.Add(new DataPoint(x, y));
            }

            return roc_curve;
        }    
        public double calculate_uac (List<DataPoint> points)
        {
            double uac = 0.0;
            for(int i = 0; i < points.Count - 1; ++i)
            {
                uac += (points[i].YValues[0] + points[i + 1].YValues[0]) / 2.0 * (points[i].XValue - points[i + 1].XValue);
            }
            return Math.Abs(uac);
        }

   
        public SearchOptimalCutOffPointResult callculateOptimalCutOffPoint(double MinDifferentChange, int MaxEpoches)
        {
            //Настройки
            int maxEpoches = MaxEpoches;
            double minDifferent = 0.000001;
            double minDifferentChange = MinDifferentChange;


            DateTime dtStart = DateTime.Now;
            List<double> Differents = new List<double>();
            int epoches = 0;
            double currentDifferent = Single.MaxValue;

            ConfusionMatrix matrix = new ConfusionMatrix(2);
            List<ClassificationResult> classification_results = classification_results_.OrderBy(x => x.CalculatedValue).Select(x => x).ToList();

            double left = classification_results_.Min(x => x.CalculatedValue);
            double right = classification_results_.Max(x => x.CalculatedValue);
            double point = (right - left) / 2.0;
            
            while (
                currentDifferent > minDifferent &&
                epoches < maxEpoches
            )
            {
                matrix.clear();
                for (int i = 0; i < classification_results.Count; ++i)
                {
                    classification_results[i].makeCalculationClass(point);
                    matrix.add(classification_results[i]);
                }

                double Recall = matrix.Recall(0);
                double Specificity = matrix.Specificity(0);

                currentDifferent = Math.Abs(Recall - Specificity);
                Differents.Add(currentDifferent);
                if(currentDifferent <= MinDifferentChange)
                {
                    break;
                }

                if (Specificity > Recall)
                    right = point;
                else
                    left = point;

                point = (right + left) / 2.0;
                epoches++;
            }

            SearchOptimalCutOffPointResult result = new SearchOptimalCutOffPointResult();
            result.Epoches = epoches;
            result.OptimalCutOffPoint = point;
            result.Different = currentDifferent;
            result.DifferntCurve = Differents;
            result.Duration = Convert.ToDouble((DateTime.Now - dtStart).Duration().TotalMilliseconds / 1000.0);
            return result;
        }
    }
}
