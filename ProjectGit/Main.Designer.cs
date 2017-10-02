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
            this.dgv_layer_2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dgv_layer_2
            // 
            this.dgv_layer_2.AllowUserToAddRows = false;
            this.dgv_layer_2.AllowUserToDeleteRows = false;
            this.dgv_layer_2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_layer_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_layer_2.Location = new System.Drawing.Point(12, 225);
            this.dgv_layer_2.Name = "dgv_layer_2";
            this.dgv_layer_2.RowHeadersVisible = false;
            this.dgv_layer_2.Size = new System.Drawing.Size(497, 150);
            this.dgv_layer_2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Веса от входного слоя к скрытому";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Веса от скрытого слоя к выходному";
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
            this.dataGridView1.Size = new System.Drawing.Size(730, 345);
            this.dataGridView1.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 396);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_layer_2);
            this.Controls.Add(this.dgv_layer_1);
            this.Name = "Main";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_layer_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_layer_1;
        private System.Windows.Forms.DataGridView dgv_layer_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

