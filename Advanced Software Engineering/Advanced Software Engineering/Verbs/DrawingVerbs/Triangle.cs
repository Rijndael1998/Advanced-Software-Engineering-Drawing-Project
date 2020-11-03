using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// The Triangle Verb class
    /// </summary>
    public class Triangle : Verb {
        Verb verb;

        /// <summary>
        /// Creates a new Triangle instance using <see cref="RegularPolygon"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">the scale of the triangle</param>
        public Triangle(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 3, scale);
        }

        /// <summary>
        /// Creates a new Triangle instance using <see cref="RegularPolygon"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">the scale of the triangle</param>
        /// <param name="offset">the offset of the triangle in degrees</param>
        public Triangle(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 3, scale, offset);
        }

        /// <summary>
        /// Creates a new Triangle instance using <see cref="DrawLines"/>. It draws lines to the points provided
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <param name="point3">third point</param>
        public Triangle(Drawer drawer, Point point1, Point point2, Point point3) {
            verb = new DrawLines(drawer, new Point[] { point1, point2, point3 });
        }

        /// <summary>
        /// Executes the created verb, either <see cref="RegularPolygon"/> or <see cref="DrawLines"/>.
        /// </summary>
        public void ExecuteVerb() => verb.ExecuteVerb();

        /// <summary>
        /// Describes how the triangle will be drawn
        /// </summary>
        /// <returns>Description of how the triangle will be drawn</returns>
        public string GetDescription() => verb.GetDescription();
    }
}
