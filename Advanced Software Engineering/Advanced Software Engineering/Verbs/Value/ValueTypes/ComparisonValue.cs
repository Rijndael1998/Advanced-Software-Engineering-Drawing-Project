using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class ComparisonValue : IValue {
        private string op;
        private IValue value1;
        private IValue value2;

        public ComparisonValue(IValue value1, IValue value2, string op) {
            this.value1 = value1;
            this.value2 = value2;

            switch (op) {
                case "=":
                case "!":
                case ">":
                case "<":
                    break;

                default:
                    throw new Exception("Invalid operation");
            }

            this.op = op;
        }

        public string GetDescription() {
            return "Compare two values";
        }

        public string GetOriginalType() {
            return "comparison";
        }

        public bool isInitialised() {
            return true;
        }

        public bool ToBool() {
            switch (op) {
                case "=":
                    return value1.ToBool() == value2.ToBool() && value1.ToDouble() == value2.ToDouble() && value1.ToInt() == value2.ToInt();

                case "!":
                    return value1.ToBool() != value2.ToBool() && value1.ToDouble() != value2.ToDouble() && value1.ToInt() != value2.ToInt();

                case ">":
                    return value1.ToDouble() > value2.ToDouble() && value1.ToInt() > value2.ToInt();

                case "<":
                    return value1.ToDouble() < value2.ToDouble() && value1.ToInt() < value2.ToInt();

                default:
                    throw new Exception("Bad operator");
            }
        }

        public Color ToColor() {
            throw new Exception("Cannot convert comparison to color");
        }

        public double ToDouble() {
            throw new Exception("Cannot convert comparison to double");
        }

        public int ToInt() {
            throw new Exception("Cannot convert comparison to int");
        }
    }
}