using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _103_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            double z = double.Parse(textBox3.Text);
            double a = double.Parse(textBox4.Text);
            double b = double.Parse(textBox5.Text);
            double c = double.Parse(textBox6.Text);
            double ans = x * a + y * b + z * c;
            richTextBox1.Text = ans == 1 || ans == 0 ? "無解" : "台北市的上班族遲到的機率是:" + ans + "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            double z = double.Parse(textBox3.Text);
            double a = double.Parse(textBox4.Text);
            double b = double.Parse(textBox5.Text);
            double c = double.Parse(textBox6.Text);
            double ans=x * a + y * b + z * c;
            double ans2 = (z * c) / ans;
            richTextBox1.Text = ans2 == 1 || ans2 == 0? "無解" : "如果已知有一個人上班遲到，那他是自己開車的機率為:" + ans2 + "\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
