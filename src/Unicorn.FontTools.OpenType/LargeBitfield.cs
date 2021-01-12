using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Parent class for types which represent OpenType bitfields that are too wide to be stored as an enum value.
    /// </summary>
    public abstract class LargeBitfield
    {
        /// <summary>
        /// This method should return an array of methods which set properties of the concrete type.  The parameter of each method is an array of bools representing
        /// the bits of one byte.  The first method in the array should be for handling the first byte of the source data, and so on.
        /// </summary>
        /// <returns>An array of property-setting methods</returns>
        protected abstract Action<bool[]>[] SetterMethods();

        /// <summary>
        /// This method should return an array of property names.  The <see cref="ToString" /> implementation in this class will return a string consisting of the
        /// properties named in this array whose values are <c>true</c>, in the order specified in this array.
        /// </summary>
        /// <returns>An array of strings representing property names.</returns>
        protected abstract IEnumerable<string> StringificationProperties();

        private static bool[] MapByte(byte b) => new[]
        {
            (b & 0x01) != 0,
            (b & 0x02) != 0,
            (b & 0x04) != 0,
            (b & 0x08) != 0,
            (b & 0x10) != 0,
            (b & 0x20) != 0,
            (b & 0x40) != 0,
            (b & 0x80) != 0,
        };

        /// <summary>
        /// This method sets the properties of a concrete instance of this type, using the setter methods returned by the type's <see cref="SetterMethods" />
        /// implementation.
        /// </summary>
        /// <param name="data">The byte array containing source data.</param>
        /// <param name="offset">The location of the first byte of source data within the array</param>
        /// <exception cref="ArgumentNullException">Thrown if the <c>data</c> parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>offset</c> parameter does not index a block of bytes within the <c>data</c>
        ///   parameter that is at least as large as the length of the array returned by the <see cref="SetterMethods" /> method.</exception>
        protected void PopulateFromBytes(byte[] data, int offset)
        {
            Action<bool[]>[] setters = SetterMethods();
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (offset < 0 || offset > data.Length - setters.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            for (int i = 0; i < setters.Length; ++i)
            {
                setters[i](MapByte(data[offset + i]));
            }
        }

        /// <summary>
        /// Convert this <see cref="UnicodeRanges" /> instance to a string.
        /// </summary>
        /// <returns>A string indicating which properties of this instance are set to <c>true</c>.</returns>
        public override string ToString()
        {
            string[] setPropertyNames = GetActiveProperties(StringificationProperties()).ToArray();
            if (setPropertyNames.Length == 0)
            {
                return "Bit field: no flags set";
            }
            return "Bit field: " + string.Join("|", setPropertyNames);
        }

        private IEnumerable<string> GetActiveProperties(IEnumerable<string> propertyNames)
        {
            foreach (string name in propertyNames)
            {
                if (CheckPropertySet(name))
                {
                    yield return name;
                }
            }
        }

        private bool CheckPropertySet(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName, typeof(bool));
            return (bool)property.GetValue(this);
        }
    }
}
