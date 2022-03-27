namespace Unicorn.Base
{
    /// <summary>
    /// Rotations by 90 degrees.
    /// </summary>
    public enum RightAngleRotation
    {
        /// <summary>
        /// No rotation.
        /// </summary>
        None,

        /// <summary>
        /// Clockwise 90 degrees or anticlockwise 270 degrees ("to the right").
        /// </summary>
        Clockwise90,

        /// <summary>
        /// 180 degrees.
        /// </summary>
        Full180,

        /// <summary>
        /// Clockwise 270 degrees or anticlockwise 90 degrees ("to the left").
        /// </summary>
        Anticlockwise90
    }
}
