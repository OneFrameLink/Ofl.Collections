using System.Collections.Generic;
using System.Linq;
using Ofl.Collections.Generic;
using Xunit;

namespace Ofl.Collections.Tests.Generic
{
    public class EnumerableEqualityComparerTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Test_EqualityComparer(int items)
        {
            // Create two separate ranges.
            IEnumerable<int> left = items == 0 ? new int[0] : Enumerable.Range(0, items);
            IEnumerable<int> right = items == 0 ? new int[0] : Enumerable.Range(0, items);

            // Not equal references.
            Assert.False(ReferenceEquals(left, right));

            // Create a hashset.
            ISet<IEnumerable<int>> set = new HashSet<IEnumerable<int>>(new EnumerableEqualityComparer<int>());

            // Add the item.
            set.Add(left);

            // Look up with right.
            Assert.True(set.Contains(right));
        }
    }
}
