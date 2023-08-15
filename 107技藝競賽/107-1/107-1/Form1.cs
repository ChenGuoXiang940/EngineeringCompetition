using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _107_1
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(250, 250);
        public static Graphics g;
        public static Font font = new Font("Default", 9);
        public static Pen pen = new Pen(Color.Black, 2);
        public static string str = "RYG";
        public static List<Brush> bList = new List<Brush>() { Brushes.Red, Brushes.Yellow, Brushes.Green };
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            Reset();
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawLine(pen, 80, 0, 80, 250);
            g.DrawLine(pen, 120, 0, 120, 250);
            g.DrawLine(pen, 0, 170, 250, 170);
            g.DrawLine(pen, 0, 130, 250, 130);
            for(int i = 0; i < 3; i++)
            {
                g.DrawString($"{str[i]}1", font, Brushes.Black, 10, 20 + 40 * i);
                g.DrawString($"{str[i]}2", font, Brushes.Black, 140 + 40 * i, 220);
            }
            pictureBox1.Image = bitmap;
        }
        public static bool fg = true;
        public static int sq = 0;
        public static Point[] point = new Point[6] {new Point(4,1),new Point(4,2),new Point(4,4),new Point(1,4),
            new Point(2,4),new Point(4,4)};
        public void DrawE(int x,int y,int i)
        {
            g.FillEllipse(bList[i], x - 10, y - 10, 20, 20);
            g.DrawEllipse(pen, x - 10, y - 10, 20, 20);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fg = true;
            sq = 0;
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fg)
            {
                Reset();
                switch (point[sq].X)
                {
                    case 1:
                        DrawE(40, 20, 0);
                        break;
                    case 2:
                        DrawE(40, 60, 1);
                        break;
                    case 4:
                        DrawE(40, 100, 2);
                        break;
                }
                switch (point[sq].Y)
                {
                    case 1:
                        DrawE(140, 190, 0);
                        break;
                    case 2:
                        DrawE(180, 190, 1);
                        break;
                    case 4:
                        DrawE(220, 190, 2);
                        break;
                }
                if (++sq == 6) sq = 0;
                pictureBox1.Image = bitmap;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sq = 0;
            Reset();
            fg = false;
        }
    }
}
