namespace RPG_Sharp
{
    partial class RPGForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelHeroInfo = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Enabled = false;
            this.textBoxLog.Location = new System.Drawing.Point(556, 124);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(318, 276);
            this.textBoxLog.TabIndex = 0;
            // 
            // labelHeroInfo
            // 
            this.labelHeroInfo.AutoSize = true;
            this.labelHeroInfo.Location = new System.Drawing.Point(554, 110);
            this.labelHeroInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeroInfo.Name = "labelHeroInfo";
            this.labelHeroInfo.Size = new System.Drawing.Size(0, 13);
            this.labelHeroInfo.TabIndex = 1;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(554, 24);
            this.labelHelp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(0, 13);
            this.labelHelp.TabIndex = 2;
            // 
            // RPGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(736, 303);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelHeroInfo);
            this.Controls.Add(this.textBoxLog);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RPGForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Finding Treasure";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RPGForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxLog;
        public System.Windows.Forms.Label labelHeroInfo;
        public System.Windows.Forms.Label labelHelp;


    }
}

