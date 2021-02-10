using Advanced_Software_Engineering.Verbs.Value.ValueObjects;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The Quadrilateral IVerb class
    /// </summary>
    public class Quadrilateral : IVerb {
        private readonly IVerb IVerb;

        /// <summary>
        /// Creates a Quadrilateral instances
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <param name="point3">third point</param>
        /// <param name="point4">fourth point</param>
        public Quadrilateral(Drawer drawer, PointValue point1, PointValue point2, PointValue point3, PointValue point4) {
            IVerb = new DrawLines(drawer, new PointValue[] { point1, point2, point3, point4 });
        }

        /// <summary>
        /// Draws a quadrilateral from the points
        /// </summary>
        public void ExecuteVerb() => IVerb.ExecuteVerb();

        /// <summary>
        /// Describes all of the points
        /// </summary>
        /// <returns>Description of the quadrilateral points</returns>
        public string GetDescription() => IVerb.GetDescription();
    }
}