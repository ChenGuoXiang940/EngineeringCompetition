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
            for (int i = 0; i < 16; i++)
            {
                pic[i].BackColor = getc();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Color color = pic[i * 4 + 1 - j].BackColor;
                    Color color2 = pic[i * 4 + 2 + j].BackColor;
                    pic[i * 4 + 2 + j].BackColor = color;
                    pic[i * 4 + 1 - j].BackColor = color2;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Color color = pic[4 - j * 4 + i].BackColor;
                    Color color2 = pic[8 + j * 4 + i].BackColor;
                    pic[8 + j * 4 + i].BackColor = color;
                    pic[4 - j * 4 + i].BackColor = color2;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    pic[i * 4 + j].BackColor = pic2[12 + i - j * 4].BackColor;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pic[12 + i - j * 4].BackColor = pic2[i * 4 + j].BackColor;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
