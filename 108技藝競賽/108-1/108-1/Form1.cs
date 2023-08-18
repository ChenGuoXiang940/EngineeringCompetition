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
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
            textBox1.Text = String.Format("{0:0.0}", balances);
        }
        public void check(int price,string name)
        {
            if (balances >= price)
            {
                balances -= price;
                mg += name;
            }
            label6.Text = mg.TrimEnd(',');
            textBox1.Text = String.Format("{0:0.0}", balances);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            check(35, "送出Cola,");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            check(30, "送出PEPSO,");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            check(25, "送出Diet Cola,");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            check(30, "送出Diet PEPSO,");
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
    }
}
