using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace _104_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static Random rnd = new Random();
        public static string getrnd(int len)
        {
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += rnd.Next(0, 2).ToString();
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = getrnd(1);
            textBox2.Text = Convert.ToString(rnd.Next(127, 257), 2);
            textBox3.Text = getrnd(23);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool fg = false;
            if (textBox1.Text == "1")
            {
                fg = true;
            }
            int val = Convert.ToInt32(textBox2.Text, 2);
            BigInteger pow = new BigInteger();
            pow = BigInteger.Pow(2, val - 127);
            BigInteger big = new BigInteger();
            string s3 = fg ? "-1." + textBox3.Text : "1." + textBox3.Text;
            big = BigInteger.Parse(s3);
            big *= pow;
            string[] str = big.ToString().Split('.');
            string s2 = str[1];
            double val2 = Convert.ToInt32(str[0], 2);
            int n = -1;
            for(int i = 0; i < s2.Length; i++)
            {
                if (s2[i] == '1') val2 += Math.Pow(2, n);
                n--;
            }
            val2 = Math.Round(val2, 10);
            textBox4.Text = fg ? "-" + val.ToString() : val.ToString();
        }
    }
}
