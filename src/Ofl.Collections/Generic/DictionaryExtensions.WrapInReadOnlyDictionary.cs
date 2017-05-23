using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class DictionaryExtensions
    {
        public static ReadOnlyDictionary<TKey, TValue> WrapInReadOnlyDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            // Wrap and return.
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}
