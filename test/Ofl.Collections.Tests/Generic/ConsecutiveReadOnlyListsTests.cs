using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ofl.Collections.Generic;
using Xunit;

namespace Ofl.Collections.Tests.Generic
{
    public class ConsecutiveReadOnlyListsTests
    {
        #region Helpers

        private static ConsecutiveReadOnlyLists<int> CreateConsecutiveReadOnlyLists(IEnumerable<int> counts)
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
            return new ConsecutiveReadOnlyLists<int>(collections.WrapInReadOnlyCollection());
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
        public void Test_Indexer(params int[] counts)
        {
            // Sum the counts.
            int count = counts.Sum();

            // Create the list.
            ConsecutiveReadOnlyLists<int> list = CreateConsecutiveReadOnlyLists(counts);

            // Cycle.
            foreach (int index in Enumerable.Range(0, count))
                // Assert the values.
                Assert.Equal(index, list[index]);
        }

        #endregion
    }
}
