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
        const string DefaultTitleString = "Advanced Software Engineering - Text Editor ";

        /// <summary>
        /// The text editor is the main window that the user will be using for writing code. 
        /// </summary>
        public Text_Editor()
        {
            SettingsAndHelperFunctions.NumberOfWindows++;
            InitializeComponent();
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Text_Editor().Show();
        }
    }
}
