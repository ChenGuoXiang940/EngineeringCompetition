using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Visible = false;
            label7.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control obj in Controls.OfType<TextBox>())
            {
                ((TextBox)obj).Text = "";
            }
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Visible = false;
            label7.Visible = false;
            int a = Int16.Parse(textBox1.Text);
            int b = Int16.Parse(textBox2.Text);
            if (a * b == Int16.Parse(textBox3.Text))
            {
                label6.Visible = true;
            }
            else
            {
                label7.Visible = true;
                int v1 = a + b % 10;
                int v2 = v1 * ((int)(b / 10) * 10);
                int v3 = (a % 10) * (b % 10);
                int v4 = v2 + v3;
                label5.Text = String.Format("(1) {0}+{1}={2}", a, b % 10, v1) + "\r\n" +
                    String.Format("(2) {0}X{1}={2}", v1, b / 10, v2) + "\r\n" +
                    String.Format("(3) {0}X{1}={2}", a % 10, b % 10, v3) + "\r\n" +
                    String.Format("(4) {0}+{1}={2}", v2, v3, v4);
            }
        }
    }
}
