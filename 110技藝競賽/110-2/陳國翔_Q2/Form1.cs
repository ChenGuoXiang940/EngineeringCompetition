using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string text = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (text.Length < 8 || text.Length > 20)
            {
                MessageBox.Show("超出範圍重新輸入");
                return;
            }
            int a = 0, b = 0;
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9') b++;
                if (text[i] >= 'a' && text[i] <= 'z') a++;
            }
            label2.Text = $"{a},{b}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0, b = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >= '0' && text[i] <= '9') b++;
                    if (text[i] >= 'a' && text[i] <= 'z') a++;
                }
                int total = 0;
                if (text.Length > 12) total++;
                if (a != 0 && b != 0) total++;
                if (a > b) total++;
                if (total == 3) label3.Text = "strong";
                else label3.Text = "week";
            }
            catch(Exception)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CheckText(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("超出範圍重新輸入");
            }
            else
            {
                text = textBox1.Text.ToString();
            }
            textBox1.Text = text.ToString();
        }
    }
}
