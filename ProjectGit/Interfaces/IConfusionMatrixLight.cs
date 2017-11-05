using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public interface IConfusionMatrixLight
    {
        /*
        Confusion Matrix
        [Description] => четырехпольная таблица сопряженности, которая строится на основе 
        результатов классификации моделью и фактической (объективной) принадлежностью примеров к классам
        [Columns] => [Reality][true], [Reality][false]
        [Rows] => [Model][true], [Model][false]
        [Items] {
          [Model][true]  && [Reality][true]  => True Positives  (TP) 
          [Model][false] && [Reality][false] => True Negatives  (TN)
          [Model][false] && [Reality][true]  => False Negatives (FN)
          [Model][true]  && [Reality][false] => False Positives (FP)
        }

        Positive => Обнаружение случая
        Negative => Пропуск случая

        Class
        [Description] => класс, к которому отнесен пример
        [Type] => bool
        [Value] {
            [true] => класс с положительным исходом
            [false] => класс с отрицательным исходом
        }

        CalculatedClass /Model /System /Algorithm
        [Description] => результат классификации примера с помощью модели
        [Type] => Class

        RealityClass
        [Description] => фактическая принадлежность примера к классу
        [Type] => Class
        */

        /// <summary>
        /// True Positives (TP) – верно классифицированные положительные случаи (принадлежащие данному классу).
        /// </summary>
        int True_Positive { get; }

        /// <summary>
        /// True Negatives (TN) – верно классифицированные отрицательные случаи (принадлежащие другому классу).
        /// </summary>
        int True_Negative { get; }

        /// <summary>
        /// False Negatives (FN) – положительные случаи (принадлежащие данному классу) классифицированные как отрицательные (отнесены к другому классу)  [ошибка I рода]. 
        /// Ложный пропуск – интересующее событие ошибочно не обнаруживается
        /// </summary>
        int False_Negative { get; }

        /// <summary>
        /// False Positives (FP) – отрицательные случаи (принадлежащие другому классу) классифицированные как положительные(отнесены к данному классу) [ошибка II рода].
        /// Ложное обнаружение - при отсутствии события ошибочно выносится решение о его присутствии
        /// </summary>
        int False_Positive { get; }

        /// <summary>
        /// Точность
        /// [Description] доля найденных системой случаев, принадлежащих классу, 
        /// относительно всех случаев, которые система отнесла к этому классу
        /// [Formula] TP / (TP + FP)
        /// </summary>
        double Precision { get; }

        /// <summary>
        /// Специфичность
        /// [Description] Доля истинно отрицательных случаев, которые были правильно идентифицированы моделью
        /// [Formula] TN / (TN + FP)
        /// </summary>
        double Specificity { get; }

        /// <summary>
        /// Общая точность
        /// [Description] Доля правильно классифицированных случаев
        /// [Formula] (TP + TN) / (TP + TN + FP + FN)
        /// </summary>
        double Accuracy { get; }

        /// <summary>
        /// Полнота
        /// [Description] Доля найденных системой случаев, принадлежащих классу,
        /// относительно всех документов этого класса
        /// [Formula] TP / (TP + FN)
        /// </summary>
        double Recall { get; }
    }
}
