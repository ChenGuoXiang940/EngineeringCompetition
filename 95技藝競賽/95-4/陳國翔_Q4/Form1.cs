using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            label5.Text = "Function Here";
            textBox4.Text = textBox5.Text = "";
            if (a == 0 && b == 0 && c != 0)
            {
                textBox4.Text = "無解";
                label5.Text = $"({a})x2({b})x+({c})=0";
            }
            else if (a == 0 && b == 0 && c == 0)
            {
                textBox4.Text = "無限多組解";
            }
            else if (a == 0 && b != 0)
            {
                textBox4.Text = $"{Math.Round(-c / b, 2)}";
                textBox5.Text = "只有一解";
            }
            else if (a != 0 && b != 0 && b * b - 4 * a * c == 0)
            {
                textBox4.Text = $"{Math.Round(-b / (2 * a), 2)}";
                textBox5.Text = "同根";
            }
            else if (a != 0 && b != 0 && b * b - 4 * a * c > 0)
            {
                double left = -b / (2 * a);
                double right = Math.Sqrt(b * b - 4 * a * c) / (2 * a);
                textBox4.Text = Math.Round(left + right, 2).ToString();
                textBox5.Text = Math.Round(left - right, 2).ToString();
            }
            else if (a != 0 && b != 0 && b * b - 4 * a * c < 0)
            {
                double left = Math.Round(-b / (2 * a), 2);
                double right = Math.Round(Math.Sqrt(4 * a * c - b * b) / (2 * a), 2);
                textBox4.Text = $"{left}+{right}i";
                textBox5.Text = $"{left}-{right}i";
            }
        }
    }
}
