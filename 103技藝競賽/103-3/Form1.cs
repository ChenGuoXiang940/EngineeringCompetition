using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _103_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "";
            string str2 = "";
            foreach(Control obj in Controls.OfType<TextBox>())
            {
                ((TextBox)obj).Text = "";
            }
            Random rnd = new Random();
            for(int i = 0; i < 8; i++)
            {
                str1 += rnd.Next(0, 2).ToString();
                str2 += rnd.Next(0, 2).ToString();
            }
            textBox1.Text = str1;
            textBox3.Text = str2;           
        }
        public static bool flag1 = false;
        private void button2_Click(object sender, EventArgs e)
        {
            flag1 = false;
            string str1 = textBox1.Text;
            string str2 = textBox3.Text;
            if (str1[0] == '1')
            {
                string tmp1 = "";
                bool fg1 = false;
                for(int i = 7; i >= 0; i--)
                {
                    if (fg1)
                    {
                        if (str1[i] == '1') tmp1 = '0' + tmp1;
                        else tmp1 = '1' + tmp1;
                    }
                    else
                    {
                        if (str1[i] == '1') tmp1 = '1' + tmp1;
                        else tmp1 = '0' + tmp1;
                    }
                    if(str1[i] == '1')
                    {
                        fg1 = true;
                    }
                    textBox2.Text = "-" + Convert.ToInt32(tmp1, 2).ToString();
                }
            }
            else
            {
                textBox2.Text = Convert.ToInt32(str1.Substring(1), 2).ToString();
            }
            if (str2[0] == '1')
            {
                string tmp1 = "";
                bool fg1 = false;
                for (int i = 7; i >= 0; i--)
                {
                    if (fg1)
                    {
                        if (str2[i] == '1') tmp1 = '0' + tmp1;
                        else tmp1 = '1' + tmp1;
                    }
                    else
                    {
                        if (str2[i] == '1') tmp1 = '1' + tmp1;
                        else tmp1 = '0' + tmp1;
                    }
                    if (str2[i] == '1')
                    {
                        fg1 = true;
                    }
                    textBox4.Text = "-" + Convert.ToInt32(tmp1, 2).ToString();
                }
            }
            else
            {
                textBox4.Text = Convert.ToInt32(str2.Substring(1), 2).ToString();
            }
            string str = "";
            int cy = 0;
            for (int i = 7; i >= 0; i--)
            {
                int s = (str1[i] - '0') + (str2[i] - '0') + cy;
                if (s >= 2)
                {
                    str = Convert.ToChar('0' + s - 2) + str;
                    cy = 1;
                }
                else
                {
                    str = Convert.ToChar('0' + s) + str;
                    cy = 0;
                }
            }
            if (cy == 1) flag1 = true;
            textBox5.Text = str;
            if (str[0] == '1') textBox6.Text = "-";
            textBox6.Text += Convert.ToInt32(str.Substring(1), 2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag1) textBox7.Text = "underflow";
            if (Int16.Parse(textBox2.Text) + Int16.Parse(textBox4.Text) != Int16.Parse(textBox6.Text)) textBox8.Text = "不足位";
        }
    }
}
