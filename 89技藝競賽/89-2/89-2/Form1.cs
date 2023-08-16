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

namespace _89_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Image = ResizeImage(Image.FromFile(ofd.FileName), new Size(200, 200));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(200, 200);
            Bitmap bitmap1 = new Bitmap(pictureBox1.Image);
            for(int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap1.GetPixel(i, j);
                    bitmap.SetPixel(i, j, Color.FromArgb((int)(color.R * 0.299), (int)(color.G * 0.587), (int)(color.B * 0.114)));
                }
            }
            pictureBox2.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(200, 200);
            Bitmap bitmap1 = new Bitmap(pictureBox2.Image);
            Data data = new Data();
            for(int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    data.Add(bitmap1.GetPixel(i, j));
                }
            }
            int val = data.GetVal();
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap1.GetPixel(i, j);
                    if ((color.R + color.G + color.B) / 3 < val)
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                }
            }
            pictureBox3.Image = bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Data
    {
        public double r, g, b;
        public Data()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
        }
        public void Add(Color color)
        {
            this.r += (double)color.R;
            this.g += (double)color.G;
            this.b += (double)color.B;
        }
        public int GetVal()
        {
            return (int)(((this.r + this.g + this.b) / 3) / 40000 * 0.7);
        }
    }
}
