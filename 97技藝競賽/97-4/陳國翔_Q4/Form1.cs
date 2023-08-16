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

namespace 陳國翔_Q4
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(400, 400);
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 2);
        public static Pen pen2 = new Pen(Color.Black, 2);
        public static Pen penB = new Pen(Color.Blue, 2);
        public static Pen penR = new Pen(Color.Red, 2);
        public static Font font = new Font("Default", 14, FontStyle.Bold);
        public static Font font2 = new Font("Default", 12);
        StringFormat format = new StringFormat(StringFormatFlags.DirectionVertical);
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            pen2.DashStyle = DashStyle.Dot;
            Reset();
            pictureBox1.Image = bitmap;
        }
        public void Reset()
        {
            g.Clear(Color.White);
            g.DrawRectangle(pen, 60, 60, 280, 280);
            g.DrawString("線性回歸-最小平方逼近", font, Brushes.Black, 100, 5);
            g.DrawString("y", font, Brushes.Black, 5, 200, format);
            g.DrawString("x", font, Brushes.Black, 200, 380);
            for(int i = 0; i <= 7; i++)
            {
                g.DrawLine(pen2, 60 + i * 40, 60, 60 + i * 40, 340);
                g.DrawLine(pen2, 60, 60 + i * 40, 340, 60 + i * 40);
                g.DrawString($"{8 - i}", font2, Brushes.Black, 40, 60 + i * 40);
                g.DrawString($"{i + 1}", font2, Brushes.Black, 60 + i * 40, 350);
            }
        }
        public static Data[] arr;
        private void Changed(object sender, EventArgs e)
        {
            int n;
            if(int.TryParse(textBox1.Text,out n) && n >= 2 && n <= 10)
            {
                panel1.Controls.Clear();
                arr = new Data[n];
                for(int i = 0; i < n; i++)
                {
                    arr[i] = new Data(i);
                    panel1.Controls.Add(arr[i].x);
                    panel1.Controls.Add(arr[i].y);
                    panel1.Controls.Add(new Label() { Text = "請輸入每筆資料的x，y座標[x,y]:", Font = new Font("Default", 10), Size = new Size(300, 30), Location = new Point(10, 10 + 40 * i) });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            arr = arr.OrderBy(item => item.x.Text).ToArray();
            double[] x = arr.Select(item => double.Parse(item.x.Text)).ToArray();
            double[] y = arr.Select(item => double.Parse(item.y.Text)).ToArray();
            double totalx = x.Sum();
            double avgx = x.Average();
            double avgy = y.Average();
            double totalxsquare = 0;
            double xy = 0;
            PointF[] points = new PointF[arr.Length];
            for(int i = 0; i < x.Length; i++)
            {
                points[i] = new PointF(60 + (float)(x[i] - 1) * 40, 340 - (float)(y[i] - 1) * 40);
                g.DrawEllipse(penB, points[i].X - 2, points[i].Y - 2, 4, 4);
                totalxsquare += x[i] * x[i];
                xy += x[i] * y[i];
            }
            g.DrawLines(penR, points);
            double m = (xy - totalx * avgy) / (totalxsquare - totalx * avgx);
            double b = avgy - m * avgx;
            label4.Text = $"斜率(m)        ={m.ToString("0.000"),10}";
            label5.Text = $"截距(b)         ={b.ToString("0.000"),10}";
            label6.Text = $"總資料點數={arr.Length,10}";
            pictureBox1.Image = bitmap;
        }
    }
    public class Data
    {
        public TextBox x;
        public TextBox y;
        public Data(int i)
        {
            this.x = GetText(210, 10 + 40 * i);
            this.y = GetText(260, 10 + 40 * i);
        }
        public TextBox GetText(int x,int y)
        {
            return new TextBox()
            {
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(40, 30),
                Font = new Font("Default", 12),
                Location = new Point(x, y)
            };
        }
    }
}
