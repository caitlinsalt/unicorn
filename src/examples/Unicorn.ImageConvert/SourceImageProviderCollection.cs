using System.Collections;

namespace Unicorn.ImageConvert
{
    public class SourceImageProviderCollection : ICollection<SourceImageProvider>, IDisposable
    {
        private bool _disposed;
        private readonly List<SourceImageProvider> _underlying = new();

        public int Count => _underlying.Count;

        public bool IsReadOnly => false;

        public void Add(SourceImageProvider item)
        {
            _underlying.Add(item);
        }

        public void Clear()
        {
            foreach (var item in _underlying)
            {
                item.Dispose();
            }
            _underlying.Clear();
        }

        public bool Contains(SourceImageProvider item) => _underlying.Contains(item);

        public void CopyTo(SourceImageProvider[] array, int arrayIndex)
        {
            _underlying.CopyTo(array, arrayIndex);
        }

        public bool Remove(SourceImageProvider item) => _underlying.Remove(item);

        public IEnumerator<SourceImageProvider> GetEnumerator() => _underlying.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _underlying.GetEnumerator();

        #region Dispose implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Clear();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
