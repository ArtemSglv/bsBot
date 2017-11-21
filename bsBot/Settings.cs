using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bsBot
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }        

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBoxMarkets.Items.AddRange(Bot.currentExchange.AvailableMarkets.ToArray());
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            if (comboBoxMarkets.SelectedIndex!=-1 && Controls.OfType<TextBox>().All(tb=> { return tb.Text != string.Empty; }))
            {
                Bot.currentMarket = comboBoxMarkets.SelectedItem.ToString();

                Bot.orderLimit.min = double.Parse(textBoxMinOrder.Text);
                Bot.orderLimit.max = double.Parse(textBoxMaxOrder.Text);

                Bot.timeout.min = int.Parse(textBoxMinTimeout.Text);
                Bot.timeout.max = int.Parse(textBoxMaxTimeout.Text);

                Bot.StartTrade();
            }
                
        }
    }
}
