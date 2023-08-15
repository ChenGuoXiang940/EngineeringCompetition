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
        public static Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int n;
            if (!int.TryParse(textBox1.Text, out n)) return;
            n = 360 / n;
            string color = textBox2.Text;
            pen = color == "B" ? Pens.Black : color == "R" ? Pens.Red : color == "G" ? Pens.Green : color == "L" ? Pens.Blue : Pens.White;
            if (pen.Color == Color.White) return;
            List<Point> points = new List<Point>();
            for(int i = 0; i < 360; i += n)
            {
                double x = 150 * Math.Cos(i * 2 * Math.PI / 180) + 150;
                double y = 150 * Math.Sin(i * 2 * Math.PI / 180) + 150;
                points.Add(new Point((int)x, (int)y));
            }
            for(int i = 0; i < points.Count; i++)
            {
                for(int j = i + 1; j < points.Count; j++)
                {
                    g.DrawLine(pen, points[i], points[j]);
                }
            }
            pictureBox1.Image = bitmap;
        }
    }
}
