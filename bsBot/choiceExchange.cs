﻿using System;
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
            switch (comboWithExchange.SelectedItem.ToString())
            {
                case "yobit.net": { Bot.currentExchange = new ExYobit(); break; }
                case "cryptopia.co.nz": { Bot.currentExchange = new ExCryptopia(); break; }
                    //case "yobit.net": { Bot.currentExchange = new ExYobit(); break; }
            }
            // загрузка доступных маркетов в отдельном потоке
            Thread trd = new Thread(delegate ()
            {
                try { Bot.GetMarkets(); }
                catch (System.Net.WebException ex)
                {
                    MessageBox.Show(ex.Message + "\n" + "Проверьте подключение к Интернету");                    
                    Application.Exit();
                }
            });
            trd.Start();
            trd.Join();

            // запуск формы ввода ключей
            new Keys().Show();

            // close this form
            //Close();
        }

        private void choiceExchange_Load(object sender, EventArgs e)
        {
            comboWithExchange.Items.AddRange(new[] { "yobit.net", "cryptopia.co.nz"/*, "coinexchange.io"*/ });
            Focus();
        }
    }
}
