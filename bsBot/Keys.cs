using System;
using System.Net;
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
                new Thread(delegate() { try { Bot.GetInfo(); } catch (WebException wex) { MessageBox.Show(wex.Message); Application.Exit(); } }).Start();
                new Settings().Show();
                Close();
            }
        }

        private void Keys_Load(object sender, EventArgs e)
        {
            Focus();
        }
    }
}
