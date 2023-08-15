using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _89_1
{
    public partial class Form1 : Form
    {
        public static Pen penB = new Pen(Color.Blue, 2);
        public static Pen pen = new Pen(Color.Black, 2);
        public static Random rnd = new Random();
        public static Bitmap bitmap = new Bitmap(400, 400);
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            Reset();
            string[] str = { "*", "1", "2", "3" };
            comboBox1.Items.AddRange(str);
            comboBox1.SelectedIndex = 0;
        }
        public static List<Data> col = new List<Data>();
        public void Reset()
        {
            col.Clear();
            g.Clear(Color.White);
            int x = 200, y = 200;
            double len = 2 * Math.PI / 12;
            double len2 = 2 * Math.PI / 24;
            double len3 = 2 * Math.PI / 48;
            double total = 2 * Math.PI;
            double total2 = 2 * Math.PI + len2 / 2;
            double total3 = 2 * Math.PI + len2 / 2;
            for (int i = 0; i < 12; i ++)
            {
                float x1 = x + 70 * (float)Math.Cos(total);
                float y1 = y + 70 * (float)Math.Sin(total);
                g.DrawLine(pen, x, y, x1, y1);
                for(int j = 0; j < 2; j++)
                {
                    float x2 = x + 140 * (float)Math.Cos(total2);
                    float y2 = y + 140 * (float)Math.Sin(total2);
                    g.DrawLine(pen, x1, y1, x2, y2);
                    for (int k = 0; k < 2; k++)
                    {
                        float x3 = x + 210 * (float)Math.Cos(total3);
                        float y3 = y + 210 * (float)Math.Sin(total3);
                        g.DrawLine(pen, x2, y2, x3, y3);
                        col.Add(new Data(new PointF(x1, y1), new PointF(x2, y2), new PointF(x3, y3)));
                        total3 -= len3;
                    }
                    total2 -= len2;
                }
                total -= len;
            }
            pictureBox1.Image = bitmap;
        }
        public static bool fg = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (fg is false)
            {
                fg = true;
                timer1.Start();
            }
            else
            {
                fg = false;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Reset();
            int val;
            if(int.TryParse(comboBox1.Text, out val))
            {
                while (val != 0)
                {
                    int target = rnd.Next(0, 48);
                    if(col[target].check is false)
                    {
                        Data tmp = col[target];
                        g.DrawLine(penB, new PointF(200, 200), tmp.p1);
                        g.DrawLine(penB, tmp.p1, tmp.p2);
                        g.DrawLine(penB, tmp.p2, tmp.p3);
                        col[target].check = true;
                        val--;
                        pictureBox1.Image = bitmap;
                    }
                }
            }
        }
    }
    public class Data
    {
        public PointF p1, p2, p3;
        public bool check;
        public Data(PointF p1,PointF p2,PointF p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.check = false;
        }
    }
}
