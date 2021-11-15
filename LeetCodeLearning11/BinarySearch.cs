using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            int head = 0, tail = nums.Length - 1;
            while (head <= tail)
            {
                int mid = (tail - head + head) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }

                if (target > nums[mid])
                {
                    head = mid + 1;
                }
                else
                {
                    tail = mid - 1;
                }
            }
            return -1;
        }
    }
}
