using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {
    /// <summary>
    /// This class simply provides settings and some functions that are used across many components.
    /// </summary>
    public class SettingsAndHelperFunctions {
        /// <summary>
        /// The variable simply keep track of the windows that are currently shown (excluding <see cref="MainMenu"/>).
        /// </summary>
        public static int NumberOfWindows = 0;

        /// <summary>
        /// This helper function is executed when a window is closed. It shows the <see cref="MainMenu"/> when the count is 0
        /// </summary>
        public static void WindowClosed() {
            NumberOfWindows--;
            if (NumberOfWindows == 0) {
                System.Console.WriteLine("Showing MainMenu");
                Program.MainMenu.Show();
            }

        }
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
            //Console.WriteLine("Stripping: '" + text + "'");
            int start;

            for (start = 0; start < text.Length; start++) {
                char character = text[start];
                if (character != " "[0]) break;
            }

            int end;

            for (end = text.Length - 1; end >= 0; end--) {
                char character = text[end];
                if (character != " "[0]) break;
            }

            if (end == -1) return "";

            string result = text.Substring(start, end - start + 1);

            //Console.WriteLine("Started at: " + start);
            //Console.WriteLine("Ended at:   " + end);
            //Console.WriteLine("Result:     " + result);

            return result;

        }

        public static int ConvertToInt(string text) {
            text = Strip(text);
            return int.Parse(text);
        }

        public static double ConvertToDouble(string text) {
            text = Strip(text);
            return double.Parse(text);
        }

        public static List<string> StripStringArray(string[] array) {
            List<string> newStringList = new List<string>();

            foreach (string arrayElement in array) {
                string strippedElement = Strip(arrayElement);
                if (strippedElement.Length == 0) continue;
                else newStringList.Add(strippedElement);
            }

            return newStringList;
        }

        public static Dictionary<string, string[]> CommandAndParameterParser(string text) {
            Dictionary<string, string[]> commandAndParameters = new Dictionary<string, string[]>();

            //prepare the parameters by stripping them of spaces
            string prepParameters = Strip(text);
            if (prepParameters.Length == 0) return commandAndParameters;

            //split the command from the parameters 
            string[] parameters = prepParameters.Split(new char[] { " "[0] }, 2);

            //There are parameters, make the command
            if (parameters.Length > 0) {
                //set command var
                string command = Strip(parameters[0]);
                commandAndParameters["command"] = new string[] { command };
            }

            //There is at least one parameter 
            if (parameters.Length > 1) {
                //seperate all of the parameters by a comma
                parameters = parameters[1].Split(","[0]);

                //Remove spaces around parameters
                parameters = StripStringArray(parameters).ToArray();

                //We don't want parameters if there aren't any
                if (!(parameters.Length == 1 && parameters[0] == "")) {
                    //set parameter list
                    commandAndParameters["parameters"] = parameters;
                }
            }

            return commandAndParameters;
        }
    }
}
