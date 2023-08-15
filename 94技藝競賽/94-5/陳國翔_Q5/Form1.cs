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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (count < 3)
            {
                int n;
                if (!int.TryParse(textBox1.Text, out n) || n < 1 || n > 10)
                {
                    if (++count >= 3)
                    {
                        MessageBox.Show("輸入錯誤超過3次");
                        return;
                    }
                    MessageBox.Show("輸入錯誤");
                    return;
                }
                string text = "";
                for (int i = 1; i <= n; i++)
                {
                    text += $"{n + 1 - i}".PadLeft(20 - i);
                    for (int j = 1; j <= i - 1; j++)
                    {
                        text += "1".PadLeft(2);
                    }
                    text += "\r\n";
                }
                textBox2.Text = text;
                count = 0;
            }
            else
            {
                if (textBox1.Text == "***")
                {
                    count = 0;
                    textBox1.ForeColor = Color.Black;
                }
                else
                {
                    textBox1.Text = "???";
                    textBox1.ForeColor = Color.Red;
                }
            }
        }
    }
}
