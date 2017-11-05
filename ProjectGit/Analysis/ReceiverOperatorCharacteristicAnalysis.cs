using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class ReceiverOperatorCharacteristicAnalysis  : IConfusionMatrixLight
    {
        int true_positive_ = 0,
            true_negative_ = 0,
            false_negative_ = 0,
            false_positive_ = 0;

        public ReceiverOperatorCharacteristicAnalysis ()
        {

        }

        public int True_Positive { get { return true_positive_; } }

        public int True_Negative { get { return true_negative_; } }

        public int False_Negative { get { return false_negative_; } }

        public int False_Positive { get { return false_positive_; } }

        



        public double Accuracy {
            get
            {
                double positive = True_Positive + True_Negative;
                double negative = False_Positive + False_Negative;
                return positive / (positive + negative);
            }
        }
        public double Precision { get { return (True_Positive + 0.0) / (True_Positive + False_Positive); } }
        public double Specificity { get { return (True_Negative + 0.0) / (True_Negative + False_Positive); } }
        public double Recall { get { return (True_Positive + 0.0) / (True_Positive + False_Negative); } }
        public double[][] Matrix
        {
            get
            {
                return new double[2][] {
                    new double[2] {True_Positive, False_Positive},
                    new double[2] {False_Negative, True_Negative}
                };
            }
        }

        void clear()
        {
            true_positive_ = 0;
            true_negative_ = 0;
            false_negative_ = 0;
            false_positive_ = 0;
        }
        public void makeClassification(double point, ref List<ClassificationResult> data)
        {
            clear();

            for (int i = 0; i < data.Count; ++i)
            {
                
            }



        }
    }
}
