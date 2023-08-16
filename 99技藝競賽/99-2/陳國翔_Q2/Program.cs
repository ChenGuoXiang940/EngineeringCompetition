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
            int n;
            while (true)
            {
                Console.Write("請輸入N=");
                if(int.TryParse(Console.ReadLine(),out n) && n >= 13 && n <= 99)
                {
                    int m = 1;
                    while (m <= n)
                    {
                        List<int> col = new List<int>();
                        for (int i = 1; i <= n; i++) col.Add(i);
                        int index = 0;
                        while (col.Count != 1)
                        {
                            col.RemoveAt(index);
                            index += m - 1;
                            index = index % col.Count;
                        }
                        if (col[0] == 13) break;
                        m++;
                    }
                    Console.WriteLine(m);
                    continue;
                }
                else
                {
                    Console.WriteLine("輸入錯誤");
                }
            }
        }
    }
}
