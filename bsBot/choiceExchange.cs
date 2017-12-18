using System;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Media;

namespace bsBot
{
    public partial class choiceExchange : Form
    {
        private const string Title = "Trade Bot [Готово]";
        Thread trd_markets = null;

        public choiceExchange()
        {
            InitializeComponent();
        }

        private void choiceExchange_Load(object sender, EventArgs e)
        {
            Text = Title;
            radioButOnlyBuy.CheckedChanged += radioButTypeOper_CheckedChanged;
            radioButOnlySell.CheckedChanged += radioButTypeOper_CheckedChanged;
            radioButRandOper.CheckedChanged += radioButTypeOper_CheckedChanged;

            radioButDynamicSpread.CheckedChanged += radioButSpread_CheckedChanged;
            radioButMinSpread.CheckedChanged += radioButSpread_CheckedChanged;
            radioButManualSpread.CheckedChanged += radioButSpread_CheckedChanged;

            groupKeys.Enabled = false;
            groupSettings.Enabled = false;
            comboWithExchange.Items.AddRange(new[] { "yobit.net", "cryptopia.co.nz" });
            Bot.mainForm = this;
            Focus();
        }

        private void comboWithExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!groupKeys.Enabled)
                groupKeys.Enabled = true;

            switch (comboWithExchange.SelectedItem.ToString())
            {
                case "yobit.net": { Bot.currentExchange = new ExYobit(); break; }
                case "cryptopia.co.nz": { Bot.currentExchange = new ExCryptopia(); break; }
            }

            // загрузка доступных маркетов в отдельном потоке
            if (trd_markets != null && trd_markets.IsAlive)
                trd_markets.Abort();
            trd_markets = new Thread(delegate () { GetMarketsInOtherThread(); })
            {
                Name = "Download markets",
                IsBackground = true
            };
            trd_markets.Start();

            //trd.Join();


        }
        private void EditTextForm(string add_title)
        {
            if (!add_title.Equals(string.Empty))
                Text = Text.Replace("Готово", add_title);
            else
                Text = Title;
        }
        public void ChangeTitle(string add_title = "")
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    EditTextForm(add_title);
                }));
            else
            {
                EditTextForm(add_title);
            }

        }

        private void GetMarketsInOtherThread()
        {

            ChangeTitle("Загрузка доступных маркетов...");
            try { Bot.GetMarkets(); }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Проверьте подключение к Интернету");
                Application.Exit();
                return;
            }
            ChangeTitle();

            Invoke(new Action(() =>
            {
                comboBoxMarkets.Items.Clear();
                comboBoxMarkets.Items.AddRange(Bot.currentExchange.AvailableMarkets.ToArray());

                // set enable groupSettings
                //groupKeys.Enabled = true;
                groupSettings.Enabled = true;
            }));
        }

        private void GetBalanceInOtherThread()
        {

            //Bot.getBalanceMutex.WaitOne();
            ChangeTitle("Загрузка баланса...");
            try
            {
                Bot.GetStartBalance();
            }
            catch (WebException wex)
            {
                //MessageBox.Show(wex.Message);
                printLog(DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + wex.Message + "\n");
                //Application.Exit();
                //return;
            }

            ChangeTitle();
            //Bot.getBalanceMutex.ReleaseMutex();

        }

        private void butStart_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text != "" && textBoxSecret.Text != "")
            {
                Bot.currentExchange.Key = textBoxKey.Text;
                Bot.currentExchange.Secret = textBoxSecret.Text;

                Thread trd = new Thread(delegate () { GetBalanceInOtherThread(); });
                trd.Name = "Get Balance";
                trd.IsBackground = true;
                trd.Start();


                if (comboBoxMarkets.SelectedIndex != -1 && Controls.OfType<TextBox>().All(tb => { return tb.Text != string.Empty; }))
                {
                    Bot.currentMarket = comboBoxMarkets.SelectedItem.ToString();

                    Bot.orderLimit.min = double.Parse(textBoxMinOrder.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    Bot.orderLimit.max = double.Parse(textBoxMaxOrder.Text.Replace(",", "."), CultureInfo.InvariantCulture);

                    Bot.timeout.min = int.Parse(textBoxMinTimeout.Text) * 1000;
                    Bot.timeout.max = int.Parse(textBoxMaxTimeout.Text) * 1000;

                    double.TryParse(textBoxMaxDiffBalance.Text.Replace(",", "."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out Bot.MaxDiffBalance);

                    Bot.StartTrade(trd);
                    BotStatus(true);
                }
            }

        }

        private void butStop_Click(object sender, EventArgs e)
        {
            BotStatus(false);
            Bot.StopTrade();
        }

        private void print(string str)
        {
            richTextBoxLog.Text += str;
            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
            richTextBoxLog.ScrollToCaret();
        }
        public void printLog(string str)
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    print(str);
                }));
            else
            {
                print(str);
            }

        }
        private void ChangeStatus(Color color, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    IsStartedLabel.BackColor = color;
                    IsStartedLabel.Text = status;
                }));
            }
            else
            {
                IsStartedLabel.BackColor = color;
                IsStartedLabel.Text = status;
            }
        }
        public void BotStatus(bool IsStarted)
        {
            if (IsStarted)
            {
                ChangeStatus(Color.LawnGreen, "Запущен");
            }
            else
            {
                ChangeStatus(Color.IndianRed, "Остановлен");
            }
        }
        public void Notify()
        {
            if (checkSoundNotify.Checked)
            {
                SoundPlayer player = new SoundPlayer("notify.wav");
                player.Play();
            }
            new BalanceError().ShowDialog();
            Focus();
        }

        private void radioButTypeOper_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch (Convert.ToInt16(radioButton.Tag))
                {
                    case 0: { Bot.botTypeOper = TypeOper.Buy; break; }
                    case 1: { Bot.botTypeOper = TypeOper.Sell; break; }
                    case 2: { Bot.botTypeOper = TypeOper.Random; break; }
                }
            }
        }
        private void radioButSpread_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch (Convert.ToInt16(radioButton.Tag))
                {
                    case 0: { Bot.botTypeSpread = TypeSpread.Min; break; }
                    case 1: { Bot.botTypeSpread = TypeSpread.Manual; break; }
                    case 2: { Bot.botTypeSpread = TypeSpread.Dynamic; break; }
                }
            }
        }
    }
}
