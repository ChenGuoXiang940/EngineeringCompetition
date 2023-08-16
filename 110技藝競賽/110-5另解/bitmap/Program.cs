using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace bitmap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data1 = new Data();
            Data data2 = new Data();
            float totalx = 0;
            float totaly = 0;
            for(int i = 0; i < 32; i++)
            {
                totalx += data1.Point[i].X > data2.Point[i].X ? (float)data2.Point[i].X / data1.Point[i].X : (float)data1.Point[i].X / data2.Point[i].X;
                totaly += data1.Point[i].Y > data2.Point[i].Y ? (float)data2.Point[i].Y / data1.Point[i].Y : (float)data1.Point[i].Y / data2.Point[i].Y;
            }
            totalx /= 32;
            totaly /= 32;
            Console.WriteLine($"求平均相似度:垂直投影:{Math.Round(totaly, 3).ToString().PadRight(5, '0')}，水平投影:{Math.Round(totalx, 3).ToString().PadRight(5, '0')}");
            Console.WriteLine($"2字元相似度{Math.Round(totalx * totaly, 5).ToString().PadRight(7, '0')}");
            Console.ReadKey();
        }
    }
    public class Data
    {
        public PointF[] Point;
        public Data()
        {
            Console.Write("輸入檔案名:");
            string path = Console.ReadLine();//bitmap點陣圖
            Bitmap bitmap = new Bitmap(@path);
            var point = new PointF[32];
            for (int i = 0; i < bitmap.Height; i++)
            {
                int count1 = 1;
                int count2 = 1;
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (bitmap.GetPixel(j, i) == Color.FromArgb(0, 0, 0)) count1++;
                    if (bitmap.GetPixel(i, j) == Color.FromArgb(0, 0, 0)) count2++;
                }
                point[i].X = count1;
                point[i].Y = count2;
            }
            this.Point = point;
        }
    }
}
