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



### Why left+(right+left)/2 equals (left+right)/2?

We can derive it from the mathematical formula.
$$
\begin{align*}
mid 
\\&=\frac{(left+right)}{2}
\\&=\frac{2left+right-left}{2}
\\&=left+\frac{(right-left)}{2}
\end{align*}
$$




### [Why left+(right+left)2/ will not overflow](https://stackoverflow.com/questions/27167943/why-leftright-left-2-will-not-overflow#)

You have $left < right$ by definition.

As a consequence:

 $right - left > 0$, 

and furthermore:

 $left + (right - left) = right$ 

(follows from basic algebra).

And consequently 

$left + (right - left) / 2 <= right$. 

So no overflow can happen since every step of the operation is bounded by the value of `right`.

------

By contrast, consider the buggy expression, $(left + right) / 2$. => $left + right >= right$,

and since we don’t know the values of `left` and `right`, it’s entirely possible that that value overflows.



## 977. Squares of a sorted array



| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [977. Squares of a Sorted Array](https://leetcode-cn.com/problems/squares-of-a-sorted-array/) | Tow Pointers | 2021-12-3 |

![img](./img/Squares_of_a_sorted_array.gif)

数组其实是有序的， 只不过负数平方之后可能成为最大数了。

那么数组平方的最大值就在数组的两端，不是最左边就是最右边，不可能是中间。

此时可以考虑双指针法了，i指向起始位置，j指向终止位置。

定义一个新数组result，和A数组一样的大小，让k指向result数组终止位置。

如果`A[i] * A[i] < A[j] * A[j]` 那么`result[k--] = A[j] * A[j];` 。

如果`A[i] * A[i] >= A[j] * A[j]` 那么`result[k--] = A[i] * A[i];` 。

- [Reference](https://leetcode-cn.com/problems/squares-of-a-sorted-array/comments/) 





## Move Zeros

| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [283. Move Zeros](https://leetcode-cn.com/problems/move-zeroes/) | Tow Pointers | 2021-12-5 |

### 题目

Given an integer array `nums`, move all `0`'s to the end of it while maintaining the relative order of the non-zero elements.

**Note** that you must do this in-place without making a copy of the array.

Example 1:

```csharp
Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
```

Example 2:

```csharp
Input: nums = [0]
Output: [0]
```

**Follow up:** Could you minimize the total number of operations done?



### 参考代码

```csharp
    public void MoveZeros(int[] nums)
    {
        int left = 0, right = 0;
        while(right<nums.Length)
        {
            if(nums[right]!=0)
            {
                Swap(nums, left, right);
                left++;
            }
            right++;
        }
    }

    private void Swap(int[] nums, int left, int right)
    {
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }
```

### 图解过程

<img src="./img/image-20211205174414441.png" alt="image-20211205174414441" style="zoom:80%;" />



正如当初我需要使用图解去理解Binary Search一样，这次双指针也是第一次遇到，过程很难理解，只能根据代码把整个执行过程都review一次，才能彻底入门。

- 对于我来说，难点在于S1和S2， 我一直以为S1之后会，right是直接跳到数组的第2个位置（亦即0），然后left还是停留在第1个位置；
- 实际上，S1会立即开始执行交换，且执行left++和right++;由于第一步理解错了，我对整个执行的过程推导都是错的，于是只能打开visual studio单步调试才正确理解；
- 对于这样的case来说，第一次需要花很长时间，且需要经验积累，跟需要同步调试。过了这关，后续相关的问题，会如Binary Search一样相当好理解了。



## 27 Remove Element



| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [27. Remove Element](https://leetcode-cn.com/problems/remove-element/) | Tow Pointers | 2021-12-5 |

Given an integer array `nums` and an integer `val`, remove all occurrences of `val` in `nums` [in-place](https://en.wikipedia.org/wiki/In-place_algorithm). The relative order of the elements may be changed.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the **first part** of the array `nums`. More formally, if there are `k` elements after removing the duplicates, then the first `k` elements of `nums` should hold the final result. It does not matter what you leave beyond the first `k` elements.

> 由于在某些语言中不可能改变数组的长度，所以必须将结果放在数组nums的第一部分。
>
> 更正式地说，如果在删除重复项之后有k个元素，那么nums的前k个元素应该保存最终结果。除了前k个元素，剩下什么都没关系。

Return `k` after placing the final result in the first `k` slots of `nums`.

> 将最终结果放入nums的前k个槽位后返回k。

Do **not** allocate extra space for another array. You must do this by **modifying the input array** [in-place](https://en.wikipedia.org/wiki/In-place_algorithm) with $O(1)$ extra memory.

> 不要使用额外的数组空间，你必须仅使用 `O(1)` 额外空间并 **[原地 ](https://baike.baidu.com/item/原地算法)修改输入数组**。

**Custom Judge:**

The judge will test your solution with the following code:

```csharp
int[] nums = [...]; // Input array
int val = ...; // Value to remove
int[] expectedNums = [...]; // The expected answer with correct length.
                            // It is sorted with no values equaling val.

int k = removeElement(nums, val); // Calls your implementation

assert k == expectedNums.length;
sort(nums, 0, k); // Sort the first k elements of nums
for (int i = 0; i < actualLength; i++) {
    assert nums[i] == expectedNums[i];
}
```

If all assertions pass, then your solution will be accepted.



![27.移除元素-双指针法](./img/008eGmZEly1gntrds6r59g30du09mnpd.gif)

**Reference:**

1. [27. 移除元素](https://programmercarl.com/0027.%E7%A7%BB%E9%99%A4%E5%85%83%E7%B4%A0.html#%E6%80%9D%E8%B7%AF)
2. 
