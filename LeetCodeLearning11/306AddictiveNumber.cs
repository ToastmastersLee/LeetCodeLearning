﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetCodeLearning11
{
    public class _306AddictiveNumber
    {
        /// <summary>
        /// 面向Debugger编程
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsAdditiveNumber(string num)
        {
            int n = num.Length;
            for (int secondStart = 1; secondStart < n - 1; secondStart++)
            {
                if (num[0] == '0' && secondStart != 1)
                {
                    break;
                }

                for (int secondEnd = secondStart; secondEnd < n - 1; secondEnd++)
                {
                    if (num[secondStart] == '0' && secondStart != secondEnd)
                    {
                        break;
                    }

                    if (Valid(secondStart, secondEnd, num))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Valid(int secondStart, int secondEnd, string num)
        {
            int n = num.Length;
            int firstStart = 0, firstEnd = secondStart - 1;

            while (secondEnd <= n - 1)
            {
                string third = StringAdd(num, firstStart, firstEnd, secondStart, secondEnd);
                int thirdStart = secondEnd + 1;
                int thirdEnd = secondEnd + third.Length;
                if (thirdEnd >= n || !num.Substring(thirdStart, thirdEnd - thirdStart + 1).Equals(third))
                {
                    break;
                }

                if (thirdEnd == n - 1)
                {
                    return true;
                }

                firstStart = secondStart;
                firstEnd = secondEnd;
                secondStart = thirdStart;
                secondEnd = thirdEnd;
            }

            return false;
        }

        private string StringAdd(string s, int firstStart, int firstEnd, int secondStart, int secondEnd)
        {
            StringBuilder third = new StringBuilder();
            int carry = 0, cur = 0;

           //while (firstEnd > firstStart || secondEnd >= secondStart || carry != 0)
           while (firstEnd >= firstStart || secondEnd >= secondStart || carry != 0)
           {
               cur = carry;
               if (firstEnd >= firstStart)
               {
                   cur += s[firstEnd] - '0';
                   --firstEnd;
               }

               if (secondEnd >= secondStart)
               {
                   cur += s[secondEnd] - '0';
                   --secondEnd;
               }

               carry = cur / 10;
               cur %= 10;
               third.Append((char) (cur + '0'));
           }



           char[] arr = third.ToString().ToCharArray();
            Array.Reverse(arr);
            third.Length = 0; //必须设置为0；
            foreach (char c in arr)
            {
                third.Append(c);
            }

            return third.ToString();
        }
    }
}
