using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectGit
{
    public class ROC_analysis
    {
        ConfusionMatrix matrix_;
        List<DataPoint> roc_curve_;
        List<ClassificationResult> classification_results_;
        double cut_off_point_;

        public List<DataPoint> Points { get { return roc_curve_; } }
        public ConfusionMatrix ConfusionMatrix { get { return matrix_; } }
        public double CutOffPoint { get { return cut_off_point_; } }

        public ROC_analysis (List<ClassificationResult> classification_results)
        {
            matrix_ = new ConfusionMatrix(2);
            classification_results_ = classification_results;
        }

        public void setCutOffPoint (double value)
        {
            matrix_.clear();

            for (int i = 0; i < classification_results_.Count; ++i) {
                classification_results_[i].setCutOffPoint(value);
                matrix_.add(classification_results_[i]);
            }
        }


        public void createROC_Curve(double point)
        {
            classification_results_ = classification_results_.OrderByDescending(x => x.CalculatedValue).Select(x => x).ToList();

            for (int i = 0; i < classification_results_.Count; ++i)
                classification_results_[i].setCutOffPoint(point);

            double step_up_max = classification_results_.Where(x => x.CalculatedClass == 1).Count();
            double step_right_max = classification_results_.Count - step_up_max;
            double step_up = 0;
            double step_right = 0;
            int last_index = 0;
            double last_value = 1;

            roc_curve_ = new List<DataPoint>();
            /*roc_curve_.Add(new DataPoint(step_right / step_right_max, step_up / step_up_max));

            for (int i = 0; i < classification_result_.Count; i = last_index)
            {
                last_value = classification_result_[i].CalculatedValue;

                for (int j = i; j < classification_result_.Count; ++j)
                {
                    if (classification_result_[i].CalculatedValue == last_value)                   
                        last_index++;                   
                    else                    
                        break;                    
                }

                for (int j = i; j < last_index && j < classification_result_.Count; ++j)
                {
                    switch (classification_result_[i].CalculatedClass)
                    {
                        case 1: step_up++; break;
                        case 2: step_right++; break;
                    }
                }
                             
                roc_curve_.Add(new DataPoint(step_right / step_right_max, step_up / step_up_max));                                         
            }*/

            for (int i = 0; i < classification_results_.Count; ++i)
            {
                switch (classification_results_[i].CalculatedClass)
                {
                    case 1: step_up++; break;
                    case 0: step_right++; break;
                }
                roc_curve_.Add(new DataPoint(step_right / step_right_max, step_up / step_up_max));
            }
        }

        
    }
}
