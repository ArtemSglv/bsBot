namespace bsBot
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.comboBoxMarkets = new System.Windows.Forms.ComboBox();
            this.labelMarkets = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.labelOrderLimit = new System.Windows.Forms.Label();
            this.labelMinOrder = new System.Windows.Forms.Label();
            this.labelMaxOrder = new System.Windows.Forms.Label();
            this.textBoxMinOrder = new System.Windows.Forms.TextBox();
            this.textBoxMaxOrder = new System.Windows.Forms.TextBox();
            this.textBoxMinTimeout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.textBoxMaxTimeout = new System.Windows.Forms.TextBox();
            this.IsStartedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMarkets
            // 
            this.comboBoxMarkets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxMarkets.FormattingEnabled = true;
            this.comboBoxMarkets.Location = new System.Drawing.Point(12, 37);
            this.comboBoxMarkets.Name = "comboBoxMarkets";
            this.comboBoxMarkets.Size = new System.Drawing.Size(134, 28);
            this.comboBoxMarkets.TabIndex = 0;
            // 
            // labelMarkets
            // 
            this.labelMarkets.AutoSize = true;
            this.labelMarkets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMarkets.Location = new System.Drawing.Point(8, 14);
            this.labelMarkets.Name = "labelMarkets";
            this.labelMarkets.Size = new System.Drawing.Size(141, 20);
            this.labelMarkets.TabIndex = 1;
            this.labelMarkets.Text = "Выберите пару:";
            // 
            // butStart
            // 
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStart.Location = new System.Drawing.Point(246, 276);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(111, 37);
            this.butStart.TabIndex = 5;
            this.butStart.Text = "Начать";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butStop
            // 
            this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStop.Location = new System.Drawing.Point(12, 276);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(137, 37);
            this.butStop.TabIndex = 6;
            this.butStop.Text = "Остановить";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // labelOrderLimit
            // 
            this.labelOrderLimit.AutoSize = true;
            this.labelOrderLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOrderLimit.Location = new System.Drawing.Point(8, 76);
            this.labelOrderLimit.Name = "labelOrderLimit";
            this.labelOrderLimit.Size = new System.Drawing.Size(230, 20);
            this.labelOrderLimit.TabIndex = 4;
            this.labelOrderLimit.Text = "Введите границы ордера:";
            // 
            // labelMinOrder
            // 
            this.labelMinOrder.AutoSize = true;
            this.labelMinOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinOrder.Location = new System.Drawing.Point(8, 106);
            this.labelMinOrder.Name = "labelMinOrder";
            this.labelMinOrder.Size = new System.Drawing.Size(46, 20);
            this.labelMinOrder.TabIndex = 5;
            this.labelMinOrder.Text = "мин:";
            // 
            // labelMaxOrder
            // 
            this.labelMaxOrder.AutoSize = true;
            this.labelMaxOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxOrder.Location = new System.Drawing.Point(177, 106);
            this.labelMaxOrder.Name = "labelMaxOrder";
            this.labelMaxOrder.Size = new System.Drawing.Size(54, 20);
            this.labelMaxOrder.TabIndex = 6;
            this.labelMaxOrder.Text = "макс:";
            // 
            // textBoxMinOrder
            // 
            this.textBoxMinOrder.Location = new System.Drawing.Point(60, 106);
            this.textBoxMinOrder.Name = "textBoxMinOrder";
            this.textBoxMinOrder.Size = new System.Drawing.Size(113, 22);
            this.textBoxMinOrder.TabIndex = 1;
            // 
            // textBoxMaxOrder
            // 
            this.textBoxMaxOrder.Location = new System.Drawing.Point(237, 106);
            this.textBoxMaxOrder.Name = "textBoxMaxOrder";
            this.textBoxMaxOrder.Size = new System.Drawing.Size(113, 22);
            this.textBoxMaxOrder.TabIndex = 2;
            // 
            // textBoxMinTimeout
            // 
            this.textBoxMinTimeout.Location = new System.Drawing.Point(60, 190);
            this.textBoxMinTimeout.Name = "textBoxMinTimeout";
            this.textBoxMinTimeout.Size = new System.Drawing.Size(38, 22);
            this.textBoxMinTimeout.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(109, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "макс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "мин:";
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeout.Location = new System.Drawing.Point(8, 141);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(220, 40);
            this.labelTimeout.TabIndex = 9;
            this.labelTimeout.Text = "Введите интервал\r\nмежду операциями (сек):";
            // 
            // textBoxMaxTimeout
            // 
            this.textBoxMaxTimeout.Location = new System.Drawing.Point(169, 190);
            this.textBoxMaxTimeout.Name = "textBoxMaxTimeout";
            this.textBoxMaxTimeout.Size = new System.Drawing.Size(38, 22);
            this.textBoxMaxTimeout.TabIndex = 4;
            // 
            // IsStartedLabel
            // 
            this.IsStartedLabel.AutoSize = true;
            this.IsStartedLabel.BackColor = System.Drawing.Color.IndianRed;
            this.IsStartedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsStartedLabel.Location = new System.Drawing.Point(246, 9);
            this.IsStartedLabel.Name = "IsStartedLabel";
            this.IsStartedLabel.Size = new System.Drawing.Size(111, 20);
            this.IsStartedLabel.TabIndex = 12;
            this.IsStartedLabel.Text = "Остановлен";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 324);
            this.Controls.Add(this.IsStartedLabel);
            this.Controls.Add(this.textBoxMaxTimeout);
            this.Controls.Add(this.textBoxMinTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTimeout);
            this.Controls.Add(this.textBoxMaxOrder);
            this.Controls.Add(this.textBoxMinOrder);
            this.Controls.Add(this.labelMaxOrder);
            this.Controls.Add(this.labelMinOrder);
            this.Controls.Add(this.labelOrderLimit);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.labelMarkets);
            this.Controls.Add(this.comboBoxMarkets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMarkets;
        private System.Windows.Forms.Label labelMarkets;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Label labelOrderLimit;
        private System.Windows.Forms.Label labelMinOrder;
        private System.Windows.Forms.Label labelMaxOrder;
        private System.Windows.Forms.TextBox textBoxMinOrder;
        private System.Windows.Forms.TextBox textBoxMaxOrder;
        private System.Windows.Forms.TextBox textBoxMinTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.TextBox textBoxMaxTimeout;
        private System.Windows.Forms.Label IsStartedLabel;
    }
}