using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// The Quadrilateral Verb class
    /// </summary>
    public class Quadrilateral : Verb {
        Verb verb;

        /// <summary>
        /// Creates a Quadrilateral instances
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <param name="point3">third point</param>
        /// <param name="point4">fourth point</param>
        public Quadrilateral(Drawer drawer, Point point1, Point point2, Point point3, Point point4) {
            verb = new DrawLines(drawer, new Point[] { point1, point2, point3, point4 });
        }

        /// <summary>
        /// Draws a quadrilateral from the points
        /// </summary>
        public void ExecuteVerb() => verb.ExecuteVerb();

        /// <summary>
        /// Describes all of the points
        /// </summary>
        /// <returns>Description of the quadrilateral points</returns>
        public string GetDescription() => verb.GetDescription();
    }
}
