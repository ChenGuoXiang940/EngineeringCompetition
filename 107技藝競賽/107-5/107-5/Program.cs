using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _107_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //7
                //-2 5 3 -6 4 -8 6
                //6
                //1 -2 3 5 -3 2
                //6
                //0 -2 3 5 -1 2
                Console.ReadLine();
                int[] num = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                int[] num2 = new int[num.Length + 1];
                int total = 0;
                num2[0] = 0;
                for (int i = 1; i < num2.Length; i++)
                {
                    total += num[i - 1];
                    num2[i - 1] = total;
                }
                Data data = new Data(0, -1, -1);
                for (int i = 0; i < num2.Length; i++)
                {
                    for (int j = i + 1; j < num2.Length; j++)
                    {
                        if (data.total < num2[j] - num2[i])
                        {
                            data = new Data(num2[j] - num2[i], i, j);
                        }
                    }
                }
                Console.WriteLine($"{data.total}\r\n{data.left + 1} {data.right}");
            }
        }
    }
    public class Data
    {
        public int total;
        public int left;
        public int right;
        public Data(int total,int left,int right)
        {
            this.total = total;
            this.left = left;
            this.right = right;
        }
    }
}
