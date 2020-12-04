using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value {

    /// <summary>
    /// A value
    /// </summary>
    public interface IValue {

        /// <summary>
        /// The description of the value
        /// </summary>
        /// <returns>The description of the IValue</returns>
        string GetDescription();

        /// <summary>
        /// Converts the value to an integer
        /// </summary>
        /// <returns>the integer representation if the IValue</returns>
        int ToInt();

        /// <summary>
        /// Get the double representation if the IValue
        /// </summary>
        /// <returns>the double representation if the IValue</returns>
        double ToDouble();

        /// <summary>
        /// Get the boolean representation if the IValue
        /// </summary>
        /// <returns>the boolean representation if the IValue</returns>
        bool ToBool();

        /// <summary>
        /// Get the color representation if the IValue
        /// </summary>
        /// <returns>the color representation if the IValue</returns>
        Color ToColor();

        /// <summary>
        /// Gets the original type of the IValue
        /// </summary>
        /// <returns>original type of the IValue</returns>
        string GetOriginalType();

        /// <summary>
        /// Checks if the IValue is initialised
        /// </summary>
        /// <returns>True if IValue is initialised</returns>
        bool isInitialised();

        /// <summary>
        /// Clones the IValue
        /// </summary>
        /// <returns></returns>
        IValue Clone();
    }
}