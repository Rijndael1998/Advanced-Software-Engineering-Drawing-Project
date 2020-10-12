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
    public partial class Draw_Preview : Form
    {

        Graphics graphics;
        Commander commander;

        /// <summary>
        /// The draw preview window.
        /// </summary>
        /// <remarks>
        /// This window is responsible for showing what has been drawn.
        /// </remarks>
        public Draw_Preview()
        {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
            graphics = panel1.CreateGraphics();
            commander = new Commander(graphics);
        }

        private void DrawPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }

        private void DrawPreviewPane_Paint(object sender, PaintEventArgs e)
        {
            commander.DrawAllCommands();
        }

        private void SubmitCommand(object sender, EventArgs e)
        {
            commander.ProcessCommands(textBox1.Text);
            textBox1.Text = "";

            //Makes sure that the panel updates
            panel1.Invalidate();
        }
    }
}
