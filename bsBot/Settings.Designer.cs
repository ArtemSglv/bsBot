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
            this.comboBoxMarkets = new System.Windows.Forms.ComboBox();
            this.labelMarkets = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
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
            this.butStart.Location = new System.Drawing.Point(246, 212);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(111, 37);
            this.butStart.TabIndex = 2;
            this.butStart.Text = "Начать";
            this.butStart.UseVisualStyleBackColor = true;
            // 
            // butStop
            // 
            this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStop.Location = new System.Drawing.Point(12, 212);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(124, 37);
            this.butStop.TabIndex = 3;
            this.butStop.Text = "Остановить";
            this.butStop.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 261);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.labelMarkets);
            this.Controls.Add(this.comboBoxMarkets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}