﻿using System;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key, TValue defaultValue)
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Get the value, if it fails, return default.
            return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            // Validate parameters.
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            // Call the overload.
            return dictionary.GetValueOrDefault(key, default);
        }
    }
}