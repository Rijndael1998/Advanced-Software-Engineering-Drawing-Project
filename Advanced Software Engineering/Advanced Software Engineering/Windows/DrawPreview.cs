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
        bool pardonCommands;

        /// <summary>
        /// The draw preview window. Spawns the basic DrawPreview.
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
            pardonCommands = true;
        }

        /// <summary>
        /// The draw preview window. Spawns the DrawPreview with commands locked.
        /// </summary>
        /// <remarks>
        /// This window is responsible for showing what has been drawn.
        /// </remarks>
        public Draw_Preview(string commands) {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
            graphics = panel1.CreateGraphics();
            graphics.ResetClip();
            commander = new Commander(graphics, commands);
            pardonCommands = false;
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
        }

        private void SubmitCommand(object sender, EventArgs e)
        {
            commander.ProcessCommandsAndExecute(textBox1.Text, pardonCommands);
            textBox1.Text = "";
        }

        /// <summary>
        /// Submit commands to the commander to execute on the form.
        /// </summary>
        /// <param name="comamnds">Commands seperated by new lines</param>
        public void SubmitCommands(string comamnds) {
            commander.ProcessCommandsAndExecute(comamnds, pardonCommands);
        }

        /// <summary>
        /// Removes all the commands from the form
        /// </summary>
        public void RemoveAllCommands() {
            commander.RemoveAllCommands();
        }

        /// <summary>
        /// Enables the textbox and submit button to allow the user to interract with the preview directly
        /// </summary>
        public void ReleaseCommandLock() {
            textBox1.Enabled = true;
            button1.Enabled = true;
            pardonCommands = true;
        }

        /// <summary>
        /// Describes all of the current commands stored inside commander.
        /// </summary>
        /// <returns>A string with all the command descriptions</returns>
        public string DescribeAllCommands() {
            return commander.ExplainCommands();
        }

        /// <summary>
        /// Returns weather there were any errors in the commander.
        /// </summary>
        /// <returns>A boolean describing the success of command phrasing</returns>
        public bool IsSuccess() {
            return commander.GetLastStatus();
        }

        /// <summary>
        /// Submits the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter && textBox1.Enabled) {
                button1.PerformClick();
            }
        }
    }
}
