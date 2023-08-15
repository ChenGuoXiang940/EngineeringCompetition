using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q1
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(300, 300);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
        }
        public static Point[] point = new Point[3];
        public static double dist = 0;
        public void DrawLine(int a,int b,int c,int d)
        {
            g.DrawLine(pen, a, b, c, d);
            dist += Math.Sqrt(Math.Pow(a - c, 2) + Math.Pow(b - d, 2));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dist = 0;
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            g.Clear(Color.White);
            for(int i = 0; i < point.Length; i++)
            {
                point[i] = new Point(rnd.Next(50, 200), rnd.Next(50, 200));
                g.FillEllipse(Brushes.Black, point[i].X - 4, point[i].Y - 4, 8, 8);
            }
            Point[] array = point.OrderBy(x => x.Y).ToArray();
            DrawLine(array[0].X, array[0].Y, array[0].X, array[1].Y);
            DrawLine(array[0].X, array[1].Y, array[1].X, array[1].Y);
            DrawLine(array[1].X, array[1].Y, array[2].X, array[1].Y);
            DrawLine(array[2].X, array[2].Y, array[2].X, array[1].Y);
            textBox1.Text = dist.ToString();
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dist = 0;
            g.Clear(Color.White);
            Point[] array = point.OrderBy(x => x.Y).ToArray();
            Array.ForEach(array, item => g.FillEllipse(Brushes.Black, item.X - 4, item.Y - 4, 8, 8));
            int dist1 = array[1].Y - array[0].Y;
            int dist2 = array[2].Y - array[1].Y;
            if (Math.Abs(array[1].X - array[2].X) > dist1)
            {
                DrawLine(array[2].X, array[2].Y, array[2].X + Math.Sign(array[1].X - array[2].X) * dist1, array[1].Y);
                DrawLine(array[1].X, array[1].Y, array[2].X + Math.Sign(array[1].X - array[2].X) * dist1, array[1].Y);
            }
            else
            {
                DrawLine(array[2].X, array[2].Y, array[2].X, array[1].Y);
                DrawLine(array[1].X, array[1].Y, array[2].X, array[1].Y);
            }
            if (Math.Abs(array[1].X - array[0].X) > dist2)
            {
                DrawLine(array[0].X, array[0].Y, array[0].X + Math.Sign(array[1].X - array[0].X) * dist2, array[1].Y);
                DrawLine(array[1].X, array[1].Y, array[0].X + Math.Sign(array[1].X - array[0].X) * dist2, array[1].Y);
            }
            else
            {
                DrawLine(array[0].X, array[0].Y, array[0].X, array[1].Y);
                DrawLine(array[1].X, array[1].Y, array[0].X, array[1].Y);
            }
            pictureBox1.Image = bitmap;
            textBox2.Text = $"{(int)dist}";
            textBox3.Text = $"{Math.Round(((double.Parse(textBox1.Text) - dist) / double.Parse(textBox1.Text) * 100), 1)}%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
