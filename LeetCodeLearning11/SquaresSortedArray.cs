using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
  public  class SquaresSortedArray
    {
        public int[] SortedSquares(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int[] result = new int[] { nums.Length};
            int index = result.Length;
            while(left<=right)
            {
                if(nums[left] * nums[left] > nums[right] * right[*])
                {
                    result[index--] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[index--] = nums[right] * nums[right];
                }
            }
            return result;
        }
    }
}
