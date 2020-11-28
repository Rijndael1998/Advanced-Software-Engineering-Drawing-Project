using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// A class that generates a RegularPolygon IVerb.
    /// </summary>
    public class RegularPolygon : IVerb {
        private readonly Drawer drawer;
        private readonly IValue sides;
        private readonly IValue scale;
        private readonly IValue offset;
        private readonly IValue degMode;

        /// <summary>
        /// Draws a regular polygon.
        /// See <see href="https://en.wikipedia.org/wiki/Regular_polygon"/>.
        /// See also <seealso href="https://www.mathsisfun.com/geometry/regular-polygons.html"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="sides">Number of sides in the regular polygon</param>
        /// <param name="scale">The scale of the regular polygon</param>
        /// <param name="offset">Rotation offset of the regular polygon</param>
        /// <param name="degMode">Default is true. If true, offset is in degrees. If false, offset is in gradians.</param>
        public RegularPolygon(Drawer drawer, IValue sides, IValue scale, IValue offset, IValue degMode) {
            this.sides = sides;
            this.scale = scale;
            this.drawer = drawer;
            this.offset = offset;
            this.degMode = degMode;
        }

        /// <summary>
        /// Draws the regular polygons
        /// </summary>
        public void ExecuteVerb() {
            double offset = this.offset.ToDouble();
            //if in degMode, convert the offset to radian
            if (degMode.ToBool()) offset = Math.PI * offset / 180;

            //Scale needs to be corercted to work correctly with Rectangle
            double scale = this.scale.ToInt() * 2 / Math.Sqrt(2);
            List<PointValue> points = new List<PointValue>();
            double constantAngleDelta = 2 * Math.PI / sides.ToInt();
            for (int side = 0; side < sides.ToInt(); side++) {
                double angle = (constantAngleDelta * side) + offset;

                double dx = scale * Math.Sin(angle);
                double dy = scale * Math.Cos(angle);

                points.Add(new PointValue(new IntValue((int)Math.Round(dx)), new IntValue((int)Math.Round(dy))));
            }
            new DrawLines(drawer, points.ToArray()).ExecuteVerb();
        }

        /// <summary>
        /// Describes how the regular polygon will be drawn
        /// </summary>
        /// <returns>A description of how the polygon will be drawn</returns>
        public string GetDescription() {
            return "Draws a regular polygon.";
        }
    }
}