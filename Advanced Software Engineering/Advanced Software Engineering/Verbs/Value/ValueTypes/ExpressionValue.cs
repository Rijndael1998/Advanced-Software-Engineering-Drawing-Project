using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value {

    /// <summary>
    /// Expression values are used when there are two IValues that need to be added or subtracted or anything from each other.
    /// </summary>
    public class ExpressionValue : IValue {

        /// <summary>
        /// An operation denoting addition
        /// </summary>
        public const int ADD = 0;

        /// <summary>
        /// An operation denoting subtraction
        /// </summary>
        public const int SUBTRACT = 1;

        /// <summary>
        /// An operation denoting multiplication
        /// </summary>
        public const int MULTIPLY = 2;

        /// <summary>
        /// An operation denoting division
        /// </summary>
        public const int DIVIDE = 3;

        private readonly IValue variable1;
        private readonly IValue variable2;
        private readonly int operation;

        /// <summary>
        /// Create a new Expression Value based on the two IValues
        /// </summary>
        /// <param name="variable1">IValue to perform the operation on</param>
        /// <param name="variable2">IValue to perform the operation on</param>
        /// <param name="operation">The operation. Can be <see cref="ADD"/>, <see cref="SUBTRACT"/>, <see cref="MULTIPLY"/> or <see cref="DIVIDE"/>.</param>
        public ExpressionValue(IValue variable1, IValue variable2, int operation) {
            this.variable1 = variable1;
            this.variable2 = variable2;
            this.operation = operation;

            //Check for bad input
            if (operation > 3 && operation < 0) throw new Exception("Bad operation");
        }

        /// <summary>
        /// Create a new Expression Value based on the two IValues
        /// </summary>
        /// <param name="variable1">IValue to perform the operation on</param>
        /// <param name="variable2">IValue to perform the operation on</param>
        /// <param name="operation">The operation. Can be "+"(<see cref="ADD"/>), "-"(<see cref="SUBTRACT"/>), "*"(<see cref="MULTIPLY"/>) or "/"(<see cref="DIVIDE"/>).</param>
        public ExpressionValue(IValue variable1, IValue variable2, string operation) {
            switch (operation) {
                case "+":
                    this.operation = ADD;
                    break;

                case "-":
                    this.operation = SUBTRACT;
                    break;

                case "*":
                    this.operation = MULTIPLY;
                    break;

                case "/":
                    this.operation = DIVIDE;
                    break;

                default:
                    throw new Exception("Undefined operation");
            }

            this.variable1 = variable1;
            this.variable2 = variable2;

            //Check for bad input
            if (this.operation > 3 && this.operation < 0) throw new Exception("Bad operation");
        }

        /// <summary>
        /// Evaluates the expression.
        /// </summary>
        /// <returns>an IValue with the result</returns>
        private IValue Evaluate() {
            IValue variable1 = this.variable1.Clone();
            IValue variable2 = this.variable2.Clone();
            IValue evaluatedValue = null;
            string outputType = variable1.GetOriginalType();

            switch (outputType) {
                case "bool":
                    //operations as standard for bool expressions eg
                    // (a + b) => a or b, (a * b) => a and b, (a ^ b) => a xor b
                    if (operation == ADD) evaluatedValue = ValueFactory.CreateValue(variable1.ToBool() || variable2.ToBool());
                    else if (operation == SUBTRACT) evaluatedValue = ValueFactory.CreateValue(variable1.ToBool() ^ variable2.ToBool());
                    else if (operation == MULTIPLY) evaluatedValue = ValueFactory.CreateValue(variable1.ToBool() && variable2.ToBool());
                    else if (operation == DIVIDE) throw new Exception("Bool cannot be divided");
                    else throw new Exception("Bad operation");
                    break;

                case "int":
                    if (operation == ADD) evaluatedValue = ValueFactory.CreateValue(variable1.ToInt() + variable2.ToInt());
                    else if (operation == SUBTRACT) evaluatedValue = ValueFactory.CreateValue(variable1.ToInt() - variable2.ToInt());
                    else if (operation == MULTIPLY) evaluatedValue = ValueFactory.CreateValue(variable1.ToInt() * variable2.ToInt());
                    else if (operation == DIVIDE) evaluatedValue = ValueFactory.CreateValue(variable1.ToInt() / variable2.ToInt());
                    else throw new Exception("Bad operation");
                    break;

                case "double":
                    if (operation == ADD) evaluatedValue = ValueFactory.CreateValue(variable1.ToDouble() + variable2.ToDouble());
                    else if (operation == SUBTRACT) evaluatedValue = ValueFactory.CreateValue(variable1.ToDouble() - variable2.ToDouble());
                    else if (operation == MULTIPLY) evaluatedValue = ValueFactory.CreateValue(variable1.ToDouble() * variable2.ToDouble());
                    else if (operation == DIVIDE) evaluatedValue = ValueFactory.CreateValue(variable1.ToDouble() / variable2.ToDouble());
                    else throw new Exception("Bad operation");
                    break;

                case "color":
                    throw new Exception("Colors are immutable");
            }

            return evaluatedValue;
        }

        /// <summary>
        /// Describes the expression
        /// </summary>
        /// <returns>A string description of the expression</returns>
        public string GetDescription() {
            string operation;
            switch (this.operation) {
                case ADD:
                    operation = "added";
                    break;

                case SUBTRACT:
                    operation = "subtracted";
                    break;

                case MULTIPLY:
                    operation = "multiplied";
                    break;

                case DIVIDE:
                    operation = "divided";
                    break;

                default:
                    throw new Exception("Bad operation");
            }
            return "Expression of the variables " + variable1 + " and " + variable2 + " being " + operation;
        }

        /// <summary>
        /// Get the type of the expression
        /// </summary>
        /// <returns>"expression"</returns>
        public string GetOriginalType() {
            return "expression";
        }

        /// <summary>
        /// Expressions are always initialised
        /// </summary>
        /// <returns>true</returns>
        public bool IsInitialised() {
            return true;
        }

        /// <summary>
        /// Gets the bool of the result
        /// </summary>
        /// <returns>bool value of the result</returns>
        public bool ToBool() {
            return Evaluate().ToBool();
        }

        /// <summary>
        /// Gets the color of the result
        /// </summary>
        /// <returns>color value of the result</returns>
        public Color ToColor() {
            return Evaluate().ToColor();
        }

        /// <summary>
        /// Gets the double value of the result
        /// </summary>
        /// <returns>double value of the result</returns>
        public double ToDouble() {
            return Evaluate().ToDouble();
        }

        /// <summary>
        /// Gets the int of the result
        /// </summary>
        /// <returns>int value of the result</returns>
        public int ToInt() {
            return Evaluate().ToInt();
        }

        /// <summary>
        /// Clones the value of the result
        /// </summary>
        /// <returns>A new IValue</returns>
        public IValue Clone() {
            return Evaluate();
        }
    }
}