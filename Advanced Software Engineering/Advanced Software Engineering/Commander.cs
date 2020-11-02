using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Advanced_Software_Engineering {
    /// <summary>
    /// The commander class takes care of commands. It also takes control of the drawer.
    /// </summary>
    public class Commander {

        Graphics graphics;
        List<Verb> commands = new List<Verb>();
        Drawer drawer;

        /// <summary>
        /// This command updates the graphics element (usually) when the page repaints.
        /// </summary>
        /// <param name="updateGraphicsElement">The graphics element to be updated</param>
        public void DrawAllCommands(Graphics updateGraphicsElement) {
            graphics = updateGraphicsElement;
            drawer.ResetDrawer();
            drawer.SetGraphics(updateGraphicsElement);

            foreach (Verb verb in this.commands) {
                verb.ExecuteVerb();
            }
        }

        /// <summary>
        /// Create a new Commander instance.
        /// </summary>
        /// <param name="graphics">initial graphics object</param>
        public Commander(Graphics graphics) {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            drawer.ResetDrawer();
        }

        /// <summary>
        /// Creates a new Commander instance without a context. Should only be used for testing purpouses.
        /// </summary>
        /// <param name="command">empty string</param>
        public Commander(string command = "") {
            Console.WriteLine("Warning! No graphics context!!!");
        }

        /// <summary>
        /// Creates a new Commander instance with a graphics context and commands to process right off the bat.
        /// </summary>
        /// <param name="graphics">Graphics contetx</param>
        /// <param name="rawCommands">Commands to process</param>
        public Commander(Graphics graphics, string rawCommands) {
            this.graphics = graphics;
            this.drawer = new Drawer(this.graphics);
            this.ProcessCommands(rawCommands);
            drawer.ResetDrawer();
        }
        /// <summary>
        /// Adds a verb to the command list to be executed.
        /// </summary>
        /// <param name="command">Verb to be added</param>
        public void AddCommand(Verb command) {
            commands.Add(command);
        }

        /// <summary>
        /// processes commands. Removes all commands if it fails parsing the raw commands.
        /// </summary>
        /// <param name="rawCommands">Processes commands seperated by \n or \r\n</param>
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

        /// <summary>
        /// Processes the commands and executes them at the same time. It's the same as <see></see>
        /// </summary>
        /// <param name="rawCommands">Processes commands seperated by \n or \r\n</param>
        public void ProcessCommandsAndExecute(string rawCommands) {
            int start = commands.Count;
            ProcessCommands(rawCommands);

            for (; start < commands.Count; start++) {
                commands[start].ExecuteVerb();
            }
        }

        /// <summary>
        /// Removes all commands from the Commander and resets the drawer.
        /// </summary>
        public void RemoveAllCommands() {
            commands = new List<Verb>();
            drawer.ResetDrawer();
        }

        /// <summary>
        /// Explains all of the commands in order
        /// </summary>
        /// <returns>Explanation of all the commands</returns>
        public string ExplainCommands() {
            string desc = "";
            foreach (Verb command in commands) {
                desc += command.GetDescription() + Environment.NewLine;
            }
            return desc;
        }

        /// <summary>
        /// Get the numder of commands inside the Commader
        /// </summary>
        /// <returns>Integer number of commands</returns>
        public int GetNumberOfCommands() {
            return commands.Count;
        }

    }

}
