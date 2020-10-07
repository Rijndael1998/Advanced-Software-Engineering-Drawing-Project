using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering
{
    class CommandParser
    {

        Graphics graphics;
        List<Command> commands = new List<Command>();


        void DrawCommands()
        {

        }

        CommandParser(Graphics graphics)
        {
            this.graphics = graphics;
        }

        CommandParser(Graphics graphics, String rawCommands)
        {
            this.graphics = graphics;
            this.ProcessCommands(rawCommands);
        }

        void AddCommand(Command command)
        {
            commands.Add(command);
        }

        void ProcessCommands(String rawCommands)
        {
            //ignore case
            rawCommands = rawCommands.ToLower();
            //isolate commands
            String[] commands = rawCommands.Split(Environment.NewLine.ToCharArray());

        }

    }

    class Command
    {
        

    }

    class Verb
    {


    }

    class Value
    {


    }

}
