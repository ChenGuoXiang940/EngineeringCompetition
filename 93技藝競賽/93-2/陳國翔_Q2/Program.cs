using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Replace("p", "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            double w = arr[0], r = arr[1], c = arr[2];
            double ro = 350, cl = 0.2;
            double tb = 350, rb = 350, cb = 0.04;
            if (w == 0)
            {
                Console.WriteLine($"{(ro + r) * (c + cl)}ps");
            }
            else if (w > 0)
            {
                Console.WriteLine($"{(ro + r / 2) * (c / 2 + w * cb) + tb + (rb / w + r / 2)*(c / 2 + cl)}ps");
            }
            Console.ReadKey();
        }
    }
}
