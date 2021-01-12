using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Collection class for <see cref="KerningPair" /> values.  This class implements <see cref="IReadOnlyCollection{KerningPair}" /> but also contains an
    /// <c>internal</c> <c>Add()</c> method to make its workflow more straightforward.
    /// </summary>
    public class KerningPairCollection : IReadOnlyCollection<KerningPair>
    {
        private readonly List<KerningPair> _list;

        /// <summary>
        /// Constructor with content provided.
        /// </summary>
        /// <param name="content">The content of the collection.</param>
        public KerningPairCollection(IEnumerable<KerningPair> content)
        {
            if (content is null)
            {
                _list = new List<KerningPair>();
            }
            else
            {
                _list = content.ToList();
            }
        }

        /// <summary>
        /// Constructor to create an empty collection.
        /// </summary>
        public KerningPairCollection()
        {
            _list = new List<KerningPair>();
        }

        /// <summary>
        /// Number of items in the collection.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Create an enumerator for the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{KerningPair}" /> instance.</returns>
        public IEnumerator<KerningPair> GetEnumerator() => _list.GetEnumerator();

        /// <summary>
        /// Integer indexer.  Returns elements of the collection by index.
        /// </summary>
        /// <param name="i">The index of the item to retrieve.</param>
        /// <returns>The specified item in the collection.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is negative, or is equal to or greater than the <see cref="KerningPairCollection.Count" />
        /// property.</exception>
        public KerningPair this[int i]
        {
            get => _list[i];
        }

        /// <summary>
        /// String indexer.  Searches for a kerning pair whose <see cref="KerningPair.Second" /> character has the given name.
        /// </summary>
        /// <param name="name">The name of a character to search for.</param>
        /// <returns>A <see cref="KerningPair" /> value whose second character has the given name, or <c>null</c> if no such pair exists in the collection.</returns>
        public KerningPair? this[string name]
        {
            get
            {
                KerningPair found = _list.FirstOrDefault(s => s.Second.Name == name);
                if (found == default)
                {
                    return null;
                }
                return found;
            }
        }

        internal void Add(KerningPair kerningPair)
        {
            _list.Add(kerningPair);
        }

        IEnumerator IEnumerable.GetEnumerator() => _list.AsEnumerable().GetEnumerator();
    }
}
