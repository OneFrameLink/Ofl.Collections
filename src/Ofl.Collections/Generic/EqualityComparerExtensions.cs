using System;
using System.Collections.Generic;

namespace Ofl.Collections.Generic
{
    public static class EqualityComparerExtensions
    {
        public static IEqualityComparer<T> CreateFromProperty<T, TProperty>(
            Func<T, TProperty> getter
        ) => CreateFromProperty(getter, EqualityComparer<TProperty>.Default);

        public static IEqualityComparer<T> CreateFromProperty<T, TProperty>(
            Func<T, TProperty> getter,
            IEqualityComparer<TProperty> equalityComparer
        )
        {
            // Validate parameters.
            if (getter == null) throw new ArgumentNullException(nameof(getter));
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer));

            // Create the equals and get hash code methods on
            // instances of T.
            int GetHashCode(T t) => equalityComparer.GetHashCode(getter(t));
            bool Equals(T x, T y) => equalityComparer.Equals(getter(x), getter(y));

            // Call the overload.
            return new DelegatedEqualityComparer<T>(Equals, GetHashCode);
        }
    }
}
