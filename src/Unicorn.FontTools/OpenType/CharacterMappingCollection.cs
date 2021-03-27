using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Read-only collection class for <see cref="CharacterMapping" /> instances.
    /// </summary>
    public class CharacterMappingCollection : IReadOnlyCollection<CharacterMapping>
    {
        private readonly CharacterMapping[] _arr;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The content of the collection.</param>
        public CharacterMappingCollection(IEnumerable<CharacterMapping> data)
        {
            if (data is null)
            {
                _arr = Array.Empty<CharacterMapping>();
            }
            else
            {
                _arr = data.ToArray();
            }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">The index of the item to return.</param>
        /// <returns>The specified element from the collection.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the parameter is less than zero or greater than or equal to the number of items in the 
        /// collection.</exception>
        public CharacterMapping this[int index] => _arr[index];

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count => _arr.Length;

        /// <summary>
        /// Get an enumerator for enumerating over the contents of the collection.
        /// </summary>
        /// <returns>An enumerator for this colletion.</returns>
        public IEnumerator<CharacterMapping> GetEnumerator() => _arr.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _arr.GetEnumerator();
    }
}
