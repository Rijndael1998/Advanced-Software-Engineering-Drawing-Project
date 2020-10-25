using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Advanced_Software_Engineering {
    public class Commander {

        Graphics graphics;
        List<Verb> commands = new List<Verb>();
        Drawer drawer;

        public void DrawAllCommands(Graphics updateGraphicsElement) {
            graphics = updateGraphicsElement;
            drawer.ResetDrawer();
            drawer.SetGraphics(updateGraphicsElement);

            foreach (Verb verb in this.commands) {
                verb.ExecuteVerb();
            }
        }

        public Commander(Graphics graphics) {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            drawer.ResetDrawer();
        }

        public Commander(string command) {
            Console.WriteLine("Warning! No graphics context!!!");
        }

        public Commander(Graphics graphics, string rawCommands) {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            this.ProcessCommands(rawCommands);
            drawer.ResetDrawer();
        }

        public void AddCommand(Verb command) {
            commands.Add(command);
        }

        public void ProcessCommands(string rawCommands) {
            //ignore case
            rawCommands = rawCommands.ToLower();
            Console.WriteLine("Processing:\n" + rawCommands);

            //remove windows \r if they exist
            rawCommands = rawCommands.Replace("\r", "");

            //isolate commands
            string[] commands = rawCommands.Split("\n"[0]);

            Console.WriteLine("\nThe rawCommand processed:");
            int lineNumber = 0;
            bool failed = false;
            foreach (string rawCommand in commands) {
                lineNumber++;
                if (rawCommand == "") continue;

                try {
                    AddCommand(VerbFactory.MakeVerb(drawer, rawCommand));
                    Console.WriteLine(rawCommand);
                } catch (Exception e) {
                    Console.WriteLine("Error!");
                    new ErrorWindow(e.Message, e.Message + " at line " + lineNumber, "While trying to process '" + rawCommand + "' an exception occured.\nMessage:\n" + e.Message + "\nStack Trace:\n" + e.StackTrace, ErrorWindow.ERROR_MESSAGE).Show();
                    failed = true;
                    break;
                }
            }

            if (failed) RemoveAllCommands();

            Console.WriteLine("\n\nHere is what the program is going to do:");
            Console.WriteLine("Set origin to 0, 0");
            foreach (Verb verb in this.commands) {
                Console.WriteLine(verb.GetDescription());
            }

        }

        public void ProcessCommandsAndExecute(string rawCommands) {
            int start = commands.Count;
            ProcessCommands(rawCommands);

            for (; start < commands.Count; start++) {
                commands[start].ExecuteVerb();
            }
        }

        public void RemoveAllCommands() {
            commands = new List<Verb>();
            drawer.ResetDrawer();
        }

        public string ExplainCommands() {
            string desc = "";
            foreach (Verb command in commands) {
                desc += command.GetDescription() + Environment.NewLine;
            }
            return desc;
        }

    }

}
