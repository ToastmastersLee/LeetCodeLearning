using System;

namespace ForDebugger
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 1024;
            int y = x >> 1;
            int z = x >> 2;

            int a = x << 1;
            int b = x << 2;

            Console.WriteLine("x="+x+ "  and Binary dispaly:" + Convert.ToString(x, 2));
            Console.WriteLine("y="+y+ "  and Binary dispaly:"+Convert.ToString(y, 2));
            Console.WriteLine("z=" + z + "  and Binary dispaly:" + Convert.ToString(z, toBase:2));

            Console.WriteLine("z=" + a + "  and Binary dispaly:" + Convert.ToString(a, toBase: 2));
            Console.WriteLine("z=" + b + "  and Binary dispaly:" + Convert.ToString(b, toBase: 2));
            Console.WriteLine("Hello World!");
        }
    }
}
