using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_1另解
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static Bitmap bitmap = new Bitmap(400, 350);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Pen penB = new Pen(Color.Blue, 3);
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
            StringFormat format = new StringFormat(StringFormatFlags.DirectionVertical);
            g.DrawString("MSE", font, Brushes.Black, 0, 165, format);
            g.DrawString("疊代次數", font, Brushes.Black, 145, 330);
            g.DrawRectangle(pen, 25, 35, 300, 280);
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(pen, 85 + 60 * i, 35, 85 + 60 * i, 39);
                g.DrawLine(pen, 85 + 60 * i, 315, 85 + 60 * i, 311);
            }
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(pen, 25, 75 + 40 * i, 29, 75 + 40 * i);
                g.DrawLine(pen, 321, 75 + 40 * i, 325, 75 + 40 * i);
            }
            pictureBox1.Image = bitmap;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Reset();
            int n = int.Parse(TextBox1.Text);
            int v = 1;
            label6.Text = string.Join("", new string[n].Select(item => $"{(v++),3} ").ToArray());
            TextBox3.Text = GetRandom(n);
            TextBox4.Text = GetRandom(n);
            TextBox5.Text = "";
        }
        public static string GetRandom(int n)
        {
            string[] str = new string[n];
            return string.Join("", str.Select(item => $"{rnd.Next(0, 101),3} "));
        }
        public static double GetDist(Type a, Type b)
        {
            return Math.Sqrt(Math.Pow(a.math - b.math, 2) + Math.Pow(a.eng - b.eng, 2));
        }
        public static List<double> mses = new List<double>();
        private void Button2_Click(object sender, EventArgs e)
        {
            mses.Clear();
            int k = 2;
            int n = int.Parse(TextBox1.Text);
            int q = int.Parse(TextBox2.Text);
            List<int> math = TextBox3.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            List<int> eng = TextBox4.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            List<Data> col = new List<Data>();
            col.Add(new Data(math[0], eng[0], 0));
            col.Add(new Data(math[1], eng[1], 1));
            for (int i = 2; i < n; i++)
            {
                col.Add(new Data(math[i], eng[i], rnd.Next(0, k)));
            }
            int p = 0;
            Type u1 = col[0].type;
            Type u2 = col[1].type;
            while (p++ < q)
            {
                double mse = 0;
                for (int i = 0; i < col.Count; i++)
                {
                    double dist1 = GetDist(col[i].type, u1);
                    double dist2 = GetDist(col[i].type, u2);
                    col[i].group = dist1 < dist2 ? 0 : 1;
                    mse += dist1 < dist2 ? dist1 : dist2;
                }
                mse /= col.Count;
                mses.Add(mse);
                int count = 0;
                u1 = new Type(0, 0);
                u2 = new Type(0, 0);
                for (int i = 0; i < col.Count; i++)
                {
                    if (col[i].group == 0)
                    {
                        u1.math += col[i].type.math;
                        u1.eng += col[i].type.eng;
                        count++;
                    }
                    else
                    {
                        u2.math += col[i].type.math;
                        u2.eng += col[i].type.eng;
                    }
                }
                u1 = new Type(u1.math / count, u1.eng / count);
                u2 = new Type(u2.math / (col.Count - count), u2.eng / (col.Count - count));
            }
            string str = "";
            col.ForEach(item => str += $"{1 + item.group,3} ");
            TextBox5.Text = str;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Reset();
            int x = int.Parse(TextBox2.Text) - 1;
            if (x % 10 != 0) x = (x / 10 + 1) * 10;
            else x = x / 10 * 10;
            double lenx = x / 5;
            double higthy = 10 + (int)mses.Max();
            double lowy = (int)mses.Min() >= 10 ? -10 + (int)mses.Min() : (int)mses.Min();
            double leny = (higthy - lowy) / 7;
            for (int i = 0; i < 6; i++)
            {
                g.DrawString($"{lenx * i}", font, Brushes.Black, 25 + i * 60, 315);
            }
            for (int i = 0; i < 8; i++)
            {
                g.DrawString($"{(int)(higthy - leny * i)}", font, Brushes.Black, 8, 25 + 40 * i);
            }
            lenx = x / 10;
            mses.Insert(0, 10 + mses.Max());
            for (int i = 0; i < x; i++)
            {
                g.DrawLine(penB, 25 + (int)(lenx * i) * 30, 315 - (float)((mses[(int)(lenx * i)] - lowy) / leny * 40), 25 + (int)(lenx * (i + 1)) * 30, 315 - (float)((mses[(int)(lenx * (i + 1))] - lowy) / leny * 40));
            }
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Type
    {
        public double math;
        public double eng;
        public Type(double math, double eng)
        {
            this.math = math;
            this.eng = eng;
        }
    }
    public class Data
    {
        public Type type;
        public int group;
        public Data(int math, int eng, int group)
        {
            this.type = new Type(math, eng);
            this.group = group;
        }
    }
}