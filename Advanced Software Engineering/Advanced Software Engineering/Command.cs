using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Advanced_Software_Engineering {
    public class VerbFactory {
        public static Verb MakeVerb(Drawer drawer, string fullCommand) {

            Dictionary<string, string[]> commandAndParameters = SettingsAndHelperFunctions.CommandAndParameterParser(fullCommand);

            string command = commandAndParameters["command"][0];
            string[] parameters = commandAndParameters.Keys.Contains("parameters") ? commandAndParameters["parameters"] : new string[] { };

            switch (command) {
                case "move":
                case "moveto":
                    //Check parameters
                    if (parameters.Length == 2) {
                        try {
                            return new
                                MoveTo(drawer,
                                SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                                SettingsAndHelperFunctions.ConvertToInt(parameters[1]));

                        } catch (Exception e) {
                            throw e;
                        }
                    } else throw new Exception("Command has an incorrect number of parameters");

                case "drawto":
                case "line":
                case "lineto":
                    //Check parameters
                    if (parameters.Length == 2) {
                        try {
                            return new
                                DrawTo(drawer,
                                SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                                SettingsAndHelperFunctions.ConvertToInt(parameters[1]));

                        } catch (Exception e) {
                            throw e;
                        }
                    } else throw new Exception("Command has an incorrect number of parameters");
                case "regularpolygon":
                case "rp":
                    //Check parameters
                    if (parameters.Length == 2) {
                        return new
                            RegularPolygon(drawer,
                            SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                            SettingsAndHelperFunctions.ConvertToDouble(parameters[1])
                            );
                    }
                    if (parameters.Length == 3) {
                        return new RegularPolygon(drawer,
                            SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                            SettingsAndHelperFunctions.ConvertToDouble(parameters[1]),
                            SettingsAndHelperFunctions.ConvertToDouble(parameters[2])
                            );
                    } else throw new Exception("Command has an incorrect number of parameters");
                case "square":
                case "rectangle":
                case "circle":
                case "triangle":


                case "dot":
                case "clear":
                case "pen":
                case "fill":
                    throw new Exception("Not implemented");

                default:
                    throw new Exception("Command not found");
            }

        }
    }

    public interface Verb {
        void ExecuteVerb();
        string GetDescription();
    }

    public class MoveTo : Verb {

        protected Drawer drawer;
        protected Point moveToPoint;

        public MoveTo(Drawer drawer, int x, int y) {
            this.drawer = drawer;
            this.moveToPoint = new Point(x, y);
        }

        public MoveTo(Drawer drawer, Point point) {
            this.drawer = drawer;
            this.moveToPoint = point;
        }

        public void ExecuteVerb() {
            this.drawer.MovePen(moveToPoint);
        }

        public string GetDescription() {
            return "Move origin to " + moveToPoint.X + ", " + moveToPoint.Y;
        }

    }

    public class DrawTo : Verb {
        protected Drawer drawer;
        protected Point moveToPoint;

        public DrawTo(Drawer drawer, int x, int y) {
            this.drawer = drawer;
            moveToPoint = new Point(x, y);
        }

        public void ExecuteVerb() {
            drawer.DrawLine(moveToPoint);
        }

        public string GetDescription() {
            return "Draw line " + moveToPoint.X + ", " + moveToPoint.Y;
        }
    }

    /// <summary>
    /// A class that generates a RegularPolygon verb. 
    /// </summary>
    class RegularPolygon : Verb {
        protected Drawer drawer;
        protected int sides;
        protected double scale;
        protected double offset;
        List<Point> points;

        public RegularPolygon(Drawer drawer, int sides, double scale, double offset = 0, bool degMode = true) {
            points = new List<Point>();

            //if in degMode, convert the offset to radians
            if (degMode) offset = Math.PI * offset / 180;

            double constantAngleDelta = 2 * Math.PI / sides;
            for (int side = 0; side < sides; side++) {
                double angle = (constantAngleDelta * side) + offset;

                double dx = scale * Math.Sin(angle);
                double dy = scale * Math.Cos(angle);

                points.Add(new Point((int)Math.Round(dx), (int)Math.Round(dy)));
            }

            this.sides = sides;
            this.scale = scale;
            this.drawer = drawer;
            this.offset = offset;
        }

        public void ExecuteVerb() {
            Point currentOrigin = drawer.GetPenPosition();
            List<Point> originShiftedPoints = new List<Point>();
            foreach (Point point in points) originShiftedPoints.Add(new Point(point.X + currentOrigin.X, point.Y + currentOrigin.Y));
            drawer.DrawLines(originShiftedPoints.ToArray());
        }

        public string GetDescription() {
            return "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;
        }
    }

    class Square : Verb {

        Verb verb;

        Square(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 4, scale);
        }

        Square(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 4, scale, offset);
        }

        public void ExecuteVerb() => verb.ExecuteVerb();

        public string GetDescription() => verb.GetDescription();
    }

    class Triangle : Verb {
        Verb verb;

        Triangle(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 3, scale);
        }

        Triangle(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 3, scale, offset);
        }

        public void ExecuteVerb() => verb.ExecuteVerb();

        public string GetDescription() => verb.GetDescription();
    }

    //TODO: correct
    class Rectangle : Verb {
        Verb verb;

        Drawer drawer;
        List<Point> points;
        bool correctForOrigin;

        Rectangle(Drawer drawer, double width, double height, bool center = true) {
            this.drawer = drawer;
            correctForOrigin = true;

            PointF[] points = new PointF[] 
            { 
                new PointF((float) -width,    (float) -height),
                new PointF((float) width,     (float) -height),
                new PointF((float) width,     (float) height),
                new PointF((float) -width,    (float) height)
            };

            this.points = new List<Point>();
            foreach (PointF pointF in points) this.points.Add(new Point((int)Math.Round(pointF.X), (int)Math.Round(pointF.Y)));
        }

        Rectangle(Drawer drawer, Point point1, Point point2) {
            this.drawer = drawer;

            PointF[] points = new PointF[]
            {
                new PointF((float) point1.X,    (float) point1.Y),
                new PointF((float) point1.X,    (float) point2.Y),
                new PointF((float) point2.X,    (float) point2.Y),
                new PointF((float) point2.X,    (float) point1.Y)
            };

            this.points = new List<Point>();
            foreach (PointF pointF in points) this.points.Add(new Point((int)Math.Round(pointF.X), (int)Math.Round(pointF.Y)));

            correctForOrigin = false;

        }

        public string GetDescription() {
            return "";
        }

        public void ExecuteVerb() => drawer.DrawLines(points.ToArray());
        
    }

    class Circle : Verb {
        Drawer drawer;
        double scale;

        public Circle(Drawer drawer, double scale) {
            this.drawer = drawer;
            this.scale = scale;
        }

        public void ExecuteVerb() {
            drawer.DrawCircle(scale);
        }

        public string GetDescription() {
            return "Draws a circle radius" + scale.ToString() + ", with origin of the pen";
        }
    }

    abstract class Value {

    }

    class FlowControl //: Verb //This one will help us in part 2
    {

    }
}
