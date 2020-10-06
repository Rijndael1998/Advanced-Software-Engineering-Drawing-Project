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
    public partial class About_Window : Form
    {
        public About_Window()
        {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
        }

        private void About_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }
    }
}
