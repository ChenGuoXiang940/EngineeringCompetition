using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q1
{
    public partial class Form1 : Form
    {
        public static  Bitmap _bitmap;
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(300, 300);
            g = Graphics.FromImage(_bitmap);
            g.Clear(Color.White);
            pictureBox1.Image = _bitmap;
        }
        public static int check(string text)
        {
            int n;
            if (int.TryParse(text, out n)) return n;
            return -1;
        }
        public void draw1(int n,int x,int y)
        {
            for (int i = 0; i < n; i++)
            {
                g.DrawLine(Pens.Red, x + 5 * i, y + 5 * i, x + 5 * i + 150, y + 5 * i - 150);
            }
        }
        public void draw2(int n,int x,int y)
        {
            for (int i = 0; i < n; i++)
            {
                g.DrawLine(Pens.Blue, x - 5 * i, y + 5 * i, x - 5 * i + 150, y + 5 * i + 150);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int a, b;
            if ((a = check(textBox1.Text)) != -1 && (b = check(textBox2.Text)) != -1)
            {
                draw1(a / 10, 50, 150);
                draw1(a % 10, 100, 200);
                draw2(b % 10, 150, 20);
                draw2(b / 10, 100, 70);
            }
            pictureBox1.Image = _bitmap;
        }
    }
}
