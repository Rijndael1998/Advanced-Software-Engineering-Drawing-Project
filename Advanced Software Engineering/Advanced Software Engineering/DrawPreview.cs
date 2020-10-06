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
    public partial class DrawPreview : Form
    {
        public DrawPreview()
        {
            InitializeComponent();
            SettingsAndHelperFunctions.NumberOfWindows++;
        }

        private void DrawPreview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(200, 200);
            Graphics g = e.Graphics;
            Pen myBlackPen = new Pen(Color.Black, 5);

            g.DrawLine(myBlackPen, pt1, pt2);
        }

        private void DrawPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsAndHelperFunctions.WindowClosed();
        }
    }
}
