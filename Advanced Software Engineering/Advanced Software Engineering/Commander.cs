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
            try {
                //ignore case
                rawCommands = rawCommands.ToLower();
                Console.WriteLine("Processing:\n" + rawCommands);

                //isolate commands
                string[] commands = rawCommands.Split(Environment.NewLine.ToCharArray());

                Console.WriteLine("\nThe rawCommand processed:");
                foreach (string rawCommand in commands) {
                    if (rawCommand == "") continue;
                    AddCommand(VerbFactory.MakeVerb(drawer, rawCommand));
                    Console.WriteLine(rawCommand);
                }

                Console.WriteLine("\n\nHere is what the program is going to do:");
                Console.WriteLine("Set origin to 0, 0");
                foreach (Verb verb in this.commands) {
                    Console.WriteLine(verb.GetDescription());
                }
            } catch (Exception e) {
                Console.WriteLine("Error: Unknown error.");

                try {
                    new ErrorWindow(
                        "Unexpected error parsing commands",
                        "The program phraser has encountered an undexpected error." + Environment.NewLine,
                        e.Message + Environment.NewLine + e.StackTrace,
                        ErrorWindow.ERROR_MESSAGE
                        ).Show();
                } catch (Exception windowError) {
                    Console.WriteLine("Failed to display error window!");
                    throw windowError;
                }
                RemoveAllCommands();
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
