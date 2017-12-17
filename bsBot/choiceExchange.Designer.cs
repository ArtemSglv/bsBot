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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choiceExchange));
            this.comboWithExchange = new System.Windows.Forms.ComboBox();
            this.labelSelectExchange = new System.Windows.Forms.Label();
            this.groupChoiceExchange = new System.Windows.Forms.GroupBox();
            this.groupKeys = new System.Windows.Forms.GroupBox();
            this.textBoxSecret = new System.Windows.Forms.TextBox();
            this.labelSecret = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.IsStartedLabel = new System.Windows.Forms.Label();
            this.textBoxMaxTimeout = new System.Windows.Forms.TextBox();
            this.textBoxMinTimeout = new System.Windows.Forms.TextBox();
            this.labelTimeMax = new System.Windows.Forms.Label();
            this.labelTimeMin = new System.Windows.Forms.Label();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.textBoxMaxOrder = new System.Windows.Forms.TextBox();
            this.textBoxMinOrder = new System.Windows.Forms.TextBox();
            this.labelMaxOrder = new System.Windows.Forms.Label();
            this.labelMinOrder = new System.Windows.Forms.Label();
            this.labelOrderLimit = new System.Windows.Forms.Label();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.labelMarkets = new System.Windows.Forms.Label();
            this.comboBoxMarkets = new System.Windows.Forms.ComboBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.textBoxMaxDiffBalance = new System.Windows.Forms.TextBox();
            this.labelMaxDiffBalance = new System.Windows.Forms.Label();
            this.groupLogic = new System.Windows.Forms.GroupBox();
            this.radioButOnlyBuy = new System.Windows.Forms.RadioButton();
            this.radioButOnlySell = new System.Windows.Forms.RadioButton();
            this.radioButRandLogic = new System.Windows.Forms.RadioButton();
            this.groupChoiceExchange.SuspendLayout();
            this.groupKeys.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.groupLogic.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboWithExchange
            // 
            this.comboWithExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboWithExchange.FormattingEnabled = true;
            this.comboWithExchange.Location = new System.Drawing.Point(16, 33);
            this.comboWithExchange.Name = "comboWithExchange";
            this.comboWithExchange.Size = new System.Drawing.Size(302, 28);
            this.comboWithExchange.TabIndex = 0;
            this.comboWithExchange.SelectedIndexChanged += new System.EventHandler(this.comboWithExchange_SelectedIndexChanged);
            // 
            // labelSelectExchange
            // 
            this.labelSelectExchange.AutoSize = true;
            this.labelSelectExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectExchange.Location = new System.Drawing.Point(3, 10);
            this.labelSelectExchange.Name = "labelSelectExchange";
            this.labelSelectExchange.Size = new System.Drawing.Size(153, 20);
            this.labelSelectExchange.TabIndex = 1;
            this.labelSelectExchange.Text = "Выберите биржу:";
            // 
            // groupChoiceExchange
            // 
            this.groupChoiceExchange.Controls.Add(this.labelSelectExchange);
            this.groupChoiceExchange.Controls.Add(this.comboWithExchange);
            this.groupChoiceExchange.Location = new System.Drawing.Point(12, 12);
            this.groupChoiceExchange.Name = "groupChoiceExchange";
            this.groupChoiceExchange.Size = new System.Drawing.Size(332, 68);
            this.groupChoiceExchange.TabIndex = 2;
            this.groupChoiceExchange.TabStop = false;
            // 
            // groupKeys
            // 
            this.groupKeys.Controls.Add(this.textBoxSecret);
            this.groupKeys.Controls.Add(this.labelSecret);
            this.groupKeys.Controls.Add(this.textBoxKey);
            this.groupKeys.Controls.Add(this.labelKey);
            this.groupKeys.Location = new System.Drawing.Point(12, 82);
            this.groupKeys.Name = "groupKeys";
            this.groupKeys.Size = new System.Drawing.Size(332, 167);
            this.groupKeys.TabIndex = 3;
            this.groupKeys.TabStop = false;
            // 
            // textBoxSecret
            // 
            this.textBoxSecret.Location = new System.Drawing.Point(16, 119);
            this.textBoxSecret.Name = "textBoxSecret";
            this.textBoxSecret.Size = new System.Drawing.Size(302, 22);
            this.textBoxSecret.TabIndex = 1;
            this.textBoxSecret.Text = "a3b9830e85af2ab6ccbcb25233785e75";
            this.textBoxSecret.TextChanged += new System.EventHandler(this.textBoxSecret_TextChanged);
            // 
            // labelSecret
            // 
            this.labelSecret.AutoSize = true;
            this.labelSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSecret.Location = new System.Drawing.Point(12, 96);
            this.labelSecret.Name = "labelSecret";
            this.labelSecret.Size = new System.Drawing.Size(208, 20);
            this.labelSecret.TabIndex = 2;
            this.labelSecret.Text = "Введите секрет ключа:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(16, 44);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(302, 22);
            this.textBoxKey.TabIndex = 0;
            this.textBoxKey.Text = "8FB2D862C2FAAAA6259CFA79D5F15649";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKey.Location = new System.Drawing.Point(12, 21);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(135, 20);
            this.labelKey.TabIndex = 0;
            this.labelKey.Text = "Введите ключ:";
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.groupLogic);
            this.groupSettings.Controls.Add(this.textBoxMaxDiffBalance);
            this.groupSettings.Controls.Add(this.labelMaxDiffBalance);
            this.groupSettings.Controls.Add(this.IsStartedLabel);
            this.groupSettings.Controls.Add(this.textBoxMaxTimeout);
            this.groupSettings.Controls.Add(this.textBoxMinTimeout);
            this.groupSettings.Controls.Add(this.labelTimeMax);
            this.groupSettings.Controls.Add(this.labelTimeMin);
            this.groupSettings.Controls.Add(this.labelTimeout);
            this.groupSettings.Controls.Add(this.textBoxMaxOrder);
            this.groupSettings.Controls.Add(this.textBoxMinOrder);
            this.groupSettings.Controls.Add(this.labelMaxOrder);
            this.groupSettings.Controls.Add(this.labelMinOrder);
            this.groupSettings.Controls.Add(this.labelOrderLimit);
            this.groupSettings.Controls.Add(this.butStop);
            this.groupSettings.Controls.Add(this.butStart);
            this.groupSettings.Controls.Add(this.labelMarkets);
            this.groupSettings.Controls.Add(this.comboBoxMarkets);
            this.groupSettings.Location = new System.Drawing.Point(350, 12);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(700, 237);
            this.groupSettings.TabIndex = 4;
            this.groupSettings.TabStop = false;
            // 
            // IsStartedLabel
            // 
            this.IsStartedLabel.AutoSize = true;
            this.IsStartedLabel.BackColor = System.Drawing.Color.IndianRed;
            this.IsStartedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsStartedLabel.Location = new System.Drawing.Point(563, 14);
            this.IsStartedLabel.Name = "IsStartedLabel";
            this.IsStartedLabel.Size = new System.Drawing.Size(111, 20);
            this.IsStartedLabel.TabIndex = 12;
            this.IsStartedLabel.Text = "Остановлен";
            // 
            // textBoxMaxTimeout
            // 
            this.textBoxMaxTimeout.Location = new System.Drawing.Point(169, 190);
            this.textBoxMaxTimeout.Name = "textBoxMaxTimeout";
            this.textBoxMaxTimeout.Size = new System.Drawing.Size(38, 22);
            this.textBoxMaxTimeout.TabIndex = 4;
            this.textBoxMaxTimeout.Text = "15";
            // 
            // textBoxMinTimeout
            // 
            this.textBoxMinTimeout.Location = new System.Drawing.Point(60, 190);
            this.textBoxMinTimeout.Name = "textBoxMinTimeout";
            this.textBoxMinTimeout.Size = new System.Drawing.Size(38, 22);
            this.textBoxMinTimeout.TabIndex = 3;
            this.textBoxMinTimeout.Text = "12";
            // 
            // labelTimeMax
            // 
            this.labelTimeMax.AutoSize = true;
            this.labelTimeMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeMax.Location = new System.Drawing.Point(109, 190);
            this.labelTimeMax.Name = "labelTimeMax";
            this.labelTimeMax.Size = new System.Drawing.Size(54, 20);
            this.labelTimeMax.TabIndex = 11;
            this.labelTimeMax.Text = "макс:";
            // 
            // labelTimeMin
            // 
            this.labelTimeMin.AutoSize = true;
            this.labelTimeMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeMin.Location = new System.Drawing.Point(8, 190);
            this.labelTimeMin.Name = "labelTimeMin";
            this.labelTimeMin.Size = new System.Drawing.Size(46, 20);
            this.labelTimeMin.TabIndex = 10;
            this.labelTimeMin.Text = "мин:";
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
            // textBoxMaxOrder
            // 
            this.textBoxMaxOrder.Location = new System.Drawing.Point(183, 106);
            this.textBoxMaxOrder.Name = "textBoxMaxOrder";
            this.textBoxMaxOrder.Size = new System.Drawing.Size(55, 22);
            this.textBoxMaxOrder.TabIndex = 2;
            this.textBoxMaxOrder.Text = "30000";
            // 
            // textBoxMinOrder
            // 
            this.textBoxMinOrder.Location = new System.Drawing.Point(60, 106);
            this.textBoxMinOrder.Name = "textBoxMinOrder";
            this.textBoxMinOrder.Size = new System.Drawing.Size(55, 22);
            this.textBoxMinOrder.TabIndex = 1;
            this.textBoxMinOrder.Text = "20000";
            // 
            // labelMaxOrder
            // 
            this.labelMaxOrder.AutoSize = true;
            this.labelMaxOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxOrder.Location = new System.Drawing.Point(123, 106);
            this.labelMaxOrder.Name = "labelMaxOrder";
            this.labelMaxOrder.Size = new System.Drawing.Size(54, 20);
            this.labelMaxOrder.TabIndex = 6;
            this.labelMaxOrder.Text = "макс:";
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
            // butStop
            // 
            this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStop.Location = new System.Drawing.Point(555, 133);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(130, 37);
            this.butStop.TabIndex = 6;
            this.butStop.Text = "Остановить";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butStart
            // 
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStart.Location = new System.Drawing.Point(555, 83);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(130, 37);
            this.butStart.TabIndex = 5;
            this.butStart.Text = "Начать";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
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
            // comboBoxMarkets
            // 
            this.comboBoxMarkets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxMarkets.FormattingEnabled = true;
            this.comboBoxMarkets.Location = new System.Drawing.Point(12, 37);
            this.comboBoxMarkets.Name = "comboBoxMarkets";
            this.comboBoxMarkets.Size = new System.Drawing.Size(134, 28);
            this.comboBoxMarkets.TabIndex = 0;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 22);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1035, 166);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.richTextBoxLog);
            this.groupLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupLog.Location = new System.Drawing.Point(12, 250);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(1041, 191);
            this.groupLog.TabIndex = 5;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Статистика";
            // 
            // textBoxMaxDiffBalance
            // 
            this.textBoxMaxDiffBalance.Location = new System.Drawing.Point(350, 36);
            this.textBoxMaxDiffBalance.Name = "textBoxMaxDiffBalance";
            this.textBoxMaxDiffBalance.Size = new System.Drawing.Size(85, 22);
            this.textBoxMaxDiffBalance.TabIndex = 13;
            // 
            // labelMaxDiffBalance
            // 
            this.labelMaxDiffBalance.AutoSize = true;
            this.labelMaxDiffBalance.BackColor = System.Drawing.Color.Transparent;
            this.labelMaxDiffBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxDiffBalance.Location = new System.Drawing.Point(265, 14);
            this.labelMaxDiffBalance.Name = "labelMaxDiffBalance";
            this.labelMaxDiffBalance.Size = new System.Drawing.Size(170, 40);
            this.labelMaxDiffBalance.TabIndex = 14;
            this.labelMaxDiffBalance.Text = "Предел изменения\r\nбаланса:";
            // 
            // groupLogic
            // 
            this.groupLogic.Controls.Add(this.radioButRandLogic);
            this.groupLogic.Controls.Add(this.radioButOnlySell);
            this.groupLogic.Controls.Add(this.radioButOnlyBuy);
            this.groupLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupLogic.Location = new System.Drawing.Point(269, 76);
            this.groupLogic.Name = "groupLogic";
            this.groupLogic.Size = new System.Drawing.Size(200, 116);
            this.groupLogic.TabIndex = 15;
            this.groupLogic.TabStop = false;
            this.groupLogic.Text = "Логика";
            // 
            // radioButOnlyBuy
            // 
            this.radioButOnlyBuy.AutoSize = true;
            this.radioButOnlyBuy.Location = new System.Drawing.Point(13, 26);
            this.radioButOnlyBuy.Name = "radioButOnlyBuy";
            this.radioButOnlyBuy.Size = new System.Drawing.Size(99, 24);
            this.radioButOnlyBuy.TabIndex = 0;
            this.radioButOnlyBuy.Tag = "0";
            this.radioButOnlyBuy.Text = "Покупка";
            this.radioButOnlyBuy.UseVisualStyleBackColor = true;
            // 
            // radioButOnlySell
            // 
            this.radioButOnlySell.AutoSize = true;
            this.radioButOnlySell.Location = new System.Drawing.Point(13, 56);
            this.radioButOnlySell.Name = "radioButOnlySell";
            this.radioButOnlySell.Size = new System.Drawing.Size(107, 24);
            this.radioButOnlySell.TabIndex = 1;
            this.radioButOnlySell.Tag = "1";
            this.radioButOnlySell.Text = "Продажа";
            this.radioButOnlySell.UseVisualStyleBackColor = true;
            // 
            // radioButRandLogic
            // 
            this.radioButRandLogic.AutoSize = true;
            this.radioButRandLogic.Checked = true;
            this.radioButRandLogic.Location = new System.Drawing.Point(13, 86);
            this.radioButRandLogic.Name = "radioButRandLogic";
            this.radioButRandLogic.Size = new System.Drawing.Size(178, 24);
            this.radioButRandLogic.TabIndex = 2;
            this.radioButRandLogic.TabStop = true;
            this.radioButRandLogic.Tag = "2";
            this.radioButRandLogic.Text = "Покупка/продажа";
            this.radioButRandLogic.UseVisualStyleBackColor = true;
            // 
            // choiceExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 453);
            this.Controls.Add(this.groupLog);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.groupKeys);
            this.Controls.Add(this.groupChoiceExchange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "choiceExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trade Bot";
            this.Load += new System.EventHandler(this.choiceExchange_Load);
            this.groupChoiceExchange.ResumeLayout(false);
            this.groupChoiceExchange.PerformLayout();
            this.groupKeys.ResumeLayout(false);
            this.groupKeys.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.groupLog.ResumeLayout(false);
            this.groupLogic.ResumeLayout(false);
            this.groupLogic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboWithExchange;
        private System.Windows.Forms.Label labelSelectExchange;
        private System.Windows.Forms.GroupBox groupChoiceExchange;
        private System.Windows.Forms.GroupBox groupKeys;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxSecret;
        private System.Windows.Forms.Label labelSecret;
        private System.Windows.Forms.GroupBox groupSettings;
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
        private System.Windows.Forms.Label labelTimeMax;
        private System.Windows.Forms.Label labelTimeMin;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.TextBox textBoxMaxTimeout;
        private System.Windows.Forms.Label IsStartedLabel;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.TextBox textBoxMaxDiffBalance;
        private System.Windows.Forms.Label labelMaxDiffBalance;
        private System.Windows.Forms.GroupBox groupLogic;
        private System.Windows.Forms.RadioButton radioButRandLogic;
        private System.Windows.Forms.RadioButton radioButOnlySell;
        private System.Windows.Forms.RadioButton radioButOnlyBuy;
    }
}

