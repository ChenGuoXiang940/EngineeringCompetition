using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _108_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入大地遊戲關卡文字檔檔名:");
            string path = Console.ReadLine();
            Console.WriteLine($"你輸入的檔名為\'{path}\'");
            StreamReader din = File.OpenText(path);
            int val = int.Parse(din.ReadLine());
            double[] cost = new double[val + 1];
            string[] record = new string[val + 1];
            record[1] = "1->";
            cost[1] = 0;
            string str = val.ToString() + "\r\n";
            for (int i = 2; i <= val; i++)
            {
                cost[i] = double.MaxValue;
            }
            for (int i = 1; i <= val; i++)
            {
                double[] arr = din.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                for (int j = 1; j <= val; j++)
                {
                    if (arr[j - 1] != 0 && cost[j] > cost[i] + arr[j - 1])
                    {
                        cost[j] = cost[i] + arr[j - 1];
                        record[j] = record[i] + j.ToString() + "->";
                    }
                    str = arr[j - 1] == 0 ? str + "0.0 " : str + arr[j - 1].ToString() + " ";
                }
                str = str.TrimEnd(' ') + "\r\n";
            }
            int[] sd = din.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("大地遊戲關卡文字檔內容為:\r\n" + str  + String.Join(" ", sd));
            Console.WriteLine($"最快的闖關路線:[{String.Join("->", sd)}]:{record[sd[1]].TrimEnd('>').TrimEnd('-') }(路徑的險峻程度:{cost[sd[1]]})");
            Console.ReadKey();
        }
    }
}
