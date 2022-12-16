# Bitwise and shift operators (C# reference)

[toc]



今日在做  [390. Elimination Game](https://leetcode-cn.com/problems/elimination-game/)的时候直接不会，看答案也是直接懵逼。

```C#
class Solution {
public:
    int lastRemaining(int n) {
        int head = 1;
        int step = 1;
        bool left = true;
        //int n = n

        while (n > 1) {
            //从左边开始移除 or（从右边开始移除，数列总数为奇数）
            if (left || n % 2 != 0) {
                head += step;
            }
            step <<= 1; //步长 * 2
            n >>= 1;  //总数 / 2
            left = !left; //取反移除方向
        }

        return head;
    }

作者：xing-you-ji
链接：https://leetcode-cn.com/problems/elimination-game/solution/wo-hua-yi-bian-jiu-kan-dong-de-ti-jie-ni-k2uj/
来源：力扣（LeetCode）
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
```





## Definition

> The left-shift operator (<<) shifts its first operand left by the number of bits specified by its second operand. The type of the second operand must be an int. [<< Operator (MSDN C# Reference)](http://msdn.microsoft.com/en-us/library/a1sway8w.aspx) 
>
> - 左移位运算符（<<）将其第一个操作数向左移位第二个操作数指定的位数。第二个操作数的类型必须是int.
> - **operand** [ɑpə'rænd] 运算对象(操作数) ：a number or quantity that has something done to it in a calculation. For example, in **`7 + y`**, **`7`** and **`y`** are the operands.
>
> 
>
> <img src="./img/300px-Rotate_left_logically.svg.png" alt="alt text" style="zoom:120%;" />

For binary numbers it is a bitwise operation that shifts all of the bits of its operand; every bit in the operand is simply moved a given number of bit positions, and the vacant bit-positions are filled in.

> 对于二进制数，它是逐位操作，移位其操作数的所有位;操作数中的每一位都被简单地移动到给定数量的位位，空的位位被填充。



## Usage

Arithmetic shifts can be useful as efficient ways of performing multiplication or division of signed integers by powers of two. Shifting left by *n* bits on a signed or unsigned binary number has the effect of multiplying it by *2n*. Shifting right by *n* bits on a two's complement signed binary number has the effect of dividing it by *2n*, but it always rounds down (towards negative infinity). This is different from the way rounding is usually done in signed integer division (which rounds towards 0). This discrepancy has led to bugs in more than one compiler.

An other usage is work with *color bits*. Charles Petzold Foundations [article "Bitmaps And Pixel Bits"](http://msdn.microsoft.com/en-us/magazine/cc534995.aspx?pr=blog) shows an example of << when working with colors:

```cs
ushort pixel = (ushort)(green << 5 | blue);
```



The following operators perform bitwise or shift operations with operands of the [integral numeric types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types) or the [char](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char) type:

- Unary [`~` (bitwise complement)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-) operator
- Binary [`<<` (left shift)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-) and [`>>` (right shift)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#right-shift-operator-) shift operators
- Binary [`&` (logical AND)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-), [`|` (logical OR)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-), and [`^` (logical exclusive OR)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-exclusive-or-operator-) operators

Those operators are defined for the `int`, `uint`, `long`, and `ulong` types. When both operands are of other integral types (`sbyte`, `byte`, `short`, `ushort`, or `char`), their values are converted to the `int` type, which is also the result type of an operation. When operands are of different integral types, their values are converted to the closest containing integral type. For more information, see the [Numeric promotions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#numeric-promotions) section of the [C# language specification](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/introduction).

The `&`, `|`, and `^` operators are also defined for operands of the `bool` type. For more information, see [Boolean logical operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators).

Bitwise and shift operations never cause overflow and produce the same results in [checked and unchecked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked-and-unchecked) contexts.



## Overview



以下运算符使用[整数类型](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)或 [char](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/char) 类型的操作数执行位运算或移位运算：

- 一元 [`~`（按位求补）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-)运算符
- 二进制 [`<<`（向左移位）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-)和 [`>>`（向右移位）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#right-shift-operator-)移位运算符
- 二进制 [`&`（逻辑 AND）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-)、[`|`（逻辑 OR）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-)和 [`^`（逻辑异或）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-exclusive-or-operator-)运算符

这些运算符是针对 `int`、`uint`、`long` 和 `ulong` 类型定义的。 如果两个操作数都是其他整数类型（`sbyte`、`byte`、`short`、`ushort` 或 `char`），它们的值将转换为 `int` 类型，这也是一个运算的结果类型。 如果操作数是不同的整数类型，它们的值将转换为最接近的包含整数类型。 有关详细信息，请参阅 [C# 语言规范](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/introduction)的[数值提升](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/expressions#numeric-promotions)部分。

`&`、`|` 和 `^` 运算符也是为 `bool` 类型的操作数定义的。 有关详细信息，请参阅[布尔逻辑运算符](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/boolean-logical-operators)。

位运算和移位运算永远不会导致溢出，并且不会在[已检查和未检查的](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/checked-and-unchecked)上下文中产生相同的结果。



## 左移位运算符 <<



`<<` 运算符将其左侧操作数向左移动[右侧操作数定义的位数](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#shift-count-of-the-shift-operators)。

左移运算会放弃超出结果类型范围的高阶位，并将低阶空位位置设置为零，如以下示例所示：

```csharp
uint x = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}");

uint y = x << 4;
Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}");
// Output:
// Before: 11001001000000000000000000010001
// After:  10010000000000000000000100010000
```

由于移位运算符仅针对 `int`、`uint`、`long` 和 `ulong` 类型定义，因此运算的结果始终包含至少 32 位。 如果左侧操作数是其他整数类型（`sbyte`、`byte`、`short`、`ushort` 或 `char`），则其值将转换为 `int` 类型，如以下示例所示：

C#复制运行

```csharp
byte a = 0b_1111_0001;

var b = a << 8;
Console.WriteLine(b.GetType());
Console.WriteLine($"Shifted byte: {Convert.ToString(b, toBase: 2)}");
// Output:
// System.Int32
// Shifted byte: 1111000100000000
```

有关 `<<` 运算符的右侧操作数如何定义移位计数的信息，请参阅[移位运算符的移位计数](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#shift-count-of-the-shift-operators)部分。



## 代码调试结果

```c#
static void Main(string[] args)
{

    int x = 1024;
    int y = x >> 1;
    int z = x >> 2;

    int a = x << 1;
    int b = x << 2;

    Console.WriteLine("x="+x+ "  and Binary dispaly:" + Convert.ToString(x, 2));
    Console.WriteLine("y="+y+ "  and Binary dispaly:"+Convert.ToString(y, 2));
    Console.WriteLine("z=" + z + "  and Binary dispaly:" + Convert.ToString(z, toBase:2));

    Console.WriteLine("a=" + a + "  and Binary dispaly:" + Convert.ToString(a, toBase: 2));
    Console.WriteLine("b=" + b + "  and Binary dispaly:" + Convert.ToString(b, toBase: 2));
}
```

| Decimal    | Binary                           |
| ---------- | -------------------------------- |
| x=**1024** | and Binary dispaly:10000000000   |
| y=**512**  | and Binary dispaly:1000000000    |
| z=**256**  | and Binary dispaly:100000000     |
| a=**2048** | and Binary dispaly:100000000000  |
| b=**4096** | and Binary dispaly:1000000000000 |

算术移位可以对2的幂次进行高效的相乘或相除的。左移动 $n$ 位，其效果是乘以 $2^n$。右移动 $n$ 位可以将其除以$2^n$

> Shifting left by *n* bits on a signed or unsigned binary number has the effect of multiplying it by $2^n$. Shifting right by *n* bits on a two's complement signed binary number has the effect of dividing it by $2^n$



### 小结

对于[这道](https://leetcode.cn/problems/search-insert-position/solution/sou-suo-cha-ru-wei-zhi-by-leetcode-solution/)题目：

```C++
class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        int n = nums.size();
        int left = 0, right = n - 1, ans = n;
        while (left <= right) {
            int mid = ((right - left) >> 1) + left;
            if (target <= nums[mid]) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans;
    }
};
```

`(right - left) >> 1` 表示的就是 `(right - left) // 2`



## Reference

1. [Bitwise and shift operators (C# reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-)
2. [位运算符和移位运算符（C# 参考）](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators)
3. [What does the operator "<<" mean in C#?](https://stackoverflow.com/questions/2007526/what-does-the-operator-mean-in-c)
4. [Quickest way to convert a base 10 number to any base in .NET?](https://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net)



## 文档修订记录

| 版本号 | 变化状态 | 简要说明             | 日期       |
| ------ | -------- | -------------------- | ---------- |
| v0.1   | 初稿     | 初步恶补了位移运算符 | 2022-1-2   |
| v0.1   | 补充     | 又重新温习了一遍     | 2022-12-16 |