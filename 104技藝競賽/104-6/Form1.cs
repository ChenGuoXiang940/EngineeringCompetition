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

namespace _104_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {               
                StreamReader din = new StreamReader(open.FileName,Encoding.Default);
                richTextBox1.Text = din.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string target = textBox1.Text;
            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("未輸入欲搜尋的字串");
            }
            else
            {
                string text = richTextBox1.Text;
                int count = 0;
                int len = 0;
                richTextBox1.Select(0, text.Length);
                richTextBox1.SelectionBackColor = Color.White;
                while (text.Contains(target))
                {
                    richTextBox1.Select(len + text.IndexOf(target), target.Length);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    len += text.IndexOf(target) + target.Length;
                    text = text.Substring(text.IndexOf(target) + target.Length);
                    count++;
                }                
                label2.Text = $"找到個數\r\n{count}";
            }
        }
    }
}
