using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyListExtensions
    {
        public static IList<T> AsList<T>(this IReadOnlyList<T> list)
        {
            // Validate parameters.
            if (list == null) throw new ArgumentNullException(nameof(list));

            // Wrap and return.
            return new ReadOnlyListWrapper<T>(list);
        }
    }
}
