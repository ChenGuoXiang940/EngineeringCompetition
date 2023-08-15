using System;
using System.Collections.Generic;   
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;
using System.Numerics;
namespace _109_5
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("請輸入運算式:   (輸入 @ 結束)");
                string line = (Console.ReadLine() + "").Replace("*", "_*_").Replace("+", "_+_");
                string[] col = line.Split('_').ToArray();
                if (col[0] == "@" && col.Length == 1) break;
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i] == "*")
                    {
                        col[i + 1] = (BigInteger.Parse(col[i - 1]) * BigInteger.Parse(col[i + 1])).ToString();
                        col[i] = "0";
                        col[i - 1] = "0";
                    }
                    else if (col[i] == "+")
                    {
                        col[i] = "0";
                    }
                }
                BigInteger result = new BigInteger();
                for (int i = 0; i < col.Length; i++)
                {
                    result += BigInteger.Parse(col[i]);
                }
                Console.WriteLine(String.Format("運算結果:{0}", result % 10000));
            }
            Console.ReadKey();
        }
    }
}