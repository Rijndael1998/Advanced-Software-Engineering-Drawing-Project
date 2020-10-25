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
            UpdateTitle();
        }

        public Text_Editor(OpenFileDialog openFile) {
            SettingsAndHelperFunctions.NumberOfWindows++;
            InitializeComponent();

            StreamReader fileStream = new StreamReader(openFile.OpenFile());
            textBox1.Text = fileStream.ReadToEnd();
            unsavedChanges = false;
            newWindow = false;
            okToOverwrite = true;
            UpdateTitle(openFile.FileName);
            fileStream.Close();
        }

        void UpdateTitle(string fileName) {
            this.fileName = fileName;
            UpdateTitle();
        }

        void UpdateTitle() {
            if (fileName != "") this.Text = DefaultTitleString + " - " + fileName;
            else this.Text = DefaultTitleString;
            if (unsavedChanges) this.Text = "* " + this.Text + " *";
        }

        private void saveFile() {
            if (!okToOverwrite) saveFileAs();
            else {
                try {
                    StreamWriter fileStream = new StreamWriter(fileName);
                    fileStream.Write(textBox1.Text);
                    unsavedChanges = false;
                    showSavedMessage();
                    fileStream.Close();
                } catch (Exception e) {
                    new ErrorWindow("Write Failed!", "The program failed to write the file.", e.Message + "\n" + e.StackTrace, ErrorWindow.ERROR_MESSAGE).Show();
                } finally {
                    UpdateTitle();
                }
            }
        }

        private void saveFileAs() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.DefaultExt = ".txt";
            if (fileName != "") saveFileDialog.FileName = fileName;
            saveFileDialog.ValidateNames = true;

            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                StreamWriter fileStream = new StreamWriter(saveFileDialog.OpenFile());
                try {
                    fileStream.Write(textBox1.Text);
                    unsavedChanges = false;
                    okToOverwrite = true;
                    fileName = saveFileDialog.FileName;
                    showSavedMessage();
                } catch (Exception e) {
                    new ErrorWindow("Write Failed!", "The program failed to write the file.", e.Message + "\n" + e.StackTrace, ErrorWindow.ERROR_MESSAGE).Show();
                } finally {
                    fileStream.Close();
                    UpdateTitle();
                }
            }
        }

        private void showSavedMessage() {
            label1.Text = "File saved";
            timer1.Start();
        }

        private void updateRowCol() {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            line++;
            column++;
            label1.Text = "row: " + line.ToString() + "   col: " + column.ToString();
        }

        private void handleKeypress() {
            if (newWindow) newWindow = false;
            updateSaveStatus();
            updateRowCol();
        }

        private void updateSaveStatus() {
            if (!unsavedChanges) {
                unsavedChanges = true;
                UpdateTitle();
            }
        }

        private void openFile() {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK) {

                if (newWindow) {
                    StreamReader fileStream = new StreamReader(openFileDialog.OpenFile());
                    textBox1.Text = fileStream.ReadToEnd();
                    unsavedChanges = false;
                    okToOverwrite = true;
                    newWindow = false;
                    UpdateTitle(openFileDialog.FileName);
                    fileStream.Close();
                } else new Text_Editor(openFileDialog).Show();
            }

        }

        private void RunCode() {
            if (DisplayForm == null || DisplayForm.IsDisposed) {
                DisplayForm = new Draw_Preview(textBox1.Text);
            } else {
                Console.WriteLine("Removed all commands");
                DisplayForm.RemoveAllCommands();
                DisplayForm.SubmitCommands(textBox1.Text);
            }
            DisplayForm.Show();
            DisplayForm.Focus();
        }

        public void CheckCode() {
            Draw_Preview tmpDrawPreview = new Draw_Preview();
            tmpDrawPreview.Hide();
            tmpDrawPreview.SubmitCommands(textBox1.Text);
            tmpDrawPreview.Close();
            SettingsAndHelperFunctions.WindowClosed();
            tmpDrawPreview.Dispose();
        }

        private void handleExit(FormClosingEventArgs e) {
            if (unsavedChanges) {
                DialogResult dialogResult = MessageBox.Show("You have unsaved work. Would you like to discard your work?", "Unsaved work!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (e != null) e.Cancel = dialogResult != DialogResult.Yes;
            }
        }

        private void DescribeCode() {
            Draw_Preview tmpDrawPreview = new Draw_Preview();
            tmpDrawPreview.Hide();
            tmpDrawPreview.SubmitCommands(textBox1.Text);

            string commandDesc = tmpDrawPreview.DescribeAllCommands();
            Console.WriteLine(commandDesc);

            tmpDrawPreview.Close();
            SettingsAndHelperFunctions.WindowClosed();
            tmpDrawPreview.Dispose();

            new DetailsWindow(commandDesc, "Command explanation").Show();
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e) {
            if (DisplayForm != null && !DisplayForm.IsDisposed) DisplayForm.ReleaseCommandLock();
            SettingsAndHelperFunctions.WindowClosed();
            Dispose();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) => RunCode();


        private void createNewInstance() => new Text_Editor().Show();

        private void handleKeypress(object sender, EventArgs e) => handleKeypress();

        private void textBox1_Click(object sender, EventArgs e) => updateRowCol();

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => saveFileAs();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => saveFile();

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) => createNewInstance();
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new About_Window().Show();

        private void Text_Editor_FormClosing(object sender, FormClosingEventArgs e) => handleExit(e);
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void openToolStripMenuItem_Click(object sender, EventArgs e) => openFile();

        private void Text_Editor_PreviewKeyDown(object sender, KeyEventArgs e) {
            //New window
            if (e.Control && e.KeyCode == Keys.N) {
                createNewInstance();
                e.Handled = true;
            } else if (e.Control && e.KeyCode == Keys.S) {
                saveFile();
                e.Handled = true;
            } else if (e.Control && e.Shift && e.KeyCode == Keys.S) {
                saveFileAs();
                e.Handled = true;
            } else if (e.Control && e.KeyCode == Keys.O) {
                openFile();
                e.Handled = true;
            } else if (e.KeyCode == Keys.F5) {
                RunCode();
                e.Handled = true;
            } else if (e.KeyCode == Keys.F5 && e.Shift) {
                CheckCode();
                e.Handled = true;
            } else if (e.KeyCode == Keys.F1 && e.Shift) {
                DescribeCode();
                e.Handled = true;
            } 
        }

        private void checkSyntaxToolStripMenuItem_Click(object sender, EventArgs e) => CheckCode();

        private void describeToolStripMenuItem_Click(object sender, EventArgs e) => DescribeCode();

        private void timer1_Tick(object sender, EventArgs e) {
            updateRowCol();
            timer1.Stop();
        }
    }
}
