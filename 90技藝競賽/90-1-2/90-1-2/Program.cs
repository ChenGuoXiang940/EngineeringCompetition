using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _90_1_2
{
    internal class Program
    {
        public static BigInteger f(BigInteger start,BigInteger stop)/*階層運算*/
        {
            BigInteger result = 1;
            for(BigInteger i = start; i <= stop; i++)
            {
                result *= i;
            }
            return result;
        }
        public static BigInteger gcd(BigInteger m, BigInteger n)/*最大公因式*/
        {
            if (n == 0)
                return m;
            else
                return gcd(n, m % n);
        }
        static void Main(string[] args)
        {
            //ex:
            //m=20,n=6:P＝38760
            //m=100,n=9:P=1902231808400
            //m=42,n=6:P＝5245786
            //m=1,n=10:P=0
            //m=100,n=100:P=1
            //m=200,n=100:P=90548514656103281165404177077484163874504589675413336841320
            while (true)
            {
                Console.Write("請輸入m=");
                BigInteger m = BigInteger.Parse(Console.ReadLine());
                Console.Write("請輸入n=");
                BigInteger n = BigInteger.Parse(Console.ReadLine());
                BigInteger ans = f(m - n + 1, m) / (f(1, n));
                if (ans == 0 || ans % 1 == 0) Console.WriteLine($"P={ans}");
                else Console.WriteLine($"P=1/{ans}");
            }
        }
    }
}
