using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q3
{
    public partial class Form1 : Form
    {
        public static Bitmap bitmap = new Bitmap(360, 200);
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.DrawLine(Pens.Black, 0, 100, 360, 100);
            if (radioButton1.Checked)
            {
                for(int i = 0; i < 360; i++)
                {
                    g.DrawLine(Pens.Red, i, 100 - 50 * (float)Math.Sin(i * Math.PI / 180), i + 1, 100 - 50 * (float)Math.Sin(i * Math.PI / 180));
                }
            }
            else if (radioButton2.Checked)
            {
                for (int i = 0; i < 360; i++)
                {
                    g.DrawLine(Pens.Red, i, 100 - 50 * (float)Math.Cos(i * Math.PI / 180), i + 1, 100 - 50 * (float)Math.Cos(i * Math.PI / 180));
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
