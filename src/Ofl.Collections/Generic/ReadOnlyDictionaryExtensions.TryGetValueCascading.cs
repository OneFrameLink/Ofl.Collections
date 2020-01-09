using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static bool TryGetValueCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries,
            TKey key, out TValue value)
        {
            // Validate parameters.
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            // Set to the default.
            value = default;

            // Cycle through the dictionaries, first one
            // that can produce a result wins.
            foreach (ReadOnlyDictionary<TKey, TValue> dictionary in dictionaries)
                // If found, return.
                if (dictionary.TryGetValue(key, out value)) return true;

            // Return false.
            return false;
        }

        public static bool TryGetValueCascading<TKey, TValue>(TKey key, out TValue value, params ReadOnlyDictionary<TKey, TValue>[] dictionaries) =>
            dictionaries.TryGetValueCascading(key, out value);

        public static TValue? TryGetValueCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key)
            where TValue : struct => dictionaries.TryGetValueCascading(key, out TValue value) ? value : (TValue?)null;

        public static TValue? TryGetValueCascading<TKey, TValue>(TKey key, params ReadOnlyDictionary<TKey, TValue>[] dictionaries)
            where TValue : struct => dictionaries.TryGetValueCascading(key);
    }
}
