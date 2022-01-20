using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeLearning11
{
    /// <summary>
    /// https://leetcode-cn.com/problems/minimum-time-difference/solution/zui-xiao-shi-jian-chai-by-leetcode-solut-xolj/
    /// </summary>
    public class _539MinimumTimeDifference
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            timePoints = timePoints.OrderBy(x => x).ToList();
            int ans = int.MaxValue;
            int t0Minutes = getMinutes(timePoints[0]);
            int preMinutes = t0Minutes;
            for (int i = 1; i < timePoints.Count; ++i)
            {
                int minutes = getMinutes(timePoints[i]);
                ans = Math.Min(ans, minutes - preMinutes); // 相邻时间的时间差
                preMinutes = minutes;
            }
            ans = Math.Min(ans, t0Minutes + 1440 - preMinutes); // 首尾时间的时间差
            return ans;
        }

        /// <summary>
        /// 没有明白数组 减去 '0' 什么意思
        /// </summary>
        /// <param name="t"> "23:59" </param>
        /// <returns></returns>
        public int getMinutes(string t)
        {
            return ((t[0] - '0') * 10 + (t[1] - '0')) * 60 + (t[3] - '0') * 10 + (t[4] - '0');
        }
    }
}
