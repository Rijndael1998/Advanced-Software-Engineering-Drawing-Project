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

        int repaintCount = 0;

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
            graphics.ResetClip();
            commander = new Commander(graphics);
        }

        public Draw_Preview(String commands) {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
            graphics = panel1.CreateGraphics();
            graphics.ResetClip();
            commander = new Commander(graphics, commands);

            //disable components
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void DrawPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
            Dispose();
        }

        private void DrawPreviewPane_Paint(object sender, EventArgs e) {
            DrawPreviewPane_Paint(sender, null);
        }

        private void DrawPreviewPane_Paint(object sender, PaintEventArgs e)
        {
            graphics = panel1.CreateGraphics();
            commander.DrawAllCommands(graphics);
            Console.WriteLine("Graphics repainted " + ++repaintCount + "times");
        }

        private void SubmitCommand(object sender, EventArgs e)
        {
            commander.ProcessCommandsAndExecute(textBox1.Text);
            textBox1.Text = "";
        }

        public void SubmitCommands(string comamnds) {
            commander.ProcessCommandsAndExecute(comamnds);
        }

        public void RemoveAllCommands() {
            commander.RemoveAllCommands();
        }

        public void ReleaseCommandLock() {
            textBox1.Enabled = true;
            button1.Enabled = true;
        }

    }
}
