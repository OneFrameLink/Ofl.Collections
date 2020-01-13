﻿using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyDictionaryExtensions
    {
        public static IReadOnlyDictionary<TToKey, TToValue> Cast<TFromKey, TFromValue, TToKey, TToValue>(
            this IReadOnlyDictionary<TFromKey, TFromValue> source)
            where TToKey : notnull
            where TFromKey : notnull, TToKey
            where TFromValue : TToValue
        {
            // Validate parameters.
            if (source == null) throw new ArgumentNullException(nameof(source));

            // Create the wrapper, return.
            return new CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue>(source);
        }
    }
}
