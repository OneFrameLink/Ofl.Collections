using System;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static TValue? TryGetValue<TKey, TValue>(
            this ReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key            
        )
            where TKey : notnull
            where TValue : struct
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Get the value, if it fails, return default.
            return dictionary.TryGetValue(key, out TValue value) ? value : (TValue?) null;
        }
    }
}