using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _109_6另解
{
    internal class Program
    {
        public static Data org, pattern;
        public static Type target;
        public static int check(int x,int y)
        {
            if (x + pattern.x > org.x || y + pattern.y > org.y) return Int16.MaxValue;
            int total = 0;
            for(int i = 0; i < pattern.y; i++)
            {
                for (int j = 0; j < pattern.x; j++)
                {
                    if (org.map[y + i][x + j] != pattern.map[i][j])
                    {
                        if (++total > target.fault) return Int16.MaxValue;
                    }
                }
            }
            return total;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter orgfilename:");
            org = new Data(File.OpenText(@Console.ReadLine()));//輸入TXT文字檔
            Console.Write("Enter pattern filename:");
            pattern = new Data(File.OpenText(@Console.ReadLine()));
            Console.Write("Enter Number of faults:");
            target = new Type(int.Parse(Console.ReadLine()), -1, -1);
            int val;
            for (int i = 0; i < org.y; i++)
            {
                for (int j = 0; j < org.x; j++)
                {
                    if ((val = check(j, i)) <= target.fault)
                    {
                        target = new Type(val, j, i);
                    }
                }
            }
            if (target.x == -1 && target.y == -1)
            {
                Console.WriteLine("\r\nNo match.");
            }
            else
            {
                Console.WriteLine($"\r\nx1:{target.x}，y1:{target.y}，x2:{target.x + pattern.x}，y2:{target.y + pattern.y}");
            }
            Console.ReadKey();
        }
    }
    public class Type
    {
        public int fault;
        public int x;
        public int y;
        public Type(int fault, int x, int y)
        {
            this.fault = fault;
            this.x = x;
            this.y = y;
        }
    }
    public class Data
    {
        public List<string> map;
        public int x;
        public int y;
        public Data(StreamReader din)
        {
            var map = new List<string>();
            int[] arr = din.ReadLine().Split(' ').Select(item => Convert.ToInt32(item, 16)).ToArray();
            string line;
            while (true)
            {
                if (string.IsNullOrEmpty(line = din.ReadLine())) break;
                line = line.Replace(" ", "");
                string line2 = "";
                for (int j = 0; j < line.Length; j++)
                {
                    line2 += Convert.ToString(Convert.ToInt32(line[j].ToString(), 16), 2).PadLeft(4, '0');
                }
                map.Add(line2);
            }
            this.map = map;
            this.x = arr[0];
            this.y = arr[1];
        }
    }
}
