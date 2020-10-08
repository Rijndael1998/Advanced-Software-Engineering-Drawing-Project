using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering
{
    class CommandParser
    {

        Graphics graphics;
        List<Command> commands = new List<Command>();
        Drawer drawer;

        void DrawAllCommands()
        {

        }

        CommandParser(Graphics graphics)
        {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
        }

        CommandParser(Graphics graphics, string rawCommands)
        {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            this.ProcessCommands(rawCommands);
        }

        void AddCommand(Command command)
        {
            commands.Add(command);
        }

        void ProcessCommands(string rawCommands)
        {
            //ignore case
            rawCommands = rawCommands.ToLower();
            //isolate commands
            string[] commands = rawCommands.Split(Environment.NewLine.ToCharArray());

            for(int i =0; i < commands.Length; i++)
            {
                commands[i] = SettingsAndHelperFunctions.StripSpaces(commands[i]);
            }

            foreach(string rawCommand in commands)
            {
                //handle errors later
                this.commands.Add(new Command(drawer, rawCommand));
            }

        }

    }

    class Drawer
    {
        protected static Color defaultPenColor = new Color();
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

        public bool isPenDown() => penDown;
        public void PenUp() => penDown = false;
        public void PenDown() => penDown = true;


    }

}
