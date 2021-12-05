using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class _283MoveZeores
    {
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
    }
}
