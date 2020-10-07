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
        public Draw_Preview()
        {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
        }

        private void DrawPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }

        private void DrawPreviewPane_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myBlackPen = new Pen(Color.Black, 5);

        }
    }
}
