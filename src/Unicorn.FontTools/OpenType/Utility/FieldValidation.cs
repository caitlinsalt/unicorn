using System;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Helper class to provide validation routines.  This class is primarily intended to ensure that parameters passed to a CLS-compliant API are within the 
    /// narrower, non-CLS-compliant range of values required by the OpenType spec.
    /// </summary>
    public static class FieldValidation
    {
        /// <summary>
        /// Validate that an <see cref="int" /> value is within the range of a <see cref="ushort" />.  This routine is intended to be called to validate method
        /// arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <param name="name">The name of the argument being validated, for use if an exception must be thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>value</c> argument is less than 0 or greater than 65,535.  The 
        ///   <see cref="ArgumentException.ParamName" /> property will equal the <c>name</c> parameter value, rather than <c>value</c>.</exception>
        public static void ValidateUShortParameter(int value, string name) => ValidateUShortParameter(value, name, 
            Resources.FieldValidation_ValidateUShortParameter_Error);

        private static void ValidateUShortParameter(int value, string name, string error)
        {
            if (value < 0 || value > ushort.MaxValue)
            {
                throw new ArgumentOutOfRangeException(name, error);
            }
        }

        /// <summary>
        /// Validate that every member of an array of <see cref="int" /> values is within the range of a <see cref="ushort" /> value.  This routine is intended to
        /// be called to validate method arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="values">The array of values to be validated.</param>
        /// <param name="name">The name of the argument being validated, for use if an exception must be thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any member of the array is less than 0 or greater than 65,535.  The 
        ///   <see cref="ArgumentException.ParamName" /> property will equal the <c>name</c> parameter value, rather than <c>value</c>.</exception>
        public static void ValidateArrayOfUShortParameter(int[] values, string name)
        {
            if (values is null)
            {
                throw new ArgumentNullException(name);
            }
            foreach (int v in values)
            {
                ValidateUShortParameter(v, name, Resources.FieldValidation_ValidateArrayOfUShortParameter_Error);
            }
        }

        /// <summary>
        /// Validate that every member of an <see cref="IEnumerable{T}"/> where <c>T</c> is <see cref="int"/> is within the range of a <see cref="ushort" /> value, 
        /// and return an array of <see cref="ushort"/> containing the enumeration's members.  This method consumes the enumeration.  It is intended to be called to 
        /// validate and cast method arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="values">The enumeration to be validated and cast.</param>
        /// <param name="name">The name of the argument being processed, for use if an exception must be thrown.</param>
        /// <returns>An array of <see cref="ushort" /> values consisting of the cast elements of the <c>values</c> parameter.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any member of the enumeration is less than 0 or greater than 65,535.  The
        ///   <see cref="ArgumentException.ParamName" /> property will equal the <c>name</c> parameter value, rather than <c>values</c>.</exception>
        [CLSCompliant(false)]
        public static ushort[] ValidateAndCastIEnumerableOfUShortParameter(IEnumerable<int> values, string name)
        {
            int[] tmpArray = values.ToArray();
            ValidateArrayOfUShortParameter(tmpArray, name);
            return tmpArray.Cast<ushort>().ToArray();
        }

        /// <summary>
        /// Validate that a <see cref="long" /> value is within the range of a <see cref="uint" />.  This routine is intended to be called to validate method
        /// arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <param name="name">The name of the argument being validated, for use if an exception must be thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>value</c> argument is less than 0 or greater than the maximum value of an unsigned int.  The 
        ///   <see cref="ArgumentException.ParamName" /> property will equal the <c>name</c> parameter value, rather than <c>value</c>.</exception>
        public static void ValidateUIntParameter(long value, string name)
        {
            if (value < 0 || value > uint.MaxValue)
            {
                throw new ArgumentOutOfRangeException(name, Resources.FieldValidation_ValidateUIntParameter_Error);
            }
        }

        /// <summary>
        /// Validate that a <see cref="long" /> value is zero or greater.  This routine is intended to be called to validate method
        /// arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <param name="name">The name of the argument being validated, for use if an exception must be thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>value</c> argument is less than 0.  The <see cref="ArgumentException.ParamName" /> 
        ///   property will equal the <c>name</c> parameter value, rather than <c>value</c>.</exception>
        public static void ValidateNonNegativeIntegerParameter(long value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, Resources.FieldValidation_ValidateNonNegativeLongParameter_Error);
            }
        }

        /// <summary>
        /// Validate that a <see cref="int" /> value is zero or greater.  This routine is intended to be called to validate method
        /// arguments, so throws <see cref="ArgumentOutOfRangeException" /> if the validation fails.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <param name="name">The name of the argument being validated, for use if an exception must be thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>value</c> argument is less than 0.  The <see cref="ArgumentException.ParamName" /> 
        ///   property will equal the <c>name</c> parameter value, rather than <c>value</c>.</exception>
        public static void ValidateNonNegativeIntegerParameter(int value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, Resources.FieldValidation_ValidateNonNegativeIntParameter_Error);
            }
        }
    }
}
