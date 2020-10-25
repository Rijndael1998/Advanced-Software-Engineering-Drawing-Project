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

        protected Dictionary<int, Image> IMAGEDIR = new Dictionary<int, Image> {
            { ERROR_MESSAGE, Properties.Resources.error },
            { WARNING_MESSAGE, Properties.Resources.warning },
            { INFO_MESSAGE, Properties.Resources.info3 }
        };

        public ErrorWindow() {
            InitializeComponent();
            this.Text = "Error";
            label1.Text = "An error has occured";
            desc = "None";

            SetPicture(ERROR_MESSAGE);

            Focus();
        }

        public ErrorWindow(string title, string brief, string desc, int type) {
            InitializeComponent();
            this.Text = title;
            label1.Text = brief;
            this.desc = desc;

            SetPicture(type);

            Focus();

        }

        protected void SetPicture(int type) {
            pictureBox1.Image = IMAGEDIR[type];
            pictureBox1.Refresh();

            switch(type) {
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

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            new DetailsWindow(desc).Show();
        }

        private void ErrorWindow_Load(object sender, EventArgs e) {

        }
    }
}
