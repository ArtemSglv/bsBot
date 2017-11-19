using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bsBot
{
    public partial class Keys : Form
    {
        public Keys()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!textBoxKey.Text.Equals(string.Empty) && !textBoxSecret.Text.Equals(string.Empty))
            {
                Bot.currentExchange.Key = textBoxKey.Text;
                Bot.currentExchange.Secret = textBoxSecret.Text;
                new Thread(delegate() { MessageBox.Show(Bot.GetInfo()); }).Start();
                new Settings().ShowDialog();
            }
        }
    }
}
