using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        [return: MaybeNull]
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries,
            TKey key,
            [AllowNull] TValue defaultValue
        )
            where TKey : notnull
        {
            // Validate parameters.
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            // Cycle through the dictionaries, first one
            // that can produce a result wins.
            foreach (ReadOnlyDictionary<TKey, TValue> dictionary in dictionaries)
                // If found, return.
                if (dictionary.TryGetValue(key, out var value)) return value;

            // Return the default value.
            return defaultValue;
        }

        [return: MaybeNull]
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(
            this IEnumerable<ReadOnlyDictionary<TKey, TValue>> dictionaries,
            TKey key)
            where TKey : notnull => dictionaries.GetValueOrDefaultCascading(key, default);
    }
}