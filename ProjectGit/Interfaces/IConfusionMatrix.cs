using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface IConfusionMatrix
    {
        /*
        Confusion Matrix
        [Description] => четырехпольная таблица сопряженности, которая строится на основе 
        результатов классификации моделью и фактической (объективной) принадлежностью примеров к классам
        [Columns] => RealityClass
        [Rows] => CalculatedClass

        Positive => Обнаружение случая
        Negative => Пропуск случая

        Class
        [Description] => класс, к которому отнесен пример
        [Type] => uint

        CalculatedClass /Model /System /Algorithm
        [Description] => результат классификации примера с помощью модели
        [Type] => Class

        RealityClass
        [Description] => фактическая принадлежность примера к классу
        [Type] => Class
        */

        /// <summary>
        /// Confusion Matrix
        /// [Description] => Матрица неточностей
        /// [Size] => Количество классов
        /// [Columns] => [RealityClass]
        /// [Rows] => [CalculatedClass]
        /// </summary>
        uint[,] Matrix { get; }

        /// <summary>
        /// Размер таблицы
        /// </summary>
        uint Size { get; }

        /// <summary>
        /// Точность
        /// [Description] доля найденных системой случаев, принадлежащих классу, 
        /// относительно всех случаев, которые система отнесла к этому классу
        /// [Formula] TP / (TP + FP)
        /// </summary>
        double Precision (uint indexClass);


        /// <summary>
        /// Специфичность
        /// [Description] Доля истинно отрицательных случаев, которые были правильно идентифицированы моделью
        /// [Formula] TN / (TN + FP)
        /// </summary>
        double Specificity (uint indexClass);

        /// <summary>
        /// Общая точность
        /// [Description] Доля правильно классифицированных случаев
        /// [Formula] (TP + TN) / (TP + TN + FP + FN)
        /// </summary>
        double Accuracy (uint indexClass);

        /// <summary>
        /// Полнота (TPR)
        /// [Description] Доля найденных системой случаев, принадлежащих классу,
        /// относительно всех документов этого класса
        /// [Formula] TP / (TP + FN)
        /// </summary>
        double Recall (uint indexClass);


        /// <summary>
        /// True Positives (TP) – верно классифицированные положительные случаи (принадлежащие данному классу).
        /// </summary>
        double getTruePositive(uint indexClass);

        /// <summary>
        /// True Negatives (TN) – верно классифицированные отрицательные случаи (принадлежащие другому классу).
        /// </summary>
        double getTrueNegative(uint indexClass);

        /// <summary>
        /// False Negatives (FN) – положительные случаи (принадлежащие данному классу) классифицированные как отрицательные (отнесены к другому классу)  [ошибка I рода]. 
        /// Ложный пропуск – интересующее событие ошибочно не обнаруживается
        /// </summary>
        double getFalseNegative(uint indexClass);

        /// <summary>
        /// False Positives (FP) – отрицательные случаи (принадлежащие другому классу) классифицированные как положительные(отнесены к данному классу) [ошибка II рода].
        /// Ложное обнаружение - при отсутствии события ошибочно выносится решение о его присутствии
        /// </summary>
        double getFalsePositive(uint indexClass);
    }
        
}
