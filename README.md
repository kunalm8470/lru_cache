# lru_cache
Implementing LRU Cache using C#

Creating the boilerplate using .NET5 CLI -
```
mkdir src
mkdir tests

cd src
dotnet new classlib -o LRU_Cache

cd ../tests
dotnet new xunit -o LRU_Cache.Tests

cd ..
dotnet new sln

dotnet sln add .\src\LRU_Cache\
dotnet sln add .\tests\LRU_Cache.Tests\
```

I am using 2 collections to implement the cache -
1. `Dictionary<K, CacheItem<K, V>>` The dictionary serves as a lookup for retreiving values from the cache in O(1) constant time

2. `LinkedList<CacheItem<K, V>>` The doubly linked list serves as a tracking list to track least used items, items which are least used are evicted from the front according to the LRU policy.

___

The cache is initialized with a positive capacity.

It provides 2 methods.

1. `Get(K key)` Gets the value from the cache, shifts the item which is fetched at last, if no matching key is found it returns `default(V)`.

2. `Put(K key, V value)` Sets the value into both the dictionary lookup and the tracking list in the end, if the tracking lists' count is equal to the capacity then the first item from the front of the tracking list is evicted and the new item is pushed into the item.

___

**Space Complexity**<br>
`O(n)` because of the extra auxillary tracking list.

**Time Complexity**<br>
* Fetching key - `O(1)`
* Setting key - Average case `O(1)`, if reaches capacity then `O(n)`







