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
        public static Pen pen = new Pen(Color.Black, 3);
        public static Pen penR = new Pen(Color.Red, 6);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.White);
            for(int i = 0; i < 10; i++)
            {
                g.DrawLine(pen, 15 + i * 30, 15, 15 + i * 30, 285);
                g.DrawLine(pen, 15, 15 + i * 30, 285, 15 + i * 30);
            }
            pictureBox1.Image = bitmap;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static List<Point> col = new List<Point>();
        public static Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            col.Clear();
            int count = 0;
            while (count != 7)
            {
                Point point = new Point(rnd.Next(1, 9), rnd.Next(1, 9));
                if (!col.FindIndex(item => item.X == point.X).Equals(-1) || !col.FindIndex(item => item.Y == point.Y).Equals(-1)) continue;
                col.Add(point);
                g.FillEllipse(Brushes.Black, 15 + point.X * 30 - 5, 15 + point.Y * 30 - 5, 10, 10);
                count++;
            }
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = (col.Max(item => item.Y) - col.Min(item => item.Y)) / 2;
            col = col.OrderBy(item => item.X).ToList();
            int total = col.Last().X - col.First().X;
            g.DrawLine(penR, 15 + 30 * col.Last().X, 15 + 30 * b, 15 + 30 * col.First().X, 15 + 30 * b);
            for(int i = 0; i < col.Count; i++)
            {
                total += Math.Abs(col[i].Y - b);
                g.DrawLine(penR, 15 + 30 * col[i].X, 15 + 30 * col[i].Y, 15 + 30 * col[i].X, 15 + 30 * b);
            }
            Array.ForEach(col.ToArray(), item => g.FillEllipse(Brushes.Black, 15 + item.X * 30 - 5, 15 + item.Y * 30 - 5, 10, 10));
            pictureBox1.Image = bitmap;
            label3.Text = $"{total}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
