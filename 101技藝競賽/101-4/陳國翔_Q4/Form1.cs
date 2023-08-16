using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q4
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(400, 340);
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawLine(Pens.Black, 200, 20, 200, 320);
            g.DrawLine(Pens.Black, 40, 170, 360, 170);
            for(int i = 0; i <= 8; i++)
            {
                g.FillEllipse(Brushes.Black, 40 + 40 * i - 2, 168, 4, 4);
            }
            for(int i = 0; i <= 6; i++)
            {
                g.FillEllipse(Brushes.Black, 200 - 2, 20 + 50 * i - 2, 4, 4);
            }
            pictureBox1.Image= bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PointF a = GetPointF(textBox1.Text), b = GetPointF(textBox2.Text), c = GetPointF(textBox3.Text), d = GetPointF(textBox4.Text);
            Reset();
            g.DrawLine(Pens.Black, 200 + a.X * 8, 170 - 5 * a.Y, 200 + b.X * 8, 170 - 5 * b.Y);
            g.DrawLine(Pens.Black, 200 + c.X * 8, 170 - 5 * c.Y, 200 + d.X * 8, 170 - 5 * d.Y);
            //---L1
            float dx1 = b.X - a.X;
            float dy1 = b.Y - a.Y;
            float a1 = dy1;
            float b1 = -dx1;
            float c1 = dy1 * a.X - dx1 * a.Y;
            //---L2
            float dx2 = c.X - d.X;
            float dy2 = c.Y - d.Y;
            float d1 = dy2;
            float e1 = -dx2;
            float f1 = dy2 * c.X - dx2 * c.Y;
            //---
            float x = (c1 * e1 - b1 * f1) / (a1 * e1 - b1 * d1);
            float y = (d1 * c1 - a1 * f1) / (d1 * b1 - a1 * e1);
            PointF ans = new PointF(x, y);
            if (Solove(a, b, ans))
            {
                textBox5.Text = "有相交";
                textBox6.Text = $"{Math.Round(ans.X, 2)},{Math.Round(ans.Y, 2)}";
            }
            else
            {
                textBox5.Text = "未相交";
                textBox6.Text = "";
            }
        }
        public static bool Solove(PointF a,PointF b,PointF ans)
        {
            float x1 = Math.Min(a.X, b.X);
            float x2 = Math.Max(a.X, b.X);
            float y1 = Math.Min(a.Y, b.Y);
            float y2 = Math.Max(a.Y, b.Y);
            if (x1 <= ans.X && ans.X <= x2 && y1 <= ans.X && ans.Y <= y2) return true;
            return false;
        }
        public static PointF GetPointF(string text)
        {
            string[] arr = text.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            return new PointF(float.Parse(arr[0]), float.Parse(arr[1]));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Array.ForEach(Controls.OfType<TextBox>().ToArray(), item => item.Text = "");
            Reset();
        }
    }
}
