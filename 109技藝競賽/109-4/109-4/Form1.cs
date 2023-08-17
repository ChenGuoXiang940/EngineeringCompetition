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

namespace _109_4
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap1;
        public static Bitmap bitmap2;
        public static Graphics g1;
        public static Graphics g2;
        public static Random rnd = new Random();
        public static Pen pen = new Pen(Color.Black, 3);
        public static Color black = Color.FromArgb(0, 0, 0);
        public static List<DashStyle> styles = new List<DashStyle>() { DashStyle.Solid, DashStyle.Dash, DashStyle.Dot, DashStyle.DashDot };
        public Form1()
        {
            InitializeComponent();
            bitmap1 = new Bitmap(300, 300);
            bitmap2 = new Bitmap(300, 300);
            g1 = Graphics.FromImage(bitmap1);
            g2 = Graphics.FromImage(bitmap2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);
            int n = rnd.Next(3, 5);
            Pen pen2 = new Pen(Color.Black, 3);
            for(int i = 0; i < n; i++)
            {
                Rectangle rect = new Rectangle(rnd.Next(20, 81), rnd.Next(20, 81), rnd.Next(40, 201), rnd.Next(40, 201));
                pen2.DashStyle = styles[i];
                g1.DrawRectangle(pen,rect);
                g2.DrawRectangle(pen2, rect);
            }
            pictureBox1.Image = bitmap2;
        }
        public static void loop(Func<int, int, bool> action,int start, int end,int n)
        {
            for (int i = start; (i >= start && i < end) || (i <= start && i >= end); i += n)
            {
                for (int j = start; (j >= start && j < end) || (j <= start && j >= end); j += n)
                {
                    if (action(i, j)) break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            loop((i, j) =>
            {
                if (bitmap1.GetPixel(i, j) == black)
                {
                    setpixel(i, j);
                    return true;
                }
                return false;
            }, 0, 300, 1);
            loop((i, j) =>
            {
                if (bitmap1.GetPixel(j, i) == black)
                {
                    setpixel(j, i);
                    return true;
                }
                return false;
            }, 0, 300, 1);
            loop((i, j) =>
            {
                if (bitmap1.GetPixel(j, i) == black)
                {
                    setpixel(j, i);
                    return true;
                }
                return false;
            }, 299, 0, -1);
            loop((i, j) =>
            {
                if (bitmap1.GetPixel(i, j) == black)
                {
                    setpixel(i, j);
                    return true;
                }
                return false;
            }, 299, 0, -1);
            pictureBox2.Image = bitmap2;
        }
        public static void setpixel(int x,int y)
        {
            for(int i = x - 1; i <= x + 2; i++)
            {
                for (int j = y - 1; j <= y + 2; j++)
                {
                    bitmap2.SetPixel(i, j, Color.Red);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
