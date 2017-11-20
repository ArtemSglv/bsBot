namespace bsBot
{
    partial class choiceExchange
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
            this.comboWithExchange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboWithExchange
            // 
            this.comboWithExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboWithExchange.FormattingEnabled = true;
            this.comboWithExchange.Location = new System.Drawing.Point(47, 43);
            this.comboWithExchange.Name = "comboWithExchange";
            this.comboWithExchange.Size = new System.Drawing.Size(164, 28);
            this.comboWithExchange.TabIndex = 0;
            this.comboWithExchange.SelectedIndexChanged += new System.EventHandler(this.comboWithExchange_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите биржу:";
            // 
            // choiceExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 85);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboWithExchange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "choiceExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор биржы";
            this.Load += new System.EventHandler(this.choiceExchange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboWithExchange;
        private System.Windows.Forms.Label label1;
    }
}

