using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    class Value {
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
    }
}
