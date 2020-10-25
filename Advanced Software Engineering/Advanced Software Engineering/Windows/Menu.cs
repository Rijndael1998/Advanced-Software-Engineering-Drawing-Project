using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    public partial class Menu : Form
    {
        /// <summary>
        /// This creates the main menu window you see when launching the program. 
        /// </summary>
        /// <remarks>
        /// This program window is only meant to show at launch and when all of the other windows are closed. It launches all windows independently of each other, so a theoretically unlimited number of windows can exist.
        /// </remarks>
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Draw_Preview().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Text_Editor().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new About_Window().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Do things on load
        }

        private void button5_Click(object sender, EventArgs e) {
            new ErrorWindow().Show();
        }
    }
}
