using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _112_5
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(300, 300);
        public static Graphics g;
        public static Random rnd = new Random();
        public static List<DashStyle> styles = new List<DashStyle>() { DashStyle.Solid, DashStyle.Dash, DashStyle.DashDot, DashStyle.DashDotDot, DashStyle.Dot };
        public static List<Rectangle> col = new List<Rectangle>();
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
            col.Clear();
            Pen pen = new Pen(Color.Black, 2);
            int len = rnd.Next(2, 5);
            for(int i = 0; i < len; i++)
            {
                pen.DashStyle = styles[i];
                Rectangle rect = new Rectangle(rnd.Next(20, 81), rnd.Next(20, 81), rnd.Next(40, 201), rnd.Next(40, 201));
                g.DrawRectangle(pen, rect);
                col.Add(rect);
            }
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < col.Count; i++)
            {
                for (int j = i + 1; j < col.Count; j++)
                {
                    Rectangle rect = Rectangle.Intersect(col[i], col[j]);
                    g.FillRectangle(new SolidBrush(Color.Pink), rect);
                }
            }
            pictureBox2.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
