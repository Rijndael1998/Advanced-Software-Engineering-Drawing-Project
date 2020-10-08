using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            { "moveto", typeof(MoveTo) }
        };



    }

    class MoveTo : Verb
    {

    }

    abstract class Value
    {

    }

    class FlowControl : Verb //This one will help us in part 2
    {

    }
}
