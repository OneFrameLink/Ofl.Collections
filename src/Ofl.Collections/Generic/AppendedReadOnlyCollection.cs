using System;
using System.Collections;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    internal class AppendedReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        #region Constructor

        internal AppendedReadOnlyCollection(IReadOnlyCollection<T> root, T item)
        {
            // Validate parameters.
            _enumerable = root?.Append(item) ?? throw new ArgumentNullException(nameof(root));

            // Assign values.
            Count = root.Count + 1;
        }

        #endregion

        #region Instance, read-only state.

        private readonly IEnumerable<T> _enumerable;

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator() => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Implementation of IReadOnlyCollection<out T>

        public int Count { get; }

        #endregion
    }
}
