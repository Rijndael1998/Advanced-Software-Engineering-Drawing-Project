using System.Collections.Generic;

namespace Advanced_Software_Engineering {

    /// <summary>
    /// This class is a direct replacement to the dictionaries that were returned by <see cref="HelperFunctions.CommandAndParameterParser(string)"/>.
    /// This class provides better intraface to the output.
    /// </summary>
    public class CommandAndParameterParserResult {
        private readonly string command;
        private readonly string[] parameters;

        /// <summary>
        /// Generates a new Result
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="parameters">The parameters</param>
        public CommandAndParameterParserResult(string command, string[] parameters) {
            this.command = command;
            this.parameters = parameters;
        }

        /// <summary>
        /// Gets the command from the result
        /// </summary>
        /// <returns>the command</returns>
        public string GetCommand() {
            return command;
        }

        /// <summary>
        /// Gets the command parameters
        /// </summary>
        /// <returns>command parameters</returns>
        public string[] GetParameters() {
            return parameters;
        }
    }

    /// <summary>
    /// This class simply provides settings and some functions that are used across many components.
    /// </summary>
    public class HelperFunctions {

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
        public static string Strip(string text) {
            return text.Trim();
        }

        /// <summary>
        /// Strips the strings of the full array. See <see cref="Strip(string)"/>
        /// </summary>
        /// <example>
        /// string[] tmp = {"    text  ", "      ", "   with", "spaces     ", ""};
        /// Console.WriteLine(StripStringArray(tmp)); // => {"text", "with", "spaces"}
        /// </example>
        /// <param name="array">Dirty array with spaces</param>
        /// <returns>A stripped aray</returns>
        public static List<string> StripStringArray(string[] array) {
            List<string> newStringList = new List<string>();

            foreach (string arrayElement in array) {
                string strippedElement = Strip(arrayElement);
                if (strippedElement.Length == 0) continue;
                else newStringList.Add(strippedElement);
            }

            return newStringList;
        }

        /// <summary>
        /// Parses the commands into a directry that Commander can use. See <see cref="Commander"/>
        /// </summary>
        /// <param name="text">A string command</param>
        /// <returns>Directory with the command and its parameters cleanly separated</returns>
        public static CommandAndParameterParserResult CommandAndParameterParser(string text) {
            //prepare the parameters by stripping them of spaces
            string prepParameters = Strip(text);
            if (prepParameters.Length == 0) return null;

            //split the command from the parameters
            string[] splitCommand = prepParameters.Split(new char[] { " "[0] }, 2);
            string command = null;
            string[] parameters = null;

            //There are parameters, make the command
            if (splitCommand.Length > 0) {
                //set command var
                command = Strip(splitCommand[0]);
            }

            //There is at least one parameter
            if (splitCommand.Length > 1) {
                //seperate all of the parameters by a comma
                splitCommand = splitCommand[1].Split(","[0]);

                //Remove spaces around parameters
                splitCommand = StripStringArray(splitCommand).ToArray();

                //We don't want parameters if there aren't any
                if (!(splitCommand.Length == 1 && splitCommand[0] == "")) {
                    //set parameter list
                    parameters = splitCommand;
                }
            }

            return new CommandAndParameterParserResult(command, parameters);
        }
    }
}