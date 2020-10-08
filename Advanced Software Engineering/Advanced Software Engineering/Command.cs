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
            verb = (Verb) Activator.CreateInstance(type);

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
            { "clear", null},
            { "rectangle", null },
            { "circle", null },
            { "triangle", null },
            { "pen", null},
            { "fill", null }
        };

        public abstract List<List<Type>> acceptedTypes {
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
            if(!penStatus) drawer.PenDown();
            base.ExecuteVerb();
            if (!penStatus) drawer.PenUp();
        }
    }

    abstract class Value
    {

    }

    class FlowControl //: Verb //This one will help us in part 2
    {

    }
}
