using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 陳國翔_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            char[] ch = new char[40].Select(x => '0').ToArray();
            for (int i = 0; i < 4; i++) ch[rnd.Next(0, 40)] = '1';
            Array.ForEach(Controls.OfType<TextBox>().ToArray(), x => x.Text = "");
            textBox1.Text = String.Join("", ch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] arr = textBox1.Text.Split('1');
            string[] ans = arr.Select(item => (item == null) ? "0" : Convert.ToString(item.Length, 2)).ToArray();
            textBox2.Text = String.Join(" ", ans);
            textBox3.Text = $"{Math.Round((double)textBox2.Text.Length / (double)textBox1.Text.Length * 100, 1)}%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
