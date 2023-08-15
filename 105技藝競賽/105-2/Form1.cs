using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int x;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(open.FileName);  
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox1.BackgroundImage = image;
            }
            x = 0;
            Bitmap bitmap = new Bitmap(pictureBox1.BackgroundImage);
            bool fg2 = false;
            while (true)
            {
                bool fg = false;
                for(int i = 0; i < bitmap.Height; i++)
                {
                    Color color = bitmap.GetPixel(x, i);
                    //bitmap.SetPixel(x, i, Color.Black);
                    int val = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    if (val <= 200)
                    {
                        fg = true;
                        break;
                    }
                }
                if (fg)
                {
                    fg2 = true;
                }
                else if(fg2)
                {
                    break;
                }
                x++;
            }
            //pictureBox1.BackgroundImage = bitmap;
            //MessageBox.Show(x.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double max1 = 0, min1 = Int16.MaxValue;
            Bitmap bitmap = new Bitmap(pictureBox1.BackgroundImage);
            for(int i = x - 1; i >= 0; i--)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (color.R * 0.3 + color.G * 0.59 + color.B * 0.11 < 200)
                    {
                        max1 = Math.Max(j, max1);
                        min1 = Math.Min(j, min1);
                    }
                }
            }
            double m = 830 / (max1 - min1 + 1);
            max1 = 0; min1 = Int16.MaxValue;
            for (int i = x + 1; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (color.R * 0.3 + color.G * 0.59 + color.B * 0.11 < 200)
                    {
                        max1 = Math.Max(j, max1);
                        min1 = Math.Min(j, min1);
                    }
                }
            }
            textBox1.Text = Math.Round(m * (max1 - min1 + 1), 2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double max1 = 0, min1 = Int16.MaxValue;
            Bitmap bitmap = new Bitmap(pictureBox1.BackgroundImage);
            for (int i = x - 1; i >= 0; i--)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (color.R * 0.3 + color.G * 0.59 + color.B * 0.11 < 200)
                    {
                        max1 = Math.Max(j, max1);
                        min1 = Math.Min(j, min1);
                    }
                }
            }
            double m = 830 / (max1 - min1 + 1);
            max1 = 0; min1 = Int16.MaxValue;
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = x + 1; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    if (color.R * 0.3 + color.G * 0.59 + color.B * 0.11 < 200)
                    {
                        max1 = Math.Max(j, max1);
                        min1 = Math.Min(j, min1);
                    }
                }
            }
            textBox2.Text = Math.Round(m * (max1 - min1 + 1), 2).ToString();
        }
    }
}
