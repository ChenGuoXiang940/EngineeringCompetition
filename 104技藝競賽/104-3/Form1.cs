using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _104_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) => Application.Exit();
        public static Random rnd = new Random();
        public static string getRnd(int len) => string.Join("", new int[len].Select(item => rnd.Next(0, 2)).ToArray());
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = getRnd(1);
            textBox2.Text = getRnd(8);
            textBox3.Text = getRnd(23);
        }
        public static int fpow(int p,int q)
        {
            if (q == 0) return 1;
            else if (q == 1) return p;
            else if ((q % 2) == 0) return fpow(p * p, q / 2);
            else  return p * fpow(p * p, q / 2);
        }
        public static double getbinaryfloat(string str)
        {
            double res = 0;
            double m = 0.5;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '1')
                {
                    res += m;
                }
                m /= 2;
            }
            return res;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool fg = textBox1.Text == "1" ? true : false;
            string Exponent = textBox2.Text[0] == '1' ? "0" + textBox2.Text.Substring(1) : textBox2.Text;
            string Mantissa = textBox3.Text;
            double Exponent_pow = fpow(2, Convert.ToInt32(Exponent, 2) + 1);
            textBox4.Text = (fg ? "-" : "") + $"{Exponent_pow * (2 + getbinaryfloat(Mantissa))}";
            //-161.875是錯的! 1.0100001111=2.多，不是1.多
        }
    }
}
