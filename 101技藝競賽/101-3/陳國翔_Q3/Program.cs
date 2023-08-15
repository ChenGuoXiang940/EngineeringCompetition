using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] f = new double[31];
            f[0] = 1;
            f[1] = 1;
            for (int i = 2; i <= 30; i++) f[i] = i * f[i - 1];
            Console.Write("請輸入徑向距離(r)=");
            double r = double.Parse(Console.ReadLine());
            Console.Write("請輸入徑向多項次的次數(n)=");
            int n = int.Parse(Console.ReadLine());
            for(int m = 0; m <= n; m += 2)
            {
                Console.WriteLine($"計算徑向多項式(radial polynomials)...r={r} n={n} m={m}");
                double rnm = 0;
                int len = (n - Math.Abs(m)) / 2;
                for (int s = 0; s <= len; s++)
                {
                    double val = f[n - s] / (f[s] * f[(n + Math.Abs(m)) / 2 - s] * f[len - s]) * Math.Pow(r, n - 2 * s);
                    rnm += s == 0 || s % 2 == 0 ? val : -val;
                }
                Console.WriteLine($"所求徑向多項式為={rnm}");
            }
            Console.WriteLine("計算完畢!");
            Console.ReadKey();
        }
    }
}
