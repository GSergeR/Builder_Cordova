namespace AppForBuildCordova
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxAppList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBuyerList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_info = new System.Windows.Forms.Label();
            this.comboBoxAppName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // comboBoxAppList
            // 
            this.comboBoxAppList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppList.FormattingEnabled = true;
            this.comboBoxAppList.Location = new System.Drawing.Point(12, 22);
            this.comboBoxAppList.Name = "comboBoxAppList";
            this.comboBoxAppList.Size = new System.Drawing.Size(215, 21);
            this.comboBoxAppList.TabIndex = 1;
            this.comboBoxAppList.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAppList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Приложение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Байер";
            // 
            // comboBoxBuyerList
            // 
            this.comboBoxBuyerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBuyerList.FormattingEnabled = true;
            this.comboBoxBuyerList.Location = new System.Drawing.Point(12, 65);
            this.comboBoxBuyerList.Name = "comboBoxBuyerList";
            this.comboBoxBuyerList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuyerList.TabIndex = 4;
            this.comboBoxBuyerList.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBuyerList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_info);
            this.groupBox1.Location = new System.Drawing.Point(444, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 282);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(6, 18);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(52, 13);
            this.label_info.TabIndex = 6;
            this.label_info.Text = "label_info";
            // 
            // comboBoxAppName
            // 
            this.comboBoxAppName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppName.FormattingEnabled = true;
            this.comboBoxAppName.Location = new System.Drawing.Point(12, 108);
            this.comboBoxAppName.Name = "comboBoxAppName";
            this.comboBoxAppName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAppName.TabIndex = 6;
            this.comboBoxAppName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAppName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxAppName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxBuyerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAppList);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxAppList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBuyerList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.ComboBox comboBoxAppName;
        private System.Windows.Forms.Label label3;
    }
}

