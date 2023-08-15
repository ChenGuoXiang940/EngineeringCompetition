using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _102_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap bitmap1 = new Bitmap(250, 250);
            Graphics g1=Graphics.FromImage(bitmap1);
            for(int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (color == Color.FromArgb(0, 0, 0))//black
                    {
                        for(int a = 0; a < 3; a++)
                        {
                            for (int b = 0; b < 3; b++)
                            {
                                if (i + a - 1 >= 0 && i + a - 1 < 250 && j + b - 1 >= 0 && j + b - 1 < 250)
                                {
                                    bitmap1.SetPixel(i - 1 + a, j - 1 + b, Color.Black);
                                }
                            }
                        }
                    }
                }
            }
            pictureBox1.Image = bitmap1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(250, 250);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, 50, 100, 50, 200);
            g.DrawLine(pen, 50, 100, 150, 100);
            g.DrawLine(pen, 150, 100, 150, 0);
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(save.FileName);
            }
        }
    }
}
