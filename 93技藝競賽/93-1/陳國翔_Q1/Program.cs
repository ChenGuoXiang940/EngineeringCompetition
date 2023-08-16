using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int h = arr[0];
            int d = arr[1];
            string ans = "";
            int count = 0;
            while (h > 0)
            {
                ans += $"{h} ";
                h = h / 2 - d / 5;
                count++;
            }
            ans += $"{0} ";
            Console.WriteLine(ans + $"{count - 1}");
            Console.ReadKey();
        }
    }
}
