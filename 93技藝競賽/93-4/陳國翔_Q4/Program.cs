using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int val = int.Parse(Console.ReadLine());
            double sqrt = Math.Sqrt(val);
            int count = 0;
            Console.WriteLine("count X Y");
            for(int i = 1; i < sqrt; i++)
            {
                for (int j = 1; j < sqrt; j++)
                {
                    if (i * i + j * j == val)
                    {
                        Console.WriteLine($"{++count} {i} {j}");
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("Sorry,No answer found.");
            }
            else if (count == 1)
            {
                Console.WriteLine("There is 1 possible answer");
            }
            else
            {
                Console.WriteLine($"There are {count} possible answers.");
            }
            Console.ReadKey();
        }
    }
}
