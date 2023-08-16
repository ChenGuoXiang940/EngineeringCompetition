using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _93_7
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(500, 250);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Pen penB = new Pen(Color.Blue, 2);
        public static Pen pen2 = new Pen(Color.Black, 2);
        public static Font font = new Font("Default", 9);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Reset();
            pictureBox1.Image = bitmap;
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawLine(pen, 40, 200, 440, 200);
            g.DrawLine(pen2, 40, 100, 440, 100);
            g.DrawLine(pen, 40, 20, 40, 200);
            g.DrawString("y(t)", font, Brushes.Black, 0, 5);
            g.DrawString("Time(秒)", font, Brushes.Black, 220, 230);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            double times = double.Parse(textBox1.Text) * 1000;
            double fi = double.Parse(textBox2.Text);
            double fo = double.Parse(textBox3.Text);
            double p = double.Parse(textBox4.Text);
            double drawx = 0,drawy = p;
            for (int i = 0; i <= 10; i++)
            {
                if (i == 0 || i % 5 == 0)
                {
                    g.DrawLine(pen, 36, 40 + i * 16, 44, 40 + i * 16);
                    g.DrawString($"{drawy}", font, Brushes.Black, 10, 35 + i * 16);
                    drawy -= p;
                }
                else
                {
                    g.DrawLine(pen, 38, 40 + i * 16, 42, 40 + i * 16);
                }
            }
            for (int i = 0; i <= 50; i++)
            {
                if (i == 0 || i % 5 == 0)
                {
                    g.DrawLine(pen, 40 + 8 * i, 196, 40 + 8 * i, 204);
                    g.DrawString($"{drawx.ToString("0.0")}", font, Brushes.Black, 25 + 8 * i, 210);
                    drawx += times / 5;
                }
                else
                {
                    g.DrawLine(pen, 40 + 8 * i, 198, 40 + 8 * i, 202);
                }
            }
            List<PointF> col = new List<PointF>();
            double time = 0;
            double len = (2 * times) / 400;
            for(int i = 0; i < 400; i++)
            {
                double o1 = 2 * Math.PI * fi;
                double o2 = 2 * Math.PI * fo;
                double y = p / 2 * Math.Cos((o1 + o2) * time) + p / 2 * Math.Cos((o1 - o2) * time);
                time += len;
                col.Add(new PointF(40 + i, (float)(100 - y / p * 80)));
            }
            g.DrawLines(penB, col.ToArray());
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            pictureBox1.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
