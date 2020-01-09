using System;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static TValue? TryGetValue<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
            where TValue : struct
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            // Return null if not found.
            return dictionary.TryGetValue(key, out TValue value) ? value : (TValue?) null;
        }
    }
}
