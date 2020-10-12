using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace Advanced_Software_Engineering
{
    class VerbFactory
    {
        public static Verb MakeVerb(Drawer drawer, string fullCommand)
        {

            Dictionary<string, string[]> commandAndParameters = SettingsAndHelperFunctions.CommandAndParameterParser(fullCommand);

            string command = commandAndParameters["command"][0];
            string[] parameters = commandAndParameters["parameters"];

            switch (command)
            {
                case "moveto":
                    //Check parameters
                    if (parameters.Length == 2)
                    {
                        try
                        {
                            return new
                                MoveTo(drawer,
                                SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                                SettingsAndHelperFunctions.ConvertToInt(parameters[1]));

                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else throw new Exception("Command has an incorrect number of parameters");

                case "drawto":
                case "line":
                case "lineto":
                    //Check parameters
                    if (parameters.Length == 2)
                    {
                        try
                        {
                            return new
                                DrawTo(drawer,
                                SettingsAndHelperFunctions.ConvertToInt(parameters[0]),
                                SettingsAndHelperFunctions.ConvertToInt(parameters[1]));

                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else throw new Exception("Command has an incorrect number of parameters");

                case "dot":
                case "clear":
                case "shape":
                case "square":
                case "rectangle":
                case "circle":
                case "triangle":
                case "pen":
                case "fill":
                case "color":
                    throw new Exception("Not implemented");

                default:
                    throw new Exception("Command not found");
            }

        }
    }

    public interface Verb
    {
        void ExecuteVerb();

    }

    class MoveTo : Verb
    {

        protected Drawer drawer;
        protected Point moveToPoint;

        public MoveTo(Drawer drawer, int x, int y)
        {
            this.drawer = drawer;
            this.moveToPoint = new Point(x, y);
        }

        public MoveTo(Drawer drawer, Point point)
        {
            this.drawer = drawer;
            this.moveToPoint = point;
        }

        public void ExecuteVerb()
        {
            this.drawer.MovePen(moveToPoint);
        }

    }

    class DrawTo : MoveTo
    {
        public DrawTo(Drawer drawer, int x, int y) : base(drawer, x, y) { }

        public DrawTo(Drawer drawer, Point point) : base(drawer, point) { }

        public new void ExecuteVerb()
        {
            this.drawer.DrawLine(moveToPoint);
        }
    }

    abstract class Shape : Verb
    {
        protected Drawer drawer;
        protected Point[] vertices;
        private List<Verb> lineVerbs;
        private bool finishDown;


        Shape(Drawer drawer, Point[] vertices)
        {
            //Throw exceptions if impossible to create Spape Verb
            switch (vertices.Length)
            {
                case 0:
                    throw new Exception("Cannot create shape with no vertices.");
                case 1:
                    throw new Exception("Cannot create shape with only one vertex. Are you thinking of 'dot'?");
                case 2:
                    throw new Exception("Cannot create shape with only two verticies. Are you thinking of 'drawto'/'moveto'/'line'?");
            }

            finishDown = drawer.IsPenDown();

            //Move pen to every vertex.
            //Using MoveTo rather than LineTo because LineTo would be slower if done multiple times (pen up pen down over and over if the pen wasn't down initially)
            for (int i = 1; i < vertices.Length; i++)
            {
                lineVerbs.Add(new DrawTo(drawer, vertices[i]));
            }

            //Join first and last line
            lineVerbs.Add(new DrawTo(drawer, vertices[0]));

        }

        public void ExecuteVerb()
        {
            foreach (Verb verb in lineVerbs) verb.ExecuteVerb();
        }
    }

    /// <summary>
    /// A class that generates sets 
    /// </summary>
    class RegularPolygons : Verb
    {

        List<Verb> verbs;

        RegularPolygons(Drawer drawer, Point origin, int sides, int scale)
        {

        }

        public void ExecuteVerb()
        {

        }
    }

    class PenControl : Verb
    {
        bool penStatus;
        Drawer drawer;

        public PenControl(Drawer drawer, bool down)
        {
            penStatus = down;
            this.drawer = drawer;
        }

        public void ExecuteVerb()
        {
            drawer.SetPen(penStatus);
        }
    }

    abstract class Value
    {

    }

    class FlowControl //: Verb //This one will help us in part 2
    {

    }
}
