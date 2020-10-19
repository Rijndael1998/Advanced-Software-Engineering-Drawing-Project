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
    public partial class ErrorWindow : Form {
        string desc;

        public const int ERROR_MESSAGE = 0;
        public const int WARNING_MESSAGE = 1;
        public const int INFO_MESSAGE = 2;

        public ErrorWindow() {
            InitializeComponent();
            this.Text = "Error";
            label1.Text = "An error has occured";
            desc = "None";
        }

        public ErrorWindow(string title, string brief, string desc, int type) {
            InitializeComponent();
            this.Text = title;
            label1.Text = brief;
            this.desc = desc;

            switch(type) {
                case INFO_MESSAGE:

                    break;
                case WARNING_MESSAGE:

                    break;

                case ERROR_MESSAGE:
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            new ErrorDetailWindow(desc).Show();
        }
    }
}
