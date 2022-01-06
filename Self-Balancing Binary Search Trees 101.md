# **Self-Balancing Binary Search Trees 101**



[toc]



**Data Structures** are a specialized means of organizing and storing data in computers in such a way that we can perform operations on the stored data more efficiently. Out of the numerous data structures present, binary search trees play an important role when it comes to efficient operations. Since I received a lot of interest and kind responses for my previous article [8 Common Data Structures every Programmer must know](https://towardsdatascience.com/8-common-data-structures-every-programmer-must-know-171acf6a1a42), I will briefly explain about self-balancing binary search trees (BSTs) in this article.

![img](https://miro.medium.com/max/38/1*pbpIC4o1lKVUR2VrjQ_oKQ.png?q=20)

![img](https://miro.medium.com/max/875/1*pbpIC4o1lKVUR2VrjQ_oKQ.png)

## What are Binary Search Trees?

If you have read my [previous article on data structures](https://towardsdatascience.com/8-common-data-structures-every-programmer-must-know-171acf6a1a42), you know that a **binary search tree (BST)** is a binary tree where data is organized in a hierarchical structure.

A binary search tree exhibits a unique property known as the **binary-search-tree property**.

Let **x** be a node in a binary search tree.

- If **y** is a node in the **left** subtree of x, then **y.key ≤ x.key**
- If **y** is a node in the **right** subtree of x, then **y.key ≥ x.key**

![img](https://miro.medium.com/max/38/1*ziYvZzrttFYMXkkV9u66jw.png?q=20)

![img](https://miro.medium.com/max/875/1*ziYvZzrttFYMXkkV9u66jw.png)

Fig 1. Visualization of Basic Terminology of Binary Search Trees.

## What are Self-Balancing Binary Search Trees?

A self-balancing binary search tree (BST) is a binary search tree that automatically tries to keep its height as minimal as possible at all times (even after performing operations such as insertions or deletions).

If you have gone through the [Big-O Algorithm Complexity Cheat Sheet](https://www.bigocheatsheet.com/), you can see that the average time complexity of BST operations is *Θ(h)*, where *h* is the height of the tree. Hence having the height as small as possible is better when it comes to performing a large number of operations. Hence, self-balancing BSTs were introduced which automatically maintain the height at a minimum. However, you may think having to self-balance every time an operation is performed is not efficient, but this is compensated by ensuring a large number of fast operations which will be performed later on the BST.

A binary tree with height *h* can have at most `2⁰+2¹+···+2ʰ = 2⁽ʰ⁺¹⁾−1` nodes.

> n ≤ 2⁽ʰ⁺¹⁾ − 1
>
> h ≥ ⌈log₂(n+1) - 1⌉ ≥ ⌊log₂(n)⌋

Hence, for self-balancing BSTs, the minimum height must always be ***log\*₂(\*n)\*** rounded down. Moreover, a binary tree is said to be **balanced** if the height of left and right children of every node differ by either **-1**, **0** or **+1**. This value is known as the **balance factor**.

> **Balance factor = Height of the left subtree - Height of the right subtree**

## How do Self-Balancing Binary Search Trees Balance?

When it comes to self-balancing, BSTs perform **rotations** after performing insert and delete operations. Given below are the two types of rotation operations that can be performed to balance BSTs without violating the binary-search-tree property.

### 1. Left rotation

When we left rotate about node *x*, node *y* becomes the new root of the subtree. Node *x* becomes the left child of node *y* and subtree *b* becomes the right child of node *x*.

![img](https://miro.medium.com/max/38/1*Y3Y4oYeIi8tu6ILcPDvJVQ.png?q=20)

![img](https://miro.medium.com/max/875/1*Y3Y4oYeIi8tu6ILcPDvJVQ.png)

Fig 2. Left rotation on node x

### 2. Right rotation

When we right rotate about node *y*, node *x* becomes the new root of the subtree. Node *y* becomes the right child of node *x* and subtree *b* becomes the left child of node *y*.

![img](https://miro.medium.com/max/38/1*gDASVRN4ZYVsnRAzLkVTVg.png?q=20)

![img](https://miro.medium.com/max/875/1*gDASVRN4ZYVsnRAzLkVTVg.png)

Fig 3. Right rotation on node y

Note that, once you have done rotations, the in-order traversal of nodes in both the previous and final trees are the same and the binary-search-tree property holds.

## Types of Self-Balancing Binary Search Trees

Given below are a few types of BSTs that are self-balancing.

1. AVL trees
2. Red-black trees
3. Splay trees
4. Treaps

## Applications of Self-Balancing Binary Search Trees

Self-balancing BSTs are used to construct and maintain ordered lists, such as priority queues. They are also used for [associative arrays](https://en.wikipedia.org/wiki/Associative_array) where key-value pairs are inserted according to an ordering based only on the key.

Many algorithms in computational geometry make use of self-balancing BSTs to solve problems such as the [line segment intersection](https://en.wikipedia.org/wiki/Line_segment_intersection) problem efficiently. Moreover, self-balancing BSTs can be extended to perform new operations which can be used to optimize database queries or other list-processing algorithms.

## AVL Trees as an Example of Self-Balancing BSTs

*Adelson-Velskii and Landis* (**AVL**) trees are binary trees which are balanced. All the node in an AVL tree stores their own balance factor.

> In an AVL tree, the balance factor of every node is either -1, 0 or +1.

In other words, the difference between the height of the left subtree and the height of the right subtree cannot be more than 1 for all of the nodes in an AVL tree.

#### Example AVL Tree

![img](https://miro.medium.com/max/38/1*p_BEs3KOMWCM0uPPbrfFMw.png?q=20)

![img](https://miro.medium.com/max/875/1*p_BEs3KOMWCM0uPPbrfFMw.png)

Fig 4. Example AVL Tree

In Figure 4, the values in red colour above the nodes are their corresponding balance factors. You can see that the balance factor condition is satisfied in all the nodes of the AVL tree shown in Figure 4.

## Rotations in AVL Trees

After performing insertions or deletions in an AVL tree, we have to check whether the balance factor condition is satisfied by all the nodes. If the tree is not balanced, then we have to do **rotations** to make it balanced.

Rotations performed on AVL trees can be of four main types that are grouped under two categories. They are,

1. **Single rotations** — **Left (LL) Rotation** and **Right (RR) Rotation**
2. **Double rotations** — **Left Right (LR) Rotation** and **Right Left (RL) Rotation**

The diagrams given below will explain each rotation type.

### 1. Single Left Rotation (LL Rotation)

In this type of rotation, we move all the nodes to the left by one position.

![img](https://miro.medium.com/max/1250/1*xoMIfEzXR9jtQkBpU0LCig.png)

Fig 5. LL Rotation

### 2. Single Right Rotation (RR Rotation)

In this type of rotation, we move all the nodes to the right by one position.

![img](https://miro.medium.com/max/1250/1*lH8JUx-hsPwuuldD9slsag.png)

Fig 6. RR Rotation

### 3. Left Right Rotation (LR Rotation)

As the name implies, this type of rotation consists of a left rotation and a right rotation.

![img](https://miro.medium.com/max/1250/1*snGqykViLDcp1Jcx-fUWuw.png)

Fig 7. LR Rotation

### 4. Right Left Rotation (RL Rotation)

This type of rotation consists of a right rotation followed by a left rotation.

![img](https://miro.medium.com/max/1250/1*W5zSFsU-gr9LFEgZ4oD1fA.png)

Fig 8. RL Rotation

## Inserting an Element to an AVL Tree

Consider the AVL tree given in Figure 4. We want to add a new node 105 to this tree. Figure 9 denotes the steps carried out to insert the new node and rebalance the tree.

![img](https://miro.medium.com/max/4478/1*MQpZMmPrfKREb3AZsfxEBg.png)

Fig 9. Insert and Balance

After adding node 105, there will be altogether 12 nodes in the tree. If we calculate the height possible for the tree to be balanced,

> h ≥ ⌈log₂(n+1) — 1⌉
>
> h ≥ ⌈log₂(12+1) — 1⌉
>
> h ≥ ⌊log₂(12)⌋ = ⌊3.58496250072⌋ = 3

However, the height of the resulting tree after insertion has a height of 4. Moreover, the balance factor of node 102 is -2. From these facts, we can see that the resulting tree after insertion is not balanced. Hence, we have to balance it by doing rotations. You can see that the subtree rooted from node 102 should be rotated and an RL rotation should be used. After performing this rotation, we get a balanced tree with a height of 3.

## Final Thoughts

I hope you found this article useful as a simple introduction to self-balancing binary search trees where we discussed AVL trees as an example. I would love to hear your thoughts. 😇

Thanks a lot for reading. 😊 Stay tuned for the upcoming articles where I will explain more about self-balancing BSTs.

Cheers! 😃

## References

- [1] [CS241 — Lecture Notes: Self-Balancing Binary Search Tree](https://www.cpp.edu/~ftang/courses/CS241/notes/self balance bst.htm)
- [2] [Self-balancing binary search tree — Wikipedia](https://en.wikipedia.org/wiki/Self-balancing_binary_search_tree)
- [3] [Data Structures Tutorials — AVL Tree | Examples | Balance Factor](http://www.btechsmartclass.com/data_structures/avl-trees.html)
- [4] [Self-Balancing Binary Search Trees 101](https://towardsdatascience.com/self-balancing-binary-search-trees-101-fc4f51199e1d)
- [5] [8 Common Data Structures every Programmer must know](https://towardsdatascience.com/8-common-data-structures-every-programmer-must-know-171acf6a1a42)

