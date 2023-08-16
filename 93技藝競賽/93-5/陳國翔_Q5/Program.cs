using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
                double m = arr[1], s = arr[1] * 60;
                switch (arr[0])
                {
                    case 1:
                        Console.WriteLine($"{600 + m * 5}");
                        break;
                    case 2:
                        double ans = s * 0.15 > 200 ? s * 0.15 - 200 : 200;
                        Console.WriteLine($"{ans}");
                        break;
                    case 3:
                        double ans2 = (s - 300) * 0.2 > 66 ? (s - 300) * 0.2 - 66 : 66;
                        Console.WriteLine($"{ans2}");
                        break;
                }
            }
        }
    }
}
