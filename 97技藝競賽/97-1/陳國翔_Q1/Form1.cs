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
        public static Bitmap bitmap = new Bitmap(400, 320);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Pen penR = new Pen(Color.Red, 3);
        public static Font font = new Font("Default", 9);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawString("Sinc(x)", font, Brushes.Black, 190, 5);
            g.DrawString("x", font, Brushes.Black, 390, 225);
            for(int i = 0; i <= 30; i++)
            {
                if (i == 0 || i % 5 == 0)
                {
                    if (0.2 * i / 5 != 1) g.DrawString($"{1 - 0.2 * (int)(i / 5)}", font, Brushes.Black, 170, 30 + i * 8);
                    if (i != 15) g.DrawString($"{-30 + 2 * i}", font, Brushes.Black, 20 + i * 12, 240);
                }
                g.DrawLine(pen, 200, 30 + i * 8, 204, 30 + i * 8);
                g.DrawLine(pen, 20 + i * 12, 230, 20 + i * 12, 234);
            }
            g.DrawLine(pen, 200, 30, 200, 280);
            g.DrawLine(pen, 20, 230, 380, 230);
            pictureBox1.Image = bitmap;
        }
        public static double sinc(double x)
        {
            if (x == 0) return 1;
            return Math.Sin(x) / x;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            double max, min;
            if (!double.TryParse(textBox1.Text, out min) || !double.TryParse(textBox2.Text, out max) || Math.Max(min, max) > 30 || Math.Min(min, max) < -30 || max < min)
            {
                MessageBox.Show("輸入錯誤!");
                return;
            }
            min = (min + 30) * 6;
            max = (max + 30) * 6;
            for(int i = (int)min; i <= max; i++)
            {
                g.DrawLine(penR, 20 + i, 230 - (float)sinc(-30 + 0.16666 * i) * 200, i + 21, 230 - (float)sinc(-30 + 0.16666 * (i + 1)) * 200);
            }
            pictureBox1.Image = bitmap;
        }
    }
}
