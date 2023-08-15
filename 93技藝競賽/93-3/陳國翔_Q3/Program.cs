using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 陳國翔_Q3
{
    internal class Program
    {
        public static PointF GetPointF(int index)
        {
            Console.Write($"{Convert.ToChar('A' + index)}(X{index + 1},Y{index + 1}):");
            float[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => float.Parse(x)).ToArray();
            return new PointF(arr[0], arr[1]);
        }
        static void Main(string[] args)
        {
            PointF a = GetPointF(0), b = GetPointF(1), c = GetPointF(2), d = GetPointF(3);
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(Pens.Black, a, b);
            float lenx = (d.X - c.X)/100;
            float leny = (d.Y - c.Y)/100;
            bool fg = false;
            for(int i = 0; i <= 100; i++)
            {
                Color color = bitmap.GetPixel((int)(c.X + lenx * i), (int)(c.Y + leny * i));
                if (color == Color.FromArgb(0, 0, 0))
                {
                    Console.WriteLine("線有交叉");
                    fg = true;
                    break;
                }
            }
            if (!fg) Console.WriteLine("線無交叉");
            Console.ReadKey();
        }
    }
}
