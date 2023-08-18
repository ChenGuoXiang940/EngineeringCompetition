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
        public static PictureBox[] pic = new PictureBox[16];
        public static PictureBox[] pic2 = new PictureBox[16];
        public static Random rnd = new Random();
        public PictureBox getp(int i, int j,Color color) => new PictureBox() { BackColor = color, Size = new Size(50, 50), Location = new Point(50 * j, 50 * i)};
        public Color getc() => Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 16; i++)
            {
                panel1.Controls.Add(pic[i] = getp(i / 4, i % 4, getc()));
                panel2.Controls.Add(pic2[i] = getp(i / 4, i % 4, DefaultBackColor));
            }
        }
        public void Reset()
        {
            for(int i = 0; i < 16; i++)
            {
                pic2[i].BackColor = pic[i].BackColor;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            Array.ForEach(pic, item => item.BackColor = getc());
        }
        public static void loop(Action<int, int> action, int end1, int end2)
        {
            for (int i = 0; i < end1; i++)
            {
                for (int j = 0; j < end2; j++)
                {
                    action(i, j);
                }
            }
        }
        public static void Swap(ref PictureBox p1,ref PictureBox p2)
        {
            Color color = p1.BackColor;
            p1.BackColor = p2.BackColor;
            p2.BackColor = color;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            loop((i, j) => Swap(ref pic[i * 4 + 1 - j], ref pic[i * 4 + 2 + j]), 4, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
            loop((i, j) => Swap(ref pic[4 - j * 4 + i], ref pic[8 + j * 4 + i]), 4, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
            loop((i, j) => pic[i * 4 + j].BackColor = pic2[12 + i - j * 4].BackColor, 4, 4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
            loop((i, j) => pic[12 + i - j * 4].BackColor = pic2[i * 4 + j].BackColor, 4, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
