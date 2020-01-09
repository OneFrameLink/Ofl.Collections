using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class DictionaryExtensions
    {
        public static TValue? TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            TKey key)
            where TValue : struct
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Return null if not found.
            return dictionary.TryGetValue(key, out TValue value) ? value : (TValue?) null;
        }
    }
}
