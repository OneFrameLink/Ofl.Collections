using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static ReadOnlyDictionary<TKey, TValue> Empty<TKey, TValue>() =>
            EmptyReadOnlyDictionarySingleton<TKey, TValue>.Instance;

        private static class EmptyReadOnlyDictionarySingleton<TKey, TValue>
        {
            internal static readonly ReadOnlyDictionary<TKey, TValue> Instance = 
                new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>());
        }
    }
}
