using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn
{
    /// <summary>
    /// A collection class for <see cref="TableCell"/> implementations.  Base class of <see cref="TableRow"/> and <see cref="TableColumn"/>.
    /// </summary>
    public class TableCellCollection : IList<TableCell>
    {
        private readonly List<TableCell> _theList;
        private uint _version;

        /// <summary>
        /// The table containing this row or column (if any).
        /// </summary>
        public Table Parent { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TableCellCollection()
        {
            _theList = new List<TableCell>();
        }

        /// <summary>
        /// Gets or sets the cell at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the cell to get or set.</param>
        /// <returns>The cell at the specified index.</returns>
        public TableCell this[int index]
        {
            get
            {
                return _theList[index];
            }

            set
            {
                _version++;
                _theList[index] = value;
                ComputeCellDimensions();
            }
        }

        /// <summary>
        /// The number of cells in the collection.
        /// </summary>
        public int Count => _theList.Count;

        /// <summary>
        /// Whether the collection is read-only or not.  Returns false.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a cell to the collection and recompute the collection dimensions.
        /// </summary>
        /// <param name="item">The cell to add to the collection.</param>
        public void Add(TableCell item)
        {
            _version++;
            _theList.Add(item);
            ComputeCellDimensions();
        }

        /// <summary>
        /// Add a range of cells to the collection and recompute the collection dimensions.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<TableCell> items)
        {
            _version++;
            _theList.AddRange(items);
            ComputeCellDimensions();
        }

        /// <summary>
        /// Clear the contents of the collection.
        /// </summary>
        public void Clear()
        {
            _version++;
            _theList.Clear();
        }

        /// <summary>
        /// Determine whether the collection contains a specific cell.
        /// </summary>
        /// <param name="item">The cell to search the collection for.</param>
        /// <returns>True if the collection contains the cell, false otherwise.</returns>
        public bool Contains(TableCell item)
        {
            return _theList.Contains(item);
        }

        /// <summary>
        /// Copy the collection's contents to the given array.
        /// </summary>
        /// <param name="array">The array to copy the cell contents to.</param>
        /// <param name="arrayIndex">The index of the element of the array to copy the first element of the collection to.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the arrayIndex parameter is negative.</exception>
        /// <exception cref="ArgumentException">Thrown if the arrayIndex parameter is greater than the length of the array, or if the array does not have enough elements to contain the 
        /// collection.</exception>
        public void CopyTo(TableCell[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException(Resources.TableCellCollection_CopyTo_Error_InsufficientArrayLength, nameof(array));
            }

            for (int i = 0; i < Count; ++i)
            {
                array[arrayIndex + i] = _theList[i];
            }
        }

        /// <summary>
        /// Get an enumerator for this collection.
        /// </summary>
        /// <returns>An enumerator for this collection.</returns>
        public IEnumerator<TableCell> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Get the index in the collection of a given cell.
        /// </summary>
        /// <param name="item">The cell to search for in the collection.</param>
        /// <returns>The zero-based index of the given cell.</returns>
        public int IndexOf(TableCell item)
        {
            return _theList.IndexOf(item);
        }

        /// <summary>
        /// Insert a cell into the collection at a given location, and recompute the collection dimensions.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert the cell.</param>
        /// <param name="item">The cell to insert into the collection.</param>
        public void Insert(int index, TableCell item)
        {
            _version++;
            _theList.Insert(index, item);
            ComputeCellDimensions();
        }

        /// <summary>
        /// Remove a cell from the collection.
        /// </summary>
        /// <param name="item">The cell to remove.</param>
        /// <returns>True if the cell was removed from the collection; false if the cell was not a member of the collection.</returns>
        public bool Remove(TableCell item)
        {
            bool result = _theList.Remove(item);
            if (result)
            {
                _version++;
                ComputeCellDimensions();
            }
            return result;
        }

        /// <summary>
        /// Remove the cell at the given index from the collection.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _version++;
            _theList.RemoveAt(index);
            ComputeCellDimensions();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Recompute the dimensions of all cells in the collection.
        /// </summary>
        protected virtual void ComputeCellDimensions()
        {
            ComputeCellWidths();
            ComputeCellHeights();
        }

        /// <summary>
        /// Recompute the widths of all cells in the collection, setting all cell computed widths to the largest minimum width of all of the cells in the collection.
        /// </summary>
        protected virtual void ComputeCellWidths()
        {
            if (Count == 0)
            {
                return;
            }
            double width = _theList.Select(c => c.MinWidth).Max();
            foreach (TableCell cell in _theList)
            {
                cell.ComputedWidth = width;
            }
        }

        /// <summary>
        /// Recompute the heights of all cells in the collection, to match the largest minimum height of all cells in the collection.
        /// </summary>
        protected virtual void ComputeCellHeights()
        {
            if (Count == 0)
            {
                return;
            }
            double ascent = _theList.Select(c => c.MinAscent).Max();
            double descent = _theList.Select(c => c.MinDescent).Max();
            foreach (TableCell cell in _theList)
            {
                cell.ComputedBaseline = ascent;
                cell.ComputedHeight = ascent + descent;
            }
        }

        /// <summary>
        /// Enumerator for <see cref="TableCellCollection" />-derived instances.
        /// </summary>
        public class Enumerator : IEnumerator<TableCell>
        {
            private readonly TableCellCollection _collection;
            private int _curIdx;
            private readonly uint _ver;

            /// <summary>
            /// Constructs the enumerator for a given <see cref="TableCellCollection"/>.
            /// </summary>
            /// <param name="collection">The <see cref="TableCellCollection"/> to construct an enumerator for.</param>
            public Enumerator(TableCellCollection collection)
            {
                if (collection is null)
                {
                    throw new ArgumentNullException(nameof(collection));
                }

                _collection = collection;
                _curIdx = -1;
                Current = null;
                _ver = _collection._version;
            }

            private TableCell _current;

            /// <summary>
            /// Gets the currently-enumerated object.
            /// </summary>
            public TableCell Current 
            {
                get
                {
                    CheckCollectionModification();
                    return _current;
                }
                private set
                {
                    _current = value;
                }
            }

            /// <summary>
            /// Gets the currently-enumerated object.
            /// </summary>
            object IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Dispose of this enumerator.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Dispose of this enumerator.
            /// </summary>
            /// <param name="disposing">Whether or not to dispose of managed objects.</param>
            protected virtual void Dispose(bool disposing)
            {

            }

            /// <summary>
            /// Move the enumerator to the next object in the collection.
            /// </summary>
            /// <returns>True if the operation was succesful; false if the end of the collection has been reached.</returns>
            public bool MoveNext()
            {
                CheckCollectionModification();
                if (++_curIdx >= _collection.Count)
                {
                    return false;
                }
                Current = _collection[_curIdx];
                return true;
            }

            /// <summary>
            /// Resets the enumerator state, so that the enumerator is pointing before the start of the collection.
            /// </summary>
            public void Reset()
            {
                CheckCollectionModification();
                _curIdx = -1;
                Current = null;
            }

            private void CheckCollectionModification()
            {
                if (_ver != _collection._version)
                {
                    throw new InvalidOperationException(Resources.TableCellCollection_Enumerator_Error_CollectionModified);
                }
            }
        }
    }
}
