using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _109_5另解
{
    internal class Program
    {
        public static BigInteger Figure(BigInteger a, BigInteger b, char ch) => (ch == '+' ? b + a : ch == '*' ? b * a : 0);
        static void Main(string[] args)
        {
            while (true)
            {
                //987654321*123456789+123456789
                //1+1*3+4
                //4294967295*4294967295+123456789
                //12+12+12*12*12+12        = 1764
                //3283+83823*3+22+22+22*22 = 255280 => 5280
                Console.WriteLine("請輸入運算式:\t(輸入@結束)");
                string line = Console.ReadLine() + "+0";
                if (line.Contains("@")) break;
                Stack<BigInteger> number = new Stack<BigInteger>();
                Stack<char> op = new Stack<char>();
                string data = "";
                foreach(char it in line)
                {
                    switch (it)
                    {                      
                        case '+':
                        case '*':
                            number.Push(BigInteger.Parse(data));
                            data = "";
                            while (op.Count >= 1 && it == '+')
                            {
                                number.Push(Figure(number.Pop(), number.Pop(), op.Pop()));
                            }
                            op.Push(it);
                            break;
                        default:
                            data += it;
                            break;
                    }
                }
                Console.WriteLine($"\r\n你輸入的數學運算式為:\r\n{line.Substring(0, line.Length - 2)}");
                Console.WriteLine($"運算結果 = {number.Pop() % (BigInteger)1E4}\r\n");
            }
            Console.ReadKey();
        }
    }
}
