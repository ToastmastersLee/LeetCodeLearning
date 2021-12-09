using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class _557ReverseWordsInString3
    {
        public string ReverseWords(string s)
        {
            string[] arrString = s.Split(' ');
            string strReverse = "";
            for (int i = 0; i <= arrString.Length-1; i++)
            {
                char[] arrChar = arrString[i].ToCharArray();
                int left = 0, right = arrChar.Length - 1;
                while (left < right)
                {
                    char temp = arrChar[left];
                    arrChar[left] = arrChar[right];
                    arrChar[right] = temp;
                    left++;
                    right--;
                }
                //strReverse = " " + arrChar.ToString();//System.char();
                strReverse += " " + new string(arrChar);
            }
            return strReverse;
        }

        public string ReverseWords2(string s)
        {
            string[] arrString = s.Split(' ');
            List<string> strReverse = new List<string>();
            for (int i = 0; i <= arrString.Length - 1; i++)
            {
                char[] arrChar = arrString[i].ToCharArray();
                int left = 0, right = arrChar.Length - 1;
                while (left < right)
                {
                    char temp = arrChar[left];
                    arrChar[left] = arrChar[right];
                    arrChar[right] = temp;
                    left++;
                    right--;
                }
                strReverse.Add(new string(arrChar));
            }
            return string.Join(" ", strReverse);
        }
    }
}
