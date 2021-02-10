using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class ComparisonValue : IValue {
        private readonly string op;
        private readonly IValue value1;
        private readonly IValue value2;

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
            return Evaluate().GetOriginalType();
        }

        public bool IsInitialised() {
            return true;
        }

        private IValue Evaluate() {
            switch (op) {
                case "=":
                    return new BoolValue(value1.ToBool() == value2.ToBool() && value1.ToDouble() == value2.ToDouble() && value1.ToInt() == value2.ToInt());

                case "!":
                    return new BoolValue(value1.ToBool() != value2.ToBool() && value1.ToDouble() != value2.ToDouble() && value1.ToInt() != value2.ToInt());

                case ">":
                    return new BoolValue(value1.ToDouble() > value2.ToDouble() && value1.ToInt() > value2.ToInt());

                case "<":
                    return new BoolValue(value1.ToDouble() < value2.ToDouble() && value1.ToInt() < value2.ToInt());

                default:
                    throw new Exception("Bad operator");
            }
        }

        public bool ToBool() {
            return Evaluate().ToBool();
        }

        public Color ToColor() {
            return Evaluate().ToColor();
        }

        public double ToDouble() {
            return Evaluate().ToDouble();
        }

        public int ToInt() {
            return Evaluate().ToInt();
        }

        public IValue Clone() {
            return new ComparisonValue(value1, value2, op);
        }
    }
}