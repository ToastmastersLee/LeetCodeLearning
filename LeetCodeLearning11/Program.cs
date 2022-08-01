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
            //_539MinimumTimeDifference mtf = new _539MinimumTimeDifference();

            //mtf.FindMinDifference(new List<string>() { "23:59", "00:00" });

            //_1791FindsCenterofStarGraph test1 = new _1791FindsCenterofStarGraph();
            //var retVal =  test1.FindCenter();
            //Console.WriteLine(retVal);


            //string order = "leewa";
            //int[] index = new int[26];
            //for (int i = 0; i < order.Length; ++i)
            //{
            //    index[order[i] - 'a'] = i;
            //}

            //Console.WriteLine("Hello World!");

            static int Coroutine1(Coroutine1Token token)
            {
                // switch on our state
                switch (token.State)
                {
                    case 0: // initially, we increment the value
                        ++token.Value;
                        // .. until it's 100, then we go to state 1
                        if (100 == token.Value)
                            token.State = 1;
                        break;
                    case 1:
                        // next, after we're done above we decrement the value
                        --token.Value;
                        // .. until it's 1, then we go to state 2
                        if (1 == token.Value)
                            token.State = 2;
                        break;
                    case 2:
                        // state 2 is just to tell us we're at the end
                        // which we signal by returning -1
                        return -1;
                }
                // finally, just yield the value we have currently before exiting
                return token.Value;
            }

            //var tok = new Coroutine1Token();
            //int c;
            //Console.WriteLine("Coroutine1():");
            //while (-1 != (c = Coroutine1(tok)))
            //    Console.Write(c.ToString() + " ");
            //Console.WriteLine();

            static IEnumerable<int> Coroutine2()
            {
                // at the first state we count from 1 to 100, yielding each value
                for (var i = 1; i <= 100; i++)
                {
                    yield return i;
                }

                // at the next state we count from 99 to 1, yielding each value
                for (var i = 99; 0 < i; i--)
                {
                    yield return i;
                }
                // the final state is implicit, handled by the C# compiler
            }
            Console.WriteLine("Coroutine2():");
            foreach (var i in Coroutine2())
                Console.Write(i.ToString() + " ");
            Console.WriteLine();

            Console.WriteLine("Coroutine2() using while:");
            using (var e = Coroutine2().GetEnumerator())
            {
                // each time MoveNext() is called, Coroutine2() is run for a single step
                while (e.MoveNext())
                {
                    // e.Current holds the result of Coroutine2()'s step
                    Console.Write(e.Current.ToString() + " ");
                }
            }
            Console.WriteLine();

        }
    }
}
