using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _108_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0.0";
        }
        public static string mg = "";
        public static int balances = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                balances += 5;
            }
            else if (radioButton2.Checked)
            {
                balances += 10;
            }
            else if (radioButton3.Checked)
            {
                balances += 50;
            }
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Text = String.Format("{0:0.0}", balances);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (balances >= 35)
            {
                balances -= 35;
                mg += "送出Cola,";
            }
            label6.Text = mg.TrimEnd(',');
            textBox1.Text = String.Format("{0:0.0}", balances);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (balances >= 30)
            {
                balances -= 30;
                mg += "送出PEPSO,";
            }
            label6.Text = mg.TrimEnd(',');
            textBox1.Text = String.Format("{0:0.0}", balances);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(balances >= 25)
            {
                balances -= 25;
                mg += "送出Diet Cola,";
            }
            label6.Text = mg.TrimEnd(',');
            textBox1.Text = String.Format("{0:0.0}", balances);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(balances >= 30)
            {
                balances -= 30;
                mg += "送出Diet PEPSO,";
            }
            label6.Text = mg.TrimEnd(',');
            textBox1.Text = String.Format("{0:0.0}", balances);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (balances != 0)
            {

                label6.Text = string.Format("{0}  退還{1}元", mg.TrimEnd(','), balances);
                balances = 0;
                textBox1.Text = "0.0";
                mg = "";
            }
            else
            {
                label6.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
