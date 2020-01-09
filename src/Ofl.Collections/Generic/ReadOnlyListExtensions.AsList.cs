using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ofl.Collections.Generic
{
    public static partial class ReadOnlyListExtensions
    {
        public static IList<T> AsList<T>(this IReadOnlyList<T> list)
        {
            // Validate parameters.
            if (list == null) throw new ArgumentNullException(nameof(list));

            // If this is a read only collection, no need to allocate extra.
            return list is ReadOnlyCollection<T> c
                ? (IList<T>) c
                : new ReadOnlyListWrapper<T>(list);
        }
    }
}
