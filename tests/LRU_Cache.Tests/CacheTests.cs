using System;
using Xunit;

namespace LRU_Cache.Tests
{
    public class CacheTests
    {
        [Fact]
        public void LRUCache_GivenZeroCapacity_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Cache<int, int>(0));
        }

        [Fact]
        public void LRUCache_GivenNonExistentKey_ReturnsDefault()
        {
            Cache<int, int> cache = new(10);
            int val = cache.Get(1);
            Assert.Equal(val, default(int));
        }

        [Fact]
        public void LRUCache_GivenExistingKey_ReturnsValue()
        {
            Cache<int, string> cache = new(4);
            string expectedValue = "Kunal Mukherjee";
            cache.Put(0, expectedValue);
            Assert.Equal(cache.Get(0), expectedValue);
        }

        [Fact]
        public void LRUCache_GivenExistingKey_OverwriteValue()
        {
            Cache<int, string> cache = new(4);
            string oldValue = "John Doe";
            string expectedValue = "Kunal Mukherjee";
            cache.Put(0, oldValue).Put(0, expectedValue);

            Assert.Equal(cache.Get(0), expectedValue);
        }

        [Fact]
        public void LRUCache_GivenNewValue_EvictLeastUsedValue()
        {
            Cache<int, string> cache = new(1);

            string val1 = "John Doe";
            string val2 = "Jane Doe";

            cache.Put(0, val1).Put(1, val2);

            Assert.Equal(cache.Get(0), default(string));
            Assert.NotEqual(cache.Get(0), val1);
            Assert.Equal(cache.Get(1), val2);
        }
    }
}
