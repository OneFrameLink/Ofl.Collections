﻿using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class DictionaryExtensions
    {
        public static bool TryGetValueCascading<TKey, TValue>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries,
            TKey key, out TValue value)
        {
            // Validate parameters.
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            // Set to the default.
            value = default(TValue);

            // Cycle through the dictionaries, first one
            // that can produce a result wins.
            foreach (IDictionary<TKey, TValue> dictionary in dictionaries)
                // If found, return.
                if (dictionary.TryGetValue(key, out value)) return true;

            // Return false.
            return false;
        }

        public static bool TryGetValueCascading<TKey, TValue>(TKey key, out TValue value, params IDictionary<TKey, TValue>[] dictionaries) =>
            dictionaries.TryGetValueCascading(key, out value);

        public static TValue? TryGetValueCascading<TKey, TValue>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries, TKey key)
            where TValue : struct => dictionaries.TryGetValueCascading(key, out TValue value) ? value : (TValue?) null;

        public static TValue? TryGetValueCascading<TKey, TValue>(TKey key, params IDictionary<TKey, TValue>[] dictionaries)
            where TValue : struct => dictionaries.TryGetValueCascading(key);
    }
}