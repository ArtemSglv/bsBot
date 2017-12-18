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
    public partial class BalanceError : Form
    {
        public BalanceError()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hide();
            Close();
        }

        private void BalanceError_Load(object sender, EventArgs e)
        {
            //Focus();
        }

        private void BalanceError_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel=true;
            //Hide();
        }
    }
}
