using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _109_6
{
    internal class Program
    {
        public static Data org, pattern;
        public static Type target;
        public static int check(int x,int y)
        {
            if (x + pattern.x > org.x || y + pattern.y > org.y) return Int16.MaxValue;
            int total = 0;
            for (int a = 0; a < pattern.y; a++)
            {
                for (int b = 0; b < pattern.x; b++)
                {
                    if (org.map[y + a, x + b] != pattern.map[a, b])
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
            org = new Data(new Bitmap(@Console.ReadLine()));//輸入Bitmap點陣圖
            Console.Write("Enter pattern filename:");
            pattern = new Data(new Bitmap(@Console.ReadLine()));
            Console.Write("Enter Number of faults:");           
            target = new Type(int.Parse(Console.ReadLine()), -1, -1);
            int val;
            for(int i = 0; i < org.y; i++)
            {
                for(int j = 0; j < org.x; j++)
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
                Console.WriteLine($"\r\nx1:{target.x}，y1:{org.y - (target.y + pattern.y)}，x2:{target.x + pattern.x}，y2:{org.y - target.y}");
            }
            Console.ReadKey();
        }
    }
    public class Type
    {
        public int fault;
        public int x;
        public int y;
        public Type(int fault,int x,int y)
        {
            this.fault = fault;
            this.x = x;
            this.y = y;
        }
    }
    public class Data
    {
        public int[,] map;
        public int x;
        public int y;
        public Data(Bitmap bitmap)
        {
            int[,] map = new int[bitmap.Height, bitmap.Width];
            for(int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    map[i, j] = bitmap.GetPixel(j, i) == Color.FromArgb(0, 0, 0) ? 0 : 1;
                }
            }
            this.map = map;
            this.x = bitmap.Width;
            this.y = bitmap.Height;
        }
    }
}
