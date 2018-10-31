using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ofl.Collections.Generic;
using Xunit;

namespace Ofl.Collections.Tests.Generic
{
    public class ConsecutiveReadOnlyCollectionsTests
    {
        #region Helpers

        private static ConsecutiveReadOnlyCollections<int> CreateConsecutiveReadOnlyCollections(IEnumerable<int> counts)
        {
            // The list of collections.
            var collections = new List<ReadOnlyCollection<int>>();

            // The current index.
            int index = 0;

            // Cycle through the ranges.
            foreach (int count in counts)
            {
                // Add the range.
                collections.Add(Enumerable.Range(index, count).ToList().WrapInReadOnlyCollection());

                // Increment the index.
                index += count;
            }

            // Return.
            return new ConsecutiveReadOnlyCollections<int>(collections.WrapInReadOnlyCollection());
        }

        #endregion

        #region Tests

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(100, 0, 0, 100)]
        [InlineData(0, 100, 0, 100)]
        [InlineData(100, 100, 0, 0)]
        [InlineData(0, 100, 100, 0)]
        [InlineData(100, 100, 100, 100)]
        public void Test_GetEnumerable(params int[] counts)
        {
            // Sum the counts.
            int count = counts.Sum();

            // Are the ranges the same?
            Assert.True(CreateConsecutiveReadOnlyCollections(counts).SequenceEqual(Enumerable.Range(0, count)), "Sequences did not match.");
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(100, 0, 0, 100)]
        [InlineData(0, 100, 0, 100)]
        [InlineData(100, 100, 0, 0)]
        [InlineData(0, 100, 100, 0)]
        [InlineData(100, 100, 100, 100)]
        public void Test_Count(params int[] counts)
        {
            // Sum the counts.
            int count = counts.Sum();

            // Are the ranges the same?
            Assert.Equal(count, CreateConsecutiveReadOnlyCollections(counts).Count);
        }

        #endregion
    }
}
