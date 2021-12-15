# Hashmap and Dictionary



在刷 [3.无重复字符串的最长子串](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/solution/wu-zhong-fu-zi-fu-de-zui-chang-zi-chuan-by-leetc-2/)这题的时候，发现难度很大，即便我抄答案都有点难度。然后发现答案都说要Hashset,我使用C#写，发现C#似乎根本就没有这个鬼。

前后翻了几篇StackOverflow的文章，才大致理清这里面的关系。





## [Hashset v.s Hashmap](https://stackoverflow.com/questions/2773824/difference-between-hashset-and-hashmap) (Java)



HashSet is a **set**, e.g. **{1,2,3,4,5}**

HashMap is a **key -> value** (key to value) map, e.g. **{a -> 1, b -> 2, c -> 2, d -> 1}**

Notice in my example above that in the HashMap there must not be duplicate keys, but it may have duplicate values.

In the HashSet, there must be no duplicate elements.



They are entirely different constructs. A `HashMap` is an implementation of `Map`. A [Map](http://java.sun.com/javase/6/docs/api/java/util/Map.html) maps keys to values. The key look up occurs using the hash.

On the other hand, a `HashSet` is an implementation of `Set`. A [Set](http://java.sun.com/javase/6/docs/api/java/util/Set.html) is designed to match the mathematical model of a set. A `HashSet` does use a `HashMap` to back its implementation, as you noted. However, it implements an entirely different interface.

When you are looking for what will be the best `Collection` for your purposes, this [Tutorial](http://java.sun.com/docs/books/tutorial/collections/index.html) is a good starting place. If you truly want to know what's going on, [there's a book for that](https://rads.stackoverflow.com/amzn/click/com/0596527756), too.



## [Hashmap equivalent in C#](https://stackoverflow.com/questions/1273139/c-sharp-java-hashmap-equivalent)

> Look at `Dictionary<key,value>` in the `System.Collections.Generic`. It is the C# "parallel" (albeit having some differences, it is the closest to) of `HashMap` in Java.

[`Dictionary`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) is probably the closest. `System.Collections.Generic.Dictionary` implements the [`System.Collections.Generic.IDictionary`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2) interface (which is similar to Java's `Map` interface).

Some notable differences that you should be aware of:

<font size=4>1. Adding/Getting items</font>

- Java's HashMap has the `put` and `get` methods for setting/getting items
  - `myMap.put(key, value)`
  - `MyObject value = myMap.get(key)`
- C#'s Dictionary uses `[]` indexing for setting/getting items
  - `myDictionary[key] = value`
  - `MyObject value = myDictionary[key]`

<font size=4>2. `null` keys</font>

- Java's `HashMap` allows null keys
- .NET's `Dictionary` throws an `ArgumentNullException` if you try to add a null key

<font size=4>3. Adding a duplicate key </font>

- Java's `HashMap` will replace the existing value with the new one.

- .NET's `Dictionary` will replace the existing value with the new one if you use `[]` indexing. If you use the `Add` method, it will instead throw an `ArgumentException`.

  >  Note, `Dictionary` throws Exceptions when adding a duplicated key. 

<font size=4>4. Attempting to get a non-existent key</font>

- Java's `HashMap` will return null.
- .NET's `Dictionary` will throw a `KeyNotFoundException`. You can use the [`TryGetValue`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.trygetvalue) method instead of the `[]` indexing to avoid this:
  `MyObject value = null; if (!myDictionary.TryGetValue(key, out value)) { /* key doesn't exist */ }`



`Dictionary`'s has a [`ContainsKey`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.containskey) method that can help deal with the previous two problems.



## Reference

1. [Difference between HashSet and HashMap?](https://stackoverflow.com/questions/2773824/difference-between-hashset-and-hashmap)

2. [C# Java HashMap equivalent](https://stackoverflow.com/questions/1273139/c-sharp-java-hashmap-equivalent)