namespace bsBot
{
    partial class MaxPriceOffset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaxPriceOffset));
            this.labelMaxOffset = new System.Windows.Forms.Label();
            this.textBoxMaxOffset = new System.Windows.Forms.TextBox();
            this.butMaxOffset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMaxOffset
            // 
            this.labelMaxOffset.AutoSize = true;
            this.labelMaxOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxOffset.Location = new System.Drawing.Point(12, 9);
            this.labelMaxOffset.Name = "labelMaxOffset";
            this.labelMaxOffset.Size = new System.Drawing.Size(170, 40);
            this.labelMaxOffset.TabIndex = 0;
            this.labelMaxOffset.Text = "Введите максимум\r\nизменения цены";
            // 
            // textBoxMaxOffset
            // 
            this.textBoxMaxOffset.Location = new System.Drawing.Point(202, 22);
            this.textBoxMaxOffset.Name = "textBoxMaxOffset";
            this.textBoxMaxOffset.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxOffset.TabIndex = 1;
            // 
            // butMaxOffset
            // 
            this.butMaxOffset.Location = new System.Drawing.Point(92, 52);
            this.butMaxOffset.Name = "butMaxOffset";
            this.butMaxOffset.Size = new System.Drawing.Size(118, 38);
            this.butMaxOffset.TabIndex = 2;
            this.butMaxOffset.Text = "Установить";
            this.butMaxOffset.UseVisualStyleBackColor = true;
            this.butMaxOffset.Click += new System.EventHandler(this.butMaxOffset_Click);
            // 
            // RangeSpread
            // 
            this.AcceptButton = this.butMaxOffset;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 94);
            this.Controls.Add(this.butMaxOffset);
            this.Controls.Add(this.textBoxMaxOffset);
            this.Controls.Add(this.labelMaxOffset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RangeSpread";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Max изменение цены";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMaxOffset;
        private System.Windows.Forms.TextBox textBoxMaxOffset;
        private System.Windows.Forms.Button butMaxOffset;
    }
}