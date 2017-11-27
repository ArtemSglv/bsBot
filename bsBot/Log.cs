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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }
        public void printLog(string str)
        {
            richTextBoxLog.Text += str;
            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength ;
            richTextBoxLog.ScrollToCaret();
        }

        
    }
}
