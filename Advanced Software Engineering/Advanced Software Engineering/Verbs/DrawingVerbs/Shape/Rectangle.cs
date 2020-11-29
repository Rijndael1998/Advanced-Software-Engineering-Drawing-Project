using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// Rectangle IVerb class
    /// </summary>
    /// <todo>
    /// Correct
    /// </todo>
    public class Rectangle : IVerb {
        private readonly PointValue[] points;

        private readonly IVerb verb;

        /// <summary>
        /// Create a rectangle instance. Makes sure that
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="width">rectangle width</param>
        /// <param name="height">rectangle height</param>
        public Rectangle(Drawer drawer, IValue width, IValue height) {
            IValue negativeWidth = new ExpressionValue(new IntValue(0), width, ExpressionValue.SUBTRACT);
            IValue negativeHeight = new ExpressionValue(new IntValue(0), height, ExpressionValue.SUBTRACT);

            points = new PointValue[]
            {
                new PointValue(negativeWidth, negativeHeight),
                new PointValue(width, negativeHeight),
                new PointValue(width, height),
                new PointValue(negativeWidth, negativeHeight)
            };

            verb = new DrawLines(drawer, points);
        }

        /// <summary>
        /// Gets the description from the rectangle
        /// </summary>
        /// <returns>Describes the rectangle</returns>
        public string GetDescription() {
            return "Draws a rectangle with the pen in the center";
        }

        /// <summary>
        /// Draws the rectangle
        /// </summary>
        public void ExecuteVerb() {
            verb.ExecuteVerb();
        }
    }
}