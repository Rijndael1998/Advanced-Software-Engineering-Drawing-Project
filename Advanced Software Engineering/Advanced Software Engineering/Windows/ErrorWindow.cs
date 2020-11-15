using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    /// <summary>
    /// The error window that can show errors, warnings and messages.
    /// </summary>
    public partial class ErrorWindow : Form {
        private string desc;

        /// <summary>
        /// The error message type.
        /// </summary>
        public const int ERROR_MESSAGE = 0;

        /// <summary>
        /// The warning message type
        /// </summary>
        public const int WARNING_MESSAGE = 1;

        /// <summary>
        /// The info message type
        /// </summary>
        public const int INFO_MESSAGE = 2;

        /// <summary>
        /// The image directory which links the message types to the image to display.
        /// </summary>
        protected Dictionary<int, Image> IMAGEDIR = new Dictionary<int, Image> {
            { ERROR_MESSAGE, Properties.Resources.error },
            { WARNING_MESSAGE, Properties.Resources.warning },
            { INFO_MESSAGE, Properties.Resources.info }
        };

        /// <summary>
        /// The default error window constructor. Creates an error window with the title "Error", short description "An error has occured", a long description of "None" and message type of ERROR.
        /// </summary>
        public ErrorWindow() {
            InitializeComponent();
            this.Text = "Error";
            label1.Text = "An error has occured";
            desc = "None";

            SetPicture(ERROR_MESSAGE);

            Focus();
        }

        /// <summary>
        /// The error window constructor.
        /// It is responsible for creating an error form which shows the user information depending on the parameters.
        /// </summary>
        /// <param name="title">Title of the window</param>
        /// <param name="brief">A brief description of the message</param>
        /// <param name="desc">A detailed description of the message</param>
        /// <param name="type">The type of message (can either be: ERROR_MESSAGE, WARNING_MESSAGE or INFO_MESSAGE</param>
        public ErrorWindow(string title, string brief, string desc, int type) {
            InitializeComponent();
            this.Text = title;
            label1.Text = brief;
            this.desc = desc;

            SetPicture(type);

            Focus();
        }

        /// <summary>
        /// Sets the picture of the window.
        /// </summary>
        /// <param name="type">The type of message (can either be: ERROR_MESSAGE, WARNING_MESSAGE or INFO_MESSAGE</param>
        public void SetPicture(int type) {
            pictureBox1.Image = IMAGEDIR[type];
            pictureBox1.Refresh();

            switch (type) {
                case ERROR_MESSAGE:
                    groupBox1.Text = "Error";
                    break;

                case WARNING_MESSAGE:
                    groupBox1.Text = "Warning";
                    break;

                case INFO_MESSAGE:
                    groupBox1.Text = "Info";
                    break;
            }
        }

        /// <summary>
        /// Closes the from.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Show description window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            new DetailsWindow(desc).Show();
        }

        private void ErrorWindow_Load(object sender, EventArgs e) {
        }
    }
}