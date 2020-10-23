using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {
    public partial class Text_Editor : Form {
        const string DefaultTitleString = "ASE - Text Editor";

        Draw_Preview DisplayForm = null;
        bool unsavedChanges = false;
        bool newWindow = true;
        bool okToOverwrite = false;
        string fileName = "";

        /// <summary>
        /// The text editor is the main window that the user will be using for writing code. 
        /// </summary>
        public Text_Editor() {
            SettingsAndHelperFunctions.NumberOfWindows++;
            InitializeComponent();
        }

        public Text_Editor(OpenFileDialog openFile) {
            SettingsAndHelperFunctions.NumberOfWindows++;
            InitializeComponent();
            StreamReader fileStream = new StreamReader(openFile.OpenFile());
            textBox1.Text = fileStream.ReadToEnd();
            UpdateTitle(openFile.FileName);
        }

        void UpdateTitle(string fileName) {
            this.fileName = fileName;
            UpdateTitle();
        }

        void UpdateTitle() {
            this.Text = DefaultTitleString + " - " + fileName;
            if (unsavedChanges) this.Text = "* " + this.Text + " *";
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e) {
            if (DisplayForm != null && !DisplayForm.IsDisposed) DisplayForm.ReleaseCommandLock();
            SettingsAndHelperFunctions.WindowClosed();
            Dispose();
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
            if(DisplayForm == null || DisplayForm.IsDisposed) {
                DisplayForm = new Draw_Preview(textBox1.Text);
            } else {
                Console.WriteLine("Removed all commands");
                DisplayForm.RemoveAllCommands();
                DisplayForm.SubmitCommands(textBox1.Text);
            }
            DisplayForm.Show();
            DisplayForm.Focus();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK) {

                if (newWindow) {
                    StreamReader fileStream = new StreamReader(openFileDialog.OpenFile());
                    textBox1.Text = fileStream.ReadToEnd();
                    UpdateTitle(openFileDialog.FileName);
                } else new Text_Editor(openFileDialog).Show();
            }

        }
    }
}
