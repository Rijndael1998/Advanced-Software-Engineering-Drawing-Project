using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs {
    public class Value {
        public static int ConvertToInt(string text) {
            text = SettingsAndHelperFunctions.Strip(text);
            return int.Parse(text);
        }

        public static double ConvertToDouble(string text) {
            text = SettingsAndHelperFunctions.Strip(text);
            return double.Parse(text);
        }

        //TODO: Make unit tests for this function
        public static Point ConvertToPoint(string text1, string text2) {
            return new Point(ConvertToInt(text1), ConvertToInt(text2));
        }

        //TODO: Make unit tests for this function
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

        public static Color IntsToColor(int r, int g, int b, int a = 0) {
            return Color.FromArgb(a, r, g, b);
        }
    }
}
