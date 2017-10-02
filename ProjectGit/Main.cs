using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ProjectGit
{
    public partial class Main : Form
    {
        List<DataItem<double>> data_;
        DataItem<string> data_info_rus_;
        DataItem<string> data_info_eng_;
        DataTable table_train_selection_;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data_info_eng_ = new DataItem<string>(
                                   new string[] { "age", "gender", "arterialHypertension", "aorticSclerosis" },
                                   new string[] { "coronarySclerosis" }
                               );
            data_info_rus_ = new DataItem<string>(
                                new string[] { "Возраст", "Пол", "АГ", "АС" },
                                new string[] { "КС" }
                            );

            //Чтение обучающей выборки
            data_ = readTrainSelection();

            //Создание таблицы с данными обучающей выборки
            table_train_selection_ = createTableTrainSelection();

            //Вывод данных таблицы
            dataGridView1.DataSource = table_train_selection_;
            for (int j = 0; j < data_info_eng_.Input.Length; j++)          
                dataGridView1.Columns[data_info_eng_.Input[j]].HeaderText = data_info_rus_.Input[j];        
            for (int j = 0; j < data_info_eng_.Output.Length; j++)          
                dataGridView1.Columns[data_info_eng_.Output[j]].HeaderText = data_info_rus_.Output[j];           
        }

        List<DataItem<double>> readTrainSelection()
        {
            List<DataItem<double>> dataList = new List<DataItem<double>>();        


            string[] items = Properties.Resources.TrainSelection.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                string[] elements = item.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                bool flag = true;
                int id = -1;
                double age = 0;
                int gender = 1;
                int arterialHypertension = 0;
                int aorticSclerosis = 0;
                int coronarySclerosis = 0;
                try
                {
                    int.TryParse(elements[0], out id);
                    double.TryParse(elements[1], out age);
                    int.TryParse(elements[2], out gender);
                    int.TryParse(elements[3], out arterialHypertension);
                    if (elements[4] == " ")
                        flag = false;
                    int.TryParse(elements[4], out aorticSclerosis);
                    int.TryParse(elements[5], out coronarySclerosis);
                }
                catch
                {
                    flag = false;
                }

                if (flag)
                {
                    dataList.Add(
                        new DataItem<double>(
                            new double[] { age, gender, arterialHypertension, aorticSclerosis}, 
                            new double[] { coronarySclerosis }
                        )                        
                    );
                }
            }

            double _min = dataList.Min(x => x.Input[0]);
            double _max = dataList.Max(x => x.Input[0]);
            double _denominator = _max - _min;
            if (_denominator != 0)
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    dataList[i].Input[0] = ((dataList[i].Input[0] - _min) / _denominator);
                }
            }

            return dataList;

        }
        DataTable createTableTrainSelection()
        {
            DataTable table = new DataTable();

            foreach (string column in data_info_eng_.Input)
                table.Columns.Add(new DataColumn(column));
            foreach (string column in data_info_eng_.Output)
                table.Columns.Add(new DataColumn(column));

            for (int i = 0; i < data_.Count; i++)
            {
                DataRow row = table.NewRow();

                for (int j = 0; j < data_info_eng_.Input.Length; j++)               
                    row[data_info_eng_.Input[j]] = data_[i].Input[j];            
                for (int j = 0; j < data_info_eng_.Output.Length; j++)                
                    row[data_info_eng_.Output[j]] = data_[i].Output[j];
                
                table.Rows.Add(row);
            }

            return table;
        }
        void createNeuralNetwork()
        {

        }
    }   
}
