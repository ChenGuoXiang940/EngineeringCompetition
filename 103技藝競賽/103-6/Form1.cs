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

namespace _103_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control obj in Controls.OfType<TextBox>())
            {
                ((TextBox)obj).Text = "";
            }
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ans = 1;
                int v = Int32.Parse(textBox1.Text);
                int p = Int32.Parse(textBox2.Text);
                int m = Int32.Parse(textBox3.Text);
                while (p!=0)
                {
                    if ((p & 1) == 1)//最後一位為1時
                    {
                        ans = ans * v % m;
                    }
                    v = v * v % m;
                    p >>= 1;//往右位移一位元
                }
                label5.Text = ans.ToString();
            }
            catch (Exception)
            {
                //nothing...
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
