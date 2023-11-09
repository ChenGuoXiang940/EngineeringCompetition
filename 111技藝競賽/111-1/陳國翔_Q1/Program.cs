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
                Func<string, int, string> pad = (x, y) => x.PadLeft(y);
                /*矩陣相乘*/
                Func<ulong[], ulong[], ulong[]> mult = (a, b) => new ulong[4] { 
                    a[0] * b[0] + a[1] * b[2],
                    a[0] * b[1] + a[1] * b[3],
                    a[2] * b[0] + a[3] * b[2],
                    a[2] * b[1] + a[3] * b[3] };
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
                        ans = mult(ans, m);
                    }
                    n >>= 1;
                    m = mult(m, m);
                }
                int len1 = getmax(ans[0], ans[1]);
                int len2 = getmax(ans[2], ans[3]);
                List<string> res = ans.ToList().Select(item => item.ToString()).ToList();
                Console.WriteLine($"[{pad(res[0], len1)} {pad(res[1], len2)}]\r\n" +
                    $"[{pad(res[2], len1)} {pad(res[3], len2)}]");
            }
        }
    }
}
