using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109_5另解
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //987654321*123456789+123456789
                //1+1*3+4
                //4294967295*4294967295+123456789
                //12+12+12*12*12+12=1764
                //3283+83823*3+22+22+22*22=255280 =>5280
                Console.WriteLine("請輸入運算式:\t(輸入@結束)");
                string line = Console.ReadLine();
                if (line.Contains("@")) break;
                Stack<int> number = new Stack<int>();
                List<char> op = new List<char>();
                string data = "";
                bool fg = false;
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    switch (line[i])
                    {
                        case '*':
                        case '+':
                            op.Add(line[i]);
                            if (data != "") number.Push(int.Parse(data));
                            data = "";
                            fg = false;
                            if (op.Count >= 2 && op.ElementAt(op.Count - 2) == '*')
                            {
                                number.Push(number.Pop() * number.Pop() % 10000);
                                op.RemoveAt(op.Count - 2);
                            }
                            break;
                        default:
                            if (!fg)
                            {
                                data = line[i] + data;
                                if (data.Length == 4)
                                {
                                    number.Push(int.Parse(data));
                                    data = "";
                                    fg = true;
                                }
                            }
                            break;
                    }
                }
                if (data.Length != 0) number.Push(int.Parse(data));
                while (number.Count != 1)
                {
                    if (op[op.Count - 1] == '*') number.Push(number.Pop() * number.Pop() % 10000);
                    else number.Push(number.Pop() + number.Pop());
                    op.RemoveAt(op.Count - 1);
                }
                Console.WriteLine($"\r\n你輸入的數學運算式為:\r\n{line}\r\n運算結果 = {number.Peek()}\r\n");
            }
            Console.ReadKey();
        }
    }
}
