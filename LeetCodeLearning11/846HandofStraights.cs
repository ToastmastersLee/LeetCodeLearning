using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class _846HandofStraights
    {
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            int len = hand.Length;
            if (len % groupSize != 0)
            {
                return false;
            }

            Array.Sort(hand);
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            foreach (int x in hand)
            {
                if (!cnt.ContainsKey(x))
                {
                    cnt.Add(x, 0);
                }

                cnt[x]++;
            }

            foreach (int x in hand)
            {
                if (!cnt.ContainsKey(x))
                {
                    continue;
                }

                for (int j = 0; j < groupSize; j++)
                {
                    int num = x + j;
                    if (!cnt.ContainsKey(num))
                    {
                        return false;
                    }

                    cnt[num]--;
                    if (cnt[num] == 0)
                    {
                        cnt.Remove(num);
                    }
                }
            }

            return true;
        }
    }
}
