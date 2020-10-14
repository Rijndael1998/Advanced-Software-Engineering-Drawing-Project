using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {
    public partial class Text_Editor : Form {
        const string DefaultTitleString = "Advanced Software Engineering - Text Editor ";

        Draw_Preview DisplayForm = null;

        /// <summary>
        /// The text editor is the main window that the user will be using for writing code. 
        /// </summary>
        public Text_Editor() {
            SettingsAndHelperFunctions.NumberOfWindows++;
            InitializeComponent();
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e) {
            SettingsAndHelperFunctions.WindowClosed();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) {
            new Text_Editor().Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            new About_Window().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            if(DisplayForm == null) {
                DisplayForm = new Draw_Preview(textBox1.Text);
            } else {
                Console.WriteLine("Removed all commands");
                DisplayForm.RemoveAllCommands();
                DisplayForm.SubmitCommands(textBox1.Text);
            }
            DisplayForm.Show();
            DisplayForm.Focus();
        }
    }
}
