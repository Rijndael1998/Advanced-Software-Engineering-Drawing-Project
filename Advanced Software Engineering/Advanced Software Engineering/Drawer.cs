using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    public class Drawer {
        protected static Color defaultColor = Color.Black;
        protected static float defaultWidth = 1f;
        protected bool fill = false;


        protected Brush brush;
        protected Pen pen;


        protected Point penPosition;
        protected Graphics graphics;

        public Drawer(Graphics graphics) {
            this.graphics = graphics;
            ResetDrawer();
        }

        public void ResetDrawer() {
            graphics.Clear(Color.White);
            penPosition = new Point(0, 0);
            pen = new Pen(defaultColor, defaultWidth);
            brush = new SolidBrush(defaultColor);
        }

        public void SetGraphics(Graphics graphics) => this.graphics = graphics;

        public void MovePen(Point point) => penPosition = point;
        public Point GetPenPosition() => new Point(penPosition.X, penPosition.Y);

        public bool GetFill() => fill;
        public void EnableFill() => fill = false;
        public void DisableFill() => fill = true;
        public void SetFill(bool down) => fill = down;

        public void SetPenColor(Color color) => pen.Color = color;
        public void SetPenWidth(float width) => pen.Width = width;

        public void SetFillColor(Color color) => ((SolidBrush)brush).Color = color;

        public void DrawLine(Point point) {
            graphics.DrawLine(pen, penPosition, point);
            penPosition = point;
        }

        public void DrawLines(Point[] points) {
            if (points.Length < 2) {
                throw new Exception("Cannot have less than two points in a line");
            }

            GraphicsPath path = new GraphicsPath();

            for (int i = 1; i < points.Length; i++) {
                path.AddLine(points[i - 1], points[i]);
            }

            path.AddLine(points[0], points.Last());

            DrawLines(path);
        }

        //Doesn't move pen
        public void DrawLines(GraphicsPath path) {
            //path.Widen(pen);
            if (fill) graphics.FillPath(brush, path);
            graphics.DrawPath(pen, path);
        }

        public void DrawCircle(double scale) {
            graphics.DrawEllipse(pen, penPosition.X - (float)(scale), penPosition.Y - (float)(scale), (float)scale * 2, (float)scale * 2);
        }

        public void ClearCanvas() {
            graphics.Clear(Color.White);
        }

        public void DrawDot() {
            graphics.FillRectangle(new SolidBrush(pen.Color), penPosition.X, penPosition.Y, 1, 1);
        }
    }
}
