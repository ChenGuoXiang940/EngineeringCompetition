// See https://aka.ms/new-console-template for more information
using System.Numerics;
namespace _106_6
{
    static class Program
    {
        static void Main()
        {
            int val = int.Parse(Console.ReadLine() + "");
            BigInteger big = new BigInteger();
            big = 1;
            for(int i = 1; i <= val; i++)
            {
                big *= i;
            }
            string line = big.ToString();
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                count += line[i] - '0';
            }
            BigInteger target = new BigInteger();
            target = big;
            int count2 = 0;
            int n = 2;
            while (n <= target)
            {
                if (target % n == 0)
                {
                    target /= n;
                    count2++;
                }
                else
                {
                    n++;
                }
            }
            Console.WriteLine(line + "\r\n" + count.ToString() + "\r\n" + count2.ToString());
            Console.ReadKey();
        }
    }
}
