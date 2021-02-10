using System;
using System.IO;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    public partial class TextEditor : Form {
        private const string DefaultTitleString = "ASE - Text Editor";

        private Draw_Preview DisplayForm = null;
        private bool unsavedChanges = false;
        private bool newWindow = true;
        private bool okToOverwrite = false;
        private string fileName = "";

        /// <summary>
        /// The text editor is the main window that the user will be using for writing code.
        /// </summary>
        public TextEditor() {
            MenuManager.NumberOfWindows++;
            InitializeComponent();
            UpdateTitle();
        }

        /// <summary>
        /// The text editor is the main window that the user will be using for writing code.
        /// </summary>
        /// <param name="openFile">File dialog which points to the file to open</param>
        public TextEditor(OpenFileDialog openFile) {
            MenuManager.NumberOfWindows++;
            InitializeComponent();

            StreamReader fileStream = new StreamReader(openFile.OpenFile());
            TextBox.Text = fileStream.ReadToEnd();
            unsavedChanges = false;
            newWindow = false;
            okToOverwrite = true;
            UpdateTitle(openFile.FileName);
            fileStream.Close();
        }

        private void UpdateTitle(string fileName) {
            this.fileName = fileName;
            UpdateTitle();
        }

        private void UpdateTitle() {
            if (fileName != "") this.Text = DefaultTitleString + " - " + fileName;
            else this.Text = DefaultTitleString;
            if (unsavedChanges) this.Text = "* " + this.Text + " *";
        }

        private void SaveFile() {
            if (!okToOverwrite) SaveFileAs();
            else {
                try {
                    StreamWriter fileStream = new StreamWriter(fileName);
                    fileStream.Write(TextBox.Text);
                    unsavedChanges = false;
                    ShowSavedMessage();
                    fileStream.Close();
                } catch (Exception e) {
                    new ErrorWindow("Write Failed!", "The program failed to write the file.", e.Message + "\n" + e.StackTrace, ErrorWindow.ERROR_MESSAGE).Show();
                } finally {
                    UpdateTitle();
                }
            }
        }

        private void SaveFileAs() {
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                OverwritePrompt = true,
                DefaultExt = ".txt"
            };
            if (fileName != "") saveFileDialog.FileName = fileName;
            saveFileDialog.ValidateNames = true;

            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                StreamWriter fileStream = new StreamWriter(saveFileDialog.OpenFile());
                try {
                    fileStream.Write(TextBox.Text);
                    unsavedChanges = false;
                    okToOverwrite = true;
                    fileName = saveFileDialog.FileName;
                    ShowSavedMessage();
                } catch (Exception e) {
                    new ErrorWindow("Write Failed!", "The program failed to write the file.", e.Message + "\n" + e.StackTrace, ErrorWindow.ERROR_MESSAGE).Show();
                } finally {
                    fileStream.Close();
                    UpdateTitle();
                }
            }
        }

        private void ShowSavedMessage() {
            label1.Text = "File saved";
            SavedLabelTimer.Start();
        }

        private void UpdateRowsAndColumnsPreview() {
            int line = TextBox.GetLineFromCharIndex(TextBox.SelectionStart);
            int column = TextBox.SelectionStart - TextBox.GetFirstCharIndexFromLine(line);
            line++;
            column++;
            label1.Text = "row: " + line.ToString() + "   col: " + column.ToString();
        }

        private void HandleKeypress() {
            if (newWindow) newWindow = false;
            UpdateSaveStatus();
            UpdateRowsAndColumnsPreview();
        }

        private void UpdateSaveStatus() {
            if (!unsavedChanges) {
                unsavedChanges = true;
                UpdateTitle();
            }
        }

        private void OpenFile() {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                if (newWindow) {
                    StreamReader fileStream = new StreamReader(openFileDialog.OpenFile());
                    TextBox.Text = fileStream.ReadToEnd();
                    unsavedChanges = false;
                    okToOverwrite = true;
                    newWindow = false;
                    UpdateTitle(openFileDialog.FileName);
                    fileStream.Close();
                } else new TextEditor(openFileDialog).Show();
            }
        }

        private void RunCode() {
            if (DisplayForm == null || DisplayForm.IsDisposed) {
                DisplayForm = new Draw_Preview(TextBox.Text);
            } else {
                Console.WriteLine("Removed all commands");
                DisplayForm.RemoveAllCommands();
                DisplayForm.SubmitCommands(TextBox.Text);
            }

            if (DisplayForm.IsSuccess()) {
                DisplayForm.Show();
                DisplayForm.Focus();
            }
        }

        /// <summary>
        /// This function checks if the code written is OK
        /// </summary>
        public void CheckCode() {
            Draw_Preview tmpDrawPreview = new Draw_Preview();
            tmpDrawPreview.Hide();
            tmpDrawPreview.SubmitCommands(TextBox.Text);
            if (tmpDrawPreview.IsSuccess()) new ErrorWindow("No errors", "No errors found in the program", "There have been no errors found", ErrorWindow.INFO_MESSAGE).Show();
            tmpDrawPreview.Close();
            MenuManager.WindowClosed();
            tmpDrawPreview.Dispose();
        }

        private void HandleExit(FormClosingEventArgs e) {
            if (unsavedChanges) {
                DialogResult dialogResult = MessageBox.Show("You have unsaved work. Would you like to discard your work?", "Unsaved work!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (e != null) e.Cancel = dialogResult != DialogResult.Yes;
            }
        }

        private void DescribeCode() {
            Draw_Preview tmpDrawPreview = new Draw_Preview();
            tmpDrawPreview.Hide();
            tmpDrawPreview.SubmitCommands(TextBox.Text);

            string commandDesc = tmpDrawPreview.DescribeAllCommands();
            Console.WriteLine(commandDesc);

            tmpDrawPreview.Close();
            MenuManager.WindowClosed();
            tmpDrawPreview.Dispose();

            new DetailsWindow(commandDesc, "Command explanation").Show();
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e) {
            if (DisplayForm != null && !DisplayForm.IsDisposed) DisplayForm.ReleaseCommandLock();
            MenuManager.WindowClosed();
            Dispose();
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e) => RunCode();

        private void CreateNewInstance() => new TextEditor().Show();

        private void HandleKeypress(object sender, EventArgs e) => HandleKeypress();

        private void TextBoxClick(object sender, EventArgs e) => UpdateRowsAndColumnsPreview();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveFileAs();

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e) => CreateNewInstance();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => new About_Window().Show();

        private void Text_Editor_FormClosing(object sender, FormClosingEventArgs e) => HandleExit(e);

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();

        private void Text_Editor_PreviewKeyDown(object sender, KeyEventArgs e) {
            //New window
            if (e.Control && e.KeyCode == Keys.N) {
                CreateNewInstance();
                e.Handled = true;
            } else if (e.Control && e.KeyCode == Keys.S) {
                SaveFile();
                e.Handled = true;
            } else if (e.Control && e.Shift && e.KeyCode == Keys.S) {
                SaveFileAs();
                e.Handled = true;
            } else if (e.Control && e.KeyCode == Keys.O) {
                OpenFile();
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
            } else {
                UpdateRowsAndColumnsPreview();
            }
        }

        private void CheckSyntaxToolStripMenuItem_Click(object sender, EventArgs e) => CheckCode();

        private void DescribeToolStripMenuItem_Click(object sender, EventArgs e) => DescribeCode();

        private void SavedLableTimerTick(object sender, EventArgs e) {
            UpdateRowsAndColumnsPreview();
            SavedLabelTimer.Stop();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e) => UpdateRowsAndColumnsPreview();

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e) => new CommandHelp().Show();
    }
}