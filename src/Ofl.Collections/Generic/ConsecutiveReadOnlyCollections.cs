using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ofl.Collections.Generic
{
    public class ConsecutiveReadOnlyCollections<T> : IReadOnlyCollection<T>
    {
        #region Constructor

        public ConsecutiveReadOnlyCollections(params IReadOnlyCollection<T>[] collections) : 
            this(collections?.WrapInReadOnlyCollection()!)
        { }

        public ConsecutiveReadOnlyCollections(IReadOnlyCollection<IReadOnlyCollection<T>> collections)
        {
            // Assign values.
            _collections = collections ?? throw new ArgumentNullException(nameof(collections));
        }

        #endregion

        #region Instance, read-only state

        private readonly IReadOnlyCollection<IReadOnlyCollection<T>> _collections;

        #endregion

        #region IReadOnlyList implementation


        public IEnumerator<T> GetEnumerator() => _collections
            .SelectMany(c => c).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _collections.Select(c => c.Count).Sum();

        #endregion
    }
}
