namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The Square Verb class
    /// </summary>
    public class Square : Verb {
        private Verb verb;

        /// <summary>
        /// A new Squre instance. Draws squares using <see cref="RegularPolygon"/>
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">size of the square</param>
        public Square(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 4, scale);
        }

        /// <summary>
        /// A new Squre instance. Draws squares using <see cref="RegularPolygon"/>
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">size of the square</param>
        /// <param name="offset">rotation offset in degrees</param>
        public Square(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 4, scale, offset);
        }

        /// <summary>
        /// Draws the regular polygon (square)
        /// </summary>
        public void ExecuteVerb() => verb.ExecuteVerb();

        /// <summary>
        /// Gets description of how it will draw the regular polygon (square)
        /// </summary>
        /// <returns></returns>
        public string GetDescription() => verb.GetDescription();
    }
}