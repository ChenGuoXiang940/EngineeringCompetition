// See https://aka.ms/new-console-template for more information
using System;

namespace 陳國翔_Q1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                /*找兩個字串最長的長度*/
                Func<ulong, ulong, int> getmax = (x, y) => Math.Max(x.ToString().Length, y.ToString().Length);
                /*整數轉字串左補 y 個空格*/
                Func<ulong, int, string> pad = (x, y) => x.ToString().PadLeft(y);
                int n;
                Console.Write("輸入N=");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 90)
                {
                    Console.WriteLine("輸入值介於1~90!");
                    continue;
                }
                n -= 1;
                ulong[] ans = new ulong[4] { 1, 1, 1, 0 };
                ulong[] m = new ulong[4] { 1, 1, 1, 0 };
                while (n != 0)
                {
                    if ((n & 1) == 1)
                    {
                        ans = new ulong[4] { ans[0] * m[0] + ans[1] * m[2], ans[0] * m[1] + ans[1] * m[3], ans[2] * m[0] + ans[3] * m[2], ans[2] * m[1] + ans[3] * m[3] };
                    }
                    n >>= 1;
                    m = new ulong[4] { m[0] * m[0] + m[1] * m[2], m[0] * m[1] + m[1] * m[3], m[2] * m[0] + m[3] * m[2], m[2] * m[1] + m[3] * m[3] };
                }
                int len1 = getmax(ans[0], ans[1]);
                int len2 = getmax(ans[2], ans[3]);
                Console.WriteLine($"[{pad(ans[0], len1)} {pad(ans[1], len2)}]\r\n[{pad(ans[2], len1)} {pad(ans[3], len2)}]");
            }
        }
    }
}
