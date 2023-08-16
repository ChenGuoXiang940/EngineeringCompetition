using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int c = int.Parse(textBox3.Text);
            int s = 1;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    s = a * s % c;
                }
                a = a * a % c;
                b >>= 1;
            }
            textBox4.Text = $"{s}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
