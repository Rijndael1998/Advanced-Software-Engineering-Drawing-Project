using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    /// <summary>
    /// This form is reponsible for showing details. It is essentially a textbox in a form.
    /// </summary>
    public partial class DetailsWindow : Form {

        /// <summary>
        /// A details window dedicated to showing details.
        /// </summary>
        /// <param name="details">The textbox text</param>
        public DetailsWindow(string details) {
            InitializeComponent();
            textBox1.Text = details;
        }

        /// <summary>
        /// A details window that shows details in the textbox and title as the window title.
        /// </summary>
        /// <param name="details">the details to be shown in the textbox</param>
        /// <param name="title">the title of the window</param>
        public DetailsWindow(string details, string title) {
            InitializeComponent();
            textBox1.Text = details;
            Text = title;
        }
    }
}