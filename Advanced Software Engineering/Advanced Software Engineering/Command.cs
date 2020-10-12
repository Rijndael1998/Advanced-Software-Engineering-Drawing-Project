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
    public static class Converters
    {
        /// <summary>
        /// This function removes spaces from the start and the end of the text. This should be unit tested.
        /// </summary>
        /// <param name="text">Simply any string of any size</param>
        /// <returns>A string without spaces at the begining or the end</returns>
        /// <example>
        /// For example
        /// <code>
        /// string a = "     a simple sentence surrounded by spaces                ";
        /// string b = StripSpaces(a);
        /// Console.WriteLine(b); // => "a simple sentence surrounded by spaces";
        /// </code>
        /// </example>
        /// <example>
        /// The code won't remove internal double spaces:
        /// <code>
        /// string a = "     a    simple    sentence     surrounded    by    spaces                ";
        /// string b = StripSpaces(a);
        /// Console.WriteLine(b); // => "a    simple    sentence     surrounded    by    spaces";
        /// </code>
        /// </example>
        public static string Strip(string text)
        {
            int start;

            for (start = 0; start < text.Length; start++)
            {
                char character = text[start];
                if (character != " "[0]) break;
            }

            int end;

            for (end = text.Length - 1; end >= 0; end--)
            {
                char character = text[end];
                if (character != " "[0]) break;
            }

            return text.Substring(start, end);

        }

        public static int ConvertToInt(string text)
        {
            text = Strip(text);
            return int.Parse(text);
        }

        public static List<string> StripStringArray(string[] array)
        {
            List<string> newStringList = new List<string>();

            foreach (string arrayElement in array)
            {
                string strippedElement = Strip(arrayElement);
                if (strippedElement.Length == 0) continue;
                else newStringList.Add(strippedElement);
            }

            return newStringList;
        }

        public static Dictionary<string, string[]> CommandAndParameterParser(string text)
        {
            Dictionary<string, string[]> commandAndParameters = new Dictionary<string, string[]>();

            //split the command from the parameters 
            string[] parameters = Strip(text).Split(new char[] { " "[0] }, 2);

            //set command var
            string command = Strip(parameters[0]);
            commandAndParameters["command"] = new string[] { command };

            //seperate all of the parameters by a comma
            parameters = parameters[1].Split(","[0]);

            //Remove spaces around parameters
            parameters = StripStringArray(parameters).ToArray();

            //set parameter list
            commandAndParameters["parameters"] = parameters;

            return commandAndParameters;
        }
    }

    class VerbFactory
    {
        Type type;
        Drawer drawer;
        Verb verb;



        public Verb MakeVerb(Drawer drawer, string fullCommand)
        {
            this.drawer = drawer;

            Dictionary<string, string[]> commandAndParameters = Converters.CommandAndParameterParser(fullCommand);

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
                                Converters.ConvertToInt(parameters[0]),
                                Converters.ConvertToInt(parameters[1]));

                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else throw new Exception("Command has an incorrect number of parameters");

                case "drawto":
                    //Check parameters
                    if (parameters.Length == 2)
                    {
                        try
                        {
                            return new
                                DrawTo(drawer,
                                Converters.ConvertToInt(parameters[0]),
                                Converters.ConvertToInt(parameters[1]));

                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else throw new Exception("Command has an incorrect number of parameters");


                default:
                    throw new Exception("Command not found");
            }

        }

        public void ExecuteCommand()
        {
            verb.ExecuteVerb();
        }

        public Type getType()
        {
            return type;
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

        public void ExecuteVerb()
        {
            
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

            finishDown = drawer.isPenDown();

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
            drawer.setPen(penStatus);
        }
    }

    abstract class Value
    {

    }

    class FlowControl //: Verb //This one will help us in part 2
    {

    }
}
