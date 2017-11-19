using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace bsBot
{
    public partial class choiceExchange : Form
    {
        public choiceExchange()
        {
            InitializeComponent();            
        }

        private void comboWithExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            // загрузка доступных маркетов в отдельном потоке
            new Thread(delegate () {  }).Start();

            // запуск формы настроек
            new Settings().ShowDialog();
        }

        private void choiceExchange_Load(object sender, EventArgs e)
        {
            comboWithExchange.Items.AddRange(new[] { "yobit.net", "cryptopia.co.nz", "coinexchange.io" });
            Focus();
        }
    }
}
