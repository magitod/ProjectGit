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
        /// Произвести вычисление класса по отчке отсечения
        /// </summary>
        /// <param name="cut_off_point">Точка отсечения</param>
        /// <returns></returns>
        public void makeCalculationClass(double cut_off_point)
        {
            calculated_class_ = calculateClass(cut_off_point);
        }

        /// <summary>
        /// Вычислить класс
        /// </summary>
        /// <param name="cut_off_point">Точка отсечения</param>
        /// <returns>Класс</returns>
        public uint calculateClass(double cut_off_point)
        {
            uint trueClass = 0;
            uint falseClass = 1;
            return (CalculatedValue > cut_off_point) ? trueClass : falseClass;
        }

        /// <summary>
        /// Фактическая принадлежность случая
        /// </summary>
        public uint RealityClass { get; }

    }
}
