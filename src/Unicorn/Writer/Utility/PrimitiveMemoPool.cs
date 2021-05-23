using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Utility
{
    internal class PrimitiveMemoPool<K, V> where V: IPdfPrimitiveObject
    {
        private readonly IDictionary<K, PrimitiveMemoPoolMember<K, V>> _pool;

        private const int _maxPoolSize = 128;

        internal PrimitiveMemoPool()
        {
            _pool = new Dictionary<K, PrimitiveMemoPoolMember<K, V>>();
        }

        internal V this[K idx]
        {
            get
            {
                if (_pool.TryGetValue(idx, out PrimitiveMemoPoolMember<K, V> member))
                {
                    member.Count++;
                    return member.Object;
                }
                return default;
            }
        }

        internal void Cache(V item, Func<V, K> keySelector)
        {
            lock (_pool)
            {
                AgePool();
                PrunePool();
                K key = keySelector(item);
                if (!_pool.ContainsKey(key))
                {
                    _pool.Add(key, new PrimitiveMemoPoolMember<K, V>(key, item));
                }
                else
                {
                    _pool[key].Count++;
                }
            }
        }

        internal void Cache(V item, K key) => Cache(item, i => key);

        private void AgePool()
        {
            foreach (var member in _pool.Values)
            {
                member.Age++;
            }
        }

        private void PrunePool()
        {
            if (_pool.Count >= _maxPoolSize * 2)
            {
                int remCount = _pool.Count - _maxPoolSize;
                foreach (var key in _pool.Where(kv => kv.Value.Age > (_maxPoolSize / 8)).OrderBy(kv => kv.Value.Count).Take(remCount).Select(kv => kv.Key).ToArray())
                {
                    _pool.Remove(key);
                }
            }
        }
    }
}
