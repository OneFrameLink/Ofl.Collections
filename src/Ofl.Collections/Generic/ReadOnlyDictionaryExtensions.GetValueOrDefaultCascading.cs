using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries,
            TKey key, TValue defaultValue)
        {
            // Validate parameters.
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Try and get the value cascading, if false, return
            // default.
            return dictionaries.TryGetValueCascading(key, out TValue value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefaultCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries,
            TKey key) => dictionaries.GetValueOrDefaultCascading(key, default);
    }
}
