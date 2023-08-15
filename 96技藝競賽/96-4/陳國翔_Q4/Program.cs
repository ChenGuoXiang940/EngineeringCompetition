using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陳國翔_Q4
{
    internal class Program
    {
        public static int compare(string ch)
        {
            if (ch == "*" || ch == "/") return 2;
            if (ch == "+" || ch == "-") return 1;
            return 0;
        }
        static void Main(string[] args)
        {
            //( 6 + 2 ) * 5 - 8 / 4
            //5 + 2 * 3 - 8 / 4
            List<string> str = Console.ReadLine().Split(' ').ToList();
            List<string> result = new List<string>();
            Stack<string> op = new Stack<string>();
            for (int i = 0; i < str.Count; i++)
            {
                switch (str[i])
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        while (op.Count != 0 && compare(str[i]) <= compare(op.Peek()))
                        {
                            result.Add(op.Pop());
                        }
                        op.Push(str[i]);
                        break;
                    case "(":
                        op.Push(str[i]);
                        break;
                    case ")":
                        while (op.Count != 0 && op.Peek() != "(")
                        {
                            result.Add(op.Pop());
                        }
                        op.Pop();
                        break;
                    default:
                        result.Add(str[i]);
                        break;
                }
            }
            while (op.Count != 0)
            {
                result.Add(op.Pop());
            }
            Console.WriteLine(string.Join(" ", result));
            Console.ReadKey();
        }
    }
}
