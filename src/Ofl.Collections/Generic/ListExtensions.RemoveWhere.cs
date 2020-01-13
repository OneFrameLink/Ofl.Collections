using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static partial class ListExtensions
    {
        //////////////////////////////////////////////////
        ///
        /// <author>Nicholas Paldino</author>
        /// <created>2013-03-24</created>
        /// <summary>Cycles through a list, removing the elements
        /// from the list which match a certain <paramref name="predicate"/>.</summary>
        /// <param name="source">The <see cref="IList{T}"/> to remove
        /// the items from.</param>
        /// <param name="predicate">The <see cref="Func{T, TResult}"/> that will
        /// be used to filter the items in the list.</param>
        /// <returns>A sequence of the items that satisfied the conditions
        /// and were removed from the list.</returns>
        /// <typeparam name="T">The type of the list.</typeparam>
        ///
        //////////////////////////////////////////////////
        public static IEnumerable<T> RemoveWhere<T>(this IList<T> source, Func<T, bool> predicate)
        {
            // Validate parameters.
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            // The implementation.
            IEnumerable<T> Implementation() {
                // Cycle backwards through the source.
                for (int i = source.Count - 1; i >= 0; --i)
                {
                    // The item.
                    T item = source[i];

                    // If the item meets the predicate, then remove it.
                    if (!predicate(item)) continue;

                    // Remove the item.
                    source.RemoveAt(i);

                    // Yield the item.
                    yield return item;
                }
            }

            // Return the implementation.
            return Implementation();
        }
    }
}
