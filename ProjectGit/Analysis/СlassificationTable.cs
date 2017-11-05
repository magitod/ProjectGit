using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectGit
{
    public class ClassificationTableItem
    {
        double value_;
        int fact_;
        int result_;

        public ClassificationTableItem(int fact, double value)
        {
            fact_ = fact;
            result_ = 1;
            value_ = value;
        }
        public int Fact { get { return fact_; } }
        public int Result { get { return result_; } }
        public void setResult(double weight)
        {
            if (value_ < weight)
                result_ = 0;
            else
                result_ = 1;
        }
        public double Value { get { return value_; } }
    }
    public class ClassificationTable
    {
        double[,] classification_;
        List<ClassificationTableItem> dataSet_;
        double cross_sens_;
        double cross_spec_;

        DataTable table_;

        public DataTable Table { get { return table_; } }
        public double CrossSens { get { return cross_sens_; } }
        public double CrossSpec { get { return cross_spec_; } }
        public ClassificationTable (List<ClassificationTableItem> data)
        {
            dataSet_ = data;
            classification_ = new double[2, 2];
            data.OrderBy(x => x.Value);

            table_ = new DataTable();
            string[] cols = new string[] { " ", "1", "0" };
            string[] rows = new string[] { "1", "0" };
            //Column
            for (int i = 0; i < cols.Length; ++i)
                table_.Columns.Add(cols[i]);
        }
        public void computeClassification()
        {
            classification_ = new double[2, 2];
            for (int i = 0; i < dataSet_.Count; ++i)
                classification_[1 - dataSet_[i].Result, 1 - dataSet_[i].Fact]++;
        }
        public void computeClassification(double weight)
        {
            foreach (var cl in dataSet_)
                cl.setResult(weight);

            classification_ = new double[2, 2];

            for (int i = 0; i < dataSet_.Count; ++i)
                classification_[1 - dataSet_[i].Result, 1 - dataSet_[i].Fact]++;
        }
        public void pushTable()
        {
            table_.Rows.Clear();

            //Row
            string[] rows = new string[] { "1", "0" };

            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = table_.NewRow();
                row[0] = rows[i];
                row[1] = classification_[i, 0];
                row[2] = classification_[i, 1];
                table_.Rows.Add(row);
            }

        }

        public double Precision {
            get{
                double positeive = classification_[0, 0] + classification_[1, 1];
                double negative = classification_[1, 0] + classification_[0, 1];
                return positeive / (positeive + negative); }
        }
        public double Recall {
            get {
                return classification_[0, 0] / (classification_[0, 0] + classification_[1, 0]); }
        }
        public double Specificity {
            get {
                return classification_[1, 1] / (classification_[0, 1] + classification_[1, 1]); }
        }

        double getRecall(double[,] data)
        {
                return data[0, 0] / (data[0, 0] + data[1, 0]);          
        }
        public double getSpecificity(double[,] data)
        {
                return data[1, 1] / (data[0, 1] + data[1, 1]);           
        }

        public void LoadChart(Chart chart)
        {
            chart.ChartAreas[0].AxisX.Minimum = 0.0;
            chart.ChartAreas[0].AxisX.Maximum = 1.0;
            chart.ChartAreas[0].AxisY.Maximum = 1.0;
            chart.Series.Clear();
            int index_series = 0;
            double step = 0.01;

            chart.Series.Add(new Series());
            chart.Series[index_series].ChartType = SeriesChartType.Spline;
            chart.Series[index_series].LegendText = "ROC - кривая";

            computeClassification(0.5);
            int start = -1;
            int end = -1;

            int ctrue = 0;
            int cfalse = 0;

            chart.Series[index_series].Points.AddXY(0, 0);
            for (double j = 0.0; j <= 1.0; j += step)
            {
                start = end + 1;
                for(int i = start; i < dataSet_.Count; ++i)
                {
                    if(dataSet_[i].Value >= j){
                        break;
                    }
                    else{                       
                        if(dataSet_[i].Result == 1)
                        {
                            if (dataSet_[i].Fact == 1)
                                ctrue++;
                            else if (dataSet_[i].Fact == 0)
                                cfalse++;
                        }
                        end++;
                    }
                }
                double Sen = (classification_[0, 0] - ctrue) / (classification_[0, 0] + classification_[1, 0]);
                double Spe = (classification_[1, 1] + cfalse) / (classification_[0, 1] + classification_[1, 1]);


                chart.Series[index_series].Points.AddXY(1 - Spe, Sen);
            }
            chart.Series[index_series].Points.AddXY(1, 1);

        }
        public void LoadChartLong(Chart chart)
        {
            chart.ChartAreas[0].AxisX.Minimum = 0.0;
            chart.ChartAreas[0].AxisX.Maximum = 1.0;
            chart.ChartAreas[0].AxisY.Maximum = 1.0;
            chart.Series.Clear();
            int index_series = 0;
            double step = 0.01;

            chart.Series.Add(new Series());
            chart.Series[index_series].ChartType = SeriesChartType.Spline;
            chart.Series[index_series].LegendText = "ROC - кривая";


            chart.Series[index_series].Points.AddXY(1, 1);
            for (double j = 0.0; j <= 1.0; j += step)
            {
                computeClassification(j);
                double Sen = (classification_[0, 0]) / (classification_[0, 0] + classification_[1, 0]);
                double Spe = (classification_[1, 1]) / (classification_[0, 1] + classification_[1, 1]);
                chart.Series[index_series].Points.AddXY(1 - Spe, Sen);
            }
            chart.Series[index_series].Points.AddXY(0, 0);

        }
        public void CrossValid(double weight)
        {
            List<int> listID = new List<int>();
            for (int i = 0; i < dataSet_.Count; ++i)
                listID.Add(i);

            List<List<int>> resultCross = new List<List<int>>();
            double Sen = 0.0, Spec = 0.0;
            bool ismin = true;
            int count = 100;
            Random rnm = new Random();

            while (listID.Count >= count)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < count; ++i)
                {
                    int id = rnm.Next(0, listID.Count);
                    list.Add(listID[id]);
                    listID.RemoveAt(id);
                }
                resultCross.Add(list);
            }
            if (ismin)
            {
                Sen = 1;
                Spec = 1;
            }
            for (int i = 0; i < resultCross.Count; ++i)
            {
                double[,] data = computeClassification(resultCross[i], weight);
                if (ismin)
                {
                    Sen = Math.Min(getRecall(data), Sen);
                    Spec = Math.Min(getSpecificity(data), Spec);
                }
                else
                {
                    Sen += getRecall(data);
                    Spec += getSpecificity(data);
                }
            }
            if (!ismin)
            {
                Sen /= resultCross.Count;
                Spec /= resultCross.Count;
            }
            cross_sens_ = Sen;
            cross_spec_ = Spec;
        }
        public double[,] computeClassification(List<int> listID, double weight)
        {
            double[,] data = new double[2, 2];

            foreach (int id in listID)
                dataSet_[id].setResult(weight);

            for (int i = 0; i < listID.Count; ++i)
                data[1 - dataSet_[listID[i]].Result, 1 - dataSet_[listID[i]].Fact]++;

            return data;
        }

        public double getPoint()
        {
            double point = 0.5;
            double limit = 0.01;
            double left = 0;
            double right = 1;
            double delta = 1;
            int count = 0;
            bool flag = true;
            while (true)
            {
                computeClassification(point);
                double Spec = Specificity;
                double Sens = Recall;
                double delta_new = Math.Abs(Spec - Sens);
                if (delta >= delta_new)
                    count++;
                else
                    delta = delta_new;

                if(count > 100)
                    flag = false;

                if (delta_new <= limit)
                {
                    break;
                }
                else
                {
                    if (Spec > Sens)
                        right = point;
                    else
                        left = point;
                    point = (right + left) / 2.0;
                }
            }
            return point;
        }
    }
}
