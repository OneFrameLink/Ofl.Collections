using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class DictionaryExtensions
    {
        public static TValue? TryGetValue<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
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