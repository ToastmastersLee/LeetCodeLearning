using System;
using System.Collections.Generic;
using System.Globalization;

namespace LeetCodeLearning11
{
    class Program
    {
        static void Main(string[] args)
        {



            //_846HandofStraights hand = new _846HandofStraights();
            // var retVal = hand.IsNStraightHand(new[] {1, 2, 3, 6, 2, 3, 4, 7, 8},3);
            // Console.WriteLine(retVal);

            /* _2022Convert1D22DArray conver2D = new _2022Convert1D22DArray();
             //var retVal =  conver2D.Construct2DArray(new[] { 1, 2, 3, 4 }, 2, 2);
             var retVal = conver2D.Construct2DArray(new[] { 1, 2, 3 }, 1, 3);

             Console.WriteLine(retVal);*/

            //_306AddictiveNumber anumber = new _306AddictiveNumber();
            //var retVal = anumber.IsAdditiveNumber("199111992");//"199111992"  112358
            //Console.WriteLine(retVal);
            _539MinimumTimeDifference mtf = new _539MinimumTimeDifference();
            
            mtf.FindMinDifference(new List<string>() { "23:59", "00:00" });

            Console.WriteLine("Hello World!");
        }
    }
}
