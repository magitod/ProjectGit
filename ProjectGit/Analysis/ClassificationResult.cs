using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class ClassificationResult
    {
        uint calculated_class_;

        public ClassificationResult(double calculated_value, uint reality_class)
        {
            CalculatedValue = calculated_value;
            RealityClass = reality_class;
            calculated_class_ = 0;
        }
        /// <summary>
        /// Вероятность отнесения к классу
        /// </summary>
        public double CalculatedValue { get; }

        /// <summary>
        /// Результат классификации случая
        /// </summary>
        public uint CalculatedClass { get { return calculated_class_; } }

        /// <summary>
        /// Установить точку отсечения
        /// </summary>
        /// <param name="point"></param>
        public void setCutOffPoint(double point)
        {
            if (CalculatedValue > point)
                calculated_class_ = 1;
            else
                calculated_class_ = 0;

        }

        /// <summary>
        /// Фактическая принадлежность случая
        /// </summary>
        public uint RealityClass { get; }

    }
}
