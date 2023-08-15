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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R = double.Parse(textBox1.Text);
            double G = double.Parse(textBox2.Text);
            double B = double.Parse(textBox3.Text);
            double total = R + G + B;
            double r = R / total;
            double g = G / total;
            double b = B / total;
            //---
            double h = Math.Acos((0.5 *( (r - g) + (r - b))) / Math.Sqrt(Math.Pow(r - g, 2) + (r - b) * (g - b)));
            h = b <= g ? h : 2 * Math.PI - h;
            double s = 1 - 3 * Math.Min(r, Math.Min(g, b));
            double i = total / 765;
            //---
            textBox4.Text = $"{(int)(h * 180 / Math.PI + 0.5)}";
            textBox5.Text = $"{(int)(s * 255 + 0.5)}";
            textBox6.Text = $"{(int)(i * 255 + 0.5)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double h = double.Parse(textBox4.Text) * Math.PI / 180;
            double s = double.Parse(textBox5.Text) / 255;
            double i = double.Parse(textBox6.Text) / 255;
            double h2 = 0;
            if (2 * Math.PI / 3 <= h && h < 4 * Math.PI / 3)
            {
                h2 = h - 2 * Math.PI / 3;
            }
            else if (4 * Math.PI / 3 <= h && h < 2 * Math.PI)
            {
                h2 = h - 4 * Math.PI / 3;
            }
            double x = i * (1 - s);
            double y = i * (1 + s * Math.Cos(h2) / Math.Cos(Math.PI / 3 - h2));
            double z = 3 * i - (x + y);
            double b = 0, r = 0, g = 0;
            if (h < 2 * Math.PI / 3)
            {
                b = x;
                r = y;
                g = z;
            }
            if (2 * Math.PI / 3 <= h && h < 4 * Math.PI / 3)
            {
                r = x;
                g = y;
                b = z;
            }
            if(4 * Math.PI / 3 <= h && h <= 2 * Math.PI)
            {
                g = x;
                b = y;
                r = z;
            }
            textBox1.Text = $"{(int)(r + 0.5) * 255}";
            textBox2.Text = $"{(int)(g + 0.5) * 255}";
            textBox3.Text = $"{(int)(b + 0.5) * 255}";
        }
    }
}
