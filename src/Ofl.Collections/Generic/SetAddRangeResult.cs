namespace Ofl.Collections.Generic
{
    public class SetAddRangeResult<T>
    {
        #region Constructor.

        public SetAddRangeResult(T item, bool added)
        {
            // Set values.
            Item = item;
            Added = added;
        }

        #endregion

        #region Instance, read-only state.

        public T Item { get; }

        public bool Added { get; }

        #endregion
    }
}
