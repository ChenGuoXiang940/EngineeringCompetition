using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 陳國翔_Q7
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(520, 320);
        public static Graphics g;
        public static Pen pen2 = new Pen(Color.Black, 2);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            pen2.DashStyle = DashStyle.Dot;
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawLine(pen2, 30, 160, 490, 160);
            g.DrawRectangle(Pens.Black, 30, 30, 460, 260);
            g.DrawString("y(t)", Font, Brushes.Black, 5, 5);
            g.DrawString("Time(t)", Font, Brushes.Black, 280, 310);
            pictureBox1.Image = bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            double f1 = double.Parse(textBox1.Text);
            double f0 = double.Parse(textBox3.Text);
            double A = double.Parse(textBox2.Text);
            double ohm0 = 2 * Math.PI * f0;
            double ohm1 = 2 * Math.PI * f1;
            double leny = A / 5;
            for (int i = 0; i <= 10; i++)
            {
                if (i == 0 || i == 10 || i == 5)
                {
                    g.DrawString($"{A - leny * i}", Font, Brushes.Black, 10, 30 + i * 26);
                    g.DrawLine(Pens.Black, 30, 30 + i * 26, 26, 30 + i * 26);
                }
                else
                {
                    g.DrawLine(Pens.Black, 30, 30 + i * 26, 28, 30 + i * 26);
                }
            }
            for(int i = 0; i <= 40; i++)
            {
                if (i == 0 || i % 4 == 0)
                {
                    g.DrawString((0.05 * i).ToString("0.0"), Font, Brushes.Black, 30 + 11.5F * i, 300);
                    g.DrawLine(Pens.Black, 30 + 11.5F * i, 290, 30 + 11.5F * i, 294);
                }
                else
                {
                    g.DrawLine(Pens.Black, 30 + 11.5F * i, 290, 30 + 11.5F * i, 292);
                }
            }
            List<PointF> col = new List<PointF>();
            for(int i = 0; i <= 460; i++)
            {
                double t = 0.00434 * i;
                double y = A / 2 * Math.Cos((ohm0 + ohm1) * t) + A / 2 * Math.Cos((ohm0 - ohm1) * t);
                col.Add(new PointF(30 + i, 160 - (float)y * 130 / (float)A));
            }
            g.DrawLines(Pens.Blue, col.ToArray());
            pictureBox1.Image = bitmap;
        }
    }
}
