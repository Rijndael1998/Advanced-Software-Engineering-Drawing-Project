using System;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    public partial class Menu : Form {

        /// <summary>
        /// This creates the main menu window you see when launching the program.
        /// </summary>
        /// <remarks>
        /// This program window is only meant to show at launch and when all of the other windows are closed. It launches all windows independently of each other, so a theoretically unlimited number of windows can exist.
        /// </remarks>
        public Menu() {
            InitializeComponent();
        }

        private void InteractivePreviewClick(object sender, EventArgs e) {
            new Draw_Preview().Show();
            this.Hide();
        }

        private void TextEditorClick(object sender, EventArgs e) {
            new TextEditor().Show();
            this.Hide();
        }

        private void AboutWindowClick(object sender, EventArgs e) {
            new About_Window().Show();
            this.Hide();
        }

        private void ExitClick(object sender, EventArgs e) {
            this.Close();
        }
    }
}