using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace _92_1
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(640, 480);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Random rnd = new Random();
        public static List<Rectangle> col = new List<Rectangle>();
        public static Stopwatch watch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{rnd.Next(20, 201)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            watch.Start();
            int count = 0;
            for(int i = 0; i < col.Count; i++)
            {
                for (int j = i + 1; j < col.Count; j++)
                {
                    Rectangle rect = Rectangle.Intersect(col[i], col[j]);
                    if (rect.Height > 0 || rect.Width > 0)
                    {
                        count++;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))), rect);
                    }
                }
            }
            watch.Stop();
            label2.Text = $"Overlapping Blocks:{count}";
            label3.Text = $"Running time:{watch.Elapsed.TotalMilliseconds}ms";
            pictureBox1.Image = bitmap;
            watch.Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Change(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(textBox1.Text,out count))
            {
                col.Clear();
                g.Clear(Color.White);
                for (int i = 0; i < count; i++)
                {
                    col.Add(new Rectangle(rnd.Next(0, 615), rnd.Next(0, 455), rnd.Next(10, 26), rnd.Next(10, 26)));
                    g.DrawRectangle(pen, col.Last());
                }
                pictureBox1.Image = bitmap;
            }
        }
    }
}
