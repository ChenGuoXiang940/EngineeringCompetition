using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _105_3
{
    class Draw
    {
        public static List<PointF> points = new List<PointF>();
        public static void f1()
        {
            Console.Write("x1，y1\tx2，y2:");
            float[] arr = Console.ReadLine().Split(new string[] { " ", ",", "，" }, StringSplitOptions.RemoveEmptyEntries).Select(x => float.Parse(x)).ToArray();
            points.Clear();
            Console.Clear();
            DrawLine(arr[0], arr[1], arr[2], arr[3]);
        }
        public static void f2()
        {
            Console.Write("x1，y1\tx2，y2\tx3，y3:");
            float[] arr = Console.ReadLine().Split(new string[] { " ", ",", "，" }, StringSplitOptions.RemoveEmptyEntries).Select(x => float.Parse(x)).ToArray();
            points.Clear();
            Console.Clear();
            DrawLine(arr[0], arr[1], arr[2], arr[3]);
            DrawLine(arr[0], arr[1], arr[4], arr[5]);
            DrawLine(arr[2], arr[3], arr[4], arr[5]);
        }
        public static void f3()
        {
            Console.Clear();
            List<PointF> points2 = new List<PointF>();
            foreach(var point in points)
            {
                SetPoint(50 - (int)point.X, (int)point.Y);
            }
            points = points2.ToList();
        }
        static void DrawLine(float x1,float y1,float x2,float y2)
        {
            float len1 = x2 - x1;//x軸
            float len2 = y2 - y1;//y軸
            float len = Math.Max(Math.Abs(len1), Math.Abs(len2));
            float m1 = len1 != 0 ? (float)len1 / len : 0;
            float m2 = len2 != 0 ? (float)len2 / len : 0;
            SetPoint((int)x1, (int)y1);
            SetPoint((int)x2, (int)y2);
            points.Add(new PointF() { X = x1, Y = y1 });
            points.Add(new PointF() { X = x2, Y = y2 });
            for (int i = 0; i < len; i++)
            {
                points.Add(new PointF() { X = x1, Y = y1 });
                SetPoint((int)x1, (int)y1);
                x1 += m1;
                y1 += m2;
            }
        }
        static void SetPoint(int x1, int y1)
        {
            Console.SetCursorPosition(x1, 50 - y1);
            Console.Write("*");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 50;
            while (true)
            {
                switch (get())
                {
                    case "1":
                        Draw.f1();
                        break;
                    case "2":
                        Draw.f2();
                        break;
                    case "3":
                        Draw.f3();
                        break;
                }
                Console.SetCursorPosition(0, 49);
                if (!check()) break;
            }
            Console.ReadKey();
        }
        public static string get()
        {
            while (true)
            {
                Console.Write("請選擇操作項目:\r\n" +
                "\t<1>輸入兩點座標<x1><y1>，<x2><y2>繪一線:\r\n" +
                "\t<2>輸入三個頂點座標<x1><y1>，<x2><y2>，<x3><y3>繪三角形:\r\n" +
                "\t<3>上題三角水平翻轉:\r\n" +
                "請選擇:");
                string str = Console.ReadLine();
                if (str == "1" || str == "2" || str == "3") return str;
            }
        }
        public static bool check()
        {
            while (true)
            {
                Console.Write("\r\n繼續: 請按1，結束: 請按0:");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        return false;
                    case "1":
                        return true;
                }
            }
        }
    }
}
