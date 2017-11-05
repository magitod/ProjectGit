namespace ProjectGit
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgv_layer_weights = new System.Windows.Forms.DataGridView();
            this.dgv_train_selection = new System.Windows.Forms.DataGridView();
            this.btn_train = new System.Windows.Forms.Button();
            this.btn_init_weights = new System.Windows.Forms.Button();
            this.tab_train_selection = new System.Windows.Forms.TabControl();
            this.tabPage_Training = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.regularization_config = new System.Windows.Forms.NumericUpDown();
            this.errorChange_config = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.error_config = new System.Windows.Forms.NumericUpDown();
            this.learningRate_config = new System.Windows.Forms.NumericUpDown();
            this.epohes_config = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage_TrainSelection = new System.Windows.Forms.TabPage();
            this.tabPage_Structure_NN = new System.Windows.Forms.TabPage();
            this.btn_random = new System.Windows.Forms.Button();
            this.lb_name_layer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_layer_weights = new System.Windows.Forms.ComboBox();
            this.tabPage_Classification = new System.Windows.Forms.TabPage();
            this.cutoffpointt_config = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_specificity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_recall = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_precision = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_accuracy = new System.Windows.Forms.TextBox();
            this.dgv_classific = new System.Windows.Forms.DataGridView();
            this.chart_classific = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_weights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_train_selection)).BeginInit();
            this.tab_train_selection.SuspendLayout();
            this.tabPage_Training.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regularization_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorChange_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRate_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epohes_config)).BeginInit();
            this.tabPage_TrainSelection.SuspendLayout();
            this.tabPage_Structure_NN.SuspendLayout();
            this.tabPage_Classification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cutoffpointt_config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_classific)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_classific)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_layer_weights
            // 
            this.dgv_layer_weights.AllowUserToAddRows = false;
            this.dgv_layer_weights.AllowUserToDeleteRows = false;
            this.dgv_layer_weights.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_weights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_weights.Location = new System.Drawing.Point(17, 37);
            this.dgv_layer_weights.Name = "dgv_layer_weights";
            this.dgv_layer_weights.RowHeadersVisible = false;
            this.dgv_layer_weights.Size = new System.Drawing.Size(719, 463);
            this.dgv_layer_weights.TabIndex = 0;
            // 
            // dgv_train_selection
            // 
            this.dgv_train_selection.AllowUserToAddRows = false;
            this.dgv_train_selection.AllowUserToDeleteRows = false;
            this.dgv_train_selection.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_train_selection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_train_selection.Location = new System.Drawing.Point(0, 0);
            this.dgv_train_selection.Name = "dgv_train_selection";
            this.dgv_train_selection.RowHeadersVisible = false;
            this.dgv_train_selection.Size = new System.Drawing.Size(942, 522);
            this.dgv_train_selection.TabIndex = 4;
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(753, 66);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(150, 32);
            this.btn_train.TabIndex = 7;
            this.btn_train.Text = "Обучить";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
            // 
            // btn_init_weights
            // 
            this.btn_init_weights.Location = new System.Drawing.Point(753, 25);
            this.btn_init_weights.Name = "btn_init_weights";
            this.btn_init_weights.Size = new System.Drawing.Size(150, 32);
            this.btn_init_weights.TabIndex = 8;
            this.btn_init_weights.Text = "Инициализировать веса";
            this.btn_init_weights.UseVisualStyleBackColor = true;
            this.btn_init_weights.Click += new System.EventHandler(this.btn_init_weights_Click);
            // 
            // tab_train_selection
            // 
            this.tab_train_selection.Controls.Add(this.tabPage_Training);
            this.tab_train_selection.Controls.Add(this.tabPage_Structure_NN);
            this.tab_train_selection.Controls.Add(this.tabPage_TrainSelection);
            this.tab_train_selection.Controls.Add(this.tabPage_Classification);
            this.tab_train_selection.Location = new System.Drawing.Point(12, 12);
            this.tab_train_selection.Name = "tab_train_selection";
            this.tab_train_selection.SelectedIndex = 0;
            this.tab_train_selection.Size = new System.Drawing.Size(950, 548);
            this.tab_train_selection.TabIndex = 10;
            // 
            // tabPage_Training
            // 
            this.tabPage_Training.Controls.Add(this.label9);
            this.tabPage_Training.Controls.Add(this.regularization_config);
            this.tabPage_Training.Controls.Add(this.errorChange_config);
            this.tabPage_Training.Controls.Add(this.label8);
            this.tabPage_Training.Controls.Add(this.label7);
            this.tabPage_Training.Controls.Add(this.label6);
            this.tabPage_Training.Controls.Add(this.label5);
            this.tabPage_Training.Controls.Add(this.error_config);
            this.tabPage_Training.Controls.Add(this.learningRate_config);
            this.tabPage_Training.Controls.Add(this.epohes_config);
            this.tabPage_Training.Controls.Add(this.label4);
            this.tabPage_Training.Controls.Add(this.label3);
            this.tabPage_Training.Controls.Add(this.label2);
            this.tabPage_Training.Controls.Add(this.textBox3);
            this.tabPage_Training.Controls.Add(this.textBox2);
            this.tabPage_Training.Controls.Add(this.textBox1);
            this.tabPage_Training.Controls.Add(this.btn_train);
            this.tabPage_Training.Controls.Add(this.btn_init_weights);
            this.tabPage_Training.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Training.Name = "tabPage_Training";
            this.tabPage_Training.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Training.Size = new System.Drawing.Size(942, 522);
            this.tabPage_Training.TabIndex = 1;
            this.tabPage_Training.Text = "Обучение НС";
            this.tabPage_Training.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Regularization";
            // 
            // regularization_config
            // 
            this.regularization_config.DecimalPlaces = 6;
            this.regularization_config.Location = new System.Drawing.Point(178, 130);
            this.regularization_config.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.regularization_config.Name = "regularization_config";
            this.regularization_config.Size = new System.Drawing.Size(120, 20);
            this.regularization_config.TabIndex = 23;
            this.regularization_config.Value = new decimal(new int[] {
            500000,
            0,
            0,
            393216});
            // 
            // errorChange_config
            // 
            this.errorChange_config.DecimalPlaces = 6;
            this.errorChange_config.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.errorChange_config.Location = new System.Drawing.Point(178, 104);
            this.errorChange_config.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.errorChange_config.Name = "errorChange_config";
            this.errorChange_config.Size = new System.Drawing.Size(120, 20);
            this.errorChange_config.TabIndex = 22;
            this.errorChange_config.Value = new decimal(new int[] {
            100000,
            0,
            0,
            720896});
            this.errorChange_config.ValueChanged += new System.EventHandler(this.errorChange_config_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Error Change (ε)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Error (Minimum)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "LearningRate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Epohes (Maximum)";
            // 
            // error_config
            // 
            this.error_config.DecimalPlaces = 6;
            this.error_config.Location = new System.Drawing.Point(178, 52);
            this.error_config.Name = "error_config";
            this.error_config.Size = new System.Drawing.Size(120, 20);
            this.error_config.TabIndex = 17;
            this.error_config.ValueChanged += new System.EventHandler(this.error_config_ValueChanged);
            // 
            // learningRate_config
            // 
            this.learningRate_config.DecimalPlaces = 6;
            this.learningRate_config.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.learningRate_config.Location = new System.Drawing.Point(178, 78);
            this.learningRate_config.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.learningRate_config.Name = "learningRate_config";
            this.learningRate_config.Size = new System.Drawing.Size(120, 20);
            this.learningRate_config.TabIndex = 16;
            this.learningRate_config.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.learningRate_config.ValueChanged += new System.EventHandler(this.learningRate_config_ValueChanged);
            // 
            // epohes_config
            // 
            this.epohes_config.Location = new System.Drawing.Point(178, 26);
            this.epohes_config.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.epohes_config.Name = "epohes_config";
            this.epohes_config.Size = new System.Drawing.Size(120, 20);
            this.epohes_config.TabIndex = 15;
            this.epohes_config.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.epohes_config.ValueChanged += new System.EventHandler(this.epohes_config_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Error";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Epohes";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(490, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(188, 20);
            this.textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(490, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(490, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 20);
            this.textBox1.TabIndex = 9;
            // 
            // tabPage_TrainSelection
            // 
            this.tabPage_TrainSelection.Controls.Add(this.dgv_train_selection);
            this.tabPage_TrainSelection.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TrainSelection.Name = "tabPage_TrainSelection";
            this.tabPage_TrainSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TrainSelection.Size = new System.Drawing.Size(942, 522);
            this.tabPage_TrainSelection.TabIndex = 0;
            this.tabPage_TrainSelection.Text = "Обучающая выборка";
            this.tabPage_TrainSelection.UseVisualStyleBackColor = true;
            // 
            // tabPage_Structure_NN
            // 
            this.tabPage_Structure_NN.Controls.Add(this.btn_random);
            this.tabPage_Structure_NN.Controls.Add(this.lb_name_layer);
            this.tabPage_Structure_NN.Controls.Add(this.label1);
            this.tabPage_Structure_NN.Controls.Add(this.cb_layer_weights);
            this.tabPage_Structure_NN.Controls.Add(this.dgv_layer_weights);
            this.tabPage_Structure_NN.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Structure_NN.Name = "tabPage_Structure_NN";
            this.tabPage_Structure_NN.Size = new System.Drawing.Size(942, 522);
            this.tabPage_Structure_NN.TabIndex = 2;
            this.tabPage_Structure_NN.Text = "Структура НС";
            this.tabPage_Structure_NN.UseVisualStyleBackColor = true;
            // 
            // btn_random
            // 
            this.btn_random.Location = new System.Drawing.Point(754, 76);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(174, 32);
            this.btn_random.TabIndex = 9;
            this.btn_random.Text = "Инициализировать веса";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // lb_name_layer
            // 
            this.lb_name_layer.AutoSize = true;
            this.lb_name_layer.Location = new System.Drawing.Point(14, 18);
            this.lb_name_layer.Name = "lb_name_layer";
            this.lb_name_layer.Size = new System.Drawing.Size(0, 13);
            this.lb_name_layer.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(751, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Слой нейронной сети";
            // 
            // cb_layer_weights
            // 
            this.cb_layer_weights.FormattingEnabled = true;
            this.cb_layer_weights.Location = new System.Drawing.Point(754, 37);
            this.cb_layer_weights.Name = "cb_layer_weights";
            this.cb_layer_weights.Size = new System.Drawing.Size(174, 21);
            this.cb_layer_weights.TabIndex = 1;
            this.cb_layer_weights.SelectedIndexChanged += new System.EventHandler(this.cb_layer_weights_SelectedIndexChanged);
            // 
            // tabPage_Classification
            // 
            this.tabPage_Classification.Controls.Add(this.cutoffpointt_config);
            this.tabPage_Classification.Controls.Add(this.label14);
            this.tabPage_Classification.Controls.Add(this.label13);
            this.tabPage_Classification.Controls.Add(this.tb_specificity);
            this.tabPage_Classification.Controls.Add(this.label12);
            this.tabPage_Classification.Controls.Add(this.tb_recall);
            this.tabPage_Classification.Controls.Add(this.label11);
            this.tabPage_Classification.Controls.Add(this.tb_precision);
            this.tabPage_Classification.Controls.Add(this.label10);
            this.tabPage_Classification.Controls.Add(this.tb_accuracy);
            this.tabPage_Classification.Controls.Add(this.dgv_classific);
            this.tabPage_Classification.Controls.Add(this.chart_classific);
            this.tabPage_Classification.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Classification.Name = "tabPage_Classification";
            this.tabPage_Classification.Size = new System.Drawing.Size(942, 522);
            this.tabPage_Classification.TabIndex = 3;
            this.tabPage_Classification.Text = "Классификация";
            this.tabPage_Classification.UseVisualStyleBackColor = true;
            // 
            // cutoffpointt_config
            // 
            this.cutoffpointt_config.DecimalPlaces = 5;
            this.cutoffpointt_config.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.cutoffpointt_config.Location = new System.Drawing.Point(122, 18);
            this.cutoffpointt_config.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cutoffpointt_config.Name = "cutoffpointt_config";
            this.cutoffpointt_config.Size = new System.Drawing.Size(167, 20);
            this.cutoffpointt_config.TabIndex = 20;
            this.cutoffpointt_config.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Cut-off point";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Specificity";
            // 
            // tb_specificity
            // 
            this.tb_specificity.Location = new System.Drawing.Point(122, 132);
            this.tb_specificity.Name = "tb_specificity";
            this.tb_specificity.Size = new System.Drawing.Size(167, 20);
            this.tb_specificity.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Recall";
            // 
            // tb_recall
            // 
            this.tb_recall.Location = new System.Drawing.Point(122, 106);
            this.tb_recall.Name = "tb_recall";
            this.tb_recall.Size = new System.Drawing.Size(167, 20);
            this.tb_recall.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Precision";
            // 
            // tb_precision
            // 
            this.tb_precision.Location = new System.Drawing.Point(122, 80);
            this.tb_precision.Name = "tb_precision";
            this.tb_precision.Size = new System.Drawing.Size(167, 20);
            this.tb_precision.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Accuracy";
            // 
            // tb_accuracy
            // 
            this.tb_accuracy.Location = new System.Drawing.Point(122, 54);
            this.tb_accuracy.Name = "tb_accuracy";
            this.tb_accuracy.Size = new System.Drawing.Size(167, 20);
            this.tb_accuracy.TabIndex = 11;
            // 
            // dgv_classific
            // 
            this.dgv_classific.AllowUserToAddRows = false;
            this.dgv_classific.AllowUserToDeleteRows = false;
            this.dgv_classific.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_classific.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_classific.ColumnHeadersVisible = false;
            this.dgv_classific.Location = new System.Drawing.Point(25, 174);
            this.dgv_classific.Name = "dgv_classific";
            this.dgv_classific.RowHeadersVisible = false;
            this.dgv_classific.Size = new System.Drawing.Size(264, 136);
            this.dgv_classific.TabIndex = 1;
            // 
            // chart_classific
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_classific.ChartAreas.Add(chartArea3);
            this.chart_classific.Location = new System.Drawing.Point(390, 67);
            this.chart_classific.Name = "chart_classific";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chart_classific.Series.Add(series3);
            this.chart_classific.Size = new System.Drawing.Size(449, 380);
            this.chart_classific.TabIndex = 0;
            this.chart_classific.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 568);
            this.Controls.Add(this.tab_train_selection);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_weights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_train_selection)).EndInit();
            this.tab_train_selection.ResumeLayout(false);
            this.tabPage_Training.ResumeLayout(false);
            this.tabPage_Training.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regularization_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorChange_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRate_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epohes_config)).EndInit();
            this.tabPage_TrainSelection.ResumeLayout(false);
            this.tabPage_Structure_NN.ResumeLayout(false);
            this.tabPage_Structure_NN.PerformLayout();
            this.tabPage_Classification.ResumeLayout(false);
            this.tabPage_Classification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cutoffpointt_config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_classific)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_classific)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_layer_weights;
        private System.Windows.Forms.DataGridView dgv_train_selection;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Button btn_init_weights;
        private System.Windows.Forms.TabControl tab_train_selection;
        private System.Windows.Forms.TabPage tabPage_TrainSelection;
        private System.Windows.Forms.TabPage tabPage_Training;
        private System.Windows.Forms.TabPage tabPage_Structure_NN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_layer_weights;
        private System.Windows.Forms.Label lb_name_layer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_random;
        private System.Windows.Forms.NumericUpDown errorChange_config;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown error_config;
        private System.Windows.Forms.NumericUpDown learningRate_config;
        private System.Windows.Forms.NumericUpDown epohes_config;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown regularization_config;
        private System.Windows.Forms.TabPage tabPage_Classification;
        private System.Windows.Forms.DataGridView dgv_classific;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_classific;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_specificity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_recall;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_precision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_accuracy;
        private System.Windows.Forms.NumericUpDown cutoffpointt_config;
        private System.Windows.Forms.Label label14;
    }
}

