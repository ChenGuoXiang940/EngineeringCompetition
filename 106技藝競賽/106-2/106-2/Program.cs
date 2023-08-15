using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入行程processes的數量(MAX 5):");
                int n = int.Parse(Console.ReadLine());
                if (n > 5)
                {
                    Console.WriteLine("");
                    continue;
                }
                int[] num = new int[n];
                Console.WriteLine("\r\n請輸入每的行程的執行時間burst_time...");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"P{i + 1}: ");
                    num[i] = int.Parse(Console.ReadLine());
                }
                Console.Write("\r\n請輸入時間配額time_quantum:");
                int time = int.Parse(Console.ReadLine());
                int c = 0;
                int total = 0;
                int total2 = num.Sum();
                int[] wait = new int[n];
                int[] record = new int[n];
                Console.WriteLine("\r\n各行程processes執行順序為:...");
                while (true)
                {
                    if (total == total2) break;
                    if (num[c] >= time)
                    {
                        Console.Write($"{total.ToString("00")}:P{c + 1}  ");
                        record[c] += total - wait[c];
                        total += time;
                        num[c] -= time;
                        wait[c] = total;
                    }
                    else if (num[c] != 0)
                    {
                        Console.Write($"{total.ToString("00")}:P{c + 1}  ");
                        record[c] += total - wait[c];
                        total += num[c];
                        num[c] = 0;
                        wait[c] = total;
                    }
                    c++;
                    if (c == n) c = 0;
                }
                Console.WriteLine(total2.ToString() + "\r\n");
                for(int i = 0; i < n; i++)
                {
                    Console.Write($"P{i + 1}的等待時間:{record[i]}  ");
                }
                break;
            }
            Console.ReadKey();
        }
    }
}
