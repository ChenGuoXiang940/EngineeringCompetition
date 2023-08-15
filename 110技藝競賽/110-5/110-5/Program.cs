using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _110_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入檔案1:");
            Data data1 = new Data(File.OpenText(Console.ReadLine()));
            Console.Write("輸入檔案1:");
            Data data2 = new Data(File.OpenText(Console.ReadLine()));
            double totalx = 0;
            double totaly = 0; 
            for(int i = 0; i < 32; i++)
            {
                totalx += data1.x[i] > data2.x[i] ? data2.x[i] / data1.x[i] : data1.x[i] / data2.x[i];
                totaly += data1.y[i] > data2.y[i] ? data2.y[i] / data1.y[i] : data1.y[i] / data2.y[i];
            }
            totalx /= 32;
            totaly /= 32;
            double similar = totalx * totaly;
            Console.WriteLine($"求平均相似度:垂直投影:{Math.Round(totalx, 3)}水平投影:{Math.Round(totaly, 3)}");
            Console.WriteLine($"2字元相似度為:{Math.Round(similar, 5)}");
            Console.ReadKey();
        }
    }
    public class Data
    {
        public double[] x;
        public double[] y;
        public Data(StreamReader din)
        {
            var map = new List<List<double>>();
            var x = new double[32];
            var y = new double[32];
            while (true)
            {
                string line = din.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                List<double> col = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                    Select(a => double.Parse(a)).ToList();
                map.Add(col.ToList());
            }
            for(int i = 0; i < map.Count; i++)
            {
                int count1 = 1;
                int count2 = 1;
                for(int j = map[0].Count - 1; j >= 0; j--)
                {
                    count1 += map[i][j] == 0 ? 1 : 0;
                    count2 += map[j][i] == 0 ? 1 : 0;
                }
                y[i] = count1;
                x[i] = count2;
            }
            this.x = x;
            this.y = y;
        }
    }
}
