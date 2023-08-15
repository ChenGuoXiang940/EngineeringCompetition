using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _92_2
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(300, 400);
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(ofd.FileName);
                g = Graphics.FromImage(bitmap);
                PictureBox1.Image = bitmap;
            }
        }
        public static int getval(Color g)
        {
            return (int)(0.299 * g.R + 0.587 * g.G + 0.114 * g.B);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int c = getval(bitmap.GetPixel(j, i));
                    bitmap.SetPixel(j, i, Color.FromArgb(c, c, c));
                }
            }
            PictureBox1.Image = bitmap;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int c = getval(bitmap.GetPixel(j, i)) / 3;
                    bitmap.SetPixel(j, i, Color.FromArgb(255 - c, 255 - c, 255 - c));
                }
            }
            PictureBox1.Image = bitmap;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Color max = Color.Black;
            Color min = Color.White;
            for(int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (getval(bitmap.GetPixel(j, i)) > getval(max))
                    {
                        max = bitmap.GetPixel(j, i);
                    }
                    if(getval(bitmap.GetPixel(j, i)) < getval(min))
                    {
                        min = bitmap.GetPixel(j, i);
                    }
                }
            }
            double max1 = getval(max);
            double min1 = getval(min);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    double c = getval(color);
                    int g = (int)(((c - min1) / (max1 - min1)) * 255);
                    bitmap.SetPixel(j, i, Color.FromArgb(g, g, g));
                }
            }
            Label1.Text = $"Max:{getval(max) / 3}";
            Label2.Text = $"Min:{getval(min) / 3}";
            PictureBox1.Image = bitmap;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    int c = 255 - (color.R + color.G + color.B) / 3;
                    bitmap.SetPixel(j, i, c < 127 ? Color.White : Color.Black);
                }
            }
            PictureBox1.Image = bitmap;
        }
    }
}
