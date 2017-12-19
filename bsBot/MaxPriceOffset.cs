using System;
using System.Windows.Forms;
using System.Globalization;

namespace bsBot
{
    public partial class MaxPriceOffset : Form
    {
        public MaxPriceOffset()
        {
            InitializeComponent();
        }

        private void butMaxOffset_Click(object sender, EventArgs e)
        {
            if (textBoxMaxOffset.Text != "")
                Bot.MaxPriceOffset = double.Parse(textBoxMaxOffset.Text.Replace(",", "."), CultureInfo.InvariantCulture);
            Close();
        }
    }
}
