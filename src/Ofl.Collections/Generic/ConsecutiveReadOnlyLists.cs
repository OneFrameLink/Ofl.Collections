using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public class ConsecutiveReadOnlyLists<T> : ConsecutiveReadOnlyCollections<T>, IReadOnlyList<T>
    {
        #region Constructor

        public ConsecutiveReadOnlyLists(params IReadOnlyList<T>[] lists) : this(lists?.WrapInReadOnlyCollection()!)
        { }

        public ConsecutiveReadOnlyLists(IReadOnlyCollection<IReadOnlyList<T>> lists) : base(lists)
        {
            // Assign values.
            _lists = lists ?? throw new ArgumentNullException(nameof(lists));
        }

        #endregion

        #region Instance, read-only state

        private readonly IReadOnlyCollection<IReadOnlyList<T>> _lists;

        #endregion

        #region IReadOnlyList implementation

        public T this[int index]
        {
            get
            {
                // The original index.
                int originalIndex = index;

                // Validate parameters.
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), index, $"The {nameof(index)} parameter must be a non-negative value.");

                // Cycle through the items.
                foreach (IReadOnlyList<T> list in _lists)
                {
                    // If the index is less than the collection length, return the item at
                    // that index.
                    if (index < list.Count) return list[index];

                    // Decrement the index by the length.
                    index -= list.Count;

                    // If the index is negative, break.
                    if (index < 0) break;
                }

                // Throw.
                throw new ArgumentOutOfRangeException(nameof(index), originalIndex, $"The {nameof(originalIndex)} parameter must be less than the length of the list.");
            }
        }

        #endregion
    }
}
