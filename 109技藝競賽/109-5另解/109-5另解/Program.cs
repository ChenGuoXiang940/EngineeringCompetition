using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _109_5另解
{
    internal class Program
    {
        public static int figure(int a, int b, char ch)
        {
            if (ch == '+') return b + a;
            if (ch == '*') return b * a;
            return 0;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                //987654321*123456789+123456789
                //1+1*3+4
                //4294967295*4294967295+123456789
                //12+12+12*12*12+12                 = 1764
                //3283+83823*3+22+22+22*22 = 255280 = 5280
                Console.WriteLine("請輸入運算式:\t(輸入@結束)");
                string line = Console.ReadLine() + "+0";
                if (line.Contains("@")) break;
                Stack<int> number = new Stack<int>();
                Stack<char> op = new Stack<char>();
                string data = "";
                for (int i = 0; i < line.Length; i++)
                {
                    switch(line[i])
                    {
                        case '+':
                        case '*':
                            number.Push(int.Parse(data));
                            data = "";
                            while (op.Count >= 1 && line[i] == '+')
                            {
                                number.Push(figure(number.Pop(), number.Pop(), op.Pop()));                               
                            }
                            op.Push(line[i]);
                            break;
                        default:
                            data += line[i];
                            break;
                    }
                }
                Console.WriteLine("運算結果:" + (number.Pop() % 1E4).ToString());
            }
            Console.ReadKey();
        }
    }
}
