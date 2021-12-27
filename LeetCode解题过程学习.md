# LeetCode解题过程学习

主要是记录一下整个解题过程的思路，以供日后不断的复习和参考。同时尝试使用英语解释整个过程。

[toc]



## 罗马数字

一道Hashmap,

一道贪心算法

### 13. Roman to Integer

Roman numerals are represented by seven different symbols: `I`, `V`, `X`, `L`, `C`, `D` and `M`.

| Symbol | Value |
| ------ | ----- |
| I      | 1     |
| V      | 5     |
| X      | 10    |
| L      | 50    |
| C      | 100   |
| D      | 500   |
| M      | 1000  |

For example, `2` is written as `II` in Roman numeral, just two one's added together. `12` is written as `XII`, which is simply `X + II`. The number `27` is written as `XXVII`, which is `XX + V + II`.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not `IIII`. Instead, the number four is written as `IV`. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as `IX`.  There are six instances where subtraction is used:

- `I` can be placed before `V` (5) and `X` (10) to make 4 and 9. 
- `X` can be placed before `L` (50) and `C` (100) to make 40 and 90. 
- `C` can be placed before `D` (500) and `M` (1000) to make 400 and 900.

Given a roman numeral, convert it to an integer.

**Example 2:**

```c#
Input: s = "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
```

**Example 3:**

```C#
Input: s = "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
```

**Constraints:**

- `s` contains only the characters `('I', 'V', 'X', 'L', 'C', 'D', 'M')`.
- It is **guaranteed** that `s` is a valid roman numeral in the range `[1, 3999]`.



<font size=5> 参考 </font>

建立一个`HashMap`(C#是`Dictionary`)来映射符号和值，然后对字符串从左到右来，如果当前字符代表的值不小于其右边，就加上该值；否则就减去该值。以此类推到最左边的数，最终得到的结果即是答案。



<font size=5> 参考代码 </font>

```C#
public class Solution {
    public int RomanToInt(string s) {
      var dic = new Dictionary<char,int>{
        {'I',1},
        {'V',5},
        {'X',10},
        {'L',50},
        {'C',100},
        {'D',500},
        {'M',1000}
      };
    
     int ans = 0;
     for (int i = 0; i<s.Length;i++){
         int numbers = dic[s[i]];
         if(i<s.Length-1 && numbers < dic[s[i+1]])
         {
             ans = ans - numbers;
         }
         else
         {
             ans = ans +numbers;
         }
     }
     return ans;
    }
}
```







## Binary Search二分查找



### 思路与关键概念

<font size=5>1. Binary Search 算法复习</font>



- 双指针：先设定左侧下标 **left** 和右侧下标 **right**, 再计算中间下标 **mid**;
- 每次根据 **nums[mid]**和**target** 之间的大小进行判断：
  - 相等则直接返回下标；
  - **nums[mid]**<**target**,说明目标落在**`[mid+1,right]`** 区间内，则 **left** 右移
  - **nums[mid]>target**,目标落在**`[left,mid-1]`**内，则**right**右移
- 查找结束如果没有相等值则返回**left**,该值为插入位置



<font size=5>2. Why left+(right+left)/2 equals (left+right)/2?</font>

We can derive it from the mathematical formula.
$$
\begin{align*}
mid 
\\&=\frac{(left+right)}{2}
\\&=\frac{2left+right-left}{2}
\\&=left+\frac{(right-left)}{2}
\end{align*}
$$



<font size=5>3. [Why left+(right+left)2/ will not overflow](https://stackoverflow.com/questions/27167943/why-leftright-left-2-will-not-overflow#) </font>

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



### 704. Binary Search

| Title                                                        | Type          | Date       |
| ------------------------------------------------------------ | ------------- | ---------- |
| [Search Insert Position](https://leetcode-cn.com/problems/search-insert-position/) | Binary Search | 2021-12-1  |
|                                                              |               | 2021-12-15 |



Given an array of integers `nums` which is sorted in ascending order, and an integer `target`, write a function to search `target` in `nums`. If `target` exists, then return its index. Otherwise, return `-1.`

You must write an algorithm with $O(log n)$ runtime complexity.

```c#
public class Solution{
    public int BinarySearch(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length -1;//这里一定要减去1，因为数组的下标是从0开始，而长度是从1开始；
        while(left<=right) //必须考虑==的情况，比如输入 [5],target=5,这种情况就会报错
        {
            int mid = (int)((left + right) /2);//默认向下取整
            if(target == nums[mid])
            {
                return mid;
            }
            if(target > nums[mid])
            {//目标值比中间值大，于数组右边，需调整left的指针.目标落座在[mid+1, right]
                left=mid +1;
            }
            if(target <num[mid])
            {//目标值比中间小，于数字左边，需要调整right的指针，目标坐落在[left,rigt-1]
                right = mid =1;
            }
        }
        return -1;
    }
}
```



### 35. Search Insert Position

| Title                                                        | Type          | Date      |
| ------------------------------------------------------------ | ------------- | --------- |
| [Search Insert Position](https://leetcode-cn.com/problems/search-insert-position/) | Binary Search | 2021-12-1 |

Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with $$O(log n)$$ runtime complexity.



## Tow Pointers双指针

### [C# array initialization](https://www.tutorialspoint.com/csharp/csharp_arrays.htm)

An array stores a **fixed-size sequential collection** of elements of the same type.

Declaring an array does not initialize the array in the memory. When the array variable is initialized, you can assign values to the array.

Array is a reference type, so you need to use the **new** keyword to create an instance of the array. For example,

```C#
double[] balance = new double[10];
```



You can assign values to the array **at the time of declaration**, as shown −

```C#
double[] balance = {2340.0, 4523.69, 3421.0};
```



You can also **create and initialize** an array, as shown −

```C#
int[] marks = new int[5]{99,  98, 92, 97, 95};
```



You may also **omit** the size of the array, as shown −

```c#
int[] marks = new [] {99,  98, 92, 97, 95};
```



### 977. Squares of a sorted array

| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [977. Squares of a Sorted Array](https://leetcode-cn.com/problems/squares-of-a-sorted-array/) | Tow Pointers | 2021-12-3 |



<font size=5> 解题思路 </font>

数组其实是有序的， 只不过负数平方之后可能成为最大数了。

那么数组平方的最大值就在数组的两端，不是最左边就是最右边，不可能是中间。

此时可以考虑双指针法了，i指向起始位置，j指向终止位置。

定义一个新数组result，和A数组一样的大小，让k指向result数组终止位置。

如果`A[i] * A[i] < A[j] * A[j]` 那么`result[k--] = A[j] * A[j];` 。

如果`A[i] * A[i] >= A[j] * A[j]` 那么`result[k--] = A[i] * A[i];` 。

- [Reference](https://leetcode-cn.com/problems/squares-of-a-sorted-array/comments/) 



<font size=5>算法图解</font>

![img](./img/Squares_of_a_sorted_array.gif)



<font size=5>参考代码</font>

```C#
public class Solution {
    public int[] SortedSquares(int[] nums) {
    	//i 是数组开头位置， j是数组结尾位置， pos是返回的数组在当前循环内最大的数组
     	int i = 0, j = nums.Length -1, pos = nums.Length -1;
     
    	// int[] ans = new int[nums.Length-1]; // 数组越界！
   		int[] ans = new int[nums.Length];
   		// while(i<j)  [-7,-3,2,3,11] => [0,9,9,49,121]
        while(i<=j)
        {
             if(nums[i] * nums[i] > nums[j] * nums[j])
             {
                 ans[pos] = nums[i] * nums[i];
                 //确认了是i最大，因此移动i指针到下一位进行比较
                i++;
             }
             else
             {
                 ans[pos] = nums[j] * nums[j];
                 //反之，如果确认是j更大，把更大的值赋予ans数组的最大位(pos),并且修改j指针的位置
                 j--;
             }
             //every iterated, need to change the pointer of pos(self minus) 
             pos-- ;
         }
         return ans;
    }
}
```



### 189.Rotate array

| Title                                                        | Type         | Date       |
| ------------------------------------------------------------ | ------------ | ---------- |
| [189. Rotate array](https://leetcode-cn.com/problems/rotate-array/solution/xuan-zhuan-shu-zu-by-leetcode-solution-nipk/) | Tow Pointers | 2021-12-4  |
|                                                              |              | 2021-12-15 |



<font size =5> 题目</font>

Given an array, **rotate** the array **to the right** by `k` steps, where `k` is non-negative

给定一个数组，将数组中的元素向右移动 `k` 个位置，其中 `k` 是非负数。

**Example 1:**

```javascript
Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
```

**Follow up:**

- Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
- Could you do it in-place with `O(1)` extra space?



<font size=5>取模（2021-9-17）</font>

这里必须要取模（需要考虑向右移动次数超出数组本身的长度的情况）：这里只有7个元素，向右边移动7次，其实等于没有移动；向右移动8次等于向右移动1次，所以**8%7=1**；



<font size=5>解题思路</font>

观察:

输入: nums = [1,2,3,4,5,6,7], k = 3
输出: [5,6,7,1,2,3,4]

<img src="./img/image-20211215140438499.png" alt="image-20211215140438499" style="zoom:80%;" />



- **[S1:翻转整个数组](https://leetcode-cn.com/problems/rotate-array/solution/shu-zu-fan-zhuan-xuan-zhuan-shu-zu-by-de-5937/)**



<img src="./img/image-20211215140549183.png" alt="image-20211215140549183" style="zoom:80%;" />

- **S2: 从第K个元素后，将数组划分为左右两快字数组**

<img src="./img/image-20211215141622437.png" alt="image-20211215141622437" style="zoom:80%;" />

- **S3:左右两组子数组，各自翻转**

<img src="./img/image-20211215141851432.png" alt="image-20211215141851432" style="zoom:80%;" />

- **S4:Done**

<img src="./img/image-20211215143721169.png" alt="image-20211215143721169" style="zoom: 80%;" />



该方法基于如下的事实：当我们将数组的元素向右移动 `k` 次后，尾部 $k\mod n$ 个元素会移动至数组头部，其余元素向后移动 个$k\mod n$位置。

该方法为数组的翻转：我们可以先将所有元素翻转，这样尾部的 $k\mod n$个元素就被移至数组头部，然后我们再翻转 **[0,k mod n−1]** 区间的元素和 **[k mod n,n−1]** 区间的元素即能得到最后的答案。



<font size=5>参考代码</font>

```c#
public class Solution {
    public void Rotate(int[] nums, int k) {
        k= k%nums.Length;//-->: k= k % nums.Length;
        reverseArr(nums,0,nums.Length-1);//第一次全翻转
        reverseArr(nums,0,k-1);//第二次翻转左边部分，由于end是数组的下标，所以需要k-1;
        reverseArr(nums,k,nums.Length-1);//翻转右边部分，如果不能理解这里为什么不需要k-1,可以参考上图的k=3的位置
    }
    private void reverseArr(int[]nums, int start, int end){
        while(start<=end){
            int temp = nums[start];
            nums[start] =nums[end];
            nums[end] =temp;
            start++;
            end--;
        }
    }
}
```



### 283.Move Zeros

| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [283. Move Zeros](https://leetcode-cn.com/problems/move-zeroes/) | Tow Pointers | 2021-12-5 |

<font size=5> 题目</font>

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



<font size=5>参考代码</font>

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

<font size=5>图解过程</font>

<img src="./img/image-20211205174414441.png" alt="image-20211205174414441" style="zoom:80%;" />



正如当初我需要使用图解去理解Binary Search一样，这次双指针也是第一次遇到，过程很难理解，只能根据代码把整个执行过程都review一次，才能彻底入门。

- 对于我来说，难点在于S1和S2， 我一直以为S1之后会，right是直接跳到数组的第2个位置（亦即0），然后left还是停留在第1个位置；
- 实际上，S1会立即开始执行交换，且执行left++和right++;由于第一步理解错了，我对整个执行的过程推导都是错的，于是只能打开visual studio单步调试才正确理解；
- 对于这样的case来说，第一次需要花很长时间，且需要经验积累，跟需要同步调试。过了这关，后续相关的问题，会如Binary Search一样相当好理解了。



<img src="./img/344_fig1.png" alt="img" style="zoom: 50%;" />



### 27. Remove Element

| Title                                                        | Type         | Date      |
| ------------------------------------------------------------ | ------------ | --------- |
| [27. Remove Element](https://leetcode-cn.com/problems/remove-element/) | Tow Pointers | 2021-12-5 |

<font size=5>题目</font>

Given an integer array `nums` and an integer `val`, remove all occurrences of `val` in `nums` [in-place](https://en.wikipedia.org/wiki/In-place_algorithm). The relative order of the elements may be changed.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the **first part** of the array `nums`. More formally, if there are `k` elements after removing the duplicates, then the first `k` elements of `nums` should hold the final result. It does not matter what you leave beyond the first `k` elements.

> 由于在某些语言中不可能改变数组的长度，所以必须将结果放在数组nums的第一部分。
>
> 更正式地说，如果在删除重复项之后有k个元素，那么nums的前k个元素应该保存最终结果。除了前k个元素，剩下什么都没关系。

Return `k` after placing the final result in the first `k` slots of `nums`.

> 将最终结果放入nums的前k个槽位后返回k。

Do **not** allocate extra space for another array. You must do this by **modifying the input array** [in-place](https://en.wikipedia.org/wiki/In-place_algorithm) with $O(1)$ extra memory.

> 不要使用额外的数组空间，你必须仅使用 `O(1)` 额外空间并 **[原地 ](https://baike.baidu.com/item/原地算法)修改输入数组**。





<font size=5>图解过程</font>

![27.移除元素-双指针法](./img/008eGmZEly1gntrds6r59g30du09mnpd.gif)

**Reference:**

1. [27. 移除元素](https://programmercarl.com/0027.%E7%A7%BB%E9%99%A4%E5%85%83%E7%B4%A0.html#%E6%80%9D%E8%B7%AF)
2. 



### 876. Middle of the Linked List

| Titile                                                       | Type         | Date       |
| ------------------------------------------------------------ | ------------ | ---------- |
| [Middle of the Linked List](https://leetcode-cn.com/problems/middle-of-the-linked-list/) | Two Pointers | 2021-12-10 |
|                                                              |              | 2021-12-18 |
|                                                              |              |            |

这题是对链表这种陌生结构的第一次了解。

<font size=5> 题目</font>

Give the `head` of a singly linked list, return *the middle node of the linked list*.

If there are two middle nodes, return **the second middle** node. 

<img src="./img/image-20211218211707715.png" alt="image-20211218211707715" style="zoom:70%;" />

<font size=5>参考代码</font>

```c#
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        var slow=head, fast=head;
        /*
        注意题目要求如果存在两个中间节点，则返回第二个。
        因此快指针fast可以前进的条件是，当前快指针和
        快指针的下一个节点都非空。
        */
        while(fast!=null && fast.next!=null)
        {
            /*
            慢指针slow走一步，快指针fast走两步
            */
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
}
```

<font size=5>图解过程</font>

<img src="./img/image-20211218214437866.png" alt="image-20211218214437866" style="zoom: 67%;" />

<img src="./img/image-20211218211153995.png" alt="image-20211218211153995" style="zoom: 67%;" />



### 19. [Remove nth node from end of list](https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/)

Given the **`head`** of a linked list, remove the **n<sup>th</sup>** node from the list and return its head.

给你一个链表（上的head节点），删除链表的倒数第 `n` 个结点，并且返回链表的头结点。

**Example 1:**

<img src="./img/image-20211213115333648.png" alt="image-20211213115333648" style="zoom:50%;" />

```c#
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
```

**Example 2:**

```c#
Input: head = [1], n = 1
Output: []
```

**Example 3:**

```c#
Input: head = [1,2], n = 1
Output: [1]
```



#### Dummy node

在对链表进行操作时，一种常用的技巧是添加一个[哑节点](https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/solution/shan-chu-lian-biao-de-dao-shu-di-nge-jie-dian-b-61/)（**dummy node**），它的**next** 指针指向链表的头节点。这样一来，我们就不需要对头节点进行特殊的判断了。

例如，在本题中，如果我们要删除节点 **y**，我们需要知道节点 **y** 的前驱节点 **x**，并将 **x** 的指针指向 **y** 的后继节点。但由于头节点不存在前驱节点，因此我们需要在删除头节点时进行特殊判断。但如果我们添加了哑节点，那么头节点的前驱节点就是哑节点本身，此时我们就只需要考虑通用的情况即可。

> 特别地，在某些语言中，由于需要自行对内存进行管理。因此在实际的面试中，对于「是否需要释放被删除节点对应的空间」这一问题，我们需要和面试官进行积极的沟通以达成一致。下面的代码中默认不释放空间。



<font size=5>双指针</font>



我们也可以在不预处理出链表的长度，以及使用常数空间的前提下解决本题。

由于我们需要找到倒数第 $n$ 个节点，因此我们可以使用两个指针 **first** 和 **second** 同时对链表进行遍历，并且**first** 比 **second**超前 **n** 个节点。当 **first** 遍历到链表的末尾时，**second** 就恰好处于倒数第 **n** 个节点。

具体地，初始时**first** 和 **second** 均指向头节点。我们首先使用 **first** 对链表进行遍历，遍历的次数为 **n**。此时，**first** 和 **second** 之间间隔了 $n−1$ 个节点，即 **first** 比 **second** 超前了 **n** 个节点。

<img src="./img/cc43daa8cbb755373ce4c5cd10c44066dc770a34a6d2913a52f8047cbf5e6e56-file_1559548337458" alt="img" style="zoom: 50%;" />

> 这个[动画](https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/solution/dong-hua-tu-jie-leetcode-di-19-hao-wen-ti-shan-chu/)实在是神来之笔

因此我们可以考虑在初始时将 **second** 指向哑节点，其余的操作步骤不变。这样一来，当**first** 遍历到链表的末尾时，**second** 的下一个节点就是我们需要删除的节点。

<img src="./img/p3.png" alt="p3" style="zoom:67%;" />



<font size=5>参考代码</font>

```c#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        /*往head上链表上插入全新的一个节点，生成一个全新的链表dummyList
        该dummyList有两个作用，一个是赋予second指针删除节点用，
        另一个是把删除过后的链表返回给方法*/
        ListNode dummyList = new ListNode(0,head);
        /*head是head，和dummyList是独立的两条链表，
        但是这样子无法解释该算法的空间复杂度为O（1）*/
        ListNode first = head;
        ListNode second = dummyList;
        for(int i=0;i<n;i++){ //先移动first指针往前n步
            first = first.next;
        }
        while(first!=null){
            first=first.next;
            second=second.next;
        }
        second.next=second.next.next;
    }
}
```

- 我对链表模型上可以理解，但是无法解释代码执行情况，说明还未彻底理解；（中文翻译也有点误导）。
-   `ListNode dummyList = new ListNode(0,head);`究竟是产生了一个全新的链表`dummyList`,还是只是产生一个新的节点？我在这两个认知中反复横条；
- 我是在尝试写备注，把每一句执行的过程记录下来的过程中发现了问题，才开始反思，否则就这样稀里糊涂过了，所以上面的备注随后以后追溯看起来很会很funny，不过这确实是一个过程，也确实是发现问题的关键所在，值得记录下来为后续的难题记录提供参考。
- 从字面意识上看 `dummyList`其实是一个节点，因为其类型是`ListNode`,而不是 `ListNode[]` 这样的东西；
- 由于我未能彻底理解`LinkedList`的结构，在**LeetCode**给出的有限的代码下做错误的理解，因此导致每次写代码都需要看提示。于是我就参考[Implementing Linked List In C#](https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/)和[LinkedList<T> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0)两片文章做进一步了解。
- 有时候编程需要深入了解才能彻底掌握，急不得，也不要急，大不了**LeetCode**代码多抄写几次，然后先卡在这些题目上几天、几个礼拜。每日的坚持比刷进度，从长远来看，更有效。



<font size=5>正确代码</font>

```C#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        /*往链表上新增一个DummyNode节点*/
        ListNode dummyNode = new ListNode(0,head);
        ListNode first = head;
        ListNode second = dummyNode;
        for(int i=0;i<n;i++){ //先移动first指针往前n步
            first = first.next;
        }
        while(first!=null){
            first=first.next;
            second=second.next;
        }
        //改变链表上的要删除的N点的前驱节点的后驱指针指向的位置
        second.next=second.next.next;
        //把哑节点的下一个节点（亦即head节点）传递给ans
        ListNode ans = dummyNode.next;
        return ans;
    }
}
```



## [滑动窗口](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/solution/hua-dong-chuang-kou-by-powcai/)

<font size =5>什么是滑动窗口？</font>

其实就是一个队列,比如例题中的 `abcabcbb`，进入这个队列（窗口）为 `abc` 满足题目要求，当再进入 `a`，队列变成了 `abca`，这时候不满足要求。所以，我们要移动这个队列！

如何移动？

我们只要把队列的左边的元素移出就行了，直到满足题目要求！

一直维持这样的队列，找出队列出现最长的长度时候，求出解！

时间复杂度：$O(n)$



###  [3. Longest substring without repeating character](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)

Given a string **s**, find the length of the **longest substring** without repeating characters.

给定一个字符串 **s** ，请你找出其中不含有重复字符的 **最长子串** 的长度。

 

示例 1:

```c#
输入: s = "abcabcbb"
输出: 3 
解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
```

示例 3:

```c#
输入: s = "pwwkew"
输出: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
```





<font size=5> C#代码 </font>

```C#
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // 哈希集合，记录每个字符是否出现过
        //Hashset<char> cSet = new Hashset<char>();
        HashSet<char> cSet = new HashSet<char>();
        int rk=0;//右指针
        int ans = 0; //答案 answers
        for (int i=0;i<s.Length-1;i++) //左指针
        {
            if(i!=0)
            {
                // 左指针向右移动一格，移除一个字符
                cSet.Remove(s[i-1]);
            }
            //如果当前哈希表不包含rk字符，则纳入到哈希表
            while(rk < s.Length-1 && !cSet.Contains(s[rk])) 
            {
              // 不断地移动右指针 
              cSet.Add(s[rk]);
              rk++;
            }
            // 第 i 到 rk 个字符是一个极长的无重复字符子串
            ans = Math.Max(ans,rk-i);
        }
        return ans;
    }
}
```



- 为什么一定要让rk=-1, 直接等于0不是更加单吗？

  因为尼玛的竟然有空字符串的情况：

  <img src="F:\Lee\Githubs\LeetCodeLearning\img\image-20211220161809062.png" alt="image-20211220161809062" style="zoom: 67%;" />



```C#
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // 哈希集合，记录每个字符是否出现过
        //Hashset<char> cSet = new Hashset<char>();
        HashSet<char> cSet = new HashSet<char>();
        int rk=-1;//右指针
        int ans = 0; //答案 answers
        for (int i=0;i<s.Length;i++) //左指针
        {
            if(i!=0)
            {
                // 左指针向右移动一格，移除一个字符
                cSet.Remove(s[i-1]);
            }
            //如果当前哈希表不包含rk字符，则纳入到哈希表
            while(rk+1 < s.Length && !cSet.Contains(s[rk+1])) 
            {
              // 不断地移动右指针 
              cSet.Add(s[rk+1]);
              rk++;
            }
            // 第 i 到 rk 个字符是一个极长的无重复字符子串
            ans = Math.Max(ans,rk-i+1);
        }
        return ans;
    }
}
```



调整之后调试通过，一开始以为 rk=-1是多此一举。。。。



<font size =5> 图解过程 </font>



以字符串**pwwkew**为例：

- S1: 很明显，我们需要遍历整个（改字符串的）数组，来建立**散列表**(**Dictionary** / **Hashset**)。

  >  由于我们需要用到子串，所以需要下标的信息

<img src="./img/image-20211219211108564.png" alt="image-20211219211108564" style="zoom:80%;" /> 

- S2: 首先是第一个字符 **p**， 由散列表中没有该记录，因此可以插入散列表中；此时，子串，或者说 移动窗口的长度 加1。

<img src="./img/image-20211219211559442.png" alt="image-20211219211559442" style="zoom:80%;" /> 



- S3：第二个字符**w**情况和S2类似，因此插入w到散列表中，子串的长度继续加1；

<img src="./img/image-20211219212555926.png" alt="image-20211219212555926" style="zoom:80%;" /> 

- S4： 第三个字符又是**w**,由于该字符串已经存在散列表内了，所以我们需要收缩窗口（子串）。具体收缩多少，取决于之前那个**w**出现的位置 和 现在的子串从哪里开始。窗口需要收缩**起始点**：如果当前子串已经包含**w**，那么收缩应该使得**子串刚好排除第一个`w`**。因此收缩后的子串变成了**w**。

  <img src="./img/image-20211219212919674.png" alt="image-20211219212919674" style="zoom:80%;" /> 

- 然后我们再看下一个子串**k**，可以插入散列表，因此移动窗口长度+1，把**k**也包含进来：

  <img src="./img/image-20211219213102446.png" alt="image-20211219213102446" style="zoom:80%;" /> 

- 同样，**e**也是如此操作：
  <img src="./img/image-20211219213212750.png" alt="image-20211219213212750" style="zoom:80%;" />



### 567.  [Permutation in string](https://leetcode-cn.com/problems/permutation-in-string/)

Given two string `s1` and `s2`, return `true` ***if** `s2` contains a permutation of `s1`, or `fase` otherwise.*

In other words, return `true` if one of `s1`'s permutation is the substring of `s2`.



**Example 1:**

```C#
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").
```



**Example 2:**

```C#
Input: s1 = "ab", s2 = "eidboaoo"
Output: false
```



**Constraints:**

- `s1` and `s2` consist of lowercase English letters.



#### `char[i] - a`: What does substracting a char by a char mean?

The goal is count the occurrences of each character.

```C#
c - 'a'
```

is a kind of clever way to get the position of the character in the alphabet. `'a' - 'a'` would give you 0. `'b' - 'a'` would give you 1. `'c' - 'a'` would give you 2, and so on.

That value is used as an index into the array (which as you correctly stated is initialised with zeros) and the count is incremented.

It's worth noting that this will break if any character other than `a-z` is present in the string (including uppercase characters), and you'd see an [`IndexOutOfBoundsException`](https://docs.oracle.com/javase/9/docs/api/java/lang/IndexOutOfBoundsException.html)



**Reference:**

1. [Java: What does subtracting a char by a char mean?](https://stackoverflow.com/questions/48424217/java-what-does-subtracting-a-char-by-a-char-mean)

   



####  [How to compare arrays in C#?](https://stackoverflow.com/questions/4423318/how-to-compare-arrays-in-c) 

You can use the Enumerable.SequenceEqual() in the System.Linq to compare the contents in the array

```C#
bool isEqual = Enumerable.SequenceEqual(target1, target2);
```



You could use [`Enumerable.SequenceEqual`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal). This works for any `IEnumerable<T>`, not just arrays.



> Great answer, and I know it's a little late, but that could be simplified to this: **bool isEqual = target1.SequenceEqual(target2)**





<font size =5> 解题思路 </font>

由于排列不会改变字符串中每个字符的个数，所以只有当两个字符串每个字符的个数均相等时，一个字符串才是另一个字符串的排列。

根据这一性质，记 `s1` 的长度为 `n` , 我们可以遍历`s2`中的每个长度为`n`的*子串*, 判断子串和`s1`中每个字符的个数是否相等，若相等则说明该子串是`s1`的一个排列。

使用两个数组`cnt1`和`cnt2`: `cnt1`统计`s1`中各个字符的个数, `cnt2`统计当前遍历的子串中各个字符的个数。

由于需要遍历的子串长度均为`n`,我们可以使用一个固定长度为 `n`的**滑动窗口**来维护`cnt2`: 滑动窗口每向右滑动一次，就多统计一次进入窗口的字符，少统计一次离开窗口的字符。然后，判断`cnt1`是否与`cnt2`相等，若相等则意味着 `s1`的排列是`s2`啊的子串。



<font size=5> 参考代码 </font>

```c#
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n = s1.Length, m = s2.Length;
        if(n>m)
        {
            return false;
        }
        int[] cnt1 = new int[26];
        int[] cnt2 = new int[26];

        for(int i=0;i<n;i++)
        {
            cnt1[s1[i]-'a']++;
            cnt2[s2[i]-'a']++;
        }
        if(Enumerable.SequenceEqual(cnt1,cnt2))
        {
            return true;
        }
        for(int i =n; i<m;i++)//滑动 n个窗口
        {
            cnt2[s2[i]-'a']++; 
            cnt2[s2[i-n]-'a']--;
            if(cnt2.SequenceEqual(cnt1))
            {
                return true;
            }
        }
        return false;
    }
}
```





## 广度优先搜索 / 深度优先搜索



### 733. [Flood fill](https://leetcode-cn.com/problems/flood-fill/)

An image is represented by an `mxn` integer grid `image` where `image[i][j]`represents the pixel value of the image.

You are also given three integers `sr`,`sc`,and `newColor`. You should perform a **flood fill** on the images starting from the pixel `images[sr][sc]`.

To perform a **flood fill**, consider the starting pixel, plus any pixels connected **4-directionally** to those pixels (also with the same color), and so on. Replace the color of all the aforementioned pixels with `newColor`.

Return *the modified image after performing the flood fill.*

<img src="./img/flood1-grid.jpg" alt="img" style="zoom:80%;" />



```c#
Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, newColor = 2
    
Output: [[2,2,2],[2,2,0],[2,0,1]]

Explanation: 
From the center of the image with position (sr, sc) = (1, 1) (i.e., the red pixel), all pixels connected by a path of the same color as the starting pixel (i.e., the blue pixels) are colored with the new color.
Note the bottom corner is not colored 2, because it is not 4-directionally connected to the starting pixel.

在图像的正中间，(坐标(sr,sc)=(1,1)), 在路径上所有符合条件的像素点的颜色都被更改成2。注意，右下角的像素没有更改为2，因为它不是在上下左右四个方向上与初始点相连的像素点。
```



<font size=5>参考代码 </font>

```c#
public class Solution {
    int[] dx={1,0,0,-1};
    int[] dy={0,1,-1,0};
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) 
    {
        int oldColor = image[sr][sc];
        if(oldColor!=newColor)
        {
            dsf(image,sr,sc,oldColor,newColor);
        }
        return image;
    }

    private void dsf(int[][] image,int r, int c,int oldColor, int newColor)
    {
        if(image[r][c]==oldColor)
        {
            image[r][c] = newColor;
            for(int i = 0; i<4;i++)
            {
                int mr = r + dx[i],mc = c+dy[i];
                if(mr>=0 && mr<image.Length && mc>=0 && mc<image[0].Length)
                {
                    dsf(image,mr,mc,oldColor,newColor);
                }
            }
        }
    }
}
```



<font size=5> 上下左右四个方向的偏移量</font>

问：

```c#
 int[] dx = {1, 0, 0, -1}; 
 int[] dy = {0, 1, -1, 0}; 
```

这两个什么意思啊

答：上下左右四个方向的偏移量；



即便有大佬给出了[答案](https://leetcode-cn.com/problems/flood-fill/solution/tu-xiang-xuan-ran-by-leetcode-solution/)，一时间还是有点难以理解，为什么dx一定是 `{1,0,0,-1}`，而不是 `{1,-1}`呢？

这个需要往回追溯之前更简单的，更易于理解，但是不那么简洁的代码：

```C#
// sr表示 row, sc表示column
public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        int oldColor = image[sr][sc];
        if(oldColor == newColor){
            return image;
        }else {
            image[sr][sc] = newColor;
        }
        //存在上
        if(sr - 1 >= 0 && image[sr-1][sc] == oldColor){
            floodFill(image,sr-1,sc,newColor);
        }
        //存在下
        if(sr + 1 < image.length && image[sr+1][sc] == oldColor){
            floodFill(image,sr+1,sc,newColor);
        }
        //存在左
        if(sc - 1 >= 0 && image[sr][sc-1] == oldColor){
            floodFill(image,sr,sc-1,newColor);
        }
        //存在右
        if(sc + 1 < image[sr].length && image[sr][sc+1] == oldColor){
            floodFill(image,sr,sc+1,newColor);
        }
        return image;
    }
```



<img src="./img/image-20211221153458658.png" alt="image-20211221153458658" style="zoom:80%;" />

如上图的一个矩阵所所示：

- image\[0][0]=a;	 image\[0][1]=b; 	image\[0][2]=c;  由此可以看出，移动第二个下标，指针会在a\b\c（同一个row的)三个**column**之间转跳检索;
- image\[0][0]=a;   image\[1][0]=d; image\[2][0]=g;  移动第一个下标，指针会在 a\d\g(同一个column下的)三个不同row之间转跳检索；

**由此可得出结论：**

- 改变第一个下标，则会在上下这个放下检索数据；
- 改变第二个下标，则会在左右这个放下检索数据。

我之前理解困难的原因：

- 移动第二个下标，明明就是改变row的位置嘛， 怎么就是改变column的位置呢?实在是是改变**同一个Row上的不同column**。这样解释是不是更能帮助自己理解？

- 有时候初学者的思维就会卡在这里面，会强烈的认为事情A是B，这时候需要反复阅读、抄写，画图理解则显得尤为重要。通过学这些算法，能深刻帮助理解孩子在学习过程中的思维以及如何引导。




## 常见单词记录



| 单词                                    | 解释                                                         |
| --------------------------------------- | ------------------------------------------------------------ |
| **Substring** <br />**Subsequence**     | "**`pwwkew`**"：`wke` be a **substring** of `pwwkew`,  whereas "`pwke`" is a **subsequence** and not a substring toward `pwwkew`. |
| **in-place**                            | adv： 部署（放置）适当的；就地；原状；在位<br />[In-place algorithm](https://en.wikipedia.org/wiki/In-place_algorithm): In [computer science](https://en.wikipedia.org/wiki/Computer_science), an **in-place algorithm** is an [algorithm](https://en.wikipedia.org/wiki/Algorithm) which transforms input using no auxiliary [data structure](https://en.wikipedia.org/wiki/Data_structure). |
| **permutation**<br />【ˌpɜːrmjuˈteɪʃn】 | per-完全 + mut-改变 + -ation表名词，***是单词 permute 派生的名词***。<br />**`per-`** <br/>表示“完全，贯穿，自始至终，向前”。forth, ford 是其同源词。<br/>**`mute-`** <br/>= change, 表示“改变、交换”。源自拉丁语 mutare "to change." |

