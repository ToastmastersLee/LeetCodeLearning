using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            /*假如它移动的是3次，6次，9次，12次.....390次？
             * 位置应该都是和移动3次是一样结构，所以取模*/
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length -1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        public void Reverse(int[] nums,int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = nums[temp];
                start++;
                end--;
            }

        }
    }
}
