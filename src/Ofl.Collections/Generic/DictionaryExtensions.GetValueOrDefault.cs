using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Ofl.Collections.Generic
{
    public static partial class DictionaryExtensions
    {
        [return: MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key, 
            [AllowNull] TValue defaultValue
        )
            where TKey : notnull
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Get the value, if it fails, return default.
            return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }

        [return: MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key
        )
            where TKey : notnull
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Call the overload.
            return dictionary.GetValueOrDefault(key, default);
        }
    }
}