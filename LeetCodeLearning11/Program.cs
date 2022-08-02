using System;
using System.Collections.Generic;
using System.Globalization;

namespace LeetCodeLearning11
{
    class Program
    {
        public class Coroutine1Token
        {
            public int State { get; set; }
            public int Value { get; set; }

        }

        static void Main(string[] args)
        {
            _3longest_substring_without_repeating_characters  test  = new _3longest_substring_without_repeating_characters();
            var retVal =  test.LengthOfLongestSubstring();
            Console.WriteLine(retVal);
        }
    }
}
