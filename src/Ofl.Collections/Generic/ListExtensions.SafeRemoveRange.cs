using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class ListExtensions
    {
        public static void SafeRemoveRange<T>(this List<T> source, int index, int count)
        {
            // Validate parameters.
            if (source == null) throw new ArgumentNullException(nameof(source));

            // If the index is less than 0 or the count is less than 0, then
            // just get out.
            if (index < 0 || count < 0) return;

            // If the index is greater than or equal the number
            // of elements, get out.
            if (index >= source.Count) return;

            // Take the min of the count of the list minus index
            // and the count minus the index.
            count = Math.Min(count, source.Count) - index;

            // Update.
            source.RemoveRange(index, count);
        }
    }
}
