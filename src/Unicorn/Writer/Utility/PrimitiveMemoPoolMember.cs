using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Utility
{
    internal class PrimitiveMemoPoolMember<K, V> where V : IPdfPrimitiveObject
    {
        internal K Key { get; private set; }

        internal V Object { get; private set; }

        internal int Count { get; set; }

        internal int Age { get; set; }

        internal PrimitiveMemoPoolMember(K key, V obj)
        {
            Key = key;
            Object = obj;
            Count = 0;
            Age = 0;
        }
    }
}
