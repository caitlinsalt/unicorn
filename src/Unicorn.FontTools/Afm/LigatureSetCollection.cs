using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Collection class for <see cref="LigatureSet" />.
    /// </summary>
    public class LigatureSetCollection : IReadOnlyCollection<LigatureSet>
    {
        private readonly LigatureSet[] _arr;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="contents">The contents of the set.</param>
        public LigatureSetCollection(IEnumerable<LigatureSet> contents)
        {
            if (contents is null)
            {
                _arr = Array.Empty<LigatureSet>();
            }
            else
            {
                _arr = contents.ToArray();
            }
        }

        /// <summary>
        /// The number of elements in the set.
        /// </summary>
        public int Count => _arr.Length;

        /// <summary>
        /// Get an enumerator for the set.
        /// </summary>
        /// <returns>An <see cref="IEnumerator&lt;LigatureSet&gt;" />.</returns>
        public IEnumerator<LigatureSet> GetEnumerator() => ((IEnumerable<LigatureSet>)_arr).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _arr.GetEnumerator();

        /// <summary>
        /// Get members of the set by index.
        /// </summary>
        /// <param name="i">The index of the item to get.</param>
        /// <returns>A <see cref="LigatureSet" /> value.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the parameter is not a valid index into the set.</exception>
        public LigatureSet this[int i]
        {
            get => _arr[i];
        }

        /// <summary>
        /// Get members of the set by character name of the second character, if they exist.
        /// </summary>
        /// <param name="name">The name of the <see cref="LigatureSet.Second" /> property of the value we are searching for.</param>
        /// <returns>A <see cref="LigatureSet" /> value whose <see cref="LigatureSet.Second" /> property equals the parameter, or <c>null</c>.</returns>
        public LigatureSet? this[string name]
        {
            get
            {
                LigatureSet found = _arr.FirstOrDefault(s => s.Second.Name == name);
                if (found == default)
                {
                    return null;
                }
                return found;
            }
        }
    }
}
