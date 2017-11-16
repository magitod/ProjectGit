using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class ConfusionMatrix : IConfusionMatrix
    {
        uint size_;
        uint[,] matrix_;

        public ConfusionMatrix(uint size)
        {
            size_ = size;
            matrix_ = new uint[size_, size_];
        }
        public uint[,] Matrix { get { return matrix_; } }

        public uint Size { get { return size_; } }

        public double Accuracy (uint indexClass)
        {
            if (indexClass < size_)
            {
                double TP = getTruePositive(indexClass);
                double TN = getTrueNegative(indexClass);
                double FP = getFalsePositive(indexClass);
                double FN = getFalseNegative(indexClass);
                return (TP + TN) / (TP + TN + FP + FN);
            }
            return -1;            
        }

        public double Precision (uint indexClass)
        {
            if (indexClass < size_) {
                double TP = getTruePositive(indexClass);
                double FP = getFalsePositive(indexClass);
                return TP / (TP + FP);
            }
            return -1;
        }

        public double Recall (uint indexClass)
        {
            if (indexClass < size_)
            {
                double TP = getTruePositive(indexClass);
                double FN = getFalseNegative(indexClass);
                return TP / (TP + FN);
            }
            return -1;
        }

        public double Specificity (uint indexClass)
        {
            if (indexClass < size_)
            {         
                double TN = getTrueNegative(indexClass);
                double FP = getFalsePositive(indexClass);
                return TN / (TN + FP);
            }
            return -1;
        }

        public double getTruePositive (uint indexClass)
        {
            if (indexClass < size_)
            {
                return matrix_[indexClass, indexClass];
            }
            return 0;
        }

        public double getTrueNegative (uint indexClass)
        {
            if (indexClass < size_)
            {
                double sum = 0;
                for (uint i = 0; i < indexClass; ++i)
                    sum += matrix_[i, i];
                for (uint i = indexClass + 1; i < size_; ++i)
                    sum += matrix_[i, i];

                return sum;
            }
            return 0;
        }

        public double getFalseNegative (uint indexClass)
        {
            if (indexClass < size_)
            {
                double sum = 0;
                for (uint i = 0; i < indexClass; ++i)
                    sum += matrix_[i, indexClass];
                for (uint i = indexClass + 1; i < size_; ++i)
                    sum += matrix_[i, indexClass];

                return sum;
            }
            return 0;
        }

        public double getFalsePositive (uint indexClass)
        {
            if (indexClass < size_)
            {
                double sum = 0;
                for (uint i = 0; i < indexClass; ++i)
                    sum += matrix_[indexClass, i];
                for (uint i = indexClass + 1; i < size_; ++i)
                    sum += matrix_[indexClass, i];

                return sum;
            }
            return 0;
        }

        public void clear()
        {
            matrix_ = new uint[size_, size_];
        }

        public void add(ClassificationResult classification)
        {
            if(classification.CalculatedClass < size_ &&
               classification.RealityClass < size_)
            {
                matrix_[classification.CalculatedClass, classification.RealityClass]++;
            }
        }

        public void remove(ClassificationResult classification)
        {
            if (classification.CalculatedClass < size_ &&
               classification.RealityClass < size_)
            {
                if (matrix_[classification.CalculatedClass, classification.RealityClass] > 0)
                {
                    matrix_[classification.CalculatedClass, classification.RealityClass]--;
                }
            }
        }

        public void load(List<ClassificationResult> data)
        {
            clear();

            for(int i = 0; i < size_; ++i)           
                add(data[i]);            
        }
    }
}
