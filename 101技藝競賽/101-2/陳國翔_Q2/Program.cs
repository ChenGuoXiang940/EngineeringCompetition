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
            double[,] map = new double[3, 3];
            do
            {
                Console.WriteLine("輸入比值:");
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        map[i, j] = i == j ? 1 : 0;
                    }
                }
                Console.Write("請輸入「專業能力」對「通識素養」的指標比值<輸入兩個數字>:");
                double[] arr1 = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                map[0, 1] = arr1[0] / arr1[1];
                map[1, 0] = arr1[1] / arr1[0];
                Console.Write("請輸入「專業能力」對「合群性」的指標比值<輸入兩個數字>:");
                double[] arr2 = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                map[2, 0] = arr2[1] / arr2[0];
                map[0, 2] = arr2[0] / arr2[1];
                Console.Write("請輸入「通識素養」對「合群性」的指標比值<輸入兩個數字>:");
                double[] arr3 = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                map[2, 1] = arr3[1] / arr3[0];
                map[1, 2] = arr3[0] / arr3[1];
                Console.WriteLine("顯示比值矩陣:");
                double[] a = new double[3];
                double[] b = new double[3];
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        a[j] += map[i, j];
                        b[i] += map[i, j];
                        Console.Write($"{map[i, j].ToString("0.000")} ");
                    }
                    Console.Write("\r\n");
                }
                double[] w = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        w[i] += map[i, j] / a[j];
                        //Console.WriteLine(map[i, j] / a[j]);
                    }
                }
                string text = "";
                double lan = 0;
                for(int i = 0; i < 3; i++)
                {
                    w[i] /= 3;
                    text += $"w{i + 1}:{Math.Round(w[i], 3)} ";
                    lan += w[i] * a[i];
                }
                double cr = (lan - 3) / ((3 - 1) * 0.58);
                Console.WriteLine($"顯示指標的權重:{text}");
                Console.WriteLine($"最大特徵值 LandaMax={Math.Round(lan, 3)}");
                Console.WriteLine($"顯示一致性比值 CR={Math.Round(cr, 3)}。{(cr < 0.1 ? "CR小於0.1，符合一致性。" : "CR大於0.1，不符合一致性。")}");

            } while (check());
            Console.ReadKey();
        }
        public static bool check()
        {
            Console.Write("繼續否?(y or n)");
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "y") return true;
                else if (text == "n") return false;
            }
        }
    }
}
