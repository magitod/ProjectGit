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
            this.dgv_layer_1 = new System.Windows.Forms.DataGridView();
            this.dgv_layer_3 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_train_selection = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_layer_2 = new System.Windows.Forms.DataGridView();
            this.btn_train = new System.Windows.Forms.Button();
            this.btn_init_weights = new System.Windows.Forms.Button();
            this.tab_train_selection = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_train_selection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).BeginInit();
            this.tab_train_selection.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_layer_1
            // 
            this.dgv_layer_1.AllowUserToAddRows = false;
            this.dgv_layer_1.AllowUserToDeleteRows = false;
            this.dgv_layer_1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_1.Location = new System.Drawing.Point(13, 32);
            this.dgv_layer_1.Name = "dgv_layer_1";
            this.dgv_layer_1.RowHeadersVisible = false;
            this.dgv_layer_1.Size = new System.Drawing.Size(497, 231);
            this.dgv_layer_1.TabIndex = 0;
            // 
            // dgv_layer_3
            // 
            this.dgv_layer_3.AllowUserToAddRows = false;
            this.dgv_layer_3.AllowUserToDeleteRows = false;
            this.dgv_layer_3.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_3.Location = new System.Drawing.Point(14, 411);
            this.dgv_layer_3.Name = "dgv_layer_3";
            this.dgv_layer_3.RowHeadersVisible = false;
            this.dgv_layer_3.Size = new System.Drawing.Size(497, 91);
            this.dgv_layer_3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Веса входного слоя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Веса выходного слоя";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Веса скрытого слоя";
            // 
            // dgv_layer_2
            // 
            this.dgv_layer_2.AllowUserToAddRows = false;
            this.dgv_layer_2.AllowUserToDeleteRows = false;
            this.dgv_layer_2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_2.Location = new System.Drawing.Point(14, 295);
            this.dgv_layer_2.Name = "dgv_layer_2";
            this.dgv_layer_2.RowHeadersVisible = false;
            this.dgv_layer_2.Size = new System.Drawing.Size(497, 88);
            this.dgv_layer_2.TabIndex = 5;
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
            this.btn_init_weights.Location = new System.Drawing.Point(753, 28);
            this.btn_init_weights.Name = "btn_init_weights";
            this.btn_init_weights.Size = new System.Drawing.Size(150, 32);
            this.btn_init_weights.TabIndex = 8;
            this.btn_init_weights.Text = "Инициализировать веса";
            this.btn_init_weights.UseVisualStyleBackColor = true;
            this.btn_init_weights.Click += new System.EventHandler(this.btn_init_weights_Click);
            // 
            // tab_train_selection
            // 
            this.tab_train_selection.Controls.Add(this.tabPage1);
            this.tab_train_selection.Controls.Add(this.tabPage2);
            this.tab_train_selection.Controls.Add(this.tabPage3);
            this.tab_train_selection.Location = new System.Drawing.Point(12, 12);
            this.tab_train_selection.Name = "tab_train_selection";
            this.tab_train_selection.SelectedIndex = 0;
            this.tab_train_selection.Size = new System.Drawing.Size(950, 548);
            this.tab_train_selection.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_train_selection);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Обучающая выборка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_train);
            this.tabPage3.Controls.Add(this.btn_init_weights);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 522);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Обучение НС";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_layer_1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgv_layer_2);
            this.tabPage2.Controls.Add(this.dgv_layer_3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(942, 522);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Структура НС";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 568);
            this.Controls.Add(this.tab_train_selection);
            this.Name = "Main";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_train_selection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).EndInit();
            this.tab_train_selection.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_layer_1;
        private System.Windows.Forms.DataGridView dgv_layer_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_train_selection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_layer_2;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Button btn_init_weights;
        private System.Windows.Forms.TabControl tab_train_selection;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

