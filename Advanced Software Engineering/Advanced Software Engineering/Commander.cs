using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    class Commander
    {

        Graphics graphics;
        List<Verb> commands = new List<Verb>();
        Drawer drawer;

        public void DrawAllCommands() 
        {
            foreach(Verb verb in this.commands)
            {
                verb.ExecuteVerb();
            }
        }

        public Commander(Graphics graphics)
        {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
        }

        public Commander(Graphics graphics, string rawCommands)
        {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            this.ProcessCommands(rawCommands);
        }

        public void AddCommand(Verb command)
        {
            commands.Add(command);
        }

        public void ProcessCommands(string rawCommands)
        {
            //ignore case
            rawCommands = rawCommands.ToLower();

            //isolate commands
            string[] commands = rawCommands.Split(Environment.NewLine.ToCharArray());

            foreach(string rawCommand in commands)
            {
                //handle errors later
                AddCommand(VerbFactory.MakeVerb(drawer, rawCommand));
            }
        }

        public void ProcessCommandsAndExecute(string rawCommands)
        {
            int start = commands.Count;
            ProcessCommands(rawCommands);

            for(; start < commands.Count; start++)
            {
                commands[start].ExecuteVerb();
            }
        }

    }

    class Drawer
    {
        protected static Color defaultPenColor = Color.Black;
        protected static float defaultPenWidth = 1f;

        Pen pen = new Pen(defaultPenColor, defaultPenWidth);
        bool penDown = true;
        
        Point penPosition;
        Graphics graphics;

        public Drawer(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void MovePen(Point point)
        {
            if(penDown) graphics.DrawLine(pen, penPosition, point);
            
            this.penPosition = point;
        }

        public bool IsPenDown() => penDown;
        public void PenUp() => penDown = false;
        public void PenDown() => penDown = true;
        public void SetPen(bool down) => penDown = down;

        public void DrawLine(Point point)
        {
            graphics.DrawLine(pen, penPosition, point);
            penPosition = point;
        }

    }

}
