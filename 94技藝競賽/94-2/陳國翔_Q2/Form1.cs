using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Bitmap GetBitmap()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(open.FileName);
            }
            throw new Exception();
        }
        public Bitmap solove(Bitmap bitmap)
        {
            for(int i = 0; i < bitmap.Height; i++)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    int avg = (color.R + color.G + color.B) / 3;
                    bitmap.SetPixel(j, i, Color.FromArgb(avg, avg, avg));
                }
            }
            return bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = GetBitmap();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = GetBitmap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = solove((Bitmap)pictureBox1.BackgroundImage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = solove((Bitmap)pictureBox1.BackgroundImage);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bitmap1 = (Bitmap)pictureBox2.BackgroundImage;
            Bitmap bitmap2 = (Bitmap)pictureBox4.BackgroundImage;
            Bitmap bitmap = new Bitmap(bitmap1.Width, bitmap1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            for(int i = 0; i < bitmap1.Width; i++)
            {
                for(int j = 0; j < bitmap1.Height; j++)
                {
                    if (bitmap1.GetPixel(i, j) != bitmap2.GetPixel(i, j))
                    {
                        bitmap.SetPixel(i, j, bitmap2.GetPixel(i, j));
                    }
                }
            }
            pictureBox5.BackgroundImage = bitmap;
        }
    }
}
