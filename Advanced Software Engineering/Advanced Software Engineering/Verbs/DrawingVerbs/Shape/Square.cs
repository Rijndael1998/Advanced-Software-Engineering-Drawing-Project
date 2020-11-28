using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The Square IVerb class
    /// </summary>
    public class Square : IVerb {
        private readonly IVerb IVerb;

        /// <summary>
        /// A new Squre instance. Draws squares using <see cref="RegularPolygon"/>
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">size of the square</param>
        public Square(Drawer drawer, IValue scale) {
            IVerb = new RegularPolygon(drawer, new IntValue(4), scale, new IntValue(0), new BoolValue(true));
        }

        /// <summary>
        /// A new Squre instance. Draws squares using <see cref="RegularPolygon"/>
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">size of the square</param>
        /// <param name="offset">rotation offset in degrees</param>
        public Square(Drawer drawer, IValue scale, IValue offset) {
            IVerb = new RegularPolygon(drawer, new IntValue(4), scale, offset, new BoolValue(true));
        }

        /// <summary>
        /// Draws the regular polygon (square)
        /// </summary>
        public void ExecuteVerb() => IVerb.ExecuteVerb();

        /// <summary>
        /// Gets description of how it will draw the regular polygon (square)
        /// </summary>
        /// <returns></returns>
        public string GetDescription() => IVerb.GetDescription();
    }
}