using System;
using System.Globalization;

namespace LeetCodeLearning11
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearch bs = new BinarySearch();
            //var retVal =  bs.Search(new[] {-1, 0, 3, 5, 9, 12}, 9);
            //SearchInsertClass sic = new SearchInsertClass();
            //var retVal = sic.SearchInsert(new[] { 1, 3, 5, 6 }, 2);

            //_557ReverseWordsInString3 resversClass = new _557ReverseWordsInString3();
            //var retVal = resversClass.ReverseWords2("Let's take LeetCode contest");
            //Console.WriteLine(retVal);

            //_3longest_substring_without_repeating_characters longS = new _3longest_substring_without_repeating_characters();
            //var retVal = longS.LengthOfLongestSubstring("pwwkew");
            //Console.WriteLine(retVal);

            //string s = "2021-12-22";
            //DateTime mDate = DateTime.Parse(s);
            //int aa =  mDate.DayOfYear;
            //Console.WriteLine(aa);

            //for (int i = 0; i < 5; ++i)
            //{
            //    for (int j = i + 1; j < 5; ++j)
            //    {
            //        Console.WriteLine($@"i={i}, j = {j}");
            //    }
            //}


            _846HandofStraights hand = new _846HandofStraights();
             var retVal = hand.IsNStraightHand(new[] {1, 2, 3, 6, 2, 3, 4, 7, 8},3);
             Console.WriteLine(retVal);

            Console.WriteLine("Hello World!");
        }
    }
}
