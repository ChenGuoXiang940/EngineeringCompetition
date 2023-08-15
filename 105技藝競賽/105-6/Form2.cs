using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(Form1.bitmap1);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    int R = Convert.ToString(color.R, 2).Last() == '1' ? 16 : 235,
                        G = Convert.ToString(color.G, 2).Last() == '1' ? 16 : 235,
                        B = Convert.ToString(color.B, 2).Last() == '1' ? 16 : 235;
                    bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            pictureBox1.BackgroundImage = bitmap;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
