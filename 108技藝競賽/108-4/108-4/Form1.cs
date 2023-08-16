using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _108_4
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(320, 320);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 3);
        public static Pen penR=new Pen(Color.Red, 4);
        public static Pen penB = new Pen(Color.Blue, 4);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            set();
            pictureBox1.Image = bitmap;
        }
        public static void set()
        {
            g.Clear(Color.White);
            for(int i = 0; i <= 10; i++)
            {
                g.DrawLine(pen, 10, 10 + i * 30, 310, 10 + i * 30);
                g.DrawLine(pen, 10 + i * 30, 10, 10 + i * 30, 310);
            }
        }
        public static int[,] move = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        public static Random rnd = new Random();
        public static int[,] map = new int[13, 13];
        public static Point end;
        public static List<Point> aim = new List<Point>();
        public static void moved(int x, int y, Stack<Point> p)
        {
            if (x == 0 || x == 12 || y == 0 || y == 12) return;
            else if (x == end.X + 1 && y == end.Y + 1)
            {
                aim = p.ToList();
                return;
            }
            for(int i = 0; i < 4; i++)
            {
                if (map[x + move[i, 0], y + move[i, 1]] == 0 || (map[x + move[i, 0], y + move[i, 1]] != Int32.MaxValue
                    && map[x + move[i, 0], y + move[i, 1]] > map[x, y] + 1))
                {
                    map[x + move[i, 0], y + move[i, 1]] = map[x, y] + 1;
                    p.Push(new Point(x + move[i, 0] - 1, y + move[i, 1] - 1));
                    moved(x + move[i, 0], y + move[i, 1],p);
                    p.Pop();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            aim.Clear();
            set();
            for (int i = 0; i < 13; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    map[i, j] = 0;
                }
            }
            List<Point> points = new List<Point>();
            while (points.Count < 32)
            {
                Point point = new Point(rnd.Next(0, 11), rnd.Next(0, 11));
                if (!points.Contains(point))
                {
                    if (points.Count < 30)
                    {
                        map[point.X + 1, point.Y + 1] = Int32.MaxValue;
                        g.FillEllipse(Brushes.Black, point.X * 30 + 5, point.Y * 30 + 5, 10, 10);
                    }
                    points.Add(point);
                }
            }
            map[points[30].X + 1, points[30].Y + 1] = 1;
            var stack = new Stack<Point>();
            stack.Push(points[30]);
            moved(points[30].X + 1, points[30].Y + 1, stack);
            if (aim.Count != 0)
            {
                label2.Text = "路徑規劃成功";
                for(int i = 0; i < aim.Count - 1; i++)
                {
                    g.DrawLine(penB, aim[i].X * 30 + 10, aim[i].Y * 30 + 10, aim[i + 1].X * 30 + 10, aim[i + 1].Y * 30 + 10);
                }
            }
            else
            {
                label2.Text = "路徑規劃失敗";
            }
            g.FillRectangle(Brushes.White, end.X * 30 + 5, end.Y * 30 + 5, 10, 10);
            g.DrawRectangle(penR, end.X * 30 + 4, end.Y * 30 + 4, 12, 12);
            g.FillEllipse(Brushes.White, points[30].X * 30 + 5, points[30].Y * 30 + 5, 10, 10);
            g.DrawEllipse(penB, points[30].X * 30 + 4, points[30].Y * 30 + 4, 12, 12);
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
