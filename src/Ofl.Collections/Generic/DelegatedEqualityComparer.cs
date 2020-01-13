using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    internal class DelegatedEqualityComparer<T> : IEqualityComparer<T>
    {
        #region Constructor

        internal DelegatedEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            // Validate parameters.
            _equals = equals ?? throw new ArgumentNullException(nameof(@equals));
            _getHashCode = getHashCode ?? throw new ArgumentNullException(nameof(getHashCode));
        }

        #endregion

        #region Instance, read-only state.

        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _getHashCode;

        #endregion

        public bool Equals(T x, T y) => _equals(x, y);

        public int GetHashCode(T obj) => _getHashCode(obj);
    }
}
