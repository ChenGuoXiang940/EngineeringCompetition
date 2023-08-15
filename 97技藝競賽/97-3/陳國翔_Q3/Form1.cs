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
            double val = double.Parse(textBox1.Text);
            int left = (int)val;
            double right = Math.Abs(val % 1);
            string text1 = Convert.ToString(Math.Abs(left), 2).PadLeft(15, '0');
            if (text1.Length > 15)
            {
                textBox2.Text = "overflow";
                return;
            }
            string text2 = "";
            while (right != 0)
            {
                right *= 2;
                if (right >= 1)
                {
                    right -= 1;
                    text2 += "1";
                }
                else
                {
                    text2 += "0";
                }
            }
            text2 = text2.ToString().PadRight(8, '0');
            textBox2.Text = val < 0 ? $"1{text1}.{text2}" : $"0{text1}.{text2}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
