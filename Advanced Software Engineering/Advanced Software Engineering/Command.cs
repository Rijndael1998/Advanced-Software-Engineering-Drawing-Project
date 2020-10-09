using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    class Command
    {
        Type type;
        Drawer drawer;
        Verb verb;

        public Command(Drawer drawer, string command)
        {
            this.drawer = drawer;

            //Seperate Values
            string[] commandAndParameters = command.Split(" "[0]);

            //Get command class
            type = Verb.verbTypes[commandAndParameters[0]];

            //Create the command's class
            verb = (Verb)Activator.CreateInstance(type);

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

    abstract class Verb
    {
        public static Dictionary<string, Type> verbTypes = new Dictionary<string, Type>()
        {
            { "moveto", typeof(MoveTo) },
            { "drawto", typeof(DrawTo) },
            { "line", null },
            { "dot", null },
            { "clear", null},
            { "rectangle", null },
            { "circle", null },
            { "triangle", null },
            { "pen", null},
            { "fill", null }
        };

        public abstract List<List<Type>> acceptedTypes
        {
            get;
        }

        public abstract void ExecuteVerb();

    }

    class MoveTo : Verb
    {
        public override List<List<Type>> acceptedTypes
        {
            get
            {
                return new List<List<Type>> {
                    new List<Type> { typeof(Drawer), typeof(int), typeof(int) },
                    new List<Type> { typeof(Drawer), typeof(Point) }
                };
            }
        }

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

        public override void ExecuteVerb()
        {
            this.drawer.MovePen(moveToPoint);
        }

    }

    class DrawTo : MoveTo
    {
        public DrawTo(Drawer drawer, int x, int y) : base(drawer, x, y) { }

        public DrawTo(Drawer drawer, Point point) : base(drawer, point) { }

        public override void ExecuteVerb()
        {
            bool penStatus = drawer.isPenDown();
            if (!penStatus) drawer.PenDown();
            base.ExecuteVerb();
            if (!penStatus) drawer.PenUp();
        }
    }

    abstract class Shape : Verb
    {
        protected Drawer drawer;
        protected Point[] vertices;
        private List<Verb> lineVerbs;

        Shape(Drawer drawer, params Point[] vertices)
        {
            switch (vertices.Length)
            {
                case 0:
                    throw new Exception("Cannot create shape with no vertices.");
                case 1:
                    throw new Exception("Cannot create shape with only one vertex. Are you thinking of 'dot'?");
                case 2:
                    throw new Exception("Cannot create shape with only two verticies. Are you thinking of 'drawto'/'moveto'/'lineto'?");
            }

            lineVerbs.Add(new PenControl(drawer, false));

            for (int i = 1; i < vertices.Length; i++)
            {
                lineVerbs.Add(new DrawTo(drawer, vertices[i]));
            }

        }

        public override void ExecuteVerb()
        {

        }

    }

    class PenControl : Verb
    {
        public override List<List<Type>> acceptedTypes
        {
            get
            {
                return new List<List<Type>> {
                    new List<Type> { typeof(Drawer), typeof(bool) }
                };
            }
        }

        bool penStatus;
        Drawer drawer;

        public PenControl(Drawer drawer, bool down)
        {
            penStatus = down;
            this.drawer = drawer;
        }

        public override void ExecuteVerb()
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
