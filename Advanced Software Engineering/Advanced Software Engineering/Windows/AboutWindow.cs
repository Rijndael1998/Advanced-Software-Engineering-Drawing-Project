using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    public partial class About_Window : Form {

        ///<summary>
        ///Creates an About Window which shows details about the program.
        ///</summary>
        public About_Window() {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
        }

        /// <summary>
        /// When the form closes, the window count should be updated which this function is responsible for.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Window_FormClosed(object sender, FormClosedEventArgs e) {
            SettingsAndHelperFunctions.WindowClosed();
        }
    }
}