namespace Advanced_Software_Engineering
{
    public static class Converters
    {
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
        public static string Strip(string text)
        {
            int start;

            for (start = 0; start < text.Length; start++)
            {
                char character = text[start];
                if (character != " "[0]) break;
            }

            int end;

            for (end = text.Length - 1; end >= 0; end--)
            {
                char character = text[end];
                if (character != " "[0]) break;
            }

            return text.Substring(start, end);

        }

        public static int ConvertToInt(string text)
        {
            text = Strip(text);
            return int.Parse(text);
        }

        public static List<string> StripStringArray(string[] array)
        {
            List<string> newStringList = new List<string>();

            foreach (string arrayElement in array)
            {
                string strippedElement = Strip(arrayElement);
                if (strippedElement.Length == 0) continue;
                else newStringList.Add(strippedElement);
            }

            return newStringList;
        }

        public static Dictionary<string, string[]> CommandAndParameterParser(string text)
        {
            Dictionary<string, string[]> commandAndParameters = new Dictionary<string, string[]>();

            //split the command from the parameters 
            string[] parameters = Strip(text).Split(new char[] { " "[0] }, 2);

            //set command var
            string command = Strip(parameters[0]);
            commandAndParameters["command"] = new string[] { command };

            //seperate all of the parameters by a comma
            parameters = parameters[1].Split(","[0]);

            //Remove spaces around parameters
            parameters = StripStringArray(parameters).ToArray();

            //set parameter list
            commandAndParameters["parameters"] = parameters;

            return commandAndParameters;
        }
    }
}