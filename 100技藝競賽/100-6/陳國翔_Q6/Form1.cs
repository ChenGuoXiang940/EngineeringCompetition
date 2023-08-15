using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q6
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public static string[] str = { "K", "M", "G", "T" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Array.ForEach(Controls.OfType<TextBox>().ToArray(), item => item.Text = "");
            TextBox1.Text = $"{rnd.Next(16, 53)}";
            TextBox2.Text = $"{rnd.Next(1, 9)}B";
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox1.Text);
            int b = int.Parse(TextBox2.Text.TrimEnd('B'));
            int c = a + (b == 8 ? 3 : b >= 4 ? 2 : b >= 2 ? 1 : 0);
            int d = 0;
            while (c >= 10)
            {
                d++;
                c -= 10;
            }
            TextBox3.Text = $"{Math.Pow(2, c)}{str[d - 1]}B";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Array.ForEach(Controls.OfType<TextBox>().ToArray(), item => item.Text = "");
            TextBox5.Text = $"{rnd.Next(1, 9)}B";
            TextBox6.Text = $"{rnd.Next(512, 32769)}{str[rnd.Next(0, 4)]}B";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string text = TextBox6.Text;
            int b = int.Parse(TextBox5.Text.TrimEnd('B'));
            int val = text.Contains("TB") ? 40 : text.Contains("GB") ? 30 : text.Contains("MB") ? 20 : text.Contains("KB") ? 10 : 0;
            Array.ForEach(str, item => text = text.Replace(item + "B", ""));
            val -= (b == 8 ? 3 : b >= 4 ? 2 : b >= 2 ? 1 : 0);
            int a = int.Parse(text);
            int c = 0;
            while (a != 0)
            {
                c++;
                a >>= 1;
            }
            TextBox4.Text = $"{val + c}";
        }
    }
}
