using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value {

    /// <summary>
    /// This class contains a large amount of useful conversions
    /// </summary>
    public class ValueHelper {

        /// <summary>
        /// Converts string to int (if possible)
        /// </summary>
        /// <param name="text">String to be converted to int</param>
        /// <returns>Integer representation of string</returns>
        public static int ConvertToInt(string text) {
            text = SettingsAndHelperFunctions.Strip(text);
            return int.Parse(text);
        }

        /// <summary>
        /// Converts string to double (if possible)
        /// </summary>
        /// <param name="text">String to be converted to double</param>
        /// <returns>Double representation of string</returns>
        public static double ConvertToDouble(string text) {
            text = SettingsAndHelperFunctions.Strip(text);
            return double.Parse(text);
        }

        /// <summary>
        /// Converts two strings to a point object.
        /// </summary>
        /// <param name="text1">X parameter</param>
        /// <param name="text2">Y parameter</param>
        /// <returns>A Point object</returns>
        /// <todo>Make unit tests for this function</todo>
        public static Point ConvertToPoint(string text1, string text2) {
            return new Point(ConvertToInt(text1), ConvertToInt(text2));
        }

        //TODO: Make unit tests for this function
        /// <summary>
        /// This function convers text to Color.
        /// </summary>
        /// <remarks>
        /// It can parse several different types of strings.
        /// Types of string accepted:
        /// - A string that is the name of a predefined color. See <see cref="Color"/> class for full list.
        /// - A string that represents a Hex Triplet (<code>#rrggbb</code>). See <see href="https://en.wikipedia.org/wiki/Web_colors#Hex_triplet"/>.
        /// - A string that represents a Hex Quadruplet (<code>#rrggbbaa</code>, where <code>aa</code> represents alpha).
        /// </remarks>
        /// <example>
        /// Color tmp = TextToColor("red");
        /// Console.WriteLine("Name: " + tmp.toString()) //=> "red"
        ///
        /// tmp = TextToColor("deadbe");
        /// Console.WriteLine("Name: " + tmp.toString()) //=> "00deadbe"
        ///
        /// //It's important to remember that C# doesn't work like HTML colors, putting alpha first, rather than last.
        ///
        /// tmp = TextToColor("deadbeef");
        /// Console.WriteLine("Name: " + tmp.toString()) //=> "efdeadbe"
        /// </example>
        ///
        /// <param name="text">a string with a valid name or format</param>
        /// <returns>color of the string</returns>
        public static Color TextToColor(string text) {
            Color color = Color.FromName(text);
            if (color.IsKnownColor) return color;

            if (text.StartsWith("#"))
                text = text.Substring(1);

            switch (text.Length) {
                case 6:
                    return Color.FromArgb(
                        int.Parse(text.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(text.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(text.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));

                case 8:
                    return Color.FromArgb(
                        int.Parse(text.Substring(6, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(text.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(text.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(text.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));

                default:
                    throw new Exception("Color not valid");
            }
        }

        /// <summary>
        /// Generate a color from RGB(A) int values
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <param name="a">Optional: Alpha/Transparancy (default is 255, 0 is transparent)</param>
        /// <returns></returns>
        public static Color IntsToColor(int r, int g, int b, int a = 255) {
            return Color.FromArgb(a, r, g, b);
        }

        public static bool ConvertToBool(string text) {
            switch (text) {
                case "true":
                case "1":
                case "on":
                    return true;

                case "false":
                case "0":
                case "off":
                    return false;

                default:
                    throw new Exception("Invalid input");
            }
        }

        public static IValue ConvertToIValue(string text) {
            text = SettingsAndHelperFunctions.Strip(text);
            //No assignmnet
            if (!text.Contains("=")) {
                if (!text.Contains("#")) {
                    //Check if string is a number
                    if (!text.Contains("."))
                        try {
                            return ValueFactory.CreateValue(text, "int");
                        } catch (Exception e) { }

                    //Check if string is a double
                    else
                        try {
                            return ValueFactory.CreateValue(text, "double");
                        } catch (Exception e) { }
                }

                //Check if color
                try {
                    return ValueFactory.CreateValue(text, "color");
                } catch (Exception e) { }
            } else {
                //Check if string is a bool TODO

                //Check if string is an expression
                return ValueFactory.CreateValue(text, "expression");
            }
            throw new Exception("Could not convert " + text + " to any type");
        }

        public static Exception ConvertToExpression(string expression) {
            throw new NotImplementedException();
        }
    }
}