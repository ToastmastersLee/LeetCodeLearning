# LeetCode解题过程学习

主要是记录一下整个解题过程的思路，以供日后不断的复习和参考。同时尝试使用英语解释整个过程。

[toc]



## 35. Search Insert Position



| Title                                                        | Type          | Date      |
| ------------------------------------------------------------ | ------------- | --------- |
| [Search Insert Position](https://leetcode-cn.com/problems/search-insert-position/) | Binary Search | 2021-12-1 |

Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with $$O(log n)$$ runtime complexity.

### Binary Search 算法复习

- 双指针：先设定左侧下标 **left** 和右侧下标 **right**, 再计算中间下标 **mid**;
- 每次根据 **nums[mid]**和**target** 之间的大小进行判断：
  - 相等则直接返回下标；
  - **nums[mid]**<**target**,说明目标落在**`[mid+1,right]`** 区间内，则 **left** 右移
  - **nums[mid]>target**,目标落在**`[left,mid-1]`**内，则**right**右移
- 查找结束如果没有相等值则返回**left**,该值为插入位置





## 977. Squares of a sorted array



| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [[977. Squares of a Sorted Array](https://leetcode-cn.com/problems/squares-of-a-sorted-array/)](https://leetcode-cn.com/problems/squares-of-a-sorted-array/submissions/) | Tow Pointers | 2021-12-3 |

![img](./img/Squares_of_a_sorted_array.gif)

数组其实是有序的， 只不过负数平方之后可能成为最大数了。

那么数组平方的最大值就在数组的两端，不是最左边就是最右边，不可能是中间。

此时可以考虑双指针法了，i指向起始位置，j指向终止位置。

定义一个新数组result，和A数组一样的大小，让k指向result数组终止位置。

如果`A[i] * A[i] < A[j] * A[j]` 那么`result[k--] = A[j] * A[j];` 。

如果`A[i] * A[i] >= A[j] * A[j]` 那么`result[k--] = A[i] * A[i];` 。

- [Reference](https://leetcode-cn.com/problems/squares-of-a-sorted-array/comments/) 
