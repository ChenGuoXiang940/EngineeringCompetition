using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _96_1
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(300, 300);
        public static Graphics g;
        public static List<TextBox> tx = new List<TextBox>();
        public static List<PointF> col = new List<PointF>();
        public static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            string[] str = { "Non-45 Length:", "On-45 Length:", "Saving:" };
            for (int i = 0; i < 3; i++)
            {
                TextBox text1 = new TextBox()
                {
                    Text = str[i],
                    Font = new Font("Default", 12),
                    Size = new Size(150, 12),
                    Location = new Point(5, 5 + 20 * i)
                };
                TextBox text2 = new TextBox()
                {
                    Text = "",
                    Font = new Font("Default", 12),
                    Size = new Size(100, 12),
                    Location = new Point(155, 5 + 20 * i)
                };
                panel1.Controls.Add(text1);
                panel1.Controls.Add(text2);
                tx.Add(text2);
            }
            pictureBox1.Image = bitmap;
        }
        public static double record = 0;
        public static Pen pen = new Pen(Color.Black, 3);
        public static void DrawLine(float x1, float y1, float x2,float y2)
        {
            record += Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            col.Clear();
            for(int i = 0; i < 3; i++)
            {
                col.Add(new PointF() { X = rnd.Next(0, 300), Y = rnd.Next(50, 250) });
                g.FillEllipse(Brushes.Black, col[i].X - 5, col[i].Y - 5, 10, 10);
                tx[i].Text = "";
            }
            col = col.OrderBy(item => item.Y).ToList();
            DrawLine(col[1].X, col[1].Y, col[2].X, col[1].Y);
            DrawLine(col[1].X, col[1].Y, col[0].X, col[1].Y);
            DrawLine(col[2].X, col[1].Y, col[2].X, col[2].Y);
            DrawLine(col[0].X, col[1].Y, col[0].X, col[0].Y);
            pictureBox1.Image = bitmap;
            tx[0].Text = record.ToString();
            record = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            float dist1 = col[2].Y - col[1].Y;//最上與中間
            float dist2 = col[1].Y - col[0].Y;//最下與中間
            if (Math.Abs(col[1].X - col[2].X) > dist1)
            {
                DrawLine(col[2].X, col[2].Y, col[2].X + Math.Sign(col[1].X - col[2].X) * dist1, col[1].Y);
                DrawLine(col[1].X, col[1].Y, col[2].X + Math.Sign(col[1].X - col[2].X) * dist1, col[1].Y);
            }
            else
            {
                DrawLine(col[2].X, col[2].Y, col[2].X, col[1].Y);
                DrawLine(col[1].X, col[1].Y, col[2].X, col[1].Y);
            }
            if (Math.Abs(col[1].X - col[0].X) > dist2)
            {
                DrawLine(col[0].X, col[0].Y, col[0].X + Math.Sign(col[1].X - col[0].X) * dist2, col[1].Y);
                DrawLine(col[1].X, col[1].Y, col[0].X + Math.Sign(col[1].X - col[0].X) * dist2, col[1].Y);
            }
            else
            {
                DrawLine(col[0].X, col[0].Y, col[0].X, col[1].Y);
                DrawLine(col[1].X, col[1].Y, col[0].X, col[1].Y);
            }
            for (int i = 0; i < 3; i++)
            {
                g.FillEllipse(Brushes.Black, col[i].X - 5, col[i].Y - 5, 10, 10);
            }
            pictureBox1.Image = bitmap;
            tx[1].Text = Math.Round(record, 0).ToString();
            tx[2].Text = $"{Math.Round((1 - record / double.Parse(tx[0].Text)) * 100, 1)}%";
            record = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
