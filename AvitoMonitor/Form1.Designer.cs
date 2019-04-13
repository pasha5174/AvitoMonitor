namespace AvitoMonitor
{
    partial class AvitoMonitor
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
            this.search = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchtextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadbd = new System.Windows.Forms.Button();
            this.comboBoxForCity = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(447, 15);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 0;
            this.search.Text = "Поиск";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 460);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // searchtextBox
            // 
            this.searchtextBox.Location = new System.Drawing.Point(12, 15);
            this.searchtextBox.Name = "searchtextBox";
            this.searchtextBox.Size = new System.Drawing.Size(429, 20);
            this.searchtextBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(447, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 460);
            this.dataGridView1.TabIndex = 3;
            // 
            // loadbd
            // 
            this.loadbd.Location = new System.Drawing.Point(528, 15);
            this.loadbd.Name = "loadbd";
            this.loadbd.Size = new System.Drawing.Size(143, 23);
            this.loadbd.TabIndex = 4;
            this.loadbd.Text = "Загрузить базу данных";
            this.loadbd.UseVisualStyleBackColor = true;
            this.loadbd.Click += new System.EventHandler(this.loadbd_Click);
            // 
            // comboBoxForCity
            // 
            this.comboBoxForCity.FormattingEnabled = true;
            this.comboBoxForCity.Location = new System.Drawing.Point(688, 16);
            this.comboBoxForCity.Name = "comboBoxForCity";
            this.comboBoxForCity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxForCity.TabIndex = 5;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(825, 15);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 6;
            // 
            // AvitoMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 521);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.comboBoxForCity);
            this.Controls.Add(this.loadbd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchtextBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.search);
            this.Name = "AvitoMonitor";
            this.Text = "AvitoMonitor";
            this.Load += new System.EventHandler(this.AvitoMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox searchtextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadbd;
        private System.Windows.Forms.ComboBox comboBoxForCity;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}

