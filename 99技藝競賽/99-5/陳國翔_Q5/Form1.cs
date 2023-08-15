using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            StreamReader din = new StreamReader(textBox1.Text, Encoding.GetEncoding("big5"));
            string text = din.ReadToEnd();
            string head = "";
            for (int i = 0, j = 1; i < 40; i++, j++)
            {
                if (j == 10) j = 0;
                head += Convert.ToChar('0' + j);
            }           
            int index = text.IndexOf(textBox2.Text) + 1;
            if (index != 0)
            {
                textBox3.Text = $"{index}";
                textBox5.Focus();
                textBox5.Select(index - 1, textBox2.Text.Length);
                Clipboard.SetText(textBox2.Text);
            }
            else
            {
                textBox3.Text = $"未找到{textBox2.Text}字串";
            }
            textBox4.Text = head;
            textBox5.Text = text;
        }
    }
}
