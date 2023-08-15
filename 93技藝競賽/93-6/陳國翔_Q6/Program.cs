using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q6
{
    internal class Program
    {
        public static int getx(char ch)
        {
            if (ch >= '0' && ch <= '9') return ch - '0';
            return ch - 'A' + 10;
        }
        static void Main(string[] args)
        {
            Console.Write("基底:");
            int b = int.Parse(Console.ReadLine());
            if (b < 2 || b > 16)
            {
                Console.WriteLine("輸入錯誤!");
                Console.ReadKey();
                return;
            }
            Console.Write("數值:");
            string text = Console.ReadLine();
            int m = 1;
            int total = 0;
            for(int i = text.Length - 1; i >= 0; i--)
            {
                total += getx(text[i]) * m;
                m *= b;
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
