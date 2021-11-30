using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class SearchInsertClass
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    //中间值大于目标值，目标值则着落在[left,mid-1]之间 2021年11月30日20:56:47
                    // left = mid + 1;
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    //中间值小于目标值，则目标值坐落在[mid+1,right]之间
                    //right = mid - 1;
                    left = mid + 1;
                }
            }
            return left;
        }
    }
}
