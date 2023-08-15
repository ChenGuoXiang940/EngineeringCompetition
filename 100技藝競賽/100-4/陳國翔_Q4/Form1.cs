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
        public Form1()
        {
            InitializeComponent();
        }
        public static Bitmap bitmap, bitmap2;
        public static Point arr;
        public static int[] num, num2;
        private void 開啟檔案影像檔OpenColorImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                arr.X = 0;
                arr.Y = 256;
                num = new int[256];
                num2 = new int[256];
                bitmap = (Bitmap)Image.FromFile(open.FileName);
                pictureBox1.Image = bitmap;
            }
            Array.ForEach(Controls.OfType<TextBox>().ToArray(), item => item.Text = "");
        }

        private void 結束離開ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 彩色影像轉灰階影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
            for(int i = 0; i < bitmap.Height; i++)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    Color color2 = Color.FromArgb((int)(color.R * 0.3), (int)(color.G * 0.59), (int)(color.B * 0.11));
                    bitmap2.SetPixel(j, i, color2);
                    int val = GetB(color2);
                    num[val]++;
                    arr.X = Math.Max(arr.X, val);
                    arr.Y = Math.Min(arr.Y, val);
                }
            }
            pictureBox2.Image = bitmap2;
        }
        public static int GetB(Color color)
        {
            return (int)((float)(color.GetBrightness() * 255));
        }
        private void 劃出灰階影像直方圖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap3 = new Bitmap(300, 250);
            Graphics g = Graphics.FromImage(bitmap3);
            g.DrawRectangle(Pens.Black, 45, 20, 210, 210);
            for (int i = 0; i <= 30; i++)
            {
                if (i == 0 || i % 5 == 0)
                {
                    g.DrawString($"{6000 - i / 5 * 1000}", Font, Brushes.Black, 0, 20 + 35 * i / 5);
                    g.DrawString($"{i / 5 * 50}", Font, Brushes.Black, 45 + 35 * i / 5, 240);
                    g.DrawLine(Pens.Black, 41, 20 + (float)(35 * i / 5), 49, 20 + (float)(35 * i / 5));
                    g.DrawLine(Pens.Black, 45 + (float)(35 * i / 5), 226, 45 + (float)(35 * i / 5), 234);
                }
                else
                {
                    g.DrawLine(Pens.Black, 43, 20 + (float)(35 * i / 5), 47, 20 + (float)(35 * i / 5));
                    g.DrawLine(Pens.Black, 45 + (float)(35 * i / 5), 228, 45 + (float)(35 * i / 5), 232);
                }
            }
            for (int i = 0; i < 256; i++)
            {
                double x = 1.171875 * i;
                double y = 0.035 * num[i];
                g.DrawLine(Pens.Blue, (float)x, 230 - (float)y, (float)x, 230);
            }
            pictureBox3.Image = bitmap3;
        }
        private void 求最小灰階和最大灰階ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{arr.X}";
            textBox2.Text = $"{arr.Y}";
        }

        private void 球最多灰階和機率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Text = $"{Array.IndexOf(num, num.Max())}";
            textBox4.Text =$"{(double)num.Max()/(double)(bitmap.Width*bitmap.Height)}";
        }
    }
}
