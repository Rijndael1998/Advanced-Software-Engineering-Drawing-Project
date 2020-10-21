using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Advanced_Software_Engineering {
    class VerbFactory {
        public static Verb MakeVerb(Drawer drawer, string fullCommand) {

            Dictionary<string, string[]> commandAndParameters = SettingsAndHelperFunctions.CommandAndParameterParser(fullCommand);

            string command = commandAndParameters["command"][0];
            string[] parameters = commandAndParameters.Keys.Contains("parameters") ? commandAndParameters["parameters"] : new string[] { };

            switch (command) {
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
                case "shape":
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
                case "color":
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

    class MoveTo : Verb {

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

    class DrawTo : Verb {
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

    abstract class Shape : Verb {
        protected Drawer drawer;
        protected Point[] vertices;
        private List<Verb> lineVerbs;


        Shape(Drawer drawer, Point[] vertices) {
            //Throw exceptions if impossible to create Spape Verb
            switch (vertices.Length) {
                case 0:
                    throw new Exception("Cannot create shape with no vertices.");
                case 1:
                    throw new Exception("Cannot create shape with only one vertex. Are you thinking of 'dot'?");
                case 2:
                    throw new Exception("Cannot create shape with only two verticies. Are you thinking of 'drawto'/'moveto'/'line'?");
            }

            //TODO

        }

        public void ExecuteVerb() {
            foreach (Verb verb in lineVerbs) verb.ExecuteVerb();
        }

        public abstract string GetDescription();
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

                points.Add(new Point((int)dx, (int)dy));
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

    abstract class Value {

    }

    class FlowControl //: Verb //This one will help us in part 2
    {

    }
}
