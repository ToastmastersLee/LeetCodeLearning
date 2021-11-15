using System;

namespace LeetCodeLearning11
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearch bs = new BinarySearch();
             var retVal =  bs.Search(new[] {-1, 0, 3, 5, 9, 12}, 9);
            Console.WriteLine(retVal);
            Console.WriteLine("Hello World!");
        }
    }

}
