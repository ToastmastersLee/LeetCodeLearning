# LeetCode刷题Python基础



[toc]

### 解包/解构

1178\. [Sum of Unique Elements](https://leetcode-cn.com/problems/sum-of-unique-elements/)

You are given an integer array `nums`. The unique elements of an array are the elements that appear **exactly once** in the array.

Return *the **sum** of all the unique elements of* `num`.

**Example 1:**

```c#
Input: nums = [1,2,3,2]
Output: 4
Explanation: The unique elements are [1,3], and the sum is 4.
```



**Code**:

```python
public class Solution {
	def sumOfUnique(self,nums:List[int]) -> int:
    	return sum(num for num, cnt in Counter(nums).items() if cnt ==1 )
}
```



**字典解包（解构）**

```python
public class Solution {
	def sumOfUnique(self,nums:List[int]) -> int:
    	return sum(cnt for cnt in Counter(nums).items() if cnt ==1 )
}
```

num for num 后续没有其他地方引用num了 ，为什么这样写不行呢？



- **这里是字典解包**，是对字典的键进行遍历
- **for key, value in d** 这样就是键值对了



**Reference**

1. [Python: List Comprehensions](https://web.archive.org/web/20180309053826/http://www.secnetix.de/olli/Python/list_comprehensions.hawk)



### 切片

#### 基本解释

Slicing is indexing syntax that extracts a portion from a list

<img src="./img/image-20220729122337128.png" alt="image-20220729122337128" style="zoom: 25%;" /> 



<img src="./img/image-20220729122535633.png" alt="image-20220729122535633" style="zoom: 36%;" /> 

<img src="./img/image-20220729122720254.png" alt="image-20220729122720254" style="zoom:33%;" /> <img src="./img/image-20220729122739434.png" alt="image-20220729122739434" style="zoom:33%;" /> 



<img src="./img/image-20220729122758686.png" alt="image-20220729122758686" style="zoom:33%;" /> 



<img src="./img/image-20220729122818495.png" alt="image-20220729122818495" style="zoom:33%;" /> 

<img src="./img/image-20220729122829099.png" alt="image-20220729122829099" style="zoom:33%;" /> 



#### 反转字符串

Given a string `s`, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:

```python
Input: s = "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
```

Example 2:

```python
Input: s = "God Ding"
Output: "doG gniD"
```



[python 反转字符串中单词思路详解](https://leetcode.cn/problems/reverse-words-in-a-string-iii/solution/python-fan-zhuan-zi-fu-chuan-zhong-dan-ci-si-lu-xi/):

**解题思路**

因为在 Python 中字符串是不可变，因此遍历字符串交换每个单词内字符位置的方法不太可行，但是利用 Python 切片的便利，可以写出更优雅的实现方式。

**1、常规思路**

将字符串分割成单词列表 然后把每个单词反转切片

代码

```python
Python

class Solution(object):
    def reverseWords(self, s):
        return " ".join(word[::-1] for word in s.split(" "))
```

**分析**

- 时间复杂度： O(n) 。其中 nn 是字符串的长度。
- 空间复杂度： O(1) 。

**2、利用两次切片，不需遍历**

先反转单词列表 再反转字符串

> 以字符串 “I love drag queen” 为例：

**s.split(" ")** 将字符串分割成单词列表:

```python
['I', 'love', 'drag', 'queen']
```

**s.split(" ")[::-1]** 将单词列表反转:

```python
['queen', 'drag', 'love', 'I']
```

**" ".join(s.split(" ")[::-1])** 将单词列表转换为字符串，以空格分隔:

```python
"queen drag love I"
```

**" ".join(s.split(" ")[::-1])[::-1]** 将字符串反转：

```python
"I evol gard neeuq"
```



**代码**

```python
class Soution(object):
    def reverseWords(self, s):
        return " ".join(s.split(" ")[::-1])[::-1]
```

**分析**

- **时间复杂度**： O(n)*O*(*n*) 。其中 n*n* 是字符串的长度。
- **空间复杂度**： O(1)*O*(1) 。

或者，



**3、先反转字符串，再反转单词列表**
**s[::-1]** 反转字符串：

```python
“neeuq gard evol I”
```

**s[::-1].split(" ")** 将字符串分割成单词列表：

```python
['neeuq', 'gard', 'evol', 'I']
```

**s[::-1].split(" ")[::-1]** 将单词列表反转：

```python
['I', 'evol', 'gard', 'neeuq']
```

**" ".join(s[::-1].split(" ")[::-1])** 将单词列表转换为字符串，以空格分隔:

```python
"I evol gard neeuq"
```


代码

```python
class Soution(object):
    def reverseWords(self, s):
        return " ".join(s[::-1].split(" ")[::-1])
```

##### 分析

- **时间复杂度**：O(n)。其中 n*n* 是字符串的长度。
- **空间复杂度**：O(1)。



### 字符串操作

[557. 反转字符串中的单词 III](https://leetcode.cn/problems/reverse-words-in-a-string-iii/)

<img src="./img/image-20220729114716245.png" alt="image-20220729114716245" style="zoom:80%;" /> 

```python
class Solution(object):
    def reverseWords(self, s):
        return " ".join(word[::-1] for word in s.split(" "))
```

Python join() 方法用于将序列中的元素以指定的字符连接生成一个新的字符串。

```python
str.join(sequence)

str = "-";
seq = ("a", "b", "c"); # 字符串序列
print str.join( seq );

#输出：
a-b-c
```



#### Join 方法