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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_layer_2 = new System.Windows.Forms.DataGridView();
            this.btn_train = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_layer_1
            // 
            this.dgv_layer_1.AllowUserToAddRows = false;
            this.dgv_layer_1.AllowUserToDeleteRows = false;
            this.dgv_layer_1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_1.Location = new System.Drawing.Point(12, 30);
            this.dgv_layer_1.Name = "dgv_layer_1";
            this.dgv_layer_1.RowHeadersVisible = false;
            this.dgv_layer_1.Size = new System.Drawing.Size(497, 150);
            this.dgv_layer_1.TabIndex = 0;
            // 
            // dgv_layer_3
            // 
            this.dgv_layer_3.AllowUserToAddRows = false;
            this.dgv_layer_3.AllowUserToDeleteRows = false;
            this.dgv_layer_3.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_3.Location = new System.Drawing.Point(12, 416);
            this.dgv_layer_3.Name = "dgv_layer_3";
            this.dgv_layer_3.RowHeadersVisible = false;
            this.dgv_layer_3.Size = new System.Drawing.Size(497, 150);
            this.dgv_layer_3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Веса от входного слоя к 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Веса от 2 слоя к выходному";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(558, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(730, 536);
            this.dataGridView1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Веса от от 1 до 2 слоя";
            // 
            // dgv_layer_2
            // 
            this.dgv_layer_2.AllowUserToAddRows = false;
            this.dgv_layer_2.AllowUserToDeleteRows = false;
            this.dgv_layer_2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_2.Location = new System.Drawing.Point(12, 217);
            this.dgv_layer_2.Name = "dgv_layer_2";
            this.dgv_layer_2.RowHeadersVisible = false;
            this.dgv_layer_2.Size = new System.Drawing.Size(497, 150);
            this.dgv_layer_2.TabIndex = 5;
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(558, 589);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(190, 29);
            this.btn_train.TabIndex = 7;
            this.btn_train.Text = "Обучить";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 630);
            this.Controls.Add(this.btn_train);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_layer_2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_layer_3);
            this.Controls.Add(this.dgv_layer_1);
            this.Name = "Main";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_layer_1;
        private System.Windows.Forms.DataGridView dgv_layer_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_layer_2;
        private System.Windows.Forms.Button btn_train;
    }
}

