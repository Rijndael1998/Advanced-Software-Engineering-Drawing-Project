using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class ValueFactory {

        /// <summary>
        /// Creates a constant Value to be used later during execution
        /// </summary>
        /// <param name="value">Text representation of the value</param>
        /// <param name="type">What type the value should be</param>
        /// <returns></returns>
        public static IValue CreateValue(string value, string type) {
            switch (type) {
                case "int":
                    return new IntValue(ValueHelper.ConvertToInt(value));

                case "double":
                    return new DoubleValue(ValueHelper.ConvertToDouble(value));

                case "color":
                    return new ColorValue(ValueHelper.TextToColor(value));

                case "bool":
                    return new BoolValue(ValueHelper.ConvertToBool(value));

                default:
                    throw new Exception("Unknown expected type: " + type.ToString());
            }
        }

        public static IValue CreateValue(bool b) {
            return new BoolValue(b);
        }

        public static IValue CreateValue(double d) {
            return new DoubleValue(d);
        }

        public static IValue CreateValue(int i) {
            return new IntValue(i);
        }
    }
}