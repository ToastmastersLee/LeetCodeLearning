using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public  class _3longest_substring_without_repeating_characters
    {
        public int LengthOfLongestSubstring(string s)
        {
            // s = "pwwkew"
            Dictionary<char, int> map = new Dictionary<char, int>();
            int maxLen = 0; //用于记录最大不重复子串的长度
            int left = 0; //滑动窗口做指针
            for(int i=0;i<s.Length;i++)
            {
                if(map.ContainsKey(s[i]))
                {
                    left = Math.Max(left, map[s[i]] + 1);
                }
                map[s[i]] = i;
                maxLen = Math.Max(maxLen, i - left + 1);
            }
            return maxLen;
        }
    }
}
