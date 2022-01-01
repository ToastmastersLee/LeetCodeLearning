using System;
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

            _2022Convert1D22DArray conver2D = new _2022Convert1D22DArray();
            //var retVal =  conver2D.Construct2DArray(new[] { 1, 2, 3, 4 }, 2, 2);
            var retVal = conver2D.Construct2DArray(new[] { 1, 2, 3 }, 1, 3);

            Console.WriteLine(retVal);

            Console.WriteLine("Hello World!");
        }
    }
}
