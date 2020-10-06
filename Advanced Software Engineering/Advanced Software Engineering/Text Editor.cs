using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    public partial class Text_Editor : Form
    {
        public Text_Editor()
        {
            InitializeComponent();
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Text editor here
        }
    }
}
