using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The Triangle IVerb class
    /// </summary>
    public class Triangle : IVerb {
        private readonly IVerb IVerb;

        /// <summary>
        /// Creates a new Triangle instance using <see cref="RegularPolygon"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">the scale of the triangle</param>
        public Triangle(Drawer drawer, IValue scale) {
            IVerb = new RegularPolygon(drawer, new IntValue(3), scale, new IntValue(0), new BoolValue(true));
        }

        /// <summary>
        /// Creates a new Triangle instance using <see cref="RegularPolygon"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">the scale of the triangle</param>
        /// <param name="offset">the offset of the triangle in degrees</param>
        public Triangle(Drawer drawer, IValue scale, IValue offset) {
            IVerb = new RegularPolygon(drawer, new IntValue(3), scale, offset, new BoolValue(true));
        }

        /// <summary>
        /// Creates a new Triangle instance using <see cref="DrawLines"/>. It draws lines to the points provided
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <param name="point3">third point</param>
        public Triangle(Drawer drawer, PointValue point1, PointValue point2, PointValue point3) {
            IVerb = new DrawLines(drawer, new PointValue[] { point1, point2, point3 });
        }

        /// <summary>
        /// Executes the created IVerb, either <see cref="RegularPolygon"/> or <see cref="DrawLines"/>.
        /// </summary>
        public void ExecuteVerb() => IVerb.ExecuteVerb();

        /// <summary>
        /// Describes how the triangle will be drawn
        /// </summary>
        /// <returns>Description of how the triangle will be drawn</returns>
        public string GetDescription() => IVerb.GetDescription();
    }
}