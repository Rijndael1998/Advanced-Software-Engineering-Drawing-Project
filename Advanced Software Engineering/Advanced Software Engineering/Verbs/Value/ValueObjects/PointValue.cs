using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueObjects {

    /// <summary>
    /// A point IValue. Simply the same as <see cref="Point"/> but with IValues intstead of ints.
    /// </summary>
    public class PointValue {
        private readonly IValue x;
        private readonly IValue y;

        /// <summary>
        /// Create a new PointValue
        /// </summary>
        /// <param name="x">X IValue</param>
        /// <param name="y">Y IValue</param>
        public PointValue(IValue x, IValue y) {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Get the X component
        /// </summary>
        /// <returns>the X component</returns>
        public int GetX() {
            return x.ToInt();
        }

        /// <summary>
        /// Get the Y component
        /// </summary>
        /// <returns>the Y component</returns>
        public int GetY() {
            return y.ToInt();
        }

        /// <summary>
        /// Get the <see cref="Point"/>.
        /// </summary>
        /// <returns><see cref="Point"/></returns>
        public Point GetPoint() {
            return new Point(GetX(), GetY());
        }
    }
}